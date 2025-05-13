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
    /// Логика взаимодействия для ProviderAddEdit.xaml
    /// </summary>
    public partial class ProviderAddEdit : Window
    {
        public ProviderAddEdit()
        {
            InitializeComponent();
        }
        MyToyContext _db = new MyToyContext();
        Provider _Prov;

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (ProvNam.Text.Length == 0) errors.AppendLine("Введите название доставки");
            
            if (TimDev.Text.Length == 0) errors.AppendLine("Введите время доставки");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Prov == null)
                {
                    _db.Providers.Add(_Prov);
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
            
            if (Data.Prov == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                RegBut.Content = "Добавить доставку";
                _Prov = new Provider();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                RegBut.Content = "Изменить доставку";
                _Prov = _db.Providers.Find(Data.Prov.ProviderId);
            }
            WindowAddEdit.DataContext = _Prov;
        }
    }
}
