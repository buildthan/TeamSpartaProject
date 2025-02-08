using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartanTeamProject
{
    public class ConsoleUtility
    {
        public static int GetInput(int min, int max)
        {
            int select = 0;

            while (true)
            {
                try
                {
                    string temp = "";
                    temp = Console.ReadLine();
                    select = int.Parse(temp);
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("잘못된 값입니다. 다시 입력해주십시오.");
                    Console.WriteLine();
                    //숫자입력을 안해 오류가 생겼다면
                    continue;
                    //다시 입력받으세요.
                }

                if (select >= min && select <= max)
                {
                    return select;
                }else
                {
                    Console.WriteLine();
                    Console.WriteLine("잘못된 값입니다. 다시 입력해주십시오.");
                    Console.WriteLine();
                    //정해진 범위 내의 값 입력이 아니라면
                    continue;
                    //다시 입력 받으세요.
                }
            }
        }

        public static void ForegroundColor_DarkGray(string s) //글씨색을 회색으로 바꿈
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
