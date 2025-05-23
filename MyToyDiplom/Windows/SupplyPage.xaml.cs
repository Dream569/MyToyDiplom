using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для SupplyPage.xaml
    /// </summary>
    public partial class SupplyPage : Window
    {
        public SupplyPage()
        {
            InitializeComponent();
        }
        void LoadDBIListView()
        {
            using (MyToyContext _db = new MyToyContext())
            {
                int selectedIndex = SupplyListView.SelectedIndex;
                SupplyListView.ItemsSource = _db.Supplies.Include(t => t.Toy).ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == SupplyListView.Items.Count) selectedIndex--;
                    SupplyListView.SelectedIndex = selectedIndex;
                    SupplyListView.ScrollIntoView(SupplyListView.SelectedItem);
                }
                SupplyListView.Focus();
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Data.Supply = null;
            SupplyAddEdit f = new SupplyAddEdit();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SupplyListView.SelectedItem != null)
            {
                Data.Supply = (Supply)SupplyListView.SelectedItem;
                SupplyAddEdit f = new SupplyAddEdit();
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
                    Supply row = (Supply)SupplyListView.SelectedItem;
                    if (row != null)
                    {
                        using (MyToyContext _db = new MyToyContext())
                        {
                            _db.Supplies.Remove(row);
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
            else SupplyListView.Focus();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            LoadDBIListView();
        }
    }
}
