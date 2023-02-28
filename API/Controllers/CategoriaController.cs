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
        public CategoriaController(IRepository<Categoria> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> GetCategorias()
        {
            csResponse _response = new csResponse();
            try
            {
                IEnumerable<Categoria> categorias = _repository.Read().ToList<Categoria>();
                _response.StatusCode = 200;
                _response.Data = categorias;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                return BadRequest(_response);
            }
            
        }

        [HttpGet]
        public ActionResult<Categoria> GetCategoriaById(int _id)
        {
            csResponse _response = new csResponse();
            try
            {
                Categoria? _categoria = _repository.GetById(_id);
                if (_categoria == null) { _response.StatusCode = 404; return NotFound(_response); }

                _response.StatusCode = 200;
                _response.Data = _categoria;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                return BadRequest(_response);
            }
        }

        [HttpPost]
        public ActionResult AddCategoria(Categoria _categoria)
        {
            csResponse _response = new csResponse();
            try
            {
                _repository.Create(_categoria);
                _response.StatusCode = 200;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                return BadRequest(_response);
            }
        }

        [HttpPut]
        public ActionResult EditCategoria(int _id, Categoria _categoria)
        {
            csResponse _response = new csResponse();

            if (_id != _categoria.Id) { _response.StatusCode = 500; _response.Message = "Los parametros ID no coinciden";  return BadRequest(_response); }
            try
            {
                _repository.Update(_id, _categoria);
                _response.StatusCode = 200;
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Message = e.Message; 
                return BadRequest(_response);
            }

        }

        [HttpDelete]
        public ActionResult DeleteCategoria(int _id)
        {
            csResponse _response = new csResponse();
            try
            {
                Categoria? categoria = _repository.GetById(_id);
                if (categoria == null) { _response.StatusCode = 404; return NotFound(_response); }

                _repository.Delete(categoria);
                _response.StatusCode = 200;  
                return Ok(_response);
            }
            catch (Exception e)
            {
                _response.Message = e.Message;
                return BadRequest(_response);
            }
        }
    }
}
