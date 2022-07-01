using CustomTxtParser.Extensions;
using Repository.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.AddAppDbContext(builder.Configuration);
builder.AddRepository();
builder.AddCustomServices();
builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.Migrate();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
