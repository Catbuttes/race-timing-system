namespace backend.Services
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    using backend.Database;
    using backend.Models;

    public class DatabaseService
    {
        private RTSContext _db;

        public DatabaseService(RTSContext database)
        {
            _db = database;
        }

        public void Migrate()
        {
            _db.Database.Migrate();
        }

        public async Task<IEnumerable<Models.Driver>> GetDrivers()
        {
            var drivers = await _db.Drivers.Select(
                d => new Models.Driver
                {
                    Id = d.Id,
                    Name = d.Name,
                    User = d.User
                }
            )
            .ToListAsync();

            return drivers;
        }


    }
    
}