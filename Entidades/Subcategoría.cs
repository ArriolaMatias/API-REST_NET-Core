namespace Entities
{
    public class Subcategoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Detalle { get; set; }
        public Categoria CategoriaPadre { get; set; }
    }
}
