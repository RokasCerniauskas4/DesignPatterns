namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new User("John", true, new List<int> { 1, 2 });
            var user2 = new User("Peter", false, new List<int>());
            var user3 = new User("Anna", true, new List<int> { 2 });

            IBook bookForJohn = new BookProxy(1, user1);
            IBook bookForPeter = new BookProxy(1, user2);
            IBook bookForAnna = new BookProxy(1, user3);

            Console.WriteLine("=== John tries to read book 1 ===");
            Console.WriteLine(bookForJohn.Read());
            Console.WriteLine();

            Console.WriteLine("=== Peter tries to read book 1 (not registered) ===");
            Console.WriteLine(bookForPeter.Read());
            Console.WriteLine();

            Console.WriteLine("=== Anna tries to read book 1 (no access) ===");
            Console.WriteLine(bookForAnna.Read());
            Console.WriteLine();

        }
    }
}