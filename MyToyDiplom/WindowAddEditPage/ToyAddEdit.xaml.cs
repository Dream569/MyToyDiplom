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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Window
    {
        public AddEditPage()
        {
            InitializeComponent();
        }
        MyToyContext _db = new MyToyContext();
        Toy _Toy;

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (ToyNam.Text.Length == 0) errors.AppendLine("Введите название товара");
            if (TpyOpis.Text.Length == 0) errors.AppendLine("Введите описание");
            if (PriceToy.Text.Length == 0) errors.AppendLine("Введите цену");
            if (IdCat.Text.Length == 0) errors.AppendLine("Укажите код категории");
            if (IdSup.Text.Length == 0) errors.AppendLine("Укажите поставщика");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Toy == null)
                {
                    _db.Toys.Add(_Toy);
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
            IdCat.ItemsSource = _db.Categories.ToList();
            IdCat.DisplayMemberPath = "Id";
            IdSup.ItemsSource = _db.Suppliers.ToList();
            IdSup.DisplayMemberPath = "Id";
            if (Data.Toy == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                RegBut.Content = "Добавить поставщика";
                _Toy = new Toy();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                RegBut.Content = "Изменить поставщика";
                _Toy = _db.Toys.Find(Data.Toy.Id);
            }
            WindowAddEdit.DataContext = _Toy;
        }
    }
}
