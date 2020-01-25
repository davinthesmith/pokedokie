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

If you provide a known pokemon, the system will tell you the pokemon's type and how this type relates to the other pokemon types.

### Sample output using Pikachu

```
Pikachu, I choose you!

Pikachu's type is: electric
Does not do damage to ground
Does half damage to grass
Does half damage to electric
Does half damage to dragon
Does double damage to flying
Does double damage to water
Takes half damage from flying
Takes half damage from steel
Takes half damage from electric
Takes double damage from ground
```

## Running Tests

Navigate to the `PokeDokieTests` project and use the Test runner to run the Unit Tests
