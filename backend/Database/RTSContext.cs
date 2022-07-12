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
                new { Id=new Guid("8F9C7D3A-FAE0-4570-A619-67D26F070FF5"), Name = "Driver 1", User=Guid.NewGuid()},
                new { Id=new Guid("D6A9074D-5EB0-4FEF-A16E-A024F14EDFCA"), Name = "Driver 2", User = Guid.NewGuid() },
                new { Id=new Guid("6A4BC4BB-FA80-45FA-AACE-4865837E928A"), Name = "Driver 3", User = Guid.NewGuid() }
            );
            modelBuilder.Entity<DriverTag>()
            .HasData(
                new
                {
                    Id = new Guid("889A5AF0-E848-42E0-B9A9-554428BA53E0"),
                    DriverId = new Guid("8F9C7D3A-FAE0-4570-A619-67D26F070FF5"),
                    TagId = new Guid("B34104E1-EFD8-46EC-80F3-B732F8AA6D75"),
                },
                new
                {
                    Id = new Guid("CBB0EFDC-EDA1-4C3B-A50E-8F02550E2006"),
                    DriverId = new Guid("D6A9074D-5EB0-4FEF-A16E-A024F14EDFCA"),
                    TagId = new Guid("B34104E1-EFD8-46EC-80F3-B732F8AA6D75"),
                },
                new
                {
                    Id = new Guid("F6818E9F-37FC-483E-8AFD-8BE3F7FAB5C5"),
                    DriverId = new Guid("6A4BC4BB-FA80-45FA-AACE-4865837E928A"),
                    TagId = new Guid("B34104E1-EFD8-46EC-80F3-B732F8AA6D75"),
                }
            );
            modelBuilder.Entity<DriverAttribute>()
            .HasData(
                new
                {
                    Id=new Guid("1C537108-3001-43DB-9FD5-B00FED55BDCB"),
                    Value = "Team1",
                    DefinitionId = new Guid("54A85F54-E87E-4B98-A2FD-A57DD2AB4DF0"),
                    DriverId = new Guid("8F9C7D3A-FAE0-4570-A619-67D26F070FF5")
                },
                new
                {
                    Id = new Guid("101D496F-ACFD-42E8-912C-632593BA0D03"),
                    Value = "Team2",
                    DefinitionId = new Guid("54A85F54-E87E-4B98-A2FD-A57DD2AB4DF0"),
                    DriverId = new Guid("D6A9074D-5EB0-4FEF-A16E-A024F14EDFCA")
                },
                new
                {
                    Id = new Guid("FD669999-4245-48B0-9AB9-1BD7E13F7A02"),
                    Value = "Team3",
                    DefinitionId = new Guid("54A85F54-E87E-4B98-A2FD-A57DD2AB4DF0"),
                    DriverId = new Guid("6A4BC4BB-FA80-45FA-AACE-4865837E928A")
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
                    Id = new Guid("CD4F4040-D248-412F-86B2-38FFFC580398"),
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
                    Id = new Guid("B34104E1-EFD8-46EC-80F3-B732F8AA6D75"),
                    CategoryId = new Guid("CD4F4040-D248-412F-86B2-38FFFC580398"),
                    Description = "The tyre the driver prefers",
                    Value = "Soft"
                }
            );
            modelBuilder.Entity<AttributeDefinition>()
            .HasData(
                new
                {
                    Id=new Guid("54A85F54-E87E-4B98-A2FD-A57DD2AB4DF0"),
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