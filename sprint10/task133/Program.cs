namespace task133
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Invoice
    {
        public virtual double Discount { get => 0.01; }
        public double GetDiscount(double amount)
        {
            return amount - amount * Discount;
        }
    }
    public class FinalInvoice : Invoice
    {
        public override double Discount { get => 0.03; }
    }
    public class ProposedInvoice : Invoice
    {
        public override double Discount { get => 0.05; }
    }
    public class RecurringInvoice : Invoice
    {
        public override double Discount { get => 0.10; }
    }
    public class OrdinaryInvoice : Invoice
    {
    }
}