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

## Step 1: Pages & Komponenten

Die App bekommt ihre erste Seite: `Recipes` unter `/` und `/recipes`. Sie zeigt zwei `RecipeCard` Komponenten, jede mit eigenem, isoliertem CSS. Die Daten stehen noch fest in der Komponente, deshalb zeigen beide Karten dasselbe Rezept.

## Step 2: Komponenten Features

Die Rezepte kommen jetzt aus einer Liste (`Data/SampleRecipes.cs`) und werden mit `@foreach` angezeigt. Jede `RecipeCard` bekommt ihr Rezept als Parameter, `@if` zeigt einen Hinweis, wenn es keine Rezepte gibt. Neu ist die Detailseite unter `/recipes/{id}` mit Routenparameter. Das Logo im Header liegt als statische Datei in `wwwroot/images`.

## Step 3: Data Binding & Events

Die Rezeptliste hat jetzt ein Suchfeld: Mit `@bind` und `@bind:event="oninput"` filtert die Liste schon beim Tippen nach Name oder Zutat, der Button "Clear" leert das Feld über `@onclick`. Auf der Detailseite kann man ein Rezept mit der neuen Komponente `StarRating` bewerten. Sie meldet die Auswahl über einen `EventCallback` an die Seite zurück und unterstützt so `@bind-Value`. Die Bewertung wird noch nirgends gespeichert.

## Step 4: Layouts & Routing

Das Layout hat jetzt ein Menü (`NavMenu`) mit `NavLink`s, die den aktiven Link hervorheben, und es gibt eine neue Seite `About`. Auf der Rezeptliste kann man nach Kategorie filtern: Die Kategorie steht als Query-Parameter in der Adresse (`/recipes?category=Pasta`) und wird mit `[SupplyParameterFromQuery]` gelesen. Die Buttons navigieren über den `NavigationManager`, so lässt sich ein Filter als Link teilen und der Zurück-Button des Browsers funktioniert.

## Step 5: Services & Dependency Injection

Die Seiten greifen nicht mehr direkt auf eine statische Liste zu, sondern auf den Service `RecipeService`. Er hält die Rezepte und die Bewertungen im Speicher und wird in `Program.cs` registriert, die Seiten bekommen sie über `@inject`. Die Methoden sind schon asynchron, damit der Service später ohne Änderung an den Seiten durch einen Aufruf an das Backend ersetzt werden kann. Bewertungen bleiben jetzt beim Wechsel zwischen den Seiten erhalten, aber noch nicht nach einem Neuladen.
