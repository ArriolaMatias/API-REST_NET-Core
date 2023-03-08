using DataAccess.Repository;
using Entities;

namespace API.Business_Layer
{
    public class BlMovimiento
    {
        private readonly IRepository<Movimiento> _repository;

        public BlMovimiento(IRepository<Movimiento> repository)
        {
            this._repository = repository;
        }

        public async Task<csResponse> GetMovimientos()
        {
            return await _repository.Read();
        }
        public async Task<csResponse> Create(Movimiento movimiento)
        {
            return await _repository.Create(movimiento);
        }
    }
}
