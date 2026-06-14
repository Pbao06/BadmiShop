using Getdata1.Data;
using Getdata1.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Getdata1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")] // set chi co admin moi duoc vao 
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context) // ocnstructor 
        {
            _context = context;
        }
        public  async Task<IActionResult> Index( string? searchName, string? RoleSearch,string? StatusFilter, int page = 1)
        {
            // get data -> checknull ->  maps -> return 
            // in this case we maps direcly 
           
          try
            {
                int pageSize = 10;
                var query = _context.Users.AsQueryable(); // lấy dữ liệu để query từ db 
               

                // filler 
                if (!string.IsNullOrWhiteSpace(searchName))
                {
                    var searchTerm = searchName.Trim().ToLower(); // convert to lower case for case-insensitive search if needed
                    query = query.Where(o => o.UserName.Contains(searchTerm));
                }
                if (!string.IsNullOrWhiteSpace(RoleSearch))
                {
                    var searchTerm = RoleSearch.Trim().ToLower(); // convert to lower case for case-insensitive search if needed
                    query = query.Where(o => o.Role.ToString().Contains(searchTerm));
                }
                // filter for status we have to calculate base on total spent of each customer


                var CustomerData =await query.Select(o => new CustomerVM // TẠO GÓI DỮ LIỆU KẾT QUẢ ĐÃ LỌC TỪ DB VÀ MAP SANG VM
                {
                    Name = o.UserName,
                    PasswordHash = o.PasswordHash,
                    Role = o.Role.ToString(),
                    OrderCount = _context._Orders.Count(u => u.UserId == o.Id),
                    TotalSpent = _context._Orders.Where(u => u.UserId == o.Id).SelectMany(o => o.OrderItems).Sum(item => (decimal?)(item.Price * item.Quantity)) ?? 0,
                    // cause TotalPrice notmap in oject so we have to -> calculate base join real o
                    Status = (_context._Orders
                    .Where(u => u.UserId == o.Id)
                    .SelectMany(ord => ord.OrderItems)
                    .Sum(item => (decimal?)(item.Price * item.Quantity)) ?? 0) >= 500000
                    ? "VIP" : "Regular"
                }).OrderByDescending(o => o.TotalSpent).ToListAsync();
                if (CustomerData == null) return NotFound();
                // filter for status we have to calculate base on total spent of each customer TÍNH SAU KHI ĐÃ CÓ KQ

                if (!string.IsNullOrWhiteSpace(StatusFilter))
                {
                   
                    CustomerData = CustomerData.Where(o => o.Status==StatusFilter).ToList();
                }

                // tính phân trang skip sản phẩm + lấy sản phẩm tiếp theo 
                int totalItems = CustomerData.Count;
                int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
                var pagedata=CustomerData.Skip((page - 1) * pageSize).Take(pageSize).ToList();



                var model = new CustomerIndexVM
                {
                    Customers = pagedata,
                    CurrentPage = page,
                    TotalPages = totalPages == 0 ? 1 : totalPages, // Tránh chia cho 0,
                    SearchName = searchName,
                    RoleSearch = RoleSearch,
                    StatusFilter = StatusFilter
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
