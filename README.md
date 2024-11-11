API and DB for management console.

## Pre-requisites
Microsoft .NET 8

## About the project
This project uses .NET 8 with Entity Framework.

The database uses SQLite, which would not be suitable for production but suffices for this demo.

The project consists of a single table database which stores randomly generated database events which are created on a timer and added periodically.

DbEventsController.cs provides an API endpoint to retrieve all events.

SignalR is used to provide a listener for the client UI to avoid polling the database repeatedly.

To run locally, use `dotnet watch`.