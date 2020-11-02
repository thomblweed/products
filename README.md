# Products API

## Run and Test API

To run the API locally please follow these steps;

- In the terminal at the 'products' folder location, cd into API project folder.
- Run command 'dotnet build' and then run command 'dotnet run'

Running the Postman tests while the api is running locally;

- Open Postman and import the 'tests.postman' file
- Run the 'backend test API' via the ui and all tests should pass

To run the API in docker, I prefer to use docker-compose so having docker-compose installed would obviously be a prerequisite for the below commands.

- Start > In the terminal at the 'products' folder location, run `docker-compose up --build -d`
- Stop > In the terminal at the 'products' folder location, run `docker-compose down --rmi local`
- There are a couple of bash scripts `start.sh` and `stop.sh` that do the same thing and can be run instead if you have bash installed :)

## Approach Notes and Decisions

Having not used .Net Core before, I spent a couple of days learning this tech and how to create an API etc. My approach to this task is based on these learnings and so you will see commit message times spanning prior to and during the weekend. The code has been written mostly for the purpose of passing the postman tests.

The decision on the database was to use SQLite, based on learnings and to simplify this as running in a single development environment. If I were to do this again, I would probably use MongoDb (I have used this with nodejs at home previously) and would run the database in a docker container.

The docker container for this solution is running in 'dotnet run' development mode on purpose for simplicity. I did spend some time looking into dockerising a .Net Core api for production use but did not implement for this task.

This solution was developed using the WSL 2 Linux layer (Ubuntu) on Windows 10.

## Learnings and Observations
