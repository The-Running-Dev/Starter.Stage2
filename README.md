## Stage 2 - DB / Web API / Swagger

### Learning
- VS Db Solutions: https://msdn.microsoft.com/en-us/library/hh272677(v=vs.103).aspx
- Web Api: https://app.pluralsight.com/library/courses/implementing-restful-aspdotnet-web-api/table-of-contents
- Web Api: https://www.asp.net/web-api
- Swagger/Swashbuckle: http://swagger.io/  https://github.com/domaindrivendev/Swashbuckle
- Swagger: https://app.pluralsight.com/library/courses/play-by-play-api-functionality-swagger/table-of-contents

### Tasks
- Database: For replacing the file, build a custom database with a single custom table in our development database called astradevdb (MS SQL). Use stored procedures when accessing data.
Add a SQL Server Database project to your Visual Studio solution that contains all the information about the database and is able to create it when built. The project should use Windows Authentication when building the database.
- Data Layer: Use ADO.NET for accessing the database. (SqlConnection, Sql Data Reader etc). Make sure you use stored procedures for accessing the data.
- Service: Build a RESTful WEB API that provides a layer between the database and the UI. Use Swagger for accessing the service functions. Use JSON structure when exchanging data. The service should be able to make the following calls: Get, Get by ID, Post, Put.
- Install the swashbuckle nuget package to get swagger working to invoke the service.
- UI: The UI should have a Master-Detail view. Ie, when an item is selected in the grid, a small side window that shows the detailed information of the selected item should be populated. The detailed information should not be cached, but pulled from the database through the service every time an item is selected. This should be done like a “Get by ID” service call.
= Use an HTTPClient to access the WebApi service. Build a Factory Pattern around the HTTP Client.