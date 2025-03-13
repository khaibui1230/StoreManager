Suy nghĩ cho
26s
Mở rộng để xem chi tiết
Dưới đây là nội dung README cho dự án StoreManager, được viết dựa trên các thông tin và yêu cầu đã trao đổi. README này cung cấp thông tin tổng quan về dự án, cách cài đặt, cấu trúc thư mục, các tính năng chính, và hướng dẫn sử dụng.

StoreManager - Hệ thống quản lý nhà hàng
StoreManager là một ứng dụng quản lý nhà hàng được xây dựng bằng .NET Core, cung cấp các tính năng quản lý menu, đơn hàng, bàn, nhân viên và khách hàng. Dự án tích hợp xác thực JWT để đảm bảo bảo mật và SignalR để hỗ trợ cập nhật thời gian thực.

Mục tiêu của dự án
Cung cấp một API RESTful để quản lý các hoạt động chính của nhà hàng.
Hỗ trợ xác thực và phân quyền cho nhân viên và khách hàng.
Thông báo thời gian thực về các thay đổi trong hệ thống như tạo đơn hàng mới hoặc cập nhật trạng thái bàn.
Tính năng chính
Quản lý menu: Thêm, sửa, xóa các món ăn trong menu.
Quản lý đơn hàng: Tạo, xem, cập nhật trạng thái đơn hàng.
Quản lý bàn: Xem và cập nhật trạng thái của các bàn trong nhà hàng.
Quản lý nhân viên: Thêm, sửa, xóa thông tin nhân viên.
Quản lý khách hàng: Thêm, sửa, xóa thông tin khách hàng.
Xác thực và phân quyền: Sử dụng JWT để xác thực và phân quyền cho các vai trò khác nhau (Admin, Staff, Customer).
Thông báo thời gian thực: Sử dụng SignalR để gửi thông báo khi có sự kiện quan trọng như tạo đơn hàng mới.
Cấu trúc thư mục
Dự án được tổ chức theo mô hình phân tầng (layered architecture) để dễ dàng bảo trì và mở rộng:

text

Thu gọn

Bọc lại

Sao chép
StoreManager/
├── Controllers/              # Chứa các API controllers
│   ├── AuthController.cs
│   ├── MenuController.cs
│   ├── OrdersController.cs
│   ├── TablesController.cs
│   ├── StaffController.cs
│   └── CustomersController.cs
├── Data/                     # Chứa logic liên quan đến dữ liệu
│   ├── RestaurantDbContext.cs
│   ├── Repositories/         # Chứa các repository
│   └── UnitOfWork/           # Chứa Unit of Work
├── Models/                   # Chứa các entity của cơ sở dữ liệu
│   ├── User.cs
│   ├── MenuItem.cs
│   ├── Order.cs
│   ├── Table.cs
│   ├── Staff.cs
│   └── Customer.cs
├── DTOs/                     # Chứa Data Transfer Objects
│   ├── MenuItemDto.cs
│   ├── OrderDto.cs
│   ├── TableDto.cs
│   ├── StaffDto.cs
│   ├── CustomerDto.cs
│   └── LoginModel.cs
├── Services/                 # Chứa logic nghiệp vụ
│   ├── IMenuService.cs
│   ├── MenuService.cs
│   ├── IOrderService.cs
│   ├── OrderService.cs
│   ├── ITableService.cs
│   ├── TableService.cs
│   ├── IStaffService.cs
│   ├── StaffService.cs
│   ├── ICustomerService.cs
│   └── CustomerService.cs
├── Hubs/                     # Chứa SignalR hubs
│   └── StoreHub.cs
├── Mapper/                   # Chứa cấu hình AutoMapper
│   └── AutoMapperProfile.cs
├── Program.cs                # File cấu hình ứng dụng
└── appsettings.json          # File cấu hình (JWT, connection string, v.v.)
Yêu cầu hệ thống
.NET: 6.0 hoặc cao hơn
Cơ sở dữ liệu: SQL Server (hoặc bất kỳ cơ sở dữ liệu nào tương thích với Entity Framework Core)
IDE: Visual Studio 2022 hoặc bất kỳ IDE tương đương
Cài đặt và chạy dự án
Clone repository:
bash

Thu gọn

Bọc lại

Sao chép
git clone https://github.com/your-repo/StoreManager.git
cd StoreManager
Cài đặt các package:
bash

Thu gọn

Bọc lại

Sao chép
dotnet restore
Cấu hình chuỗi kết nối:
Mở file appsettings.json và cập nhật chuỗi kết nối trong phần ConnectionStrings:
json

Thu gọn

Bọc lại

Sao chép
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=RestaurantDb;Trusted_Connection=True;"
}
Chạy migration để tạo database:
bash

Thu gọn

Bọc lại

Sao chép
dotnet ef database update
Chạy ứng dụng:
bash

Thu gọn

Bọc lại

Sao chép
dotnet run
API sẽ chạy tại http://localhost:5000 (hoặc port được cấu hình trong appsettings.json).
Sử dụng API
Đăng nhập: Gửi POST request đến /api/auth/login với body:
json

Thu gọn

Bọc lại

Sao chép
{
  "username": "admin",
  "password": "your_password"
}
Response sẽ trả về token JWT.
Gọi các endpoint bảo vệ: Thêm header Authorization: Bearer <token> vào các request.
Ví dụ các endpoint:
Menu:
GET /api/menu - Lấy danh sách món ăn
POST /api/menu - Thêm món ăn
PUT /api/menu/{id} - Cập nhật món ăn
DELETE /api/menu/{id} - Xóa món ăn
Đơn hàng:
GET /api/orders - Lấy danh sách đơn hàng
POST /api/orders - Tạo đơn hàng mới
PUT /api/orders/{id} - Cập nhật đơn hàng
Bàn:
GET /api/tables - Lấy danh sách bàn
PUT /api/tables/{id} - Cập nhật trạng thái bàn
Nhân viên:
GET /api/staff - Lấy danh sách nhân viên
POST /api/staff - Thêm nhân viên
DELETE /api/staff/{id} - Xóa nhân viên
Khách hàng:
GET /api/customers - Lấy danh sách khách hàng
POST /api/customers - Thêm khách hàng
PUT /api/customers/{id} - Cập nhật thông tin khách hàng
DELETE /api/customers/{id} - Xóa khách hàng
Thông báo thời gian thực với SignalR
Client có thể kết nối đến /storeHub để nhận thông báo khi có sự kiện như tạo đơn hàng mới hoặc cập nhật trạng thái bàn.
Ví dụ code client JavaScript:
html

Thu gọn

Bọc lại

Sao chép
<script src="https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/6.0.1/signalr.min.js"></script>
<script>
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5000/storeHub", {
            accessTokenFactory: () => "your_jwt_token_here"
        })
        .build();

    connection.on("ReceiveUpdate", (eventType, message) => {
        console.log(`${eventType}: ${message}`);
    });

    connection.start().catch(err => console.error(err));
</script>
Phân quyền
Admin: Có toàn quyền quản lý (tạo, sửa, xóa) cho tất cả các thực thể.
Staff: Có quyền xem và quản lý đơn hàng, bàn, và khách hàng (tùy theo cấu hình).
Customer: Chỉ có quyền xem và cập nhật thông tin cá nhân của mình.
Cải tiến trong tương lai
Thêm tính năng thanh toán trực tuyến.
Xây dựng giao diện người dùng (frontend) để dễ dàng tương tác.
Triển khai caching để tối ưu hóa hiệu suất.
Thêm logging và monitoring để giám sát hệ thống.
