using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers;

public class ProductController : Controller
{
    // Демонстрациялық деректер. Бұл тапсырмада дерекқор талап етілмейді.
    private static readonly List<Product> Products =
    [
        new() { Id = 1, Name = "MacBook Air M3", Price = 549990, Category = "Ноутбуктер", IsAvailable = true, Description = "Жеңіл әрі қуатты ноутбук. Оқу мен жұмысқа арналған.", Icon = "bi-laptop", ImageUrl = "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?auto=format&fit=crop&w=1200&q=85" },
        new() { Id = 2, Name = "iPhone 15 Pro", Price = 499990, Category = "Смартфондар", IsAvailable = true, Description = "Заманауи камера және жоғары өнімділік.", Icon = "bi-phone", ImageUrl = "https://images.unsplash.com/photo-1592750475338-74b7b21085ab?auto=format&fit=crop&w=1200&q=85" },
        new() { Id = 3, Name = "Sony WH-1000XM5", Price = 169990, Category = "Аудио", IsAvailable = true, Description = "Шуды белсенді басатын сымсыз құлаққап.", Icon = "bi-headphones", ImageUrl = "https://images.unsplash.com/photo-1546435770-a3e426bf472b?auto=format&fit=crop&w=1200&q=85" },
        new() { Id = 4, Name = "iPad Air", Price = 329990, Category = "Планшеттер", IsAvailable = false, Description = "Оқу, жазба жүргізу және шығармашылыққа арналған.", Icon = "bi-tablet", ImageUrl = "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?auto=format&fit=crop&w=1200&q=85" },
        new() { Id = 5, Name = "Logitech MX Master 3S", Price = 59990, Category = "Аксессуарлар", IsAvailable = true, Description = "Күнделікті жұмысқа арналған эргономикалық тінтуір.", Icon = "bi-mouse", ImageUrl = "https://images.unsplash.com/photo-1527814050087-3793815479db?auto=format&fit=crop&w=1200&q=85" },
        new() { Id = 6, Name = "Samsung Galaxy Watch6", Price = 119990, Category = "Аксессуарлар", IsAvailable = true, Description = "Белсенділік пен күнделікті көрсеткіштерді бақылаңыз.", Icon = "bi-smartwatch", ImageUrl = "https://images.unsplash.com/photo-1523275335684-37898b6baf30?auto=format&fit=crop&w=1200&q=85" },
        new() { Id = 7, Name = "ASUS Zenbook 14", Price = 429990, Category = "Ноутбуктер", IsAvailable = false, Description = "Ықшам дизайн және OLED дисплей.", Icon = "bi-laptop", ImageUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?auto=format&fit=crop&w=1200&q=85" },
        new() { Id = 8, Name = "JBL Flip 6", Price = 64990, Category = "Аудио", IsAvailable = true, Description = "Портативті акустика, қуатты дыбыс.", Icon = "bi-speaker", ImageUrl = "https://images.unsplash.com/photo-1608043152269-423dbba4e7e1?auto=format&fit=crop&w=1200&q=85" }
    ];

    public IActionResult Index(string? search, string? category)
    {
        IEnumerable<Product> result = Products;

        if (!string.IsNullOrWhiteSpace(search))
        {
            result = result.Where(p =>
                p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(category) && category != "Барлығы")
        {
            result = result.Where(p => p.Category == category);
        }

        ViewBag.Search = search;
        ViewBag.SelectedCategory = category ?? "Барлығы";
        ViewBag.Categories = new[] { "Барлығы" }.Concat(Products.Select(p => p.Category).Distinct()).ToList();
        ViewBag.TotalProducts = Products.Count;
        ViewBag.AvailableProducts = Products.Count(p => p.IsAvailable);

        return View(result.ToList());
    }

    public IActionResult Details(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product is null) return NotFound();

        return View(product);
    }
}
