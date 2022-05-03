# CowBackEndApi by Guangya Zhu

This is a exercise for Halter recruitment process.

## Usage
You would notice that the redis postgresql server is hosted in the docker container.\
Run
```bash
docker-compose up --build
```
beside the docker-compose.yml file to set up the database envrionment and run this before you use the app.\

Set the environment variable of your computer "ASPNETCORE_ENVIRONMENT" to "Production" to hide the debugging messages.\
Make sure Microsoft.NETCore.App 5.0.15 is installed on the machine to run the app.
```bash
Double clicking the "./HalterExercise/HalterExercise.exe" will start the backend.
I guess you will not be using a real front end for testing so I didn't enable CORS.
The localhost port used was 5001
```

