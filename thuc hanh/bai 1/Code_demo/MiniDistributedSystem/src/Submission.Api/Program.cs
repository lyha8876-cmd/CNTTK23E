var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Thí nghiệm a: Thêm bài tập thứ 3 vào danh sách
var assignments = new List<Assignment>
{
    new Assignment(1, "Bai tap 1"),
    new Assignment(2, "Bai tap 2"),
    new Assignment(3, "Bai tap 3") 
};

// 1. Endpoint GET danh sách bài tập
app.MapGet("/api/assignments", () => assignments);

// 2. Endpoint POST nộp bài (có kiểm tra dữ liệu rỗng cho Thí nghiệm c)
app.MapPost("/api/assignments/{id}/submit", (int id, SubmissionRequest req) =>
{
    if (string.IsNullOrWhiteSpace(req.StudentCode))
    {
        return Results.BadRequest(new { error = "StudentCode không được để trống" });
    }
    
    var submissionId = Guid.NewGuid().ToString();
    return Results.Ok(new SubmissionResult(submissionId, "received"));
});

app.Run();

record Assignment(int Id, string Title);
record SubmissionRequest(string StudentCode, int AssignmentId);
record SubmissionResult(string SubmissionId, string Status);