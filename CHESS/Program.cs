using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHESS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\tWelcome to");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"                                                         
                   ,--,                                  
  ,----..        ,--.'|    ,---,.  .--.--.    .--.--.    
 /   /   \    ,--,  | :  ,'  .' | /  /    '. /  /    '.  
|   :     :,---.'|  : ',---.'   ||  :  /`. /|  :  /`. /  
.   |  ;. /|   | : _' ||   |   .';  |  |--` ;  |  |--`   
.   ; /--` :   : |.'  |:   :  |-,|  :  ;_   |  :  ;_     
;   | ;    |   ' '  ; ::   |  ;/| \  \    `. \  \    `.  
|   : |    '   |  .'. ||   :   .'  `----.   \ `----.   \ 
.   | '___ |   | :  | '|   |  |-,  __ \  \  | __ \  \  | 
'   ; : .'|'   : |  : ;'   :  ;/| /  /`--'  //  /`--'  / 
'   | '/  :|   | '  ,/ |   |    \'--'.     /'--'.     /  
|   :    / ;   : ;--'  |   :   .'  `--'---'   `--'---'   
 \   \ .'  |   ,/      |   | ,'                          
  `---`    '---'       `----'                            
                                                         ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\tPress Any Key to Continue");
            Console.Read();
            Console.WriteLine("To begin a game, type 'begin' \nTo configure your game, type 'options' \nTo quit, type 'exit' or 'quit'");
            string line = "";
            while (line.ToLower() != "quit" && line.ToLower() != "exit")
            {
                line = Console.ReadLine();
            }

        }
    }
}
