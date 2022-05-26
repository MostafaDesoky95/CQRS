using Microsoft.EntityFrameworkCore;
using CQRS.Data;
using CQRS.Services.EventService;
using MediatR;
using System.Reflection;
using CQRS.Services.PhotoAlbumService;
using CQRS.Services.SourcesService;
using Microsoft.AspNetCore.Mvc.Razor;
using CQRS.Services.PhotoService;
using CQRS.Services.CategoryService;
using CQRS.ViewModels.AutoMapper;
using CQRS.Services.EventCategoryService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

builder.Services.AddScoped<IEventService,EventService>();
builder.Services.AddScoped<IPhotoAlbumsService,PhotoAlbumsService>();
builder.Services.AddScoped<ISourceService,SourcesService>();
builder.Services.AddScoped<IPhotoService,PhotoService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IEventCategoryService, EventCategoryService>();
builder.Services.AddDbContext<DBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext") ?? throw new InvalidOperationException("Connection string 'DBContext' not found.")));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(typeof(SharedProfile));

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
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.MapControllers();
app.Run();
