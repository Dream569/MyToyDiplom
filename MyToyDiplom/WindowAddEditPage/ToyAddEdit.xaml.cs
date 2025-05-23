using Microsoft.EntityFrameworkCore;
using MyToyDiplom.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

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
            _db.Toys.Load();
        }
        MyToyContext _db = new MyToyContext();
        Toy _Toy;
        OpenFileDialog open = new OpenFileDialog();

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
                if (open.SafeFileName.Length != 0)
                {
                    string newNamePhoto = Directory.GetCurrentDirectory() + "\\image\\" + open.SafeFileName;
                    File.Copy(open.FileName, newNamePhoto, true);
                    _Toy.Photo = open.SafeFileName.ToString();
                }
            }
            catch { }
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
        private void AddPhoto(object sender, RoutedEventArgs e)
        {
            open.Filter = "Все файлы |*.*| Файлы *.jpg|*.jpg";
            open.FilterIndex = 2;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BitmapImage photoImage = new BitmapImage(new Uri(open.FileName));
                Photo.Source = photoImage;
            }
        }
        private void Window_Loaded3(object sender, RoutedEventArgs e)
        {
            IdCat.ItemsSource = _db.Categories.ToList();
            IdCat.SelectedValuePath = "Id";
            IdCat.DisplayMemberPath = "Name";
            IdSup.ItemsSource = _db.Suppliers.ToList();
            IdCat.SelectedValuePath = "Id";
            IdSup.DisplayMemberPath = "SupplierName";
            if (Data.Toy == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                RegBut.Content = "Добавить товар";
                _Toy = new Toy();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                RegBut.Content = "Изменить товар";
                _Toy = _db.Toys.Find(Data.Toy.Id);
            }
            WindowAddEdit.DataContext = _Toy;
        }
    }
}
