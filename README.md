# SMC
Student manager console app

## Structure
The solution has the following folder structure:

* **01-Common**  Contains all models and interfaces on a .Net standard library so this can be consumed from any platform (Xamarin, .NetFramework, .NetCore)
* **02-DataAccess** Contains the specific implementations for the IDataAccess interface. Right now it only supports CSV files but it is opened to new implementations for differnt store types as RDB/NoSQL.
* **03-Apps** Contains the specific platform applications like Web Applications, Mobile. Right now only console application was implemented using .net core.

* **UnitTests** last but not least, this contains the Unit tests to verify the DML operations over the Data access is working as expected.

## Usage
The console application can be executed either using visual studio or publishing the binaries as an executable.

First it is necessary to have installed .NetCore 2.1 on your machine
* The version of .net core can be verified running the following command in a terminal
```sh
> dotnet --info 
# you may see something like the following result:
.NET Core SDKs installed:
  2.0.2 [C:\Program Files\dotnet\sdk]
  2.0.3 [C:\Program Files\dotnet\sdk]
  2.1.2 [C:\Program Files\dotnet\sdk]
  2.1.4 [C:\Program Files\dotnet\sdk]
  2.1.503 [C:\Program Files\dotnet\sdk]
```
* If .Net Core 2.1 is not installed you can found the  SDK on this [Link](https://dotnet.microsoft.com/download/dotnet-core/2.1)

### Running the console app
Application arguments can be specified inside visual studio or also an executable can be created runing the following command inside the following folder: SM\SM.ConsoleApp
```sh
SM\SM.ConsoleApp> dotnet publish -c Debug -r win10-x64
```
That will create a new folder named "publish" inside the bin\Debug\netcoreapp2.1\win10-x64 folder, there is the executable.

The executable can run with or without arguments. 
```sh
> SM.ConsoleApp.exe input.csv name=leia
> SM.ConsoleApp.exe input.csv type=kinder
``` 
A sample csv with 500 records can be found on
SMC/SM/SM.ConsoleApp/

