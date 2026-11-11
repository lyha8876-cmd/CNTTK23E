var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 1. Endpoint trang chủ GET /
app.MapGet("/", () => Results.Ok(new { application = "BasicWebApi" }));

// 2. Endpoint GET hello kèm ngôn ngữ
app.MapGet("/hello/{name}", (string name, string? language) => {
    if (language == "en") return $"Hello {name}!";
    if (language == "ja") return $"Konnichiwa, {name}!";
    return $"Xin chào {name}!";
});

// 3. Danh sách lưu tạm cho POST
var greetings = new List<Greeting>();
int nextId = 1;

// 4. Endpoint POST /greetings
app.MapPost("/greetings", (GreetingInput input) => {
    if (string.IsNullOrWhiteSpace(input.Name))
    {
        return Results.BadRequest(new { message = "Name must not be empty." });
    }

    var newGreeting = new Greeting(nextId++, input.Name);
    greetings.Add(newGreeting);

    return Results.Created($"/greetings/{newGreeting.Id}", newGreeting);
});

app.Run();

record GreetingInput(string? Name);
record Greeting(int Id, string Name);