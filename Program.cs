using lr11.Filters;

var builder = WebApplication.CreateBuilder(args);

// �� �����
builder.Services.AddScoped<LogFilter>();

// ������ MVC � �������� LogActionFilter �� ���������� ������ �������� 1
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LogFilter>();
});

// ��������� ������� �� ����������� �������� 2
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<UnFilter>();
});

var app = builder.Build();

// ������������ HTTP-�������
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
