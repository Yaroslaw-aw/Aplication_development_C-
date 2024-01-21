namespace Test
{
    internal class Program
    {
        static bool ValidBrackets(string str)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var ch in str)
            {
                if (ch == '[') stack.Push(']');
                if (ch == '(') stack.Push(')');
                if (ch == '{') stack.Push('}');

                if ("])}".Contains(ch))
                {
                    if (stack.Count == 0) return false;
                    if (stack.Pop() != ch) return false;
                }
            }
            return stack.Count == 0;
        }

        static void Main(string[] args)
        {
            string brakets = "((( [ ) ] )) "; 

            Console.WriteLine(ValidBrackets(brakets));


            //List<BaseHero> heroes = new List<BaseHero>();

            //BaseHero cleric = new Magician();

            //heroes.Add(cleric);

            //if (heroes.BinarySearch(cleric) >= 0)
            //{
            //    Console.WriteLine("Содержит");
            //}
            //else
            //{
            //    Console.WriteLine("Не содержит"); 
            //}

        }
    }
}
