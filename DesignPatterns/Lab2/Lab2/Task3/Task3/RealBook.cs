namespace task3
{
    public interface IBook
    {
        string Read();
    }
    
    public class RealBook : IBook
    {
        public int Id { get; }
        public string Title { get; }
        public string Text { get; }

        public RealBook(int id)
        {
            Id = id;
            
            Console.WriteLine("Geting book info  " + id + " from data source...");

            Title = "Book " + id;
            Text = "This is the text of book " + id + ".";
        }

        public string Read()
        {
            return "Title: " + Title + "\nText: " + Text;
        }
    }
}

