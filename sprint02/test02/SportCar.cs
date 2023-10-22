using System;

namespace test02
{
    public class SportCar : Car
    {
        private int maxSpeed;
        public SportCar(string mark, int prodYear, int maxSpeed) : base(mark, prodYear)
        {
            this.maxSpeed = maxSpeed;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Maximum speed is {maxSpeed}");
        }
    }
}
