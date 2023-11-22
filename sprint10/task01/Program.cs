namespace task01
{
    // Following SRP principle, the responsibility of the Customer class should be only the Register method.
    // The Customer class should not worry about the definition of Validation Rules of the Email address and
    // sending messages.
    // Please change the class Customer and create the class MailService following the SRP principle.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Customer
    {
        readonly MailService mailService;
        // Constructor Injection
        public Customer(MailService mailService) => this.mailService = mailService;
        public void Register(string email, string password)
        {
            try
            {
                if (mailService.ValidEmail(email))
                {
                    // code for registering user
                    mailService.SendEmail(email, "Email title", "Email body");
                }
            }
            catch (Exception ex)
            {
                // log if error occurs
                throw;
            }
        }
    }

    public class MailService
    {
        public bool ValidEmail(string email) => email.Contains(email);
        public void SendEmail(string email, string emailTitle, string emailBody) =>
            // send email
            Console.WriteLine(string.Format("Mail:{0}, Title:{1}, Body:{2}", email, emailTitle, emailBody));
    }
}