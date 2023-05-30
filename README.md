# MDT -Domain Driven Design- Application

- Domain Driven Design Net is a RESTful API service developed in .Net Core 6 LTS
- Design using hexagonal architecture

## Tools for compiling

Download Linux/Windows SDK from:

* [.NET Core Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) - V. 6.0.16


## Steps for build


```linux

dotnet clean
dotnet restore
dotnet build

```

## Steps for run

From command line, within root folder you can execute next command:

```
dotnet run --project src/Application/MDT.AppService/MDT.AppService.csproj 
```

If the project is running ok, then you would see the following log in command line:

```

Application started. Press Ctrl+C to shut down.
```

Finally, you can open a brownser and navigate to following address to review Swagger API definitions:


```
https://localhost:54212/swagger/index.html
```


## Steps for test

```
dotnet test
```


## Built-in

* [.NET Core](https://dotnet.microsoft.com/download)
