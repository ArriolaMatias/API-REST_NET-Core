using API.Business_Layer;
using DataAccess.Repository;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[Controller]/[Action]")]
    public class CategoriaController : Controller
    {
        private readonly IRepository<Categoria> _repository;
        private readonly BlCategoria _blCategorias;
        public CategoriaController(IRepository<Categoria> repository)
        {
            _repository = repository;
            _blCategorias = new BlCategoria(_repository);
        }

        #region CRUD
        [HttpGet]
        public async Task<csResponse> GetCategorias()
        {
            return await _blCategorias.GetCategorias();
        }

        [HttpGet]
        public async Task<csResponse> GetCategoriaById(int _id)
        {
            return await _blCategorias.GetCategoriaById(_id);
        }

        [HttpPost]
        public async Task<csResponse> AddCategoria(Categoria _categoria)
        {
            return await _blCategorias.Create(_categoria);
        }

        [HttpPut]
        public async Task<csResponse> EditCategoria(int _id, Categoria _categoria)
        {
            return await _blCategorias.Edit(_id, _categoria);
        }

        [HttpDelete]
        public async Task<csResponse> DeleteCategoria(Categoria _categoria)
        {
            return await _blCategorias.Delete(_categoria);
        }
        #endregion
    }
}
