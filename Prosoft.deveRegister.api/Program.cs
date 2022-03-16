using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.CloudListeners.Auth;
using KissLog.Formatters;
using Microsoft.EntityFrameworkCore;
using Prosoft.devRegister.Business;
using Prosoft.devRegister.Business.Interfaces;
using Prosoft.devRegister.Data.Context;
using Prosoft.devRegister.Data.Repository;
//using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository> ();

//kisslogger
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IKLogger>((provider) => Logger.Factory.Get());
builder.Services.AddLogging(logging =>
{
    logging.AddKissLog(options =>
    {
        options.Formatter = (FormatterArgs args) =>
        {
            if (args.Exception == null)
                return args.DefaultValue;

            string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);

            return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
        };
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseKissLogMiddleware(options => ConfigureKissLog(options));
 void ConfigureKissLog(IOptionsBuilder options)
{
    KissLogConfiguration.Listeners.Add(new RequestLogsApiListener(new Application(builder.Configuration["KissLog.OrganizationId"], builder.Configuration["KissLog.ApplicationId"]))
        {
            ApiUrl = builder.Configuration["KissLog.ApiUrl"]
        });
}

// Configure the HttP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
