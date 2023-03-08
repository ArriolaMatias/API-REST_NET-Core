using DataAccess.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Repository
{
    public class MovimientoRepository : IRepository<Movimiento>
    {
        private readonly EFContext _context;
        public MovimientoRepository(EFContext context) 
        {
            this._context = context;
            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public async Task<csResponse> Create(Movimiento _object)
        {
            try
            {
                _context.Add(_object);
                _context.SaveChanges();
                return new csResponse { StatusCode = HttpStatusCode.Created,
                                        Message = "El registro se ha insertado correctamente",
                                        Data = _object};
            }
            catch (Exception ex)
            {
                string innerMsg ="";
                if (ex.InnerException != null) { innerMsg = ex.InnerException.Message; }
                return new csResponse { StatusCode = HttpStatusCode.BadRequest,
                                        Message = "No se ha insertado el registro. Error: " + ex.Message
                                        + "\n InnerException Message: " + innerMsg,
                                        Data = null };
                }
        }

        public Task<csResponse> Delete(Movimiento _object)
        {
            throw new NotImplementedException();
        }

        public Task<csResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<csResponse> Read()
        {
            try
            {
                var movimientos = from c in _context.Movimientos
                                  .Include(cat => cat.Categoria)
                                  select c;

                if (!movimientos.Any()) 
                {
                    return new csResponse { StatusCode = HttpStatusCode.NoContent,
                                              Message = "No se han encontrado elementos.",
                                              Data = movimientos.ToList<Movimiento>() };
                }
                else
                {
                    return new csResponse { StatusCode = HttpStatusCode.OK,
                                            Message = "Operacion ejecutada correctamente",
                                            Data = movimientos.ToList<Movimiento>() };
                }
            }
            catch (Exception ex)
            {
                return new csResponse() { StatusCode = HttpStatusCode.InternalServerError, Message = "Ha ocurrido un error no controlado: \n" + ex.Message };
            }
        }

        public Task<csResponse> Update(int id, Movimiento _object)
        {
            throw new NotImplementedException();
        }
    }
}
