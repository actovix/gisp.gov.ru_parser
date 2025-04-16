using gisp.gov.ru_parser.Middleware;
using gisp.gov.ru_parser.Models.Configs;
using gisp.gov.ru_parser.Parser;
using gisp.gov.ru_parser.Parser.Gisp.gov;
using gisp.gov.ru_parser.Parser.GosZakupki;
using gisp.gov.ru_parser.Parser.Loader;
using gisp.gov.ru_parser.Parser.ReestrDigitalGovRu;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


var conf = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .AddEnvironmentVariables()
    .Build();

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddHttpClient().ConfigureHttpClientDefaults(cb =>
{
    cb.ConfigureHttpClient(c =>
    {
        c.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 YaBrowser/24.6.0.0 Safari/537.36");
    });
}
);

if (builder.Environment.IsDevelopment())
{
    builder.Host.UseSerilog(logger, dispose: true)
        .ConfigureLogging(l => l.SetMinimumLevel(LogLevel.Debug));
}

builder.Host.UseSerilog(logger, dispose: true)
    .ConfigureLogging(l => l.SetMinimumLevel(LogLevel.Information));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.Configure<ApiKeysStorage>(conf.GetSection("ApiKeysStorage"));
builder.Services.AddScoped<IHtmlLoader, HtmlLoader>();
builder.Services.AddScoped<ParserBase>();

builder.Services.AddScoped<GispGovRuParser>();
builder.Services.Configure<GispGovRuConfig>(conf.GetSection(nameof(GispGovRuConfig)));

builder.Services.Configure<ReestrDigitalGovRuConfig>(conf.GetSection(nameof(ReestrDigitalGovRuConfig)));
builder.Services.AddScoped<ReestrDigGovRuParser>();

builder.Services.Configure<GosZakupkiConfig>(conf.GetSection(nameof(GosZakupkiConfig)));
builder.Services.AddScoped<GosZakupkiParser>();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen((opt) =>
    {

    });
}

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseMiddleware<ApiKeyAuth>();
    app.UseMiddleware<TimeoutMiddleware>();
}

app.MapControllers();
app.UseAuthorization();

app.UseCors((x) => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.Urls.Add("http://0.0.0.0:5069");

app.Run();
