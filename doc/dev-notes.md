# Notes

- AzureB2C doesn't seem to be supported by terraform/pulumi at the moment. It looks as though you can create things with them, but they don't work properly and you waste a ton of time trying to make them work. Instead, I have just created things by hand, and will get them documented when I get around to it...

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
- Tyre
    - Id
    - Name
    - Description
