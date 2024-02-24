using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_Hendrickson.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) //constructor
        {
        }
        //the name of table (Applications)
        public DbSet<MovieModel> Movies { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(

                new CategoryModel { CategoryId = 1, CategoryName = "Drama" }
                // seed the data (unrelated to connecitng the table)
                ); ;
        }
    }
}
