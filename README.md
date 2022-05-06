# CowBackEndApi by Guangya Zhu

This is a backend api exercise using .net core 3.1, postgres, redis and docker.
The backend api will listen to localhost:8000 by default.

This project is about making a back end to integrate with a external smart collar api to monitor the status of cows.
It contains three endpoints, GET, POST and PUT

# Expected Responses
GET /cows\
returns:\
[\
{\
"id": "fe0a1ec1-e7d4-4b2d-a555-ae23926ee9d0",\
"collarId": "261",\
"cowNumber": "88261",\
"collarStatus": "Healthy",\
"lastLocation": {\
"lat": 123,\
"long": 456\
}\
},\
{\
"id": "fe0a1ec1-e7d4-4b2d-a555-ae23926ee9d0",\
"collarId": "222",\
"cowNumber": "88222",\
"collarStatus": "Broken",\
"lastLocation": {\
"lat": 123,\
"long": 456\
}\
}\
]\
POST /cows\
body:\
{\
"collarId": "261",\
"cowNumber": "88261",\
}\
returns:\
{\
"id": "fe0a1ec1-e7d4-4b2d-a555-ae23926ee9d0",\
"collarId": "261",\
"cowNumber": "88261",\
"collarStatus": "Healthy" (or "Broken"),\
"lastLocation": {\
"lat": 123,\
"long": 456\
}\
}\
PUT /cows/:id\
body:\
{\
"collarId": "261",\
"cowNumber": "88261",\
}\
returns:\
{\
"id": "fe0a1ec1-e7d4-4b2d-a555-ae23926ee9d0",\
"collarId": "261",\
"cowNumber": "88261",\
"collarStatus": "Broken" (or Healthy),\
"lastLocation": {\
"lat": 123,\
"long": 456\
}\
}\

## Usage
Run the following command in the root directory
```bash
docker-compose up --build
```

