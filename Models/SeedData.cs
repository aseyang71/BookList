using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// Load the book data from the assignment documentation

// Data normalization step: 
// 1. Divide name to two fields (AuthorFirstName and AuthorLastName) to avoid non-atomic field 
// 2. Create two fileds for category: Category1 and Category2 to avoid repeating groups

// Add "F" after each Price field to covert float data type. 
// Finally, save the changes to the database using context.SaveChanges();
namespace BookList.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BookListDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BookListDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            
            if (!context.BLPs.Any())
            {
                context.BLPs.AddRange(
                    new BLP
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Category1 = "Fiction",
                        Category2 = "Classic",
                        Price = 9.95F
                    },

                    new BLP
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Category1 = "Non-Fiction",
                        Category2 = "Biography",
                        Price = 14.58F
                    },

                    new BLP
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Category1 = "Non-Fiction",
                        Category2 = "Biography",
                        Price = 21.54F
                    },

                    new BLP
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Category1 = "Non-Fiction",
                        Category2 = "Biography",
                        Price = 11.61F
                    },

                    new BLP
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Category1 = "Non-Fiction",
                        Category2 = "Biography",
                        Price = 13.33F
                    },

                    new BLP
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Category1 = "Fiction",
                        Category2 = "Historical Fiction",
                        Price = 15.95F
                    },

                    new BLP
                    {
                        Title = "Deep  Work",
                        AuthorFirstName = "Cal",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Category1 = "Non-Fiction",
                        Category2 = "Self-Help",
                        Price = 14.99F
                    },

                    new BLP
                    {
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Category1 = "Non-Fiction",
                        Category2 = "Self-Help",
                        Price = 21.66F
                    },

                    new BLP
                    {
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Category1 = "Non-Fiction",
                        Category2 = "Business",
                        Price = 29.16F
                    },

                    new BLP
                    {
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Category1 = "Fiction",
                        Category2 = "Thrillers",
                        Price = 15.03F
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
