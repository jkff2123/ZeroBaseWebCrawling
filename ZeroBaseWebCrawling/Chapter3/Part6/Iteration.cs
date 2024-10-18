namespace ZeroBaseWebCrawling.Chapter3.Part6
{
    public class Iteration
    {
        public static void RunIterationByHand()
        {
            Console.WriteLine(1);
            Console.WriteLine(2);
            Console.WriteLine(3);
            Console.WriteLine(4);
            Console.WriteLine(5);
            Console.WriteLine(6);
            Console.WriteLine(7);
            Console.WriteLine(8);
            Console.WriteLine(9);
            Console.WriteLine(10);
        }
        public static void RunIteration()
        {
            // 1부터 10까지
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            // 1부터 10까지, 4면 건너뛰기, 6이면 종료
            for(int i = 1;i <= 10; i++)
            {
                if (i == 4)
                {
                    Console.WriteLine("continue");
                    continue;
                }
                else if (i == 6)
                {
                    Console.WriteLine("break");
                    break;
                }
                Console.WriteLine(i);
            }

            // foreach 사용
            var list = new int[] { 1, 2, 3, 4, 5 };
            foreach (var e in list)
            {
                Console.WriteLine(e);
            }
        }
    }
}
