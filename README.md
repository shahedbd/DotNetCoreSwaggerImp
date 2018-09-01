# ASP.NET Core Swagger Implementations
Seamlessly adds a swagger to WebApi projects!

### Swagger API Documentation
https://swagger.io/solutions/api-documentation/

### Swashbuckle
https://github.com/domaindrivendev/Swashbuckle

### Swashbuckle Nuget
https://www.nuget.org/packages/Swashbuckle/

### Get started with Swashbuckle and ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.1&tabs=visual-studio%2Cvisual-studio-xml


## Application flow:
01. Install the standard Nuget package into your ASP.NET Core application.

Package Manager : Install-Package Swashbuckle.AspNetCore
CLI : dotnet add package Swashbuckle.AspNetCore

02. In the ConfigureServices method of Startup.cs, register the Swagger generator, defining one or more Swagger documents.

services.AddMvc();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
});

03. Ensure your API actions and non-route parameters are decorated with explicit "Http" and "From" bindings.

[HttpPost]
public void Create([FromBody]Product product)
...

[HttpGet]
public IEnumerable<Product> Search([FromQuery]string keywords)
...
NOTE: If you omit the explicit parameter bindings, the generator will describe them as "query" params by default.


04. In the Configure method, insert middleware to expose the generated Swagger as JSON endpoint(s)

app.UseSwagger();
At this point, you can spin up your application and view the generated Swagger JSON at "/swagger/v1/swagger.json."


05. Optionally insert the swagger-ui middleware if you want to expose interactive documentation, specifying the Swagger JSON endpoint(s) to power it from.

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
Now you can restart your application and check out the auto-generated, interactive docs at "/swagger

06. Browse to the Swagger UI at 
http://localhost:38845/swagger/index.html
or http://localhost:<random_port>/swagger 


## API Swagger  
![API Swagger](https://github.com/shahedbd/DotNetCoreSwaggerImp/blob/master/Sln.DotNetCoreSwaggerImp/API.DotNetCoreSwaggerImp/ProjectNotes/Resources/APISwagger.png)

## API Swagger Result
![API Swagger](https://github.com/shahedbd/DotNetCoreSwaggerImp/blob/master/Sln.DotNetCoreSwaggerImp/API.DotNetCoreSwaggerImp/ProjectNotes/Resources/APISwaggerResult.png)


## API Web View Result set 
![API Swagger](https://github.com/shahedbd/DotNetCoreSwaggerImp/blob/master/Sln.DotNetCoreSwaggerImp/API.DotNetCoreSwaggerImp/ProjectNotes/Resources/WebViewResult.png)







