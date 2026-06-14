namespace WpfLibrary.Models
{
    public class Book : LibraryItem
    {
        public string Author { get; set; }

        public override string Type => "Книга";

        public override string GetInfo()
        {
            return $"ID:{Id} | Книга | {Title} | {Year} | {Author}";
        }
    }
}