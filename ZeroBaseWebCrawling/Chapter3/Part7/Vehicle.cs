namespace ZeroBaseWebCrawling.Chapter3.Part7
{
    public class Vehicle
    {
        private string cannotSee;
        public string Type;
        public int Doors;
        public int Wheels;
        public void PrintInfo()
        {
            Console.WriteLine("Vehicle Type = " + Type);
            Console.WriteLine("Doors = " + Doors);
            Console.WriteLine("Wheels = " + Wheels);
        }
    }

    public class ClassExecute
    {
        public static void Run()
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Type = "Car";
            vehicle.Doors = 4;
            vehicle.Wheels = 4;

            vehicle.PrintInfo();
        }
    }
}
