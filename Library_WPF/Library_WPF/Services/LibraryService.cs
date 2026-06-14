using System.Collections.Generic;
using System.Linq;
using WpfLibrary.Models;
using WpfLibrary.Repositories;

namespace WpfLibrary.Services
{
    public class LibraryService
    {
        private readonly LibraryRepository repo;
        private int nextId = 1;

        public LibraryService(LibraryRepository repo)
        {
            this.repo = repo;
        }

        public void AddBook(string title, int year, string author)
        {
            repo.Add(new Book
            {
                Id = nextId++,
                Title = title,
                Year = year,
                Author = author
            });
        }

        public void AddMagazine(string title, int year, int issue)
        {
            repo.Add(new Magazine
            {
                Id = nextId++,
                Title = title,
                Year = year,
                Issue = issue
            });
        }

        public void Remove(int id)
        {
            repo.Remove(id);
        }

        public List<LibraryItem> GetAll()
        {
            return repo.GetAll();
        }

        public void Update(int id, string title, int year, string extra)
        {
            var item = repo.GetAll().FirstOrDefault(x => x.Id == id);
            if (item == null) return;

            item.Title = title;
            item.Year = year;

            if (item is Book b)
                b.Author = extra;
            else if (item is Magazine m)
                m.Issue = int.Parse(extra);
        }

        public string GetStats()
        {
            var items = repo.GetAll();

            int books = items.Count(x => x is Book);
            int magazines = items.Count(x => x is Magazine);

            return $"Книги: {books}\nЖурналы: {magazines}\nВсего: {items.Count}";
        }
    }
}