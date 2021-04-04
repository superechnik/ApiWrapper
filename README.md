# ApiWrapper

A simple demonstration Api wrapper in .NET 5.

The project is comprised of a class library, an Api called Fake, and an Api called Wrapper.

## Running the app
To run the app and test you will need the (cross-platform) .NET 5 SDK from https://dotnet.microsoft.com/download.

Once you have the code and SDK, do the following:
`cd ApiWrapper/Fake; dotnet run`
`cd ApiWrapper/Wapper; dotnet run`

You should have a successful build:
![image](https://user-images.githubusercontent.com/10968503/113521652-d35a9b00-9568-11eb-9bf7-715c775a070d.png)

To use the app, Postman, Curl or whatever to the Wrapper endpoint at GET:https://localhost:5001/
Acceptable query string combinations are:
`address="some address"
zipcode="some zipcode"`
OR
`address="some address"
city="some city"
state="some state"`

### Example of GET:
![image](https://user-images.githubusercontent.com/10968503/113521715-54199700-9569-11eb-9395-193935c454d2.png)

To post multiple requests: POST:https://localhost:5001
The acceptable parameters are the same, as a JSON payload:
`[{
  "address": "some address",
  "zipcode": "some zipcode"
}]`

### Example of POST:
![image](https://user-images.githubusercontent.com/10968503/113521873-4e708100-956a-11eb-9c4b-b62491539d5d.png)

Any other combinations should return a 400

## Running the tests
For the integration tests, please keep the app running.

In new console tabs run:
`(cd Fake.Tests; dotnet test)`
`(cd Wrapper.Tests; dotnet test)`

### Test output
![image](https://user-images.githubusercontent.com/10968503/113521989-3cdba900-956b-11eb-93a0-f06da3f97cfe.png)

![image](https://user-images.githubusercontent.com/10968503/113521994-4e24b580-956b-11eb-88b8-1d259eee788e.png)



