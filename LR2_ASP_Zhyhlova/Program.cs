using LR2_ASP_Zhyhlova;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/task1", CompaniesRequest);
app.MapGet("/task2", AboutRequest);

// - Task 1
async Task CompaniesRequest(HttpContext context)
{
    context.Response.ContentType = "text/html; charset=utf-8";

    Company microsoft = new Company();
    builder.Configuration.AddXmlFile("microsoft.xml");
    builder.Configuration.Bind(microsoft);
    Company apple = new Company();
    builder.Configuration.AddJsonFile("apple.json");
    builder.Configuration.Bind(apple);
    Company google = new Company();
    builder.Configuration.AddIniFile("google.ini");
    builder.Configuration.Bind(google);

    int mostEmployees = 0;
    Company[] companies = { microsoft, apple, google };
    for (int i = 0; i < companies.Length; i++)
    {
        if (mostEmployees < companies[i].Employees)
        {
            mostEmployees = companies[i].Employees;
            await context.Response.WriteAsync("The company with the most employees - " + companies[i]);
        }
    }
}

// - Task 2
async Task AboutRequest(IConfiguration appConfig, HttpContext context)
{
    builder.Configuration.AddJsonFile("bio.json");
    AboutMyself bio = new AboutMyself(appConfig["full name"], Convert.ToInt32(appConfig["age"]), appConfig["education"]);

    StringBuilder sb = new StringBuilder();
    sb.Append("<style>div{text-align: center; color: #319B56; font-size: 14pt; font-family: Century Gothic; font-weight: bold;}</style>" +
              $"<div>Full name: {bio.Name}" +
              $"<div>Age: {bio.Age}</div>" +
              $"<div>Education: {bio.Education}</div></div>");
    await context.Response.WriteAsync(sb.ToString());
}

app.Run();
