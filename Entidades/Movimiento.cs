namespace Entities
{
    public class Movimiento
    {
        public int Id { get; set; }
        public string FormaDePago { get; set; }
        public decimal Monto { get; set; }
        public string Concepto { get; set; }
        public DateTime Fecha { get; set; }
        public string? Detalle { get; set; }
        public Categoria? Categoria { get; set; }
        public int? CategoriaId { get; set; }
        //public Subcategoria? Subcategoria { get; set; }
        //public int SubcategoriaID { get; set; }
        public int? IdAsociado { get; set; }
        public Tipo TipoDeMovimiento { get; set; }
        
        public enum Tipo

        {
            _INGRESO,
            EGRESO
        }
    }
}
