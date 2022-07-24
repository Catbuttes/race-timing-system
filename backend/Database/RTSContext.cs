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
            modelBuilder.Entity<Driver>();
            modelBuilder.Entity<DriverTag>();
            modelBuilder.Entity<DriverAttribute>();
            modelBuilder.Entity<Race>();
            modelBuilder.Entity<RaceTag>();
            modelBuilder.Entity<RaceAttribute>();
            modelBuilder.Entity<RaceDriver>();
            modelBuilder.Entity<RaceDriverTag>();
            modelBuilder.Entity<RaceDriverAttribute>();
            modelBuilder.Entity<Lap>();
            modelBuilder.Entity<LapTag>();
            modelBuilder.Entity<LapAttribute>();
            modelBuilder.Entity<TagCategory>();
            modelBuilder.Entity<TagDefinition>();
            modelBuilder.Entity<AttributeDefinition>();
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