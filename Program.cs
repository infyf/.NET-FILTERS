using lr11.Filters;

var builder = WebApplication.CreateBuilder(args);

// як сервіс
builder.Services.AddScoped<LogFilter>();

// Додаємо MVC і реєструємо LogActionFilter як глобальний фільтр завдання 1
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LogFilter>();
});

// Реєстрація фільтру як глобального завдання 2
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<UnFilter>();
});

var app = builder.Build();

// Налаштування HTTP-конвеєра
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
