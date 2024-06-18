using PR43.Classes;
using PR43.Classes.DataBase;
using PR43.Modell;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace PR43.Context
{
    public class AuthorsContext : Authors
    {
        private static bool _isNew = true;
        public AuthorsContext(bool save = false)
        {
            if (save) save = true;
        }
        public static ObservableCollection<AuthorsContext> AllAuthors()
        {
            ObservableCollection<AuthorsContext> allAuthors = new ObservableCollection<AuthorsContext>();
            SqlConnection connection;
            SqlDataReader dataItems = Connection.Query("Select * from [dbo].[Authors]", out connection);
            while (dataItems.Read())
            {
                allAuthors.Add(new AuthorsContext()
                {
                    Id = dataItems.GetInt32(0),
                    Surname = dataItems.GetString(1),
                    Name = dataItems.GetString(2),
                    Lastname = dataItems.GetString(3),
                });
            }
            Connection.CloseConnection(connection);
            return allAuthors;
        }
        public void Save()
        {
            SqlConnection connection;
            if (_isNew)
            {
                SqlDataReader dataItems = Connection.Query("Insert into " +
                    "[dbo].[Authors](" +
                    "Surname, " +
                    "Name, " +
                    "Lastname) " +
                    "OUTPUT Inserted.Id " +
                    "Values (" +
                    $"N'{Surname}', " +
                    $"N'{Name}', " +
                    $"N'{Lastname}')", out connection);
                dataItems.Read();
                Id = dataItems.GetInt32(0);
            }
            else
            {
                Connection.Query("Update [dbo].[Authors] " +
                    "Set " +
                    $"Surname = N'{Surname}', " +
                    $"Name = N'{Name}', " +
                    $"Lastname = N'{Lastname}' " +
                    "Where " +
                    $"Id = {Id}", out connection);
            }
            Connection.CloseConnection(connection);
            MainWindow.MW.frame.Navigate(MainWindow.Main);
        }
        public void Delete()
        {
            SqlConnection connection;
            Connection.Query("Delete from [dbo].[Authors] " +
                "Where " +
                $"Id = {Id}", out connection);
            Connection.CloseConnection(connection);
        }
        public RelayCommand OnEdit
        {
            get
            {
                _isNew = false;
                return new RelayCommand(obj => MainWindow.MW.frame.Navigate(new View.AddAuthors(this)));
            }
        }
        public RelayCommand OnSave
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Save();
                    _isNew = true;
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
                    (MainWindow.Main.Authors.DataContext as ViewModell.VMAuthors).Authors.Remove(this);
                });
            }
        }
    }
}
