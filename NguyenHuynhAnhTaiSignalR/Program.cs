using NguyenHuynhAnhTaiSignalR;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(typeof(INewsArticleService), typeof(NewsArticleService));
builder.Services.AddSingleton(typeof(ICategoryService), typeof(CategoryService));
builder.Services.AddSingleton(typeof(ISystemAccountService), typeof(SystemAccountService));
builder.Services.AddSingleton(typeof(ITagService), typeof(TagService));

builder.Services.AddSingleton(typeof(ITagRepository), typeof(TagRepository));
builder.Services.AddSingleton(typeof(ICategoryRepository), typeof(CategoryRepository));
builder.Services.AddSingleton(typeof(ISystemAccountRepository), typeof(SystemAccountRepository));
builder.Services.AddSingleton(typeof(INewsArticleRepository), typeof(NewsArticleRepository));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24);
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<WebHub>("/Webhub");
app.UseSession();

app.MapGet("/", (HttpContext context) =>
{
    context.Response.Redirect("/LoginPage");
});

app.Run();
