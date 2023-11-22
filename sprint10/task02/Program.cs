using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace task02
{
    // Consider the class Customer from the previous task (1) with the SRP principle applied. 
    //Let’s say that we want to add additional functionality.After user registration, we want to send email and sms to that user.According to the SRP principle, we would add additional classes.You have to create:
    //1) public abstract class NotificationService with abstract method SendNotification().
    //2) public class MailService(inherited from class NotificationService) with:
    //- three string properties: Email, EmailTitle, and EmailBody;
    //- boolean method ValidEmail() that returns True if the Email contains "@";
    //- overriden method  SendNotification() that output in console formatted string ("Mail:{0}, Title:{1}, Body:{2}", Email, EmailTitle, EmailBody).
    //3) public class SmsService(inherited from class NotificationService) with:
    //- two string properties Number, SmsText;
    //- overriden method  SendNotification() that output in console formatted string ("Number:{0}, Message:{1}", Number, SmsText).
    //The result of the registration of the new user would be as follows: ...

    // Console.WriteLine(Reflector.HasTypeDeclaredMethod(typeof(MyProgram.MailService), "ValidEmail", new Type[] { typeof(string)}));
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class Customer
    {
        // Property Injection
        public static NotificationService? NotificationService { get; set; }
        public static void Register(string email, string password)
        {
            try
            {
                // code for registering user
                NotificationService = new MailService() { Email = email, EmailTitle = "User registration", EmailBody = "Body of message..." };
                if (NotificationService is MailService ms)
                {
                    if (ms.ValidEmail())
                    {
                        NotificationService.SendNotification();
                    }
                }
                NotificationService = new SmsService() { Number = "111 111 111", SmsText = "User successfully registered..." };
                NotificationService.SendNotification();
            }
            catch (Exception ex)
            {
                // log if error occurs
                throw;
            }
        }
    }

    public abstract class NotificationService
    {
        public abstract void SendNotification();
    }
    public class MailService : NotificationService
    {
        public string Email { get; set; }
        public string EmailTitle { get; set; }
        public string EmailBody { get; set; }
        public bool ValidEmail() => Email.Contains("@");
        public override void SendNotification() =>
            // send email
            Console.WriteLine(string.Format("Mail:{0}, Title:{1}, Body:{2}", Email, EmailTitle, EmailBody));
    }
    public class SmsService : NotificationService
    {
        public string Number { get; set; }
        public string SmsText { get; set; }
        public override void SendNotification() =>
            // send sms
            Console.WriteLine(string.Format("Number:{0}, Message:{1}", Number, SmsText));
    }
}