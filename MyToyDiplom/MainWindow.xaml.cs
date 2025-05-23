using MyToyDiplom.DataBase;
using MyToyDiplom.Windows;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyToyDiplom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<string> _promoImages = new List<string>
        {
            "C:\\Users\\user\\source\\repos\\MyToyDiplom\\MyToyDiplom\\Images\\wTZRavfdZZk.jpg",
            "C:\\Users\\user\\source\\repos\\MyToyDiplom\\MyToyDiplom\\Images\\-d08Jq9NNkg.jpg",
            "C:\\Users\\user\\source\\repos\\MyToyDiplom\\MyToyDiplom\\Images\\0tjOXC6QL60.jpg"
        };

        private int _currentPromoIndex = 0;
        private readonly DispatcherTimer _promoTimer = new DispatcherTimer();
        private readonly DispatcherTimer _clockTimer = new DispatcherTimer();

        public DateTime CurrentDateTime => DateTime.Now;

        private void PromoTimer_Tick(object sender, EventArgs e)
        {
            _currentPromoIndex = (_currentPromoIndex + 1) % _promoImages.Count;
            LoadPromoImage();
        }

        private void LoadPromoImage()
        {
            try
            {
                var uri = new Uri(_promoImages[_currentPromoIndex], UriKind.Absolute);
                PromoImage.Source = new BitmapImage(uri);
            }
            catch
            {
                // В случае ошибки загрузки изображения
                PromoImage.Source = new BitmapImage(new Uri("C:\\Users\\user\\source\\repos\\MyToyDiplom\\MyToyDiplom\\Images\\wTZRavfdZZk.jpg"));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Настройка таймера для смены рекламных изображений
            _promoTimer.Interval = TimeSpan.FromSeconds(5);
            _promoTimer.Tick += PromoTimer_Tick;
            _promoTimer.Start();

            // Настройка таймера для обновления времени
            _clockTimer.Interval = TimeSpan.FromSeconds(1);
            _clockTimer.Tick += (s, e) => OnPropertyChanged(nameof(CurrentDateTime));
            _clockTimer.Start();

            // Загрузка первого изображения
            LoadPromoImage();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Авторизация f = new Авторизация();
            f.ShowDialog();
            if (Data.login == false) Close();
            if (Data.Right == "Buyer")
            {
                Cater.IsEnabled = false;
                Suplr.IsEnabled = false;
                Empl.IsEnabled = false;
                Sal.IsEnabled = false;
                Supl.IsEnabled = false;
                Prov.IsEnabled = false;
                Cater.Opacity = 0.0;
                Suplr.Opacity = 0.0;
                Empl.Opacity = 0.0;
                Sal.Opacity = 0.0;
                Supl.Opacity = 0.0;
                Prov.Opacity = 0.0;

            }
            else
            if (Data.Right == "Admin" || Data.Right == "Employee")
            {

            }
            else
            {
                Cater.IsEnabled = false;
                Suplr.IsEnabled = false;
                Empl.IsEnabled = false;
                Sal.IsEnabled = false;
                Supl.IsEnabled = false;
                Prov.IsEnabled = false;
                Cater.Opacity = 0.0;
                Suplr.Opacity = 0.0;
                Empl.Opacity = 0.0;
                Sal.Opacity = 0.0;
                Supl.Opacity = 0.0;
                Prov.Opacity = 0.0;
            }
            Title = Title + " " + Data.UserSurname + " " + Data.UserName + " (" + Data.Right + ")";
        }


        private void ProductsButton_Click(object sender, RoutedEventArgs e)
        {
           ToysPage f = new ToysPage();
           f.ShowDialog();
        }

        private void CategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            CategoryPage f = new CategoryPage();
            f.ShowDialog();
        }

        private void SuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            SupplierPage f = new SupplierPage();
            f.ShowDialog();
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeePage f = new EmployeePage();
            f.ShowDialog();
        }

        private void SalesButton_Click(object sender, RoutedEventArgs e)
        {
            SalePage f = new SalePage();
            f.ShowDialog();
        }

        private void DeliveriesButton_Click(object sender, RoutedEventArgs e)
        {
            SupplyPage f = new SupplyPage();
            f.ShowDialog();
        }

        private void ShippingButton_Click(object sender, RoutedEventArgs e)
        {
            ProviderPage f = new ProviderPage();
            f.ShowDialog();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            BasketPage f = new BasketPage();
            f.ShowDialog();
        }

        public event EventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}