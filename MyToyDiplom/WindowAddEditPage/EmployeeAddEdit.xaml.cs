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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;


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
            _db.Employees.Load();
        }
        MyToyContext _db = new MyToyContext();
        Employee _Empl;
        OpenFileDialog open = new OpenFileDialog();

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Surn.Text.Length == 0) errors.AppendLine("Введите фамилию");
            if (Nam.Text.Length == 0) errors.AppendLine("Введите имя");

            var p = _db.Employees.Where(p => p.Phone == int.Parse(Tel.Text));
            if (p.Count() > 0) errors.AppendLine("Такой телефон уже существует");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (open.SafeFileName.Length != 0)
                {
                    string newNamePhoto = Directory.GetCurrentDirectory() + "\\image2\\" + open.SafeFileName;
                    File.Copy(open.FileName, newNamePhoto, true);
                    _Empl.Photo = open.SafeFileName.ToString();
                }
            }
            catch { }
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
