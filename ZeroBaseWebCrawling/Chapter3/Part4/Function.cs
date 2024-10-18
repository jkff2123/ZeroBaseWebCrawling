namespace ZeroBaseWebCrawling.Chapter3.Part4
{
    public class Function
    {
        public static void Function1()
        {
            Console.WriteLine("이것은 Function1 입니다.");
        }
        public static void Function2(string message)
        {
            Console.WriteLine(message);
        }
        public static string Function3()
        {
            return "이것은 Function3 입니다.";
        }
        public static void Run()
        {
            Function1();
            Function2("이것은 Function2 입니다.");
            Console.WriteLine(Function3());

            // val 키워드 사용
            var val1 = 1;                               // int 형
            var val2 = "Hi";                            // 문자형
            var val3 = new int[] { 1, 2, 3, 4 };        // 배열형
        }
    }
}
