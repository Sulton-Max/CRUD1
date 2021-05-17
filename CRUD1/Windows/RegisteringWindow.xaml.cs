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

namespace CRUD1
{
    /// <summary>
    /// Interaction logic for RegisteringWindow.xaml
    /// </summary>
    public partial class RegisteringWindow : Window
    {
        private AccountsList _accounts;
        private 

        public RegisteringWindow(AccountsList accounts)
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommandsHelper.Create(new Account(FirstName.Text, LastName.Text, int.Parse(Age.Text), 
                (Gender.SelectedIndex == 0)? true : false));
            this.Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CheckValidity(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FirstName.Text)
                && !string.IsNullOrWhiteSpace(LastName.Text)
                && !string.IsNullOrWhiteSpace(Age.Text))
                this.AddBtn.IsEnabled = true;
            else
                this.AddBtn.IsEnabled = false;
        }
    }
}
