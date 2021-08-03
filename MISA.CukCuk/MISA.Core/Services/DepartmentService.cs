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
    public class DepartmentService : IDepartmentService
    {
        IDepartmentContext _departmentContext;
        ServiceResult _serviceResult;

        #region Constructors
        public DepartmentService(IDepartmentContext departmentContext)
        {
            _departmentContext = departmentContext;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Methods
        public ServiceResult Add(Department department)
        {
            // Check DepartmentCode có trùng lặp không
            if (_departmentContext.GetByCode(department.DepartmentCode) != null)
            {
                _serviceResult.Success = false;
                _serviceResult.UserMsg = Properties.Resources.ValidationError_DepartmentCodeDuplicated;
                _serviceResult.MISACode = Constants.MISAConst.MISACodeValidationError;
                return _serviceResult;
            }

            // Số bản ghi được thêm
            var res = _departmentContext.Add(department);

            if (res > 0)
            {
                // Nếu thêm thành công
                _serviceResult.Success = true;
                _serviceResult.Data = res;
                return _serviceResult;
            }

            // Nếu thêm thất bại
            _serviceResult.Success = false;
            _serviceResult.UserMsg = Properties.Resources.ExceptionError;
            _serviceResult.MISACode = Constants.MISAConst.MISACodeExceptionError;
            return _serviceResult;
        }

        public int Update(Department entity)
        {
            throw new NotImplementedException();
        }

        ServiceResult IBaseService<Department>.Update(Department entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
