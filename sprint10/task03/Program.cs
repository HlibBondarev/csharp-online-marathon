using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System;

namespace task03
{
    //Consider the previous tasks(1) and(2) with the SRP and OCP principles applied.Let’s say that we want to add additional
    //functionality to the NotificationService class for writing notification records to Database but these records have to be
    //only for emails.
    //
    //The above code in the Customer class will fail because of the AddNotificationToDB method in the smsService class called.
    //One solution is not to call the above method but we raise another problem. We have a class that implements the method that
    //is not used.According to LSP you have to ensure that new derived classes extend the base classes without changing their behavior.
    //
    //You have to fix this issue by implementing in the following way:
    //- create an interface INotification with the method SendNotification();
    //- create an interface INotificationToDB with the method AddNotificationToDB();
    //- the class MailService has to implement both interfaces INotification and INotificationToDB;
    //- the class SmsService has to implement INotification;
    //- change the class Customer. You may comment out the code that uses the call of the method AddNotificationToDB().
    // Note.You may use the console notification from the method SendNotification() in the classes MailService and SmsService
    // as it was described in previous tasks.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class Customer
    {
        public static void Register(string email, string password)
        {
            try
            {
                // code for registering user

                var mailService = new MailService();
                mailService.Email = email;
                mailService.EmailBody = "Body of message...";
                mailService.EmailTitle = "User registration";

                if (mailService.ValidEmail())
                {
                    mailService.SendNotification();
                    mailService.AddNotificationToDB();
                }

                var smsService = new SmsService();
                smsService.Number = "111 111 111";
                smsService.SmsText = "User successfully registered...";

                smsService.SendNotification();
            }
            catch (Exception ex)
            {
                // log if error occurs
                throw;
            }
        }
    }
    public interface INotification
    {
        void SendNotification();
    }
    public interface INotificationToDB
    {
        void AddNotificationToDB();
    }
    public class MailService : INotification, INotificationToDB
    {
        public string Email { get; set; }
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }
        public bool ValidEmail() => Email.Contains("@");
        public void SendNotification() =>
            // send email
            Console.WriteLine(string.Format("Mail:{0}, Title:{1}, Body:{2}", Email, EmailTitle, EmailBody));
        public void AddNotificationToDB()
        {
            // add to database
        }
    }
    public class SmsService : INotification
    {
        public string Number { get; set; }
        public string SmsText { get; set; }
        public void SendNotification() =>
            // send sms
            Console.WriteLine(string.Format("Number:{0}, Message:{1}", Number, SmsText));
    }
}
