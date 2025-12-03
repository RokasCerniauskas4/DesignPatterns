namespace task3
{
    public class BookProxy : IBook
    {
        private RealBook _realBook;
        private readonly int _bookId;
        private readonly User _user;

        public BookProxy(int bookId, User user)
        {
            _bookId = bookId;
            _user = user;
        }

        public string Read()
        {
            if (!_user.IsRegistered)
            {
                return "Access denied: user is not registered.";
            }
            
            if (!_user.CanRead(_bookId))
            {
                return "Access denied: user " + _user.Name + " cannot read book " + _bookId + ".";
            }
            
            if (_realBook == null)
            {
                _realBook = new RealBook(_bookId);
            }
            
            return _realBook.Read(); 
        }
    }
}