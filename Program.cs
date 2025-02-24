using Amazon.SQS;
using AWSEKS_WebAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register the Amazon SQS client and the SQS producer service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonSQS>();
builder.Services.AddScoped<ISQSProducer, SQSProducerService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/",  () => "Hello World, this is the latest version of the app!");

app.MapControllers();

app.Run();
