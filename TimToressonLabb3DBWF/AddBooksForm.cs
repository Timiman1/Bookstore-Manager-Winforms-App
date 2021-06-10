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

namespace TimToressonLabb3DBWF
{
    public partial class AddBooksForm : Form
    {
        public AddBooksForm(List<StockBalanceRecord> sblist)
        {
            InitializeComponent();
            InitializeDataGridViewContents();
        }

        #region Methods and nested classes
        private void InitializeDataGridViewContents()
        {

            using (TimToressonLabb3DBContext context = new TimToressonLabb3DBContext())
            {
                bookstoreComboBox.Items.AddRange(
                context.Bookstores.Select(bs => bs.BookstoreName).ToArray()
                );

                var books = context.Books;
                var authors = context.Authors;

                var bookRecordsList = books
                        .Join(authors,
                        book => book.AuthorId,
                        author => author.Id,
                        (book, author) => new BookRecord()
                        {
                            ISBN13 = book.Isbn13,
                            Title = book.Title,
                            Author = string.Concat(author.FirstName, ' ', author.LastName)
                        }
            ).ToList();

                dataGridView1.DataSource = bookRecordsList;
            }
        }
        private void bookstoreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = (bookstoreComboBox.SelectedIndex != -1);
            addBooksButton.Enabled = flag;
            label3.Visible = !flag;
        }

        private void addBooksButton_Click(object sender, EventArgs e)
        {
            List<StockBalances> tempEntityList = new List<StockBalances>();

            using (TimToressonLabb3DBContext context = new TimToressonLabb3DBContext())
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    long isbn = (row.DataBoundItem as BookRecord).ISBN13;
                    tempEntityList.Add(new StockBalances()
                    {
                        Isbn13 = isbn,
                        Amount = (int)numericUpDown1.Value,
                        BookstoreId = context.Bookstores.First(bs => bs.BookstoreName == bookstoreComboBox.Text).Id,

                        Bookstore = new Bookstore() { BookstoreName = bookstoreComboBox.Text }
                    }
                    ) ;
                }
            }
            (Owner as Form1).AddBooks(tempEntityList);
        }

        class BookRecord
        {
            public long ISBN13 { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
        }
        #endregion
    }
}
