namespace WpfLibrary.Models
{
    public abstract class LibraryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public abstract string Type { get; }
        public abstract string GetInfo();
    }
}