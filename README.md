# StoreManager

1. Xác định yêu cầu hệ thống
Một hệ thống quản lý nhà hàng cơ bản cần hỗ trợ các chức năng chính sau:

Quản lý thực đơn: Thêm, sửa, xóa các món ăn trong thực đơn.
Quản lý đơn hàng: Tạo đơn hàng, thêm món ăn vào đơn hàng, tính tổng tiền.
Quản lý bàn: Quản lý trạng thái của các bàn (trống, có khách, đang phục vụ).
Quản lý nhân viên: Quản lý thông tin nhân viên và vai trò của họ.
2. Thiết kế API Endpoints
Dưới đây là danh sách các API endpoints cần thiết cho từng chức năng:

2.1. Quản lý thực đơn
GET /api/menu: Lấy danh sách tất cả các món ăn.
GET /api/menu/{id}: Lấy thông tin chi tiết của một món ăn.
POST /api/menu: Thêm một món ăn mới.
PUT /api/menu/{id}: Cập nhật thông tin của một món ăn.
DELETE /api/menu/{id}: Xóa một món ăn.
2.2. Quản lý đơn hàng
GET /api/orders: Lấy danh sách tất cả các đơn hàng.
GET /api/orders/{id}: Lấy thông tin chi tiết của một đơn hàng.
POST /api/orders: Tạo một đơn hàng mới.
PUT /api/orders/{id}: Cập nhật thông tin của một đơn hàng.
DELETE /api/orders/{id}: Xóa một đơn hàng.
POST /api/orders/{id}/items: Thêm một món ăn vào đơn hàng.
DELETE /api/orders/{id}/items/{itemId}: Xóa một món ăn khỏi đơn hàng.
2.3. Quản lý bàn
GET /api/tables: Lấy danh sách tất cả các bàn.
GET /api/tables/{id}: Lấy thông tin chi tiết của một bàn.
POST /api/tables: Thêm một bàn mới.
PUT /api/tables/{id}: Cập nhật thông tin của một bàn.
DELETE /api/tables/{id}: Xóa một bàn.
PUT /api/tables/{id}/status: Cập nhật trạng thái của một bàn.
2.4. Quản lý nhân viên
GET /api/staff: Lấy danh sách tất cả các nhân viên.
GET /api/staff/{id}: Lấy thông tin chi tiết của một nhân viên.
POST /api/staff: Thêm một nhân viên mới.
PUT /api/staff/{id}: Cập nhật thông tin của một nhân viên.
DELETE /api/staff/{id}: Xóa một nhân viên.
