﻿using MyToyDiplom.DataBase;
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
    /// Логика взаимодействия для ProviderPage.xaml
    /// </summary>
    public partial class ProviderPage : Window
    {
        public ProviderPage()
        {
            InitializeComponent();
        }
        void LoadDBIListView()
        {
            using (MyToyContext _db = new MyToyContext())
            {
                int selectedIndex = ProvidersListView.SelectedIndex;
                ProvidersListView.ItemsSource = _db.Providers.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == ProvidersListView.Items.Count) selectedIndex--;
                    ProvidersListView.SelectedIndex = selectedIndex;
                    ProvidersListView.ScrollIntoView(ProvidersListView.SelectedItem);
                }
                ProvidersListView.Focus();
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Data.Prov = null;
            ProviderAddEdit f = new ProviderAddEdit();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProvidersListView.SelectedItem != null)
            {
                Data.Prov = (Provider)ProvidersListView.SelectedItem;
                ProviderAddEdit f = new ProviderAddEdit();
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
                    Provider row = (Provider)ProvidersListView.SelectedItem;
                    if (row != null)
                    {
                        using (MyToyContext _db = new MyToyContext())
                        {
                            _db.Providers.Remove(row);
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
            else ProvidersListView.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBIListView();
        }
    }
}
