using System.Net.Http.Json;

var serverUrl = args.Length > 0 ? args[0] : "http://localhost:5000";
var client = new HttpClient { BaseAddress = new Uri(serverUrl) };

try
{
    // 1. Gọi API lấy danh sách bài tập
    Console.WriteLine("Dang lay danh sach bai tap...");
    var assignments = await client.GetFromJsonAsync<Assignment[]>("api/assignments");
    
    if (assignments != null)
    {
        foreach (var a in assignments)
        {
            Console.WriteLine($"  {a.Id}: {a.Title}");
        }
    }

    // 2. Gửi request nộp bài (Thí nghiệm c: bạn có thể đổi StudentCode thành "" để test lỗi 400)
    var submission = new { StudentCode = "SV001", AssignmentId = 1 };
    var response = await client.PostAsJsonAsync("api/assignments/1/submit", submission);
    
    // Dòng này sẽ ném ngoại lệ nếu server trả về mã lỗi (như 400 Bad Request)
    response.EnsureSuccessStatusCode(); 
    
    var result = await response.Content.ReadFromJsonAsync<SubmissionResult>();
    if (result != null)
    {
        Console.WriteLine($"Da nop bai. Ma luot nop: {result.SubmissionId}   Trang thai: {result.Status}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Loi xay ra: {ex.Message}");
}

record Assignment(int Id, string Title);
record SubmissionResult(string SubmissionId, string Status);