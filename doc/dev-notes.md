# Notes

- AzureB2C doesn't seem to be supported by terraform/pulumi at the moment. It looks as though you can create things with them, but they don't work properly and you waste a ton of time trying to make them work. Instead, I have just created things by hand, and will get them documented when I get around to it...

- It looks like (most of) the stuff I need is supported, it is just unclearly documented. I will have a prod when I am able to (setting up a service principle for pulumi will make life so much easier as well!)

## Hosting environment

- IDP is Azure AD B2C instance (free for 50k users!)
- App Host is fly.io (It's great if you just want a one off thing with light traffic)
- DNS is Cloudflare

## Task List

- DONE: Add Monitoring withn Prometheus
- DONE: Add a Healthcheck endpoint
- DONE: Assign some persistant storage for the DB
- DONE(ish): Complete the Driver API endpoint **(don't forget to reenable authentication)**
- TODO: Complete the Race API endpoint
- TODO: Complete the Lap API endpoint
- TODO: Complete the Attributes endpoint
- TODO: Complete the tags endpoint
- TODO: Error Handling
- TODO: Logging

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


