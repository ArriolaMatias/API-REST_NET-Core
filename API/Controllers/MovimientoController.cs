using API.Business_Layer;
using DataAccess.Repository;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class MovimientoController : ControllerBase
    {
        private readonly IRepository<Movimiento> _repositoryMovimiento;
        private BlMovimiento _blMovimiento;
        public MovimientoController(IRepository<Movimiento> repository)
        {
            _repositoryMovimiento = repository;
            _blMovimiento = new BlMovimiento(_repositoryMovimiento);
        }

        [HttpGet]
        public async Task<csResponse> GetMovimientos()
        {
            return await _blMovimiento.GetMovimientos();
        }

        [HttpPost]
        public async Task<csResponse> AddMovimiento(Movimiento movimiento)
        {
            return await _blMovimiento.Create(movimiento);
        }
    }
}
