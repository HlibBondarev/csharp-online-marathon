namespace task12
{
// An Invoice class might have the responsibility of calculating various amounts based on its data. In that case, it probably
// shouldn’t know how to retrieve this data from a database, or how to format an invoice for print or display or logging,
// sending Email, etc.
// So in the answer preload, you can see the Invoice class that contains almost the whole probable logic. This Invoice class
// has its own responsibility i.e.Add, Delete invoices, and also has extra activities like logging and Sending emails as well.
// You have to make the refactoring according to the SRP so that the Invoice class can happily delegate additional activities
// to other types.This way Invoice class can concentrate on Invoice related activities.


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Invoice
    {
        public long Amount { get; set; }
        public DateTime InvoiceDate { get; set; }
        public void Add()
        {
            Console.WriteLine("Adding amount...");
            // Code for adding invoice
            // Once Invoice has been added , send mail 
            string mailMessage = "Your invoice is ready.";
            MailSender.SendEmail(mailMessage);
        }
        public void Delete()
        {
            Console.WriteLine("Deleting amount...");
            // Code for Delete invoice
        }
    }
    public interface IFileLogger
    {
        void Check();
        void Debug();
        void Info();
    }
    public class FileLogger : IFileLogger
    {
        readonly Invoice invoice;
        // Constructor Injection
        public FileLogger(Invoice invoice)
        {
            this.invoice = invoice;
        }
        public FileLogger()
        {
            // Code for initialization i.e. Creating Log file with specified  
            // details
            this.invoice = new Invoice();
        }
        public void Check()
        {
            /// log check result to file
        }
        public void Debug()
        {
            /// log debug result to file
        }
        public void Info()
        {
            /// log info result to file
        }
    }
    public class MailSender
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public static void SendEmail(string mailMessage)
        {
            Console.WriteLine("Sending Email: {0}", mailMessage);
            // Code for getting Email setting and send invoice mail
        }
    }
}