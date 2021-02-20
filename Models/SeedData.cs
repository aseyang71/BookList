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
                        Price = 9.95F,
                        PageNum = "1488"
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
                        Price = 14.58F,
                        PageNum = "944"
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
                        Price = 21.54F,
                        PageNum = "832"
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
                        Price = 11.61F,
                        PageNum = "864"
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
                        Price = 13.33F,
                        PageNum = "528"
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
                        Price = 15.95F,
                        PageNum = "288"
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
                        Price = 14.99F,
                        PageNum = "304"
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
                        Price = 21.66F,
                        PageNum = "240"
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
                        Price = 29.16F,
                        PageNum = "400"
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
                        Price = 15.03F,
                        PageNum = "400"
                    },

                    new BLP
                    {
                        Title = "成為1%的創業存活者",
                        AuthorFirstName = "繁捷",
                        AuthorLastName = "王",
                        Publisher = "三采",
                        ISBN = "978-9576584633",
                        Category1 = "商業理財",
                        Category2 = "自我成長",
                        Price = 12.5F,
                        PageNum = "833"
                    },

                    new BLP
                    {
                        Title = "致富心態",
                        AuthorFirstName = "摩根",
                        AuthorLastName = "豪瑟",
                        Publisher = "天下文化",
                        ISBN = "978-9865250348",
                        Category1 = "投資學",
                        Category2 = "無",
                        Price = 17.99F,
                        PageNum = "1020"
                    },

                    new BLP
                    {
                        Title = "生活投資學",
                        AuthorFirstName = "凱迪",
                        AuthorLastName = "許",
                        Publisher = "遠流",
                        ISBN = "978-9573283454",
                        Category1 = "投資學",
                        Category2 = "股票/證卷",
                        Price = 12.32F,
                        PageNum = "822"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
