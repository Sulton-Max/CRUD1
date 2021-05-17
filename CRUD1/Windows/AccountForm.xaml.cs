using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CRUD1.Windows
{
    /// <summary>
    /// Interaction logic for AccountForm.xaml
    /// </summary>
    public partial class AccountForm : Window
    {
        public DBExecuter Executer;
        public bool IsEditMode = false;

        public AccountForm()
        {
            InitializeComponent();
        }

        public void EditMode(Account account)
        {
            if (!IsEditMode)
            {
                this.IdLabel.Visibility = Visibility.Visible;
                this.Id.Visibility = Visibility.Visible;
                this.PrimaryBtn.Content = "Update";
                this.IsEditMode = true;
            }
            this.Id.Text = account.Id.ToString();
            this.FirstName.Text = account.FirstName;
            this.LastName.Text = account.LastName;
            this.Age.Text = account.Age.ToString();
            this.Gender.SelectedIndex = (account.Gender == true) ? 0 : 1;
        }

        public void CreateMode()
        {
            if (IsEditMode)
            {
                this.IdLabel.Visibility = Visibility.Collapsed;
                this.Id.Visibility = Visibility.Collapsed;
                PrimaryBtn.Content = "Add";
                this.IsEditMode = false;
            }
        }

        private void PriaaryBtn_Click(object sender, RoutedEventArgs e)
        {
            FirstName.Text = FirstName.Text.Trim();
            LastName.Text = LastName.Text.Trim();
            if (IsEditMode)
            {
                var account = new Account(int.Parse(Id.Text), FirstName.Text, LastName.Text, int.Parse(Age.Text),
                    ((Gender.SelectedIndex == 0) ? true : false));
                Executer.Update(account);
            }
            else
            {
                var account = new Account(FirstName.Text, LastName.Text, int.Parse(Age.Text), ((Gender.SelectedIndex == 0) ? true : false));
                Executer.Create(account);
            }
            this.Visibility = Visibility.Hidden;
            Clear();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Clear();
        }

        private void CheckValidity(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FirstName.Text)
                && !string.IsNullOrWhiteSpace(LastName.Text)
                && !string.IsNullOrWhiteSpace(Age.Text))
                this.PrimaryBtn.IsEnabled = true;
            else
                this.PrimaryBtn.IsEnabled = false;
        }

        private void Clear()
        {
            FirstName.Text = string.Empty;
            LastName.Text = string.Empty;
            Age.Text = string.Empty;
            Gender.SelectedIndex = 0;
        }
    }
}
