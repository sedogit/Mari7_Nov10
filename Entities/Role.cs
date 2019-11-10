namespace Mari7.Entities
{
    public static class Role
    {
        public const string Admin = "1";
        public const string Manager = "2";
        public const string Operator = "3";
        public const string Salesman ="4";
        public const string Purchaser="5";
        public const string Accountant = "6";
        public const string User = "7";
    
/*             public const int Admin = 1;
        public const int Manager = 2;
        public const int Operator = 3;
        public const int Salesman =4;
        public const int Purchaser=5;
        public const int Accountant = 6;
        public const int User = 7; */
    }

    // public sealed class Singleton
    // {
    // private static readonly Singleton instance = new Singleton();

    // // Explicit static constructor to tell C# compiler
    // // not to mark type as beforefieldinit
    // static Singleton()
    // {
    // }

    // private Singleton()
    // {

    // }

    // public static Singleton Instance
    // {
    // get
    // {
    // return instance;
    // }
    // }
    // }
}