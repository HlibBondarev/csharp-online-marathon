using System.ComponentModel;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace task05
{
    // From the previous tasks (1) - (4) we had the following situations with the Customer class:
    // ...
    // We have a lot of code here. DIP says that high-level modules/classes should not depend upon low-level modules/classes.
    // Both should depend upon abstractions. Secondly, abstractions should not depend upon details. Details should depend upon
    // abstractions
    //
    // Let’s isolate this class Customer as a separate component. You have to define within this class
    // - the constructor with INotification parameter;
    // - leave method Register() with two string input parameters email and password. Leave only empty "try ... catch ..." statement
    //   in the body of the method;
    // - leave method SendNotification() with INotification notification parameter.It will initiate the console output of notification
    //   (as in the previous tasks).
    // Classes MailService, SmsService, and interfaces INotification, INotificationToDB, and INotificationToDBRead use without any change.
    // The instantiation of the classes will cause the output as follows:
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class Customer
    {
        INotification notification;
        public Customer(INotification notification) => this.notification = notification;
        public void SendNotification(INotification notification) => notification.SendNotification();
        public void Register(string email, string password)
        {
            try
            {
                // code for registering user
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
        }

        public void ReadNotification()
        {
            // read from database
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