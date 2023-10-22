using System;

namespace test02
{
    public class Lory : Car
    {
        private double loadCapacity;
        public Lory(string mark, int prodYear, double loadCapacity) : base(mark, prodYear)
        {
            this.loadCapacity = loadCapacity;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"The load capacity is {loadCapacity}");
        }
    }
}
