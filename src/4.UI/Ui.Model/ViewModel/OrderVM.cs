namespace Ui.Model.ViewModel
{
    public class OrderVM
    {
        public int Id { get; set; }

        public DateTime FechaCompra { get; set; }

        public decimal Monto { get; set; }

        public int? UsuarioId { get; set; }

        public IEnumerable<ProductVM> Products { get; set; }
    }
}
