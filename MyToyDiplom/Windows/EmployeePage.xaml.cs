using MyToyDiplom.DataBase;
using MyToyDiplom.WindowAddEditPage;
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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Window
    {
        public EmployeePage()
        {
            InitializeComponent();
        }
        void LoadDBIListView()
        {
            using (MyToyContext _db = new MyToyContext())
            {
                int selectedIndex = EmployesListView.SelectedIndex;
                EmployesListView.ItemsSource = _db.Employees.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == EmployesListView.Items.Count) selectedIndex--;
                    EmployesListView.SelectedIndex = selectedIndex;
                    EmployesListView.ScrollIntoView(EmployesListView.SelectedItem);
                }
                EmployesListView.Focus();
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Data.Employ = null;
            EmployeeAddEdit f = new EmployeeAddEdit();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployesListView.SelectedItem != null)
            {
                Data.Employ = (Employee)EmployesListView.SelectedItem;
                EmployeeAddEdit f = new EmployeeAddEdit();
                f.Owner = this;
                f.ShowDialog();
                LoadDBIListView();
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Employee row = (Employee)EmployesListView.SelectedItem;
                    if (row != null)
                    {
                        using (MyToyContext _db = new MyToyContext())
                        {
                            _db.Employees.Remove(row);
                            _db.SaveChanges();
                        }
                        LoadDBIListView();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else EmployesListView.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBIListView();
        }
    }
}
