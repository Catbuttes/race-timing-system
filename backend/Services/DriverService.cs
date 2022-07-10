namespace backend.Services
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    using backend.Database;

    public class DriverService
    {
        private RTSContext _db;

        public DriverService(RTSContext database)
        {
            _db = database;
        }

        public async Task<IEnumerable<Models.Driver>> GetDrivers()
        {
            var drivers = await _db.Drivers.Select(
                d => new Models.Driver
                {
                    Id = d.Id,
                    Name = d.Name,
                    User = d.User,
                }
            )
            .ToListAsync();

            foreach (var driver in drivers)
            {
                driver.Attributes = await _db.DriverAttributes
                .Where(a => a.DriverId == driver.Id)
                .Select(
                    a => new Models.Attribute
                    {
                        DriverAttributeId = a.Id,
                        Name = a.Definition.Name,
                        Value = a.Value
                    }
                )
                .ToListAsync();

                driver.Tags = await _db.DriverTags
                .Where(a => a.DriverId == driver.Id)
                .Select(
                    t => new Models.Tag
                    {
                        DriverTagId = t.Id,
                        Category = t.Tag.Category.Name,
                        Value = t.Tag.Value
                    }
                )
                .ToListAsync();
            }

            return drivers;
        }

        public async Task<Models.Driver?> GetDriver(long driverId)
        {
            var driver = await _db.Drivers
            .Where(d => d.Id == driverId)
            .Select(
                d => new Models.Driver
                {
                    Id = d.Id,
                    Name = d.Name,
                    User = d.User,
                }
            )
            .FirstOrDefaultAsync();

            if (driver != null)
            {
                driver.Attributes = await _db.DriverAttributes
                .Where(a => a.DriverId == driver.Id)
                .Select(
                    a => new Models.Attribute
                    {
                        DriverAttributeId = a.Id,
                        Name = a.Definition.Name,
                        Value = a.Value
                    }
                )
                .ToListAsync();

                driver.Tags = await _db.DriverTags
                .Where(a => a.DriverId == driver.Id)
                .Select(
                    t => new Models.Tag
                    {
                        DriverTagId = t.Id,
                        Category = t.Tag.Category.Name,
                        Value = t.Tag.Value
                    }
                )
                .ToListAsync();
            }

            return driver;
        }


    }
    
}