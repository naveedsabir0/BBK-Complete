using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MovieDatabaseBlazorServerApp.Components;
using MovieDatabaseBlazorServerApp.Components.Account;
using MovieDatabaseBlazorServerApp.Data;
using MovieDatabaseBlazorServerApp.Helpers;
using MovieDatabaseBlazorServerApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddDbContextFactory<ApplicationDbContext>();
builder.Services.AddScoped<CyclistService>();
builder.Services.AddScoped<PartService>();
builder.Services.AddScoped<BikeService>();
builder.Services.AddScoped<RepairService>();
builder.Services.AddScoped<ClassService>();
builder.Services.AddScoped<FaultService>();
builder.Services.AddScoped<VolunteerService>();
builder.Services.AddScoped<UploadedFileToFolderService>();

builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, CustomClaimsPrincipalFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

    CreateInitialRolesAndUsersAsync(userManager, roleManager)
       .Wait();
}

app.Run();

async Task CreateInitialRolesAndUsersAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
{
    try
    {
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }

        if (!await roleManager.RoleExistsAsync(Roles.Staff))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Staff));
        }

        if (!await roleManager.RoleExistsAsync(Roles.Premium))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Premium));
        }

        var user = new ApplicationUser();
        user.UserName = "admin@bbk.ac.uk";
        user.Email = user.UserName;
        user.Firstname = "Naveed";
        user.Lastname = "Sabir";
        user.Enabled = true;

        string password = "R00t123.";

        if (await userManager.FindByNameAsync(user.UserName) == null)
        {
            var createSuccess = await userManager.CreateAsync(user, password);
            if (createSuccess.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
                await userManager.SetLockoutEnabledAsync(user, false);
            }
            else
            {
                throw new Exception(createSuccess.Errors.FirstOrDefault().ToString());
            }
        }
    }
    catch (Exception e)
    {
        throw new Exception(e.Message);
    }
    //new
}
