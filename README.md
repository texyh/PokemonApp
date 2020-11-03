## Technical Details

### Architecture 

I've used `Clean Architecture` for this project. There are four projects: 
`PokemonApp.Api` - This handles the request and response.

`PokemonApp.Application` - This handles all application logic and all related classes reside. 

`PokemonApp.Domain` - This handles all domain objects and domain logic. 

`PokemonApp.Infrastructure` - This handle infrastructure related code, eg. Database, Integration to external serevices. 

There are also two projects for tests.  
`PokemonApp.IntegrationTests` - This contains the Acceptance tests for the solution.

`PokemonApp.UnitTests` - This contains all the unit test for the solution.

In the `CI\CD` folder,  there is an Azure pipeline file for Continous integration using azure devops.

### Libraries 
You can find what libraries I've used the following;

- XUnit
- FluentAssertion
- Xbehave
- Serilog
- Swagger
- Fluent Validation

 ## Build & Run
 There are two ways you can run the application
 1) if you have `dotnet core` installed, to run the project, navigate to `src/PokemonApp.Api` folder and run `dotnet run`.
 2) You can run the application using docker as follows: 

    a) In the root folder, paste and excute this command `docker build -t pokemon -f docker/Dockerfile .`

    b) Then, `docker run -p 5000:5000 pokemon`

Using Either ways above, the app should be runnnig on port `5000`. Navigate to http://localhost:5000/swagger/index.html to test the api.
