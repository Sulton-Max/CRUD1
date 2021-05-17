using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using CRUD1.Windows;

namespace CRUD1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AccountsList Accounts = new AccountsList();
        private DBExecuter _executer = new DBExecuter();
        private AccountForm _accForm = new AccountForm();

        public MainWindow()
        {
            InitializeComponent();

            _executer.Accounts = Accounts;
            _executer.LogSource = LogLabel;
            _accForm.Executer = _executer;

            DataContext = Accounts;
            _executer.Read();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            _accForm.CreateMode();
            _accForm.Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var acc = this.AccountListView.SelectedItem as Account;
            if (acc == null)
                this.LogLabel.Content = "Not selected";
            else
            {
                _accForm.EditMode(acc);
                _accForm.Show();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var acc = this.AccountListView.SelectedItem as Account;
            if (acc == null)
                this.LogLabel.Content = "Not selected";
            else
                _executer.Delete(acc.Id);
        }
    }
}
