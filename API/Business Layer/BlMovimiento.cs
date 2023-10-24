using DataAccess.Repository;
using Entities;
using System.Net;

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
        public async Task<csResponse> GetMovimientoById(int _id)
        {
            return await _repository.GetById(_id);
        }
        public async Task<csResponse> Create(Movimiento movimiento)
        {
            return await _repository.Create(movimiento);
        }
        public async Task<csResponse> Edit(int _id, Movimiento _movimiento)
        {
            if (_id != _movimiento.Id)
            {
                return new csResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Los parametros ID enviados no coinciden con el del objeto seleccionado"
                };
            }
            else
            {
                return await _repository.Update(_id, _movimiento);
            }
        }
        public async Task<csResponse> Delete(Movimiento _movimiento)
        {
            return await _repository.Delete(_movimiento);
        }
    }
}
