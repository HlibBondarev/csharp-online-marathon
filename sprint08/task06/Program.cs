using System.Threading;
using System.Xml.Linq;
using System;
using System.Threading.Channels;

namespace task06
{
    //We have a shop.Due to the situation with coronavirus, there are limitations on the number of buyers that are allowed to be
    //in the shop simultaneously.
    // There are allowed 10 users maximum in the shop.
    // Create a class Buyer. Objects of this class must do their shopping in separate threads.
    // Buyer must be derived from PersonInTheShop class. Don't create PersonInTheShop, it already exists in the same namespace.
    // Implement constructor for Buyer which takes a string argument - thread name.Use this name to set the name of a new thread
    // that will be started.Start the thread in the constructor.
    // Every buyer does shopping in its own thread.Four methods of a base class should be called for every shopping:
    // Enter(), SelectGroceries(), Pay(), Leave().      


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            for (int i = 0; i < 17; i++)
            {
                Buyer buyer=new Buyer($"Buyer={i.ToString()}");
            }

            Console.ReadKey();
        }
    }

    class Buyer : PersonInTheShop
    {
        static int count = 10;
        static SemaphoreSlim semSlim = new SemaphoreSlim(count, count);
        public Buyer(string name)
        {
            Thread buyerThread = new Thread(Shop);
            buyerThread.Name = name;
            buyerThread.Start();
        }

        static void Shop()
        {
            while (count > 0)
            {
                semSlim.Wait();
                Enter();
                SelectGroceries();
                Pay();
                Leave();
                semSlim.Release();
                count--;
            }
        }
    }

    public class PersonInTheShop
    {
        public static void Enter()  {Console.WriteLine("Enter"); Thread.Sleep(1000); }
        public static void SelectGroceries() => Console.WriteLine("Select Groceries");
        public static void Pay() => Console.WriteLine("Pay");
        public static void Leave() => Console.WriteLine("Leave");
    }
}