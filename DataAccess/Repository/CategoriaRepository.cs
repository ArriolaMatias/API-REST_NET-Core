using DataAccess.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class CategoriaRepository : IRepository<Categoria>
    {
        EFContext _context;
        public CategoriaRepository(EFContext context) 
        { 
            this._context = context;
            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public void Create(Categoria _object)
        {
            _context.Add(_object);
            _context.SaveChanges();
        }

        public void Delete(Categoria _categoria)
        {
            _context.Remove(_categoria);
            _context.SaveChanges();
        }

        public Categoria? GetById(int id)
        {

            var categoria = from c in _context.Categorias
                            where c.Id == id
                            select c;

            return categoria.ToList().FirstOrDefault();
        }

        public IEnumerable<Categoria> Read()
        {
            var categorias = from c in _context.Categorias
                             select c;
            return categorias.ToList<Categoria>();
        }

        public void Update(int id, Categoria _object)
        {
            _context.Entry(_object).State = EntityState.Modified;
            _context.SaveChanges();
            
        }
    }
}
