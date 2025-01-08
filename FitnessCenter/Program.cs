using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FitnessCenter.Data;
using FitnessCenter.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Adaugam RazorPages si configuram contextul pentru aplicatia ta (FitnessCenterContext pentru entitatile tale proprii)
builder.Services.AddRazorPages();
builder.Services.AddDbContext<FitnessCenterContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FitnessCenterContext")
    ?? throw new InvalidOperationException("Connection string 'FitnessCenterContext' not found.")));

// Configuram contextul pentru Identity
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FitnessCenterContext")
    ?? throw new InvalidOperationException("Connection string 'FitnessCenterContext' not found.")));

// Adaugam Identity cu entitatile specifice aplicatiei tale pentru autentificare
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Migratia datelor pentru Identity
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<FitnessCenterContext>();

    context.Workout.AddRange(
        new Workout
        {
            Name = "Yoga Class",
            Description = "A class focusing on flexibility and mindfulness.",
            InstructorId = 2
        },
        new Workout
        {
            Name = "Cardio Blast",
            Description = "High-intensity interval training for cardio improvement.",
            InstructorId = 1
        },
        new Workout
        {
            Name = "Strength Training",
            Description = "Build muscle and improve strength with targeted exercises.",
            InstructorId = 3
        }
    );

    context.SaveChanges();
}

// Configurarea pipeline-ului de request
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();  // Adauga autentificarea
app.UseAuthorization();   // Adauga autorizarea

app.MapRazorPages();

app.Run();

