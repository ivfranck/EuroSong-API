using Euro_Song.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Euro_Song;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCors(s => s.AddPolicy("MyPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));//part of security added
        builder.Services.AddSingleton(typeof(IDataContext), typeof(Database));//before we used typeof(DataList)
        
        //ConfigureServices
        builder.Services
            .AddAuthentication()
            .AddScheme<AuthenticationSchemeOptions, 
                BasicAuthenticationHandler>("BasicAuthenticationScheme", options => { });

        builder.Services.AddAuthorization(options => {
            options.AddPolicy("BasicAuthentication", 
                new AuthorizationPolicyBuilder("BasicAuthenticationScheme").RequireAuthenticatedUser().Build());
        });
        
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        

        var app = builder.Build();
        app.UseCors("MyPolicy");//added for security
        app.UseHttpsRedirection();//added for security
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

