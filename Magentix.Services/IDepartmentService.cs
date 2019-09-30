using System.Collections.Generic;
using Magentix.Domain.Models.Tickets;

namespace Magentix.Services
{
    public interface IDepartmentService 
    {
        Department GetDepartment(int id);
        IEnumerable<Department> GetDepartments();
        void UpdatePriceTag(string departmentName,string priceTag);
        void ResetCache();
    }
}
