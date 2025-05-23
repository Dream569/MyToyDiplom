using Microsoft.VisualBasic.Logging;
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

namespace MyToyDiplom.WindowAddEditPage
{
    /// <summary>
    /// Логика взаимодействия для SupplierAddEdit.xaml
    /// </summary>
    public partial class SupplierAddEdit : Window
    {
        public SupplierAddEdit()
        {
            InitializeComponent();
        }
        MyToyContext _db = new MyToyContext();
        Supplier _Suplr;

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (SupNam.Text.Length == 0) errors.AppendLine("Введите имя поставщика");

            var p = _db.Suppliers.Where(p => p.Phone == int.Parse(Telep.Text));
            if (p.Count() > 0) errors.AppendLine("Такой телефон уже существует");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Supl == null)
                {
                    _db.Suppliers.Add(_Suplr);
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
            if (Data.Supl == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                RegBut.Content = "Добавить поставщика";
                _Suplr = new Supplier();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                RegBut.Content = "Изменить поставщика";
                _Suplr = _db.Suppliers.Find(Data.Supl.Id);
            }
            WindowAddEdit.DataContext = _Suplr;
        }
    }
}
