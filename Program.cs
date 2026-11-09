using MyProfileWeb.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 1. Register Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Student Profile API",
        Version = "v1",
        Description = "REST API for John Paul C. Ayupan's Student Profile"
    });
});

// 2. Register HttpClient for internal server calls using 127.0.0.1
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://127.0.0.1:5032/")
});

// 3. Force Kestrel web server to listen on all network interfaces (allows iPhone connection)
builder.WebHost.UseUrls("http://0.0.0.0:5032");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Profile API v1");
    });
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();