using LearningAPI.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace LearningAPI.Data
{
    public class ApplicationdbContext : DbContext
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options) : base(options)
        {
        }
        public DbSet<Places> Places { get; set; } //Places will get the name in the database.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Places>().HasData(
                new Places
                {
                    Id = 1,
                    Name = "Delhi",
                    Details = "Food City of India.",
                    ImageUrl = "https://www.localsamosa.com/wp-content/uploads/2020/06/original_shutterstock_1294137358.jpg",
                    Occupancy = 200,
                    Rate = 100,
                    Sqft = 120,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                },
                new Places
                {
                    Id = 2,
                    Name = "Mumbai",
                    Details = "Dream city of India.",
                    ImageUrl = "https://www.burohappold.com/wp-content/uploads/2022/02/Mumbai-skyline_copyright-Adobe-Stock_01.jpg",
                    Occupancy = 100,
                    Rate = 300,
                    Sqft = 200,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                },
                new Places
                {
                    Id = 3,
                    Name = "Lucknow",
                    Details = "Nawab City of India.",
                    ImageUrl = "https://www.uptourism.gov.in/images/shahnafaz.jpg",
                    Occupancy = 200,
                    Rate = 200,
                    Sqft = 120,
                    Amenity = "",
                    CreatedDate = DateTime.Now

                }

                );
        }

    }
}
