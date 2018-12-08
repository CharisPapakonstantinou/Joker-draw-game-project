using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDrawNumbersSecondStage
{
    public class Player 
    {
       public List<int> playerNumbers { get; private set; } 
       public List<int> playerJokerNumber { get; private set; }
       public string DrawResult { get; set; }

        public Player()
        {
            if (RandomOrUserNumbers())
            {
                // H GetListWithUniqueRandomNumbers MOU EPISTREFEI MIA OLOKLIRI tempListAllDrawNumbers ME INTEGERS GI AUTO DEN XREIAZETAI NA DIMIOURGISO tempListAllDrawNumbers
                playerNumbers = NumbersMachine.GetListWithUniqueRandomNumbers(5, 1, 45); //VAZEI STHN tempListAllDrawNumbers 5 MONADIKOUS ARITHMOUS
                playerJokerNumber = NumbersMachine.GetListWithUniqueRandomNumbers(1, 1, 20); // VAZEI STHN tempListAllDrawNumbers 1 MONADIKO ARITHMO
            }
            else
            {
                playerNumbers = NumbersMachine.GetListWithUniqueNumbersFromUser(5, 1, 45);
                playerJokerNumber = NumbersMachine.GetListWithUniqueNumbersFromUser(1, 1, 20);
            }
        }

        private  bool RandomOrUserNumbers()
        {
            Console.Write("Do you want random numbers or numbers from user? press 'r' for random or something else for 'user': ");
            string answear = Console.ReadLine();

            if (answear == "r")
                return true;
            else
                return false;

        }
    }
}
