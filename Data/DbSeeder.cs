using BookWebAPI.Models;

namespace BookWebAPI.Data
{
    public class DbSeeder
    {
            public static void Seed(DataContext context)
            {
                SeedCountries(context);
                SeedAuthors(context);
                SeedBooks(context);
                SeedShops(context);
                SeedGenres(context);
            }

            private static void SeedCountries(DataContext context)
            {
                if (!context.Country.Any())
                {
                    var countries = new List<Country>
                {
                    new Country { Name = "UK" },
                    new Country { Name = "Japan" },
                    new Country { Name = "Italy" }
                };

                    context.Country.AddRange(countries);
                    context.SaveChanges();
                }
            }

            private static void SeedAuthors(DataContext context)
            {
                if (!context.Authors.Any())
                {
                    var authors = new List<Author>
                {
                    new Author { Name = "Nick", LastName = "Hornby", BirthDay = new DateTime(1980, 1, 1), CountryId = 1 },
                    new Author { Name = "Yukio", LastName = "Mishima", BirthDay = new DateTime(1990, 2, 2), CountryId = 2 },
                    new Author { Name = "Paolo", LastName = "Cognetti", BirthDay = new DateTime(2000, 3, 3), CountryId = 3 }
                };

                    context.Authors.AddRange(authors);
                    context.SaveChanges();
                }
            }

            private static void SeedBooks(DataContext context)
            {
                if (!context.Books.Any())
                {
                    var books = new List<Books>
                    {
                    new Books { Title = "High-Fidelity", Description = "Drama", AuthorId = 1},
                    new Books { Title = "The Man Who Fell From Grace With The Sea", Description = "Drama", AuthorId = 2},
                    new Books { Title = "Antonia", Description = "Poetry", AuthorId = 3}
                };

                    context.Books.AddRange(books);
                    context.SaveChanges();
                }
            }

        private static void SeedGenres(DataContext context)
        {
            if (!context.Genres.Any())
            {
                var genres = new List<Genre>

                {
                    new Genre { Name = "Drama"},
                    new Genre { Name = "Comedy"},
                    new Genre { Name = "Poetry" }
                };

                context.Genres.AddRange(genres);
                context.SaveChanges();
            }
        }

            private static void SeedShops(DataContext context)
            {
                if (!context.Shops.Any())
                {
                    var shops = new List<Shop>
                {
                    new Shop { Name = "De Groene Waterman", Address = "Kapelstraat 8", City = "Antwerp" },
                    new Shop { Name = "De Slegte", Address = "Waterstraat 5", City = "Ghent" },
                    new Shop { Name = "Demian", Address = "Veldstraat 54", City = "Antwerp" }
                };

                    context.Shops.AddRange(shops);
                    context.SaveChanges();
                }
            }
        }
    }

