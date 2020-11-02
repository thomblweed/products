# Products API

## Run and Test API

To run the API locally please follow these steps;

- In the terminal at the 'products' folder location, cd into API project folder.
- Run command 'dotnet build' and then run command 'dotnet run'

Running the Postman tests while the api is running locally;

- Open Postman and import the 'tests.postman' file
- Run the 'backend test API' via the UI and all tests should pass

To run the API in docker, I prefer to use docker-compose so having docker-compose installed would obviously be a prerequisite for the below commands.

- Start > In the terminal at the 'products' folder location, run `docker-compose up --build -d`
- Stop > In the terminal at the 'products' folder location, run `docker-compose down --rmi local`
- There are a couple of bash scripts `start.sh` and `stop.sh` that do the same thing and can be run instead if you have bash installed :)

## Approach Notes and Decisions

Having not used .Net Core before, I spent a couple of days learning this tech and how to create an API using .Net Core. My approach to this task is based on these learnings and so you will see commit message times spanning prior to and during the weekend. The code has been written mostly for the purpose of passing the postman tests.

The decision on the database was to use SQLite, based on learnings and to simplify this as running in a single development environment. If I were to do this again, I would probably use MongoDb (I have used this with nodejs at home previously) and would run the database in a docker container.

I created a DTO for the Product responses as noticed the front end (tests) expected a string for price but I would prefer to store as decimal for the database.

The docker container for this solution is running in 'dotnet run' development mode on purpose for simplicity. I did spend some time looking into dockerising a .Net Core api for production use but did not implement for this task.

This solution was developed using the WSL 2 Linux layer (Ubuntu) on Windows 10.

## Observations and Learnings

The postman tests can only be run 1 time to get a successful pass on all tests. This is due to the auto increment of the product id in the SQLite database. A retry or second run of the postman tests means the POST endpoint will create a new product with an id of 5 instead of 4 causing fails on a few of the tests. The fix for this is to restart the api and re run the tests.

I have also run into a couple of occasions where I had to re import the postman tests file to resolve when the tests stopped passing. They do pass if I click each test in order one by one so assuming it could be due to an async issue. I haven't used postman to run tests before so can't be sure.

The test suite provided seems to have the 'initial_state' and 'products' sections running in the wrong order but as they run the same thing it seems to be ok.

Normally I would return a 201 instead of a 200 on a successful POST but I left it as 200 so that the tests pass ok.

I didn't look into any data validation to keep this simple so you will notice a couple of if statements in the controllers to manage handling scenarios outside of running the tests. For example, I wouldn't normally handle the PUT controller in this way and have left notes in the code to explain. This api will not update (PUT) the price for a product if `0` is provided.

I have seen Swagger used in previous roles but have not configured it for use before, so I kept the setup very simple for now. I understand there are missing areas for the Schemas etc but it can be used to interact with the api. I would normally spend more time tidying this up.
