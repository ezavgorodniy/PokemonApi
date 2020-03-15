# PokemonApi
Fetch information about pokemon and translate it to Shakespearean 

# How to run the project
### Using DotNetCore CLI (https://dotnet.microsoft.com/download/dotnet-core/3.1): 

1) cd into the "src" folder
2) run command "dotnet run --project Pokemon.Api"

Example of command is 
D:\Personal\PokemonApi\src>dotnet run --project Pokemon.Api

### Using Docker

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
