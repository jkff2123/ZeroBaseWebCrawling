using ZeroBaseWebCrawling.Chapter3.Part7;

namespace ZeroBaseWebCrawling.Chapter3.Part8
{
    public class ExceptionHandling
    {
        public static void RunException1()
        {
            Vehicle vehicle = null;
            vehicle.Type = "Car";
        }

        public static void RunException2()
        {
            Vehicle vehicle = null;
            try
            {
                vehicle.Type = "Car";
            }
            catch
            {
                vehicle = new Vehicle();
                vehicle.Type = "Car";
            }
            finally
            {
                vehicle.PrintInfo();
            }
        }

        public static void RunException3()
        {
            Vehicle vehicle = null;
            try
            {
                vehicle.Type = "Car";
            }
            catch (NullReferenceException)
            {
                vehicle = new Vehicle();
                vehicle.Type = "Car";
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                vehicle.PrintInfo();
            }
        }

        public static void RunException4()
        {
            Vehicle vehicle = null;
            try
            {
                throw new NullReferenceException();
            }
            catch (NullReferenceException)
            {
                vehicle = new Vehicle();
                vehicle.Type = "Car";
            }
        }
    }
}
