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
    [Route("api/v1/positions")]
    [ApiController]
    public class PositionControllers : BaseEntityController<Position>
    {
        #region Constructors
        public PositionControllers(IBaseRepository<Position> positionRepository, IPositionService positionService) : base(positionRepository, positionService)
        {
        }
        #endregion
    }
}
