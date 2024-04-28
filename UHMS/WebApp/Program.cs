using BusinessLogic;
using DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DoctorDAL>(); // This registers DoctorDAL
builder.Services.AddScoped<DoctorManager>(); // This registers DoctorManager, which depends on DoctorDAL
builder.Services.AddScoped<AdministratorManager>();
builder.Services.AddScoped<AdministratorDAL>();
builder.Services.AddScoped<PatientManager>();
builder.Services.AddScoped<PatientDAL>();


// Add services to the container.
builder.Services.AddRazorPages();

// Register the UserManager for dependency injection
builder.Services.AddScoped<UserManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
