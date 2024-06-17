using PR43.Classes;
using PR43.Classes.DataBase;
using PR43.Modell;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;

namespace PR43.Context
{
    public class BooksContext : Books
    {
        public BooksContext(bool save = false)
        {
            if (save) save = true;
            Author = new Authors();
        }
        public static ObservableCollection<BooksContext> AllBooks()
        {
            ObservableCollection<BooksContext> allBooks = new ObservableCollection<BooksContext>();
            ObservableCollection<AuthorsContext> allAuthors = AuthorsContext.AllAuthors();
            SqlConnection connection;
            SqlDataReader dataItems = Connection.Query("Select * from [dbo].[Books]", out connection);
            while (dataItems.Read())
            {
                allBooks.Add(new BooksContext()
                {
                    Id = dataItems.GetInt32(0),
                    Name = dataItems.GetString(1),
                    Author = dataItems.IsDBNull(2) ? null : allAuthors.Where(x => x.Id == dataItems.GetInt32(4)).First(),
                    Description = dataItems.GetString(3),
                });
            }
            Connection.CloseConnection(connection);
            return allBooks;
        }
        public void Save(bool New = false)
        {
            SqlConnection connection;
            if (New)
            {
                SqlDataReader dataItems = Connection.Query("Insert into " +
                    "[dbo].[Books](" +
                    "Name, " +
                    "Author, " +
                    "Description) " +
                    "OUTPUT Inserted.Id " +
                    "Values (" +
                    $"N'{Name}', " +
                    $"{Author}, " +
                    $"N'{Description}')", out connection);
                dataItems.Read();
                Id = dataItems.GetInt32(0);
            }
            else
            {
                Connection.Query("Update [dbo].[Books] " +
                    "Set " +
                    $"Name = N'{Name}', " +
                    $"Author = {Author}, " +
                    $"Description = N'{Description}' " +
                    "Where " +
                    $"Id = {Id}", out connection);
            }
            Connection.CloseConnection(connection);
            MainWindow.MW.frame.Navigate(MainWindow.Main);
        }
        public void Delete()
        {
            SqlConnection connection;
            Connection.Query("Delete from [dbo].[Books] " +
                "Where " +
                $"Id = {Id}", out connection);
            Connection.CloseConnection(connection);
        }
        public RelayCommand OnEdit
        {
            get { return new RelayCommand(obj => MainWindow.MW.frame.Navigate(new View.AddBook(this))); }
        }
        public RelayCommand OnSave
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Author = AuthorsContext.AllAuthors().Where(x => x.Id == Author.Id).First();
                    Save();
                });
            }
        }
        public RelayCommand OnDelete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Delete();
                    (MainWindow.Main.DataContext as ViewModell.VMBooks).Books.Remove(this);
                });
            }
        }
    }
}
