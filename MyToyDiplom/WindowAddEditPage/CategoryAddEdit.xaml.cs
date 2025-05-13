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
    /// Логика взаимодействия для CategoryAddEdit.xaml
    /// </summary>
    public partial class CategoryAddEdit : Window
    {
        public CategoryAddEdit()
        {
            InitializeComponent();
        }
        MyToyContext _db = new MyToyContext();
        Category _Cater;

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Cat.Text.Length == 0) errors.AppendLine("Введите категорию");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Cater == null)
                {
                    _db.Categories.Add(_Cater);
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

            if (Data.Employ == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                RegBut.Content = "Добавить категорию";
                _Cater = new Category();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                RegBut.Content = "Изменить категорию";
                _Cater = _db.Categories.Find(Data.Cater.Id);
            }
            WindowAddEdit.DataContext = _Cater;
        }
    }
}
