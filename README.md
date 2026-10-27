# Campus Cuisine Blazor

Campus Cuisine Blazor ist ein Beispielprojekt, das zeigt, wie man mit Blazor WebAssembly ein Frontend in C# erstellt. Die App ist das Frontend zu Campus Cuisine, einer Plattform, auf der Studenten Rezepte austauschen.

Das Projekt wird Schritt für Schritt aufgebaut, jeder Schritt hat seinen eigenen Branch (`step/NN-*`). `main` enthält den letzten Stand.

## Starten

Voraussetzung ist das [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).

```bash
dotnet run --project CampusCuisine.Client
```

Die App läuft dann unter http://localhost:5100.

## Step 0: Setup

Die App wurde mit dem Template `blazorwasm` erstellt und aufgeräumt: Die Beispielseiten (Counter, Weather) und das Menü sind entfernt, übrig bleiben ein einfaches Layout und eine Seite für nicht gefundene Adressen. Die App hat noch keine eigene Seite, jede Adresse zeigt deshalb "Not found".
