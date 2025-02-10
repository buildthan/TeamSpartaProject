using System;
using System.Web;



namespace SpartanTeamProject
{

    public static class ConsoleStyler
    {
        // 고양이 ASCII 아트 출력
        public static void PrintCatArt()
        {
            //string htmlEncodedText = "&amp;";
            //string decodedText = HttpUtility.HtmlDecode(htmlEncodedText);
            //Console.WriteLine(decodedText); // 출력: &


            string catArt = @"

                 *     ,MMM8&amp;&amp;&amp;.            *
                      MMMM88&amp;&amp;&amp;&amp;&amp;    .
                     MMMM88&amp;&amp;&amp;&amp;&amp;&amp;&amp;
         *           MMM88&amp;&amp;&amp;&amp;&amp;&amp;&amp;&amp;
                     MMM88&amp;&amp;&amp;&amp;&amp;&amp;&amp;&amp;
                     'MMM88&amp;&amp;&amp;&amp;&amp;&amp;'
                       'MMM8&amp;&amp;&amp;'      *    _
              |\___/|                      \\
              )     (    |\_/|              ||    '
             =\     /=   )a a '._.-""""""""-.  //
               )===(    =\T_= /    ~  ~  \//
              /     \     `""`\   ~   / ~  /
              |     |         |~   \ |  ~/
             /       \         \  ~/- \ ~\
             \       /         || |  // /`
      aac_/\_/\_   _/_/\_/\_/\_((_|\((_//\_/\_/\_
      |  |  |  |( (  |  |  |  |  |  |  |  |  |  |
      |  |  |  | ) ) |  |  |  |  |  |  |  |  |  |
      |  |  |  |(_(  |  |  |  |  |  |  |  |  |  |    
      |  |  |  |  |  |  |  |  |  |  |  |  |  |  |
      |  |  |  |  |  |  |  |  |  |  |  |  |  |  |

    ";
            Console.ForegroundColor = ConsoleColor.Green; // 초록색 고양이
            Console.WriteLine(catArt);
            Console.ResetColor();
        }

        // 구분선 출력
        public static void DrawSeparator(char symbol = '=', int length = 40)
        {
            Console.WriteLine(new string(symbol, length));
        }

        // 중앙 정렬 텍스트 출력
        public static void WriteCentered(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            int padding = (Console.WindowWidth - text.Length) / 2;
            Console.WriteLine(new string(' ', Math.Max(0, padding)) + text);
            Console.ResetColor();
        }
    }
}



