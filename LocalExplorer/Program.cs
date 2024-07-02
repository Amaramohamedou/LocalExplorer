using LocalExplorer.Services;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);


var apiKey = builder.Configuration.GetConnectionString("OpenAIKey");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddHttpClient<IpInfoService>();
builder.Services.AddHttpClient<WeatherService>();
builder.Services.AddHttpClient<ActivitySuggestionService>(client =>
{
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.WithOrigins("https://localhost:7052")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();


app.Urls.Add("https://localhost:7039");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapBlazorHub();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LocalExplorer}/{action=GetSuggestions}");

app.Run();

