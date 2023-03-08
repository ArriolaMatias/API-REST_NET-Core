using DataAccess.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DataAccess.Repository
{
    public class CategoriaRepository : IRepository<Categoria>
    {
        EFContext _context;
        public CategoriaRepository(EFContext context) 
        { 
            this._context = context;
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public async Task<csResponse> Create(Categoria _object)
        {
            try
            {
                _context.Add(_object);
                _context.SaveChanges();
                return new csResponse()
                {
                    StatusCode = HttpStatusCode.Created,
                    Message = "Registro insertado correctamente.",
                    Data = _object
                };

            }catch(Exception ex)
            {
                string innerEx = "";
                if (ex.InnerException != null) { innerEx = ex.InnerException.Message;  }
                return new csResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "No se ha insertado el registro. Error: " + ex.Message + "\n" + innerEx,
                    Data = null
                };
            }
        }

        public async Task<csResponse> Delete(Categoria _categoria)
        {
            try
            {
                _context.Remove(_categoria);
                _context.SaveChanges();

                return new csResponse()
                {
                    StatusCode = HttpStatusCode.NoContent,
                    Message = "El registro se ha eliminado correctamente."
                };
            }
            catch (Exception ex)
            {
                return new csResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El registro no se ha eliminado. Error: "+ ex.Message
                };
            }
        }

        public async Task<csResponse> GetById(int id)
        {
            try
            {
                var categoria = from c in _context.Categorias
                                where c.Id == id
                                select c;

                if (!categoria.Any())
                {
                    return new csResponse()
                    {
                        StatusCode = HttpStatusCode.NoContent,
                        Message = "No se ha encontrado el elemento.",
                        Data = categoria.ToList<Categoria>()
                    };
                }
                else
                {
                    return new csResponse()
                    {
                        StatusCode = HttpStatusCode.OK,
                        Message = "Operacion ejecutada correctamente",
                        Data = categoria.FirstOrDefault()
                    };
                }
            }
            catch (Exception ex)
            {
                return new csResponse() { StatusCode = HttpStatusCode.InternalServerError, Message = "Ha ocurrido un error no controlado: \n" + ex.Message };
            }
        }

        public async Task<csResponse> Update(int id, Categoria _object)
        {
            try
            {
                _context.Entry(_object).State = EntityState.Modified;
                _context.SaveChanges();

                return new csResponse()
                {
                    StatusCode = HttpStatusCode.OK,
                    Message = "Registro actualizado correctamente.",
                    Data = _object
                };

            }
            catch (Exception ex)
            {
                return new csResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El registro no ha podido modificarse. Error: "+ex.Message,
                    Data = _object
                };
            }
        }

        public async Task<csResponse> Read()
        {
            try
            {
                var categorias = from c in _context.Categorias
                                 select c;

                if (!categorias.Any())
                {
                    return new csResponse() {   StatusCode = HttpStatusCode.NoContent, 
                                                Message = "No se han encontrado elementos.", 
                                                Data = categorias.ToList<Categoria>() };
                }
                else
                {
                    return new csResponse() {   StatusCode = HttpStatusCode.OK,
                                                Message = "Operacion ejecutada correctamente",
                                                Data = categorias.ToList<Categoria>() };
                }
            }
            catch (Exception ex)
            {
                return new csResponse() { StatusCode = HttpStatusCode.InternalServerError, Message = "Ha ocurrido un error no controlado: \n" + ex.Message };
            }
        }
    }
}
