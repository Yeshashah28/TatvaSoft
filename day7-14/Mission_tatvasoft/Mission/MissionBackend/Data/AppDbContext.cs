using Microsoft.EntityFrameworkCore;
using MissionBackend.Models;
using System.Collections.Generic;

namespace MissionBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<MissionTheme> MissionTheme { get; set; }

        public DbSet<MissionSkill> MissionSkill { get; set; }

        public DbSet<Mission> Mission { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<MissionApplication> MissionApplications { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Entity<Country>().HasData(new Country() { Id = 1, CountryName = "India" });
            builder.Entity<Country>().HasData(new Country() { Id = 2, CountryName = "USA" });
            builder.Entity<Country>().HasData(new Country() { Id = 3, CountryName = "UK" });
            builder.Entity<Country>().HasData(new Country() { Id = 4, CountryName = "Russia" });

            builder.Entity<City>().HasData(new City() { Id = 1, CountryId = 1, CityName = "Ahmedabad" });
            builder.Entity<City>().HasData(new City() { Id = 2, CountryId = 1, CityName = "Rajkot" });
            builder.Entity<City>().HasData(new City() { Id = 3, CountryId = 1, CityName = "Surat" });
            builder.Entity<City>().HasData(new City() { Id = 4, CountryId = 1, CityName = "Jamnagar" });
            builder.Entity<City>().HasData(new City() { Id = 5, CountryId = 2, CityName = "New York" });
            builder.Entity<City>().HasData(new City() { Id = 6, CountryId = 2, CityName = "California" });
            builder.Entity<City>().HasData(new City() { Id = 7, CountryId = 2, CityName = "Texas" });
            builder.Entity<City>().HasData(new City() { Id = 8, CountryId = 3, CityName = "London" });
            builder.Entity<City>().HasData(new City() { Id = 9, CountryId = 3, CityName = "Manchester" });
            builder.Entity<City>().HasData(new City() { Id = 10, CountryId = 3, CityName = "Birmingham" });
            builder.Entity<City>().HasData(new City() { Id = 11, CountryId = 4, CityName = "Moscow" });
            builder.Entity<City>().HasData(new City() { Id = 12, CountryId = 4, CityName = "Saint Petersburg" });
            builder.Entity<City>().HasData(new City() { Id = 13, CountryId = 4, CityName = "Yekaterinburg" });

            base.OnModelCreating(builder);
        }
    }
}
