using System;
using System.Linq;
using System.Text;
namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string s = "aaaabbccccccccaaAA";

            var result=s.GroupBy(c=>c);

            StringBuilder sb = new StringBuilder();
            int count = 1;
            int i = 0;
            for (i = 0; i < s.Length - 1; i++)
            {

                if (s[i] == s[i + 1])
                {
                    count = count + 1;
                }
                else
                {
                    Console.WriteLine(s[i]+" "+count);
                    count = 1;
                }
            
                //sb = sb.Append( item.Key).Append(item.Count());   


            }
            Console.WriteLine(s[i] + " " + count);
            Console.WriteLine(sb);
        }

        

        
    }
}
