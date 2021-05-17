using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace CRUD1
{
    public class AccountsList : INotifyPropertyChanged
    {
        private List<Account> _list = new List<Account>();
        public List<Account> List
        {
            get { return _list; }
            set
            {
                _list = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
