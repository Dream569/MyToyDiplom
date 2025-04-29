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

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Surn.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (Nam.Text.Length == 0) errors.AppendLine("Введите имя");
            if (LasNam.Text.Length == 0) errors.AppendLine("Введите отчество");
            if (Log.Text.Length == 0) errors.AppendLine("Введите логин");
            if (Pas.Text.Length == 0) errors.AppendLine("Введите пароль");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Use == null)
                {
                    _db.Users.Add(_Us);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void CanselClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded2(object sender, RoutedEventArgs e)
        {
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
