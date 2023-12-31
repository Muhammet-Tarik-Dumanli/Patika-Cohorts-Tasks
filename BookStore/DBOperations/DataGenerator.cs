using System;
using System.Linq;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                    return;

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                );
                
                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1, //Book.cs de Id property'sine verdiğimiz [DatabaseGenerated(DatabaseGeneratedOption.Identity)] attribute'den sonra gerek kalmadı
                        Title = "Lean Startup",
                        GenreId = 1, //Personal Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2, //Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 2,
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 21)
                    }
                );

                context.Authors.AddRange( 
                    new Author
                    {
                        FirstName = "Lev",
                        LastName = "Tolstoy",
                        DateOfBirth = new DateTime(1828, 9, 9)
                    },
                    new Author
                    {
                        FirstName = "Dan",
                        LastName = "Brown",
                        DateOfBirth = new DateTime(1964, 6, 22)
                    },
                    new Author
                    {
                        FirstName = "George",
                        LastName = "Martin",
                        DateOfBirth = new DateTime(1948, 9, 20)
                    }                   
                );
                
                context.SaveChanges();
            }
        }
    }
}