# Cat Fact App

A small .NET console application that fetches a random cat fact from an external API and saves it locally.

## Features

- Fetches a cat fact from `https://catfact.ninja/fact`
- Deserializes the JSON response into a C# model
- Appends the fact and its length to a local text file
- Uses dependency injection and `IHttpClientFactory`
- Handles common HTTP, JSON, and file errors

## Technologies

- C#
- .NET 10
- `HttpClient` and `IHttpClientFactory`
- `System.Text.Json`
- `Microsoft.Extensions.DependencyInjection`
- `Microsoft.Extensions.Http`

## How to run

Install the .NET 10 SDK, then run:

```bash
git clone https://github.com/anzeval/Cat-Fact-App.git
cd Cat-Fact-App
dotnet restore
dotnet run
```

## Output

Each run sends one API request. When it succeeds, the application displays the received data:

```text
Fact: Cats have five toes on their front paws.
Length: 40
Saved to catfacts.txt
```

The application creates `catfacts.txt` in its working directory if the file does not exist. Every successful request appends a new line without removing previous entries:

```text
Fact: Cats have five toes on their front paws. | Length: 40
```
