namespace backend.Database
{
    using Microsoft.EntityFrameworkCore;
    using backend.Database.Models;

    public class RTSContext : DbContext
    {
        public RTSContext(DbContextOptions<RTSContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>()
            .HasData(
                new { Id=1, Name = "Driver 1", User=Guid.NewGuid()},
                new { Id=2, Name = "Driver 2", User = Guid.NewGuid() },
                new { Id=3, Name = "Driver 3", User = Guid.NewGuid() }
            );
            modelBuilder.Entity<DriverTag>()
            .HasData(
                new
                {
                    Id = 1,
                    DriverId = 1,
                    TagId = 1,
                },
                new
                {
                    Id = 2,
                    DriverId = 2,
                    TagId = 1,
                },
                new
                {
                    Id = 3,
                    DriverId = 3,
                    TagId = 1,
                }
            );
            modelBuilder.Entity<DriverAttribute>()
            .HasData(
                new
                {
                    Id=1,
                    Value = "Team1",
                    DefinitionId = 1,
                    DriverId = 1
                },
                new
                {
                    Id = 2,
                    Value = "Team2",
                    DefinitionId = 1,
                    DriverId = 2
                },
                new
                {
                    Id = 3,
                    Value = "Team3",
                    DefinitionId = 1,
                    DriverId = 3
                }
            );
            modelBuilder.Entity<Race>();
            modelBuilder.Entity<RaceTag>();
            modelBuilder.Entity<RaceAttribute>();
            modelBuilder.Entity<RaceDriver>();
            modelBuilder.Entity<RaceDriverTag>();
            modelBuilder.Entity<RaceDriverAttribute>();
            modelBuilder.Entity<Lap>();
            modelBuilder.Entity<LapTag>();
            modelBuilder.Entity<LapAttribute>();
            modelBuilder.Entity<TagCategory>()
            .HasData(
                new
                {
                    Id = 1,
                    Name = "Tyre",
                    Description = "The tyre the driver prefers",
                    DriverValid = true,
                    RaceValid = false,
                    RaceDriverValid = true,
                    LapValid = false,
                }
            );
            modelBuilder.Entity<TagDefinition>()
            .HasData(
                new
                {
                    Id = 1,
                    CategoryId = 1,
                    Description = "The tyre the driver prefers",
                    Value = "Soft"
                }
            );
            modelBuilder.Entity<AttributeDefinition>()
            .HasData(
                new
                {
                    Id=1,
                    Name = "Team",
                    Description = "The team the driver belongs to",
                    Type = "SingleLineOfText",
                    DriverValid = true,
                    RaceValid = false,
                    RaceDriverValid = true,
                    LapValid = false,
                }
            );
        }

        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<DriverTag> DriverTags => Set<DriverTag>();
        public DbSet<DriverAttribute> DriverAttributes => Set<DriverAttribute>();
        public DbSet<Race> Races => Set<Race>();
        public DbSet<RaceTag> RaceTags => Set<RaceTag>();
        public DbSet<RaceAttribute> RaceAttributes => Set<RaceAttribute>();
        public DbSet<RaceDriver> RaceDrivers => Set<RaceDriver>();
        public DbSet<RaceDriverTag> RaceDriverTags => Set<RaceDriverTag>();
        public DbSet<RaceDriverAttribute> RaceDriverAttributes => Set<RaceDriverAttribute>();
        public DbSet<Lap> Laps => Set<Lap>();
        public DbSet<LapTag> LapTags => Set<LapTag>();
        public DbSet<LapAttribute> LapAttributes => Set<LapAttribute>();
        public DbSet<TagCategory> TagCategorys => Set<TagCategory>();
        public DbSet<TagDefinition> TagDefinitions => Set<TagDefinition>();
        public DbSet<AttributeDefinition> AttributeDefinitions => Set<AttributeDefinition>();
    }
}