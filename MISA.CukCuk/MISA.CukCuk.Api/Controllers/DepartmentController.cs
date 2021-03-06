using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Lớp Controller các hoạt động liên quan đến Department
    /// </summary>
    [Route("api/v1/departments")]
    [ApiController]
    public class DepartmentController : BaseEntityController<Department>
    {
        #region Constructors
        public DepartmentController(IBaseRepository<Department> baseRepository, IDepartmentService departmentService) : base(baseRepository, departmentService)
        {
        }
        #endregion
    }
}
