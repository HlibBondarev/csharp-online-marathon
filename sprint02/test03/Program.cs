using System;

namespace test03
{
    public class Science
    {
        public virtual void Awards()
        {
            Console.WriteLine("We can obtain the Nobel Prize");
        }
    }

    public class Mathematics: Science
    {
        public override void Awards()
        {
            Console.WriteLine("We don't need any awards, but we still can obtain The Abel Prize that nobody else can!");
        }
    }

    public class Physics: Science
    {
    }
}
