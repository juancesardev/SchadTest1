using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace test4.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public int Qty { get; set; }
        [Display(Name = "Price / Without ITBIS")]
        public decimal Price { get; set; }
        public decimal TotalItbis { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

        public virtual Invoice Customer { get; set; } = null!;
    }
}
