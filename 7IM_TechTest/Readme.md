# 7IM Technical Test
## Api Endpoint

Single /search POST endpoint.
Accepts a searchTerm in the body.

This is a simple minimal api example, that injects a repository directly into the endpoint handler.
The repository itself simply uses System.Text.Json to read in the provided json file and caches the data locally.

Running the project directly in VS will open the swagger page for easy testing.
Use the '..\start_backend.bat' file to run standalone.