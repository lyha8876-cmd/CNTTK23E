# Nhật ký thực hành Bài 1

## Mô tả 5 mô hình MEP (Bước 7)
- MEP 1 (Request–Response): Máy khách gửi một yêu cầu trực tiếp đến máy chủ và chờ nhận lại phản hồi ngay lập tức.
- MEP 2 (One-Way): Máy khách gửi thông điệp đi một chiều mà không cần hoặc không mong đợi máy chủ phải phản hồi lại.
- MEP 3 (Queue-Based): Các thông điệp được đưa vào một hàng đợi chung để phân phối lần lượt cho các worker độc lập cùng chia nhau xử lý.
- MEP 4 (Publish–Subscribe): Một sự kiện từ nhà phát hành được phát tán đồng thời tới tất cả các dịch vụ đã đăng ký nhận tin.
- MEP 5 (Streaming): Dữ liệu được truyền tải liên tục thành một dòng dữ liệu (stream) theo thời gian thực giữa các bên.