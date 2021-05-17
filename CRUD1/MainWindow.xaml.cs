using System;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUD1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AccountsList accounts = new AccountsList();
        private RegisteringWindow _regWindow = new RegisteringWindow(accounts);
        private 

        //public List<Account> Accounts
        //{
        //    get { return _accounts; }
        //    set
        //    {
        //        _accounts = value;
        //        OnPropertyChanged();
        //    }
        //}

        public MainWindow()
        {
            InitializeComponent();
            this.ConnStatus.Text = DBConnector.Connect();
            DataContext = this;
            Accounts = SqlCommandsHelper.Read();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            _regWindow.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
