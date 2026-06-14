using Getdata1.Models;

namespace Getdata1.Areas.Admin.ViewModels
{
    public class CustomerVM // this for page details each of customer
    {
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public int OrderCount { get; set; }
        public decimal TotalSpent { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }

    }
    public class CustomerIndexVM // this for page index of customer
    {
        public List<CustomerVM> Customers { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        // add more somethings 
        // this for search filter + we put ? cause User can search or not search
        public string?  SearchName{ get; set; }  
        public string? RoleSearch { get; set; }
        public string? StatusFilter { get; set; }
    }

}
