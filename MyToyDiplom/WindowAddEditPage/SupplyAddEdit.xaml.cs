using MyToyDiplom.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyToyDiplom.WindowAddEditPage
{
    /// <summary>
    /// Логика взаимодействия для SupplyAddEdit.xaml
    /// </summary>
    public partial class SupplyAddEdit : Window
    {
        public SupplyAddEdit()
        {
            InitializeComponent();
        }
        MyToyContext _db = new MyToyContext();
        Supply _Sup;

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (IdToy.Text.Length == 0) errors.AppendLine("Введите код товара");
            if (Dat.SelectedDate == null) errors.AppendLine("Укажите дату");
            if (Coun.Text.Length == 0) errors.AppendLine("Введите колличество");
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Supply == null)
                {
                    _db.Supplies.Add(_Sup);
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
        private void Window_Loaded3(object sender, RoutedEventArgs e)
        {
            IdToy.ItemsSource = _db.Toys.ToList();
            IdToy.DisplayMemberPath = "Id";
            if (Data.Supply == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                RegBut.Content = "Добавить поставщика";
                _Sup = new Supply();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                RegBut.Content = "Изменить поставщика";
                _Sup = _db.Supplies.Find(Data.Supply.Id);
            }
            WindowAddEdit.DataContext = _Sup;
        }
    }
}
