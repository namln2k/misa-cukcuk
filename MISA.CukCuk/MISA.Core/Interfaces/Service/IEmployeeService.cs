using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Service
{
    /// <summary>
    /// Interface các nghiệp vụ về thông tin nhân viên
    /// </summary>
    /// Created By LNNam (31/07/2021)
    public interface IEmployeeService
    {
        // Thêm mới thông tin nhân viên
        public ServiceResult Add(Employee employee);

        // Sửa đổi thông tin nhân viên
        public ServiceResult Update(Employee employee);
    }
}
