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
    /// Логика взаимодействия для EmployeeAddEdit.xaml
    /// </summary>
    public partial class EmployeeAddEdit : Window
    {
        public EmployeeAddEdit()
        {
            InitializeComponent();
        }
        MyToyContext _db = new MyToyContext();
        Employee _Empl;

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Surn.Text.Length == 0) errors.AppendLine("Введите фамилию");

            if (Nam.Text.Length == 0) errors.AppendLine("Введите имя");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Employ == null)
                {
                    _db.Employees.Add(_Empl);
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
                RegBut.Content = "Добавить сотрудника";
                _Empl = new Employee();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                RegBut.Content = "Изменить сотрудника";
                _Empl = _db.Employees.Find(Data.Employ.EmpoleeId);
            }
            WindowAddEdit.DataContext = _Empl;
        }
    }
}
