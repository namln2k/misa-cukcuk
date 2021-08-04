using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        IDepartmentRepository _departmentRepository;

        #region Constructors
        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion

        #region Methods
        public override ServiceResult AddValidate(Department department)
        {
            var res = new ServiceResult();

            // Check DepartmentCode có trùng lặp không
            if (_departmentRepository.GetByCode(department.DepartmentCode) != null)
            {
                res.Success = false;
                res.UserMsg = Properties.Resources.ValidationError_DepartmentCodeDuplicated;
                res.MISACode = Constants.MISAConst.MISACodeValidationError;
                return res;
            }

            // Trả về kết quả
            return res;
        }

        public override ServiceResult UpdateValidate(Department department)
        {
            var departmentById = _departmentRepository.GetById(department.DepartmentId);
            var res = new ServiceResult();

            // Check xem khách hàng có yêu cầu thay đổi EmployeeCode không
            if (!String.Equals(department.DepartmentCode, departmentById.DepartmentCode))
            {
                // Nếu có yêu cầu thay đổi EmployeeCode thì check xem EmployeeCode có bị trùng lặp không
                var employeeByCode = _departmentRepository.GetByCode(department.DepartmentCode);

                if (employeeByCode != null)
                {
                    res.Success = false;
                    res.UserMsg = Properties.Resources.ValidationError_EmployeeCodeDuplicated;
                    res.MISACode = Constants.MISAConst.MISACodeValidationError;
                    return res;
                }
            }

            // Trả về kết quả
            return res;
        }
        #endregion
    }
}
