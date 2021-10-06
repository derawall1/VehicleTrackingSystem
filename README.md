# Vehicle Tracking System API
Name: Muhammad Mushtaq

#### Visual studio

Please make sure you've already installed Visual Studio 2019 and .Net 5 SDK  on your Windows 10 platform.

[Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)  
[.Net 5](https://dotnet.microsoft.com/download/dotnet/5.0)  

## Database:
For the sack of test and run project easily I have used SQLite database with EntityframeWork Core for testing and developement purpose we can use this db, and for production purpose we can change it to SQL Server or other RDBMS easily.

To view the database tables etc you can use VS Code : https://code.visualstudio.com/download and its extension for SQLite : https://marketplace.visualstudio.com/items?itemName=alexcvzz.vscode-sqlite

Open **VehicleTrackingSystem.sln** from `/VehicleTrackingSystem/` folder.


Run `VehicleTrackingSystem.Api` project.
swagger documentation is implemented. You can see api documentation below url

```
Api documentation: https://localhost:5001/swagger/index.html
```

## How it works

1. Register a user with first name, last name, email, password etc . Or login with following user
```
{
  "email": "derawall@gmail.com",
  "password": "Abc!@345"
}
```
2. User can login with email, password. 
3. A registered user can add multiple vehicle with Name, DeviceId, ExtendedData. DeviceId is unique id which you get from the GPS device. And ExtendData is json string to input and a Dictionary Object in backend
4. GPS device send vehicle location with deviceId, latitude, longitude for the authentic user.
5. Authentic user can see their vehicle current location by vehicleId. Api will return longitude , latitude and address name if the API key is present and correct. Google map api will return current address name based on the position.
6. User can also see the vehicle journey by vehicleId, start and end datetime.

**Demo Login Credentials:**

URL: `https://localhost:5001/api/v1/Account/Login`

```
{
  "email": "derawall@gmail.com",
  "password": "Abc!@345"
}
```

## Extensibility

If the customer wants to add more properties then he/she Can add the json into ExtendedData field.
e.g:
```
"name": "XYZ"
"deviceId": "device023",
"ExtendedData": {
  "speed": "120 KM",
  "fuel": "Desiel 500 Ltr",
  "color": "gold",
  "driverName": "adam jhon",
  "registraionNumber": "LXB-123",
  "ownerName": "Mark Smith"
}


## Bonus

google map geocode  is implemented which will send address based on latitude and longitude. You can find in the `GoogleApiService` in VehicleTrackingSystem.Application project under Services folder .
You need to provide your API KEY for google map cloud platform 