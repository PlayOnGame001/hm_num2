var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run(async (context) =>
{
    var responce = context.Response;
    var request = context.Request;
    string path = request.Path.ToString().ToLower();

    if(path == "/")
    {
        responce.ContentType = "text/html; charset=utf-8";
        await responce.SendFileAsync("index.html");
    }
    else if (path == "/form" && request.Method == "POST")
    {
        string userName = request.Form["userName"];
        string userPhone = request.Form["userPhone"];
        await responce.WriteAsync($"User name - {userName}{Environment.NewLine}User phone - {userPhone}");
    }
    else
    {
        responce.StatusCode = 404;
        await responce.WriteAsync("NOT found");
    }
});

app.Run();