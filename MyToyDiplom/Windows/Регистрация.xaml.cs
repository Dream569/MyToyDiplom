using MyToyDiplom.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyToyDiplom.Windows
{
    /// <summary>
    /// Логика взаимодействия для Регистрация.xaml
    /// </summary>
    public partial class Регистрация : Window
    {
        
        public Регистрация()
        {
            InitializeComponent();
        }
        MyToyContext _db = new MyToyContext();
        User _Us;

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Surn.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (Nam.Text.Length == 0) errors.AppendLine("Введите имя");
            if (LasNam.Text.Length == 0) errors.AppendLine("Введите отчество");
            if (Log.Text.Length == 0) errors.AppendLine("Введите логин");
            if (Pas.Text.Length == 0) errors.AppendLine("Введите пароль");

            var p = _db.Users.Where(p => p.Login == Log.Text);
            if (p.Count() > 0) errors.AppendLine("Такой логин уже существует");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Use == null)
                {
                    _Us.UserRole = 3;
                    _db.Users.Add(_Us);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
                Close();
                Data.Use = null;
                Авторизация f = new Авторизация();
                f.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void CanselClick(object sender, RoutedEventArgs e)
        {
            Close();
            Data.Use = null;
            Авторизация f = new Авторизация();
            f.ShowDialog();
        }
        private void Window_Loaded3(object sender, RoutedEventArgs e)
        {
            //Rol.ItemsSource = _db.Roles.ToList();
            //Rol.DisplayMemberPath = "Id";
            //Rol.SelectedValuePath = "RoleName";
            //Rol.SelectedIndex = 3;
            if (Data.Use == null)
            {
                WindowAddEdit.Title = "Регистрация";
                RegBut.Content = "Зарегистрироваться";
                _Us = new User();
            }
            WindowAddEdit.DataContext = _Us;
        }
    }
}
