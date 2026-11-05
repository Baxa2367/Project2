# ProductCatalog — 2-апта зертханалық жұмысы

ASP.NET Core MVC, Razor, Strongly Typed Views, Layout және Partial Views тақырыптарына арналған демонстрациялық веб-каталог.

## Талаптар
- .NET 8 SDK немесе одан жаңасы
- Visual Studio 2022 немесе VS Code

## Іске қосу
Терминалда жоба бумасына өтіңіз:

```bash
dotnet restore
dotnet run
```

Терминалда көрсетілген `http://localhost:...` немесе `https://localhost:...` мекенжайын браузерде ашыңыз.

## Жоба құрылымы

```text
ProductCatalog/
├── Controllers/
│   └── ProductController.cs
├── Models/
│   └── Product.cs
├── Views/
│   ├── Product/
│   │   ├── Index.cshtml
│   │   └── Details.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _ProductCard.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
├── wwwroot/
│   └── css/
│       └── site.css
├── Program.cs
└── ProductCatalog.csproj
```

## Тапсырма талаптарының орындалуы
1. `ProductCatalog` — ASP.NET Core MVC жобасы.
2. `Product` моделінде `Id`, `Name`, `Price`, `Category`, `IsAvailable` қасиеттері бар.
3. `_Layout.cshtml` ортақ Bootstrap интерфейсін береді.
4. `_ProductCard.cshtml` тауар карточкасын қайта қолданылатын компонент ретінде көрсетеді.
5. `Index.cshtml` — `IEnumerable<Product>` типіндегі Strongly Typed View.
6. `ProductController` тауарларды View-ге береді; іздеу және санат бойынша сүзгілеу бар.

Ескерту: тапсырмада дерекқор талап етілмегендіктен, бастапқы тауарлар контроллердегі демонстрациялық тізімде сақталған.


### Product photos
Each product supports an `ImageUrl` property. Set it to a direct image URL to display a photo on the product card. If it is empty, the card displays its icon instead.
