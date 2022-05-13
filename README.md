 <img align="left" width="116" height="116" src="https://raw.githubusercontent.com/jasontaylordev/CleanArchitecture/main/.github/icon.png" />
 
 # Pokemon backend API project with Clean Architecture structure
<br/>
The project objective is to develop a REST API that, given a Pokemon name, returns its Shakespearean description.

## Technologies

* ASP.NET Core 5
* Redis
* FluentValidation
* NUnit, FluentAssertions, Moq
* Docker
* Swagger

## Getting Started
1. Install the latest [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
2. Clone the repository
3. Execute from the root folder `docker-compose build`
4. Start everything up by executing `docker-compose up`
5. Call the pokemon Http Get endpoint to localhost/api/pokemon/<pokemon name>
6. Finish by cleaning up by executing `docker-compose down`



## Application Project layers
The code base is splited into different project layers and folder structure , this is to help maintain the seperation of concern and to achieve Clean Architecture structure .
### Common
This project layer contains all class for cross cutting concern like custom exception class, extension methods , options etc. 
### Model
This project layer contains  all Dto (data transfer objects).
### API or the Presentation 
This layer contains all REST API (Application protocol interface) which can be called by any client (Mobile or web) over http. this project layer only know 
about other project via reference  and dependency injection.
### ServiceProvider
This project layer contains classes for accessing external resources such as web services so on. These classes should be based on interfaces defined within the application layer.
Below are two web service accessed via this project layer 
1. Shakespeare translator: https://funtranslations.com/api/shakespeare
2. PokéAPI: https://pokeapi.co/
### CachingService
This project layer contains classes for accessing a distributed caching provider like Redis.
### Application
This layer contains all application business logic. This layer defines interfaces that are implemented by outside layers. 

