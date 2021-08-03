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
    /// Lớp Controller các hoạt động liên quan đến Employee
    /// </summary>
    /// Created By LNNam(03/08/2021)
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeeControllers : BaseEntityController<Employee>
    {
        //IBaseRepository<Employee> _employeeRepository;
        //IEmployeeService _employeeService;

        #region Constructors
        public EmployeeControllers(IBaseRepository<Employee> employeeRepository, IEmployeeService employeeService) : base(employeeRepository, employeeService)
        {
            //_employeeRepository = employeeRepository;
            //_employeeService = employeeService;
        }
        #endregion
    }
}
