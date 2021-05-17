namespace CRUD1
{
    public interface IAccount
    {
        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get; }
        
        public int Age { get; }
        
        public bool Gender { get; }
    }

    public class Account : IAccount
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
    }

    public static class IdGenerator
    {
        private static int _id = 0;

        public static int GetId() => _id;
    }
}
