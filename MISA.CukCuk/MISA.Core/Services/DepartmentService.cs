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
        protected override ServiceResult CustomValidate(Department department)
        {
            var res = new ServiceResult();
            return res;
        }
        #endregion
    }
}
