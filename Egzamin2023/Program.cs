// Novytskyi Rostyslav 15204
using Egzamin2023.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IDateProvider, DefaultDateProvider>();



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<NoteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    name: "details",
    pattern: "Exam/Details/{title}",
    defaults: new { controller = "Exam", action = "Details" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();