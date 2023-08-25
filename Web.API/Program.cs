using Web.API.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    //builder
    //    .AllowAnyMethod()
    //    .AllowAnyHeader()
    //    .WithOrigins("http://localhost:4200", "https://localhost:4200");
    builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();

}));
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();


#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<NotificationHub>("/notificationHub");
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

app.MapControllers();

app.Run();
