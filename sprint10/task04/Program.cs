using System.Threading;

namespace task04
{
    // According to the previous tasks(1), (2), (3) let’s say that we want to add additional functionality to the Notification
    // interface for Reading notifications from Database:
    // With this definition, we obligate the class that inherits from this interface to implement the method for reading
    // notifications.Maybe in some cases, we don’t want to have this but because of the inheritance, we need to define the
    // method in the class even if we don’t want to implement this. The solution for this problem is to separate all the
    // methods that are not used everywhere in a separate interface like as follows:
    // - change the interface INotificationToDB and leave only one method in it(as you consider);
    // - create the interface INotificationToDBRead and define one method in it(as you consider);
    // - the class MailService will implement three interfaces: INotification, INotificationToDB, INotificationToDBRead.
    //   Each of the methods of these interfaces will output some message into the console;
    // - change class Customer if you need.
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
                    mailService.ReadNotification();
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
    public interface INotificationToDBRead
    {
        void ReadNotification();
    }
    public class MailService : INotification, INotificationToDB, INotificationToDBRead
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
            //Console.WriteLine(string.Format("Mail:{0}, Title:{1}, Body:{2}", Email, EmailTitle, EmailBody));
        }
        public void ReadNotification()
        {
            // read from database
            //Console.WriteLine(string.Format("Mail:{0}, Title:{1}, Body:{2}", Email, EmailTitle, EmailBody));
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