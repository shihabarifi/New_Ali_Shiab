using POS.Data;

using POS.Models; 
using POS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using POS.Interfaces;
using POS.Repositories;
using POS.Models.DB;
using Microsoft.AspNetCore.Authorization;
using POS.Permission;
using POS.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<SecurityStampValidatorOptions>(op =>
op.ValidationInterval = TimeSpan.FromSeconds(0));

builder.Services.AddSession();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddScoped<ICurrency, CurrencyRepo>();
builder.Services.AddScoped<IExchangeRate, ExchangeRateRepo>();
builder.Services.AddScoped<IFund, FundRepo>();
builder.Services.AddScoped<IFiscalYear, FiscalYearReop>();
builder.Services.AddScoped<IAccountingManual, AccountingManualRepo>();
builder.Services.AddScoped<IExpensVoucher, ExpensVoucherRepo>();
builder.Services.AddScoped<IBank, BankRepo>();
builder.Services.AddScoped<IPayCheckVoucher, PayCheckVoucherRepo>();
builder.Services.AddScoped<ICheckExpens, CheckExpensRepo>();
builder.Services.AddScoped<ICheckPaycheck, CheckPaycheckRepo>();
builder.Services.AddScoped<pay_recie_finRepository<FiscalYear>, FiscalYearsDb_Repository>();
builder.Services.AddScoped<pay_recie_finRepository<Currency>, CurrenciesDb_REpository>();
builder.Services.AddScoped<pay_recie_finRepository<AccountingManual>, AccountingManualDb_Repository>();
builder.Services.AddScoped<pay_recie_finRepository<JournalEnterieType>, JournaEnteryTypeDb_Repository>();
builder.Services.AddScoped<pay_recie_finRepository<DetailedJournalEntery>, DetailedJournalEnteryDb_Repository>();
builder.Services.AddScoped<pay_recie_finRepository<GeneralLedger>, GeneralLedgerDb_Repoditory>();
builder.Services.AddScoped<AccountingManualCurrens_Db_REpository>();
builder.Services.AddScoped<pay_recie_finRepository<FinalAccountType>, FinalAccountDB_Repo>();
//builder.Services.AddScoped<pay_recie_finRepository<ActivityType>, ActivityTypeDb_Repository>();
builder.Services.AddScoped<pay_recie_finRepository<CurrenciesExchangeRate>, CurrenciExchangeRateDb_Repository>();
builder.Services.AddScoped<pay_recie_finRepository<MainJournalEntery>, MainJournalEnteryDb_Repository>();
builder.Services.AddDbContext<posDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<posDbContext>();



builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "";
    options.AccessDeniedPath = "/Home/Denied";
});



var app = builder.Build();
using var Scope = app.Services.CreateScope();
var services = Scope.ServiceProvider;
try
{
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await DefaultRole.SeedAsync(roleManager);
    await DefaultUser.SeedSuperAdminAsync(userManager, roleManager);
    await DefaultUser.SeedAdminAsync(userManager, roleManager);
    await DefaultUser.SeedBasicUserAsync(userManager, roleManager);
}
catch (Exception) { throw; }

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");

app.Run();
