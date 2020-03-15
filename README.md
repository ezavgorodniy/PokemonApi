# PokemonApi
Fetch information about pokemon and translate it to Shakespearean 

# How to run the project
### Using DotNetCore CLI (https://dotnet.microsoft.com/download/dotnet-core/3.1): 

1) cd into the "src" folder
2) run command "dotnet run --project Pokemon.Api"

Example of command is 
D:\Personal\PokemonApi\src>dotnet run --project Pokemon.Api

### Using Docker

You'll need to have Docker Desktop (https://www.docker.com/products/docker-desktop) installed. 

1) cd into the "src" folder
2) run command "docker build . -t pokemon-api"
3) run command "docker run -p 5000:80 pokemon-api"

Examples of commands are 

1) D:\Personal\PokemonApi\src>docker build . -t pokemon-api
2) D:\Personal\PokemonApi\src>docker run -p 5000:80 pokemon-api


### Using VisualStudio 2019: 

1) Open "src/Pokemon.Api.sln"
2) Set Pokemon.Api as startup project
3) Select one of way to run the project (Docker, IIS Express or as API)
4) Click on run 


# How to run the tests

### Unit tests

To run unit tests you may use a PowerShell and 

1) cd to src
2) Run "dotnet test --filter "Category!=Functional""

Example of command is: 

PS D:\Personal\PokemonApi\src> dotnet test --filter "Category!=Functional"

### Functional tests 

Functional/e2e/integration (depends on wording used in your company) tests of API is a test which you're running to ensure that all pieces are together. Usually this kind of tests you're running on your local or team environment and make it as part of pull request build to avoid master having corrupted code. 

To run this kind of test you need to run your API somewhere and then use PS script and pass Pokemon Api URL as parameter: 

1) cd to src 
2) run ".\runFunctionalTests.cmd <YourApiUrl>"

Example of command is: 

PS D:\Personal\PokemonApi\src> .\runFunctionalTests.cmd http://localhost:5000