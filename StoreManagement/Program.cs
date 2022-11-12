using Microsoft.EntityFrameworkCore;
using NToastNotify;
using StoreManagement.Data;
using StoreManagement.Data.Models.Utility;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add Service ProductDbContext
builder.Services.AddDbContext<ProductDbContext>(option =>
        option.UseSqlServer(builder.Configuration.GetConnectionString("StoreManagementDB")));

// Add Service For AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add Service For NtoastNotify & some options
builder.Services.AddRazorPages().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = true,
    PositionClass = ToastPositions.TopCenter,
    PreventDuplicates = true,
    CloseButton = true
});


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

app.Run();
