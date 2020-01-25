# PokéDokie

A quickie project in C# to fetch pokemon type comparisons

## Getting Started

> NOTE: This project targets **.NET Core 3.1**. I didn't make use of many new features, but other versions of .NET have not been tested

1. Open the project into Visual Studio
1. Restore the NuGet packages
1. Use the Debug runner to run the application in the Console

## Using the app

The command line will prompt you for a name of a pokemon. At the time of writing, there is no mechanism for suggesting pokemon names based on slight misspellings.

If you misspell the Pokemon name or enter an unknown string, you will receive a message in the console saying the Pokemon cannot be found.

## Running Tests

Navigate to the `PokeDokieTests` project and use the Test runner to run the Unit Tests
