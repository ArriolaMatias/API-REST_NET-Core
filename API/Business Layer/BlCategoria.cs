using DataAccess.Repository;
using Entities;
using System.Net;

namespace API.Business_Layer
{
    public class BlCategoria
    {
        private readonly IRepository<Categoria> _repository;

        public BlCategoria(IRepository<Categoria> repository)
        {
            this._repository = repository;
        }

        public async Task<csResponse> GetCategorias()
        {
            return await _repository.Read();
        }
        public async Task<csResponse> GetCategoriaById(int _id)
        {
            return await _repository.GetById(_id);
        }
        public async Task<csResponse> Create(Categoria _categoria)
        {
            return await _repository.Create(_categoria);
        }
        public async Task<csResponse> Edit(int _id, Categoria _categoria)
        {
            if (_id != _categoria.Id)
            {
                return new csResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Los parametros ID enviados no coinciden con el del objeto seleccionado"
                };
            }
            else
            {
                return await _repository.Update(_id, _categoria);
            }
        }
        public async Task<csResponse> Delete(Categoria _categoria)
        {
            return await _repository.Delete(_categoria);
        }
    }
}