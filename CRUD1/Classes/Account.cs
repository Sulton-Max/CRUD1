using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.Generic;

namespace CRUD1
{
    // The Data model
    public class Account
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public bool Gender { get; }

        // Constructor for creating absolutely new Account
        public Account (string fn, string ln, int age, bool gen)
        {
            Id = IdGenerator.GetId();
            FirstName = fn;
            LastName = ln;
            Age = age;
            Gender = gen;
        }

        // Constructor for creating new object read from DB
        public Account(int id, string fn, string ln, int age, bool gen)
        {
            Id = id;
            FirstName = fn;
            LastName = ln;
            Age = age;
            Gender = gen;
        }

        // To String method changed for UPDATE SQL command
        public override string ToString()
        {
            return $"FirstName='{FirstName}',LastName='{LastName}',Age={Age},Gender='{Gender.ToString().ToUpper()}'";
        }
    }

    // The Data model list for binding
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

    // To generate Id for new account
    public static class IdGenerator
    {
        private static int _id = 0;

        public static int GetId() => ++_id;
    }

}
