# MDT -Domain Driven Design- Application

Domain Driven Design Net is a RESTful API service developed in .Net Core 2.2

## Tools for compiling

Linux:

* [.NET Core Runtime](https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/runtime-current) - V. 2.2


## Steps for build


```linux

dotnet clean
dotnet restore
dotnet build

```

## Steps for run

From command line, within root folder you can execute next command:

```
dotnet run --project src/Applications/MDT.AppServices/MDT.AppServices.csproj 
```

If the the project is running ok, then you would see the following logs in command line:

```
mongodb://127.0.0.1:27017|mdt
Hosting environment: Production
Content root path: /home/tuxito/DevJ/NetCore/DomanDrivenDesignNet/src/Application/MDT.AppService
Now listening on: http://localhost:5000
Now listening on: https://localhost:5001
Application started. Press Ctrl+C to shut down.
```

And to end, you can open a brownser and navigate to following address:


```
http://localhost:5000
```


## Steps for test

```
dotnet test
```


## Built-in

* [.NET Core](https://dotnet.microsoft.com/download) - V. 2.2
