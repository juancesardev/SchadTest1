namespace test4.Models
{
    public class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string CustName { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public bool? Status { get; set; }
        public int CustomerTypeId { get; set; }

        public virtual CustomerType CustomerType { get; set; } = null!;// = null!;
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
