namespace BookShop
{
    using Data;
    using System;
    using Initializer;
    using System.Linq;
    using System.Text;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            string result;

            using (var db = new BookShopContext())
            {
                DbInitializer.ResetDatabase(db);

                //result = GetBooksByAgeRestriction(db, "miNor");
                //result = GetGoldenBooks(db);
                //result = GetBooksByPrice(db);
                //result = GetBooksNotReleasedIn(db, 2000);
                //result = GetBooksByCategory(db, "horror mystery drama");
                //result = GetBooksReleasedBefore(db, "12-04-1992");
                //result = GetAuthorNamesEndingIn(db, "e");
                //result = GetBookTitlesContaining(db, "sK");
                //result = GetBooksByAuthor(db, "R");
                //result = CountBooks(db, 12);
                //result = CountCopiesByAuthor(db);
                //result = GetTotalProfitByCategory(db);
                result = GetMostRecentBooks(db);
            }

            Console.WriteLine(result);

        }

        // Problem 2
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            var titles = context.Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            foreach (var title in titles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 3
        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var titles = context.Books
                .Where(b => (int)b.EditionType == 2 && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (var title in titles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 4
        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            var titles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            foreach (var title in titles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }


        // Problem 6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var categories = input.Split(' ').Select(c => c.ToLower()).ToList();

            var titles = context.BooksCategories
                .Where(b => input.Contains(b.Category.Name.ToLower()))
                .Select(b => b.Book.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var title in titles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            DateTime convertedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < convertedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price

                })
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - {book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var names = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(n => n)
                .ToList();

            return String.Join("\n", names).TrimEnd();
        }

        // Problem 9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join("\n", books).TrimEnd();
        }

        // Problem 10
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();

            return String.Join("\n", books).TrimEnd();
        }

        // Problem 11
        public static string CountBooks(BookShopContext context, int lengthCheck)
        {
            int count = context.Books
                .Count(b => b.Title.Length > lengthCheck);

            return $"There are {count} books with longer title than {lengthCheck} symbols";
        }

        // Problem 12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(b => b.Copies)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categories = context
                .Categories
                .Select(c => new
                {
                    Name = c.Name,
                    TotalProfit = c.CategoryBooks
                        .Select(cb => cb.Book)
                        .Sum(b => b.Price * b.Copies)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit}");
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var recentBooks = context
                .Categories
                .Select(c => new
                {
                    Category = c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(cb => cb.Book.ReleaseDate)
                        .Select(cb => new
                        {
                            Title = cb.Book.Title,
                            ReleaseDate = cb.Book.ReleaseDate
                        })
                        .Take(3)
                })
                .OrderBy(c => c.Category)
                .ToList();

            foreach (var category in recentBooks)
            {
                sb.AppendLine($"--{category.Category}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // Problem 15
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }


        // Problem 16
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            int countRemovedBooks = books.Count;

            context.RemoveRange(books);

            return countRemovedBooks;
        }

    }
}
