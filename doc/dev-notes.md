# Notes

- AzureB2C doesn't seem to be supported by terraform/pulumi at the moment. It looks as though you can create things with them, but they don't work properly and you waste a ton of time trying to make them work. Instead, I have just created things by hand, and will get them documented when I get around to it...

## Hosting environment

- IDP is Azure AD B2C instance (free for 50k users!)
- App Host is fly.io (It's great if you just want a one off thing with light traffic)
- DNS is Cloudflare

## DB Design

### Tables

- Driver
    - Id
    - UserId
    - DriverName
- Race
    - Id
    - Location
    - Description
    - LapDistance
    - Laps
    - StartTime
- RaceDriver
    - Id
    - RaceId
    - DriverId
- Lap
    - Id
    - RaceDriverId
    - TyreId
    - RaceLapNumber
    - LapTime
- TagCategory
    - Id
    - Name
    - Description
    - DriverValid
    - RaceValid
    - RaceDriverValid
    - LapValid
- Tag
    - Id
    - TagCategoryId
    - Value
- DriverTag
    - Id
    - DriverId
    - TagId
- RaceTag
    - Id
    - RaceId
    - TagId
- RaceDriverTag
    - Id
    - RaceDriverId
    - TagId
- LapTag
    - Id
    - LapId
    - TagId
- AttributeDefinition
    - Id
    - Name
    - Description
    - Type
    - Required
    - DriverValid
    - RaceValid
    - RaceDriverValid
    - LapValid
- DriverAttribute
    - Id
    - AttributeClassId
    - DriverId
    - Value
- RaceAttribute
    - Id
    - AttributeClassId
    - RaceId
    - Value
- RaceDriverAttribute
    - Id
    - AttributeClassId
    - RaceDriverId
    - Value
- LapAttribute
    - Id
    - AttributeClassId
    - LapId
    - Value


