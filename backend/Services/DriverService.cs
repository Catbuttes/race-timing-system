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

        public async Task<IEnumerable<Models.Driver>> GetAllMine(Guid userId)
        {
            var drivers = await _db.Drivers
                .Where(d => d.User == userId)
                .Select(
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
                        DefinitionId = a.DefinitionId,
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
                        TagId = t.TagId,
                        Category = t.Tag.Category.Name,
                        Value = t.Tag.Value
                    }
                )
                .ToListAsync();
            }

            return drivers;
        }

        public async Task<IEnumerable<Models.Driver>> GetAll()
        {
            var drivers = await _db.Drivers
                .Select(
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
                        DefinitionId = a.DefinitionId,
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
                        TagId = t.TagId,
                        Category = t.Tag.Category.Name,
                        Value = t.Tag.Value
                    }
                )
                .ToListAsync();
            }

            return drivers;
        }

        public async Task<Models.Driver?> Get(Guid userId, Guid driverId)
        {
            var driver = await _db.Drivers
            .Where(d => d.Id == driverId && d.User == userId)
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
                        DefinitionId = a.DefinitionId,
                        Name = a.Definition.Name,
                        Value = a.Value
                    }
                )
                .ToListAsync();

                driver.Tags = await GetTags(userId, driver.Id);
            }

            return driver;
        }

        public async Task<IEnumerable<Models.Tag>?> GetTags(Guid userId, Guid? driverId)
        {
            var tags = await _db.DriverTags
                .Where(a => a.DriverId == driverId && a.Driver.User == userId)
                .Select(
                    t => new Models.Tag
                    {
                        DriverTagId = t.Id,
                        TagId = t.TagId,
                        Category = t.Tag.Category.Name,
                        Value = t.Tag.Value
                    }
                )
                .ToListAsync();

            return tags;
        }

        public async Task<IEnumerable<Models.Tag>?> ApplyTag(Guid userId, Guid driverId, Guid tagId)
        {
            var tag = await _db.DriverTags
                .Where(a => a.DriverId == driverId && a.TagId == tagId && a.Driver.User == userId)
                .SingleOrDefaultAsync();

            if(tag == null)
            {
                var newTag = new Database.Models.DriverTag
                {
                    DriverId = driverId,
                    TagId = tagId,
                    Id = Guid.NewGuid()
                };

                await _db.DriverTags.AddAsync(newTag);
                await _db.SaveChangesAsync();
            }

            return await GetTags(userId, driverId);
        }

        public async Task<Models.Attribute?> ApplyAttribute(Guid userId, Guid driverId, Models.Attribute attribute)
        {
            var dbAttribute = await _db.DriverAttributes
                .Where(a => a.DefinitionId == attribute.DefinitionId && a.DriverId == driverId && a.Driver.User == userId)
                .SingleOrDefaultAsync();

            if(dbAttribute == null)
            {
                var newAttribute = new Database.Models.DriverAttribute
                {
                    DriverId = driverId,
                    DefinitionId = attribute.DefinitionId,
                    Value = attribute.Value
                };

                await _db.DriverAttributes.AddAsync(newAttribute);
                await _db.SaveChangesAsync();
            }
            else
            {
                dbAttribute.Value = attribute.Value;
                await _db.SaveChangesAsync();
            }

            return await _db.DriverAttributes
                .Where(a => a.DefinitionId == attribute.DefinitionId && a.DriverId == driverId && a.Driver.User == userId)
                .Select(
                    a => new Models.Attribute
                    {
                        DriverAttributeId = a.Id,
                        DefinitionId = a.DefinitionId,
                        Name = a.Definition.Name,
                        Value = a.Value
                    }
                )
                .SingleOrDefaultAsync();

        }
        public async Task<IEnumerable<Models.Tag>?> RemoveTag(Guid userId, Guid driverId, Guid tagId)
        {
            var tag = await _db.DriverTags
                .Where(a => a.DriverId == driverId && a.TagId == tagId && a.Driver.User == userId)
                .SingleOrDefaultAsync();

            if (tag != null)
            {
                 _db.DriverTags.Remove(tag);
                await _db.SaveChangesAsync();
            }

            return await GetTags(userId, driverId);
        }

        public async Task<Models.Driver?> Create(Guid userId, Models.Driver driver)
        {
            var newDriver = new Database.Models.Driver
            {
                Id = userId,
                User = driver.User,
                Name = driver.Name ?? System.String.Empty
            };

            await _db.Drivers.AddAsync(newDriver);
            await _db.SaveChangesAsync();

            if (driver.Attributes != null && driver.Attributes.Count() > 0)
            {
                foreach (var attribute in driver.Attributes)
                {
                    await ApplyAttribute(userId, newDriver.Id, attribute);
                }
            }

            if(driver.Tags != null && driver.Tags.Count() > 0)
            {
                foreach (var tag in driver.Tags)
                {
                    await ApplyTag(userId, newDriver.Id, tag.TagId);
                }
            }

            return await Get(userId, newDriver.Id);
        }

        public async Task<Models.Driver?> Update(Guid userId, Models.Driver driver)
        {
            if (driver.Id == null) return null;

            var dbDriver = await _db.Drivers
                .Where(d => d.Id == driver.Id && d.User == userId)
                .SingleOrDefaultAsync();

            if (dbDriver == null) return null;

            dbDriver.Name = driver.Name;

            await _db.SaveChangesAsync();

            if (driver.Attributes != null && driver.Attributes.Count() > 0)
            {
                foreach (var attribute in driver.Attributes)
                {
                    await ApplyAttribute(userId, dbDriver.Id, attribute);
                }
            }

            if (driver.Tags != null && driver.Tags.Count() > 0)
            {
                foreach (var tag in driver.Tags)
                {
                    await ApplyTag(userId, dbDriver.Id, tag.TagId);
                }
            }

            return await Get(userId, dbDriver.Id);
        }

        public async Task<Boolean> Delete(Guid userId, Guid driverId)
        {
            var driver = await _db.Drivers
                .Where(d => d.Id == driverId && d.User == userId)
                .SingleOrDefaultAsync();

            if (driver == null) return false;

            if(driver.Attributes != null && driver.Attributes.Count > 0)
            {
                foreach (var attribute in driver.Attributes)
                {
                    _db.Remove(attribute);
                }
            }

            if (driver.Tags != null && driver.Tags.Count > 0)
            {
                foreach (var tag in driver.Tags)
                {
                    _db.Remove(tag);
                }
            }

            _db.Remove(driver);
            await _db.SaveChangesAsync();

            return true;

        }
    }
    
}