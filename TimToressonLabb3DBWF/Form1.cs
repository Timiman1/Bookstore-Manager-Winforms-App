using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimToressonLabb3DBWF.Data;
using TimToressonLabb3DBWF.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.IO;

namespace TimToressonLabb3DBWF
{
    public partial class Form1 : Form
    {
        private List<StockBalanceRecord> sbRecordList = null;
        private List<AuthorNameISBNPair> authorNameISBNPairList = new List<AuthorNameISBNPair>();

        public Form1()
        {
            #region Check DB
            using (var context = new TimToressonLabb3DBContext())
            {
                if (!context.Database.CanConnect())
                {
                    try
                    {
                        var sql = File.ReadAllText("../../../script.sql");
                        context.Database.EnsureCreated();
                        context.Database.ExecuteSqlRaw(sql);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Something went wrong: ", e);
                    }
                }
            }
            #endregion 

            InitializeComponent();
            InitializeDataGridViewContents();
        }

        #region Methods and nested classes
        private void InitializeDataGridViewContents()
        {
            using (TimToressonLabb3DBContext context = new TimToressonLabb3DBContext())
            {
                var stockBalances = context.StockBalances;
                var bookstores = context.Bookstores;
                var authors = context.Authors;
                var books = context.Books;

                if (stockBalances != null && bookstores != null && authors != null && books != null)
                {
                    sbRecordList = stockBalances
                        .Join(bookstores,
                        sBal => sBal.BookstoreId,
                        bookStore => bookStore.Id,
                        (sBal, bookStore) => new
                        {
                            Bookstore_Name = bookStore.BookstoreName,
                            ISBN13 = sBal.Isbn13,
                            Amount = sBal.Amount,
                        }
                        )
                        .Join(books,
                        bookStore => bookStore.ISBN13,
                        book => book.Isbn13,
                        (bookStore, book) => new
                        {
                            Bookstore_Name = bookStore.Bookstore_Name,
                            ISBN13 = book.Isbn13,
                            Title = book.Title,
                            AuthorId = book.AuthorId,
                            Amount = bookStore.Amount,
                        }

                    ).Join(authors,
                    book => book.AuthorId,
                    author => author.Id,
                    (book, author) => new StockBalanceRecord()
                    {
                        Bookstore_Name = book.Bookstore_Name,
                        ISBN13 = book.ISBN13,
                        Title = book.Title,
                        Author_Name = string.Concat(author.FirstName, ' ', author.LastName),
                        Amount = book.Amount,
                    }
                    )
                    .ToList();

                    authorNameISBNPairList = authors.Join(books,
                         author => author.Id,
                         book => book.AuthorId,
                         (author, book) => new AuthorNameISBNPair()
                         {
                             ISBN13 = book.Isbn13,
                             AuthorName = string.Concat(author.FirstName, ' ', author.LastName)
                         }).ToList();
                 
                    UpdateTable(sbRecordList);

                }
                else
                {
                    MessageBox.Show("Records were missing.", "C# SQL Server EF Core 5.0.6", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.DataSource = null;
                }
            }
        }

        public void AddBooks(List<StockBalances> list)
        {
            using (TimToressonLabb3DBContext context = new TimToressonLabb3DBContext())
            {
                foreach (var sbentity in list)
                {
                    StockBalanceRecord record;

                    if ((record = sbRecordList.Find(sbdat => sbdat.Bookstore_Name == sbentity.Bookstore.BookstoreName && sbdat.ISBN13 == sbentity.Isbn13)) != null)
                    {
                        record.Amount += sbentity.Amount;
                    }
                    else
                    {
                        int insertIndex = sbRecordList.FindLastIndex(p => p.Bookstore_Name == sbentity.Bookstore.BookstoreName) + 1;

                        if (insertIndex == 0)
                            insertIndex = sbRecordList.Count;

                        sbRecordList.Insert(insertIndex, new StockBalanceRecord()
                        {
                            Bookstore_Name = sbentity.Bookstore.BookstoreName,
                            ISBN13 = sbentity.Isbn13,
                            Title = context.Books.First(b => b.Isbn13 == sbentity.Isbn13).Title,
                            Author_Name = authorNameISBNPairList.Find(p => p.ISBN13 == sbentity.Isbn13).AuthorName,
                            Amount = sbentity.Amount
                        });
                    }
                }
                UpdateTable(sbRecordList);
            }
        }

        public void UpdateTable(List<StockBalanceRecord> list)
        {
            dataGridView1.DataSource = ToDataTable(list);
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private void addBooksButton_Click(object sender, EventArgs e)
        {
            var f = new AddBooksForm(sbRecordList);
            f.Owner = this;
            f.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sbRecordList = ConvertDataTable<StockBalanceRecord>(dataGridView1.DataSource as DataTable);

            using (TimToressonLabb3DBContext context = new TimToressonLabb3DBContext())
            {
                var stockBal = context.StockBalances;

                foreach (var entity in stockBal)
                {
                    stockBal.Remove(entity);
                }

                foreach (var item in sbRecordList)
                {
                    stockBal.Add(new StockBalances()
                    {
                        BookstoreId = context.Bookstores.First(bs => bs.BookstoreName == item.Bookstore_Name).Id,
                        Isbn13 = item.ISBN13,
                        Amount = item.Amount
                    });
                }
                context.SaveChanges();
            }
            MessageBox.Show("Changes were successfully saved to the database!", "Changes saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }

    public class StockBalanceRecord
    {
        public string Bookstore_Name { get; set; }
        public long ISBN13 { get; set; }
        public string Title { get; set; }
        public string Author_Name { get; set; }
        public int? Amount { get; set; }
    }

    public class AuthorNameISBNPair
    {
        public string AuthorName { get; set; }
        public long ISBN13 { get; set; }
    }
    #endregion
}


