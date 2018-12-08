using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDrawNumbersSecondStage
{
    class Draw
    {
        private List<Player> listWithAllPlayers; //= new List<Player>();
        private Player player; // PROPERTY TUPOU Player
        private List<int> listWithDrawNumbers; //LISTA POU PERIEXEI TUXAIOUS ARITHMOUS
        private List<int> jockerDrawNumber; // //LISTA POU PERIEXEI TON ARITHMO JOKER
        private FIndNumberOfResults findNumberOfResults; // pedio findNumberOfResults to opoio einai Delegate
        private Category FinalDrawResults; // TA TELIKA APOTELESMATA THS KATHE KLIROSHS

        private Statistics allDrawNumbersStatistics;

        private static List<int> listAllDrawNumbers = new List<int>(); // EDW THA MPOUN OLOI KLIROTHENTES ARITHMOI

        public Draw()
        {
            // Fill_ListWithDrawNumbersFill_JokerDrawNumber(); // gemizei tous klirothentes arithmous
            HowManyPlayersWillJoin();
            FinalDrawResults = new Category();
            allDrawNumbersStatistics = new Statistics();
        }

        public void Fill_ListWithDrawNumbersFill_JokerDrawNumber()
        {
            // H GetUniqueRandomNumbers5, 1, 45) MOU EPISTREFEI MIA OLOKLIRI LISTA ME INTEGERS GI AUTO DEN XREIAZETAI NA DIMIOURGISO LISTA
            listWithDrawNumbers = NumbersMachine.GetListWithUniqueRandomNumbers(5, 1, 45); //pernaei tous tuxaious arithmous sth lista
            listWithDrawNumbers.Sort();
            jockerDrawNumber = NumbersMachine.GetListWithUniqueRandomNumbers(1, 1, 20); // pernaei to tzoker sth lista

            this.AddDrawNumbersTo_listAllDrawNumbers(listWithDrawNumbers, jockerDrawNumber);
        }

        private void AddDrawNumbersTo_listAllDrawNumbers(List<int> drawNumbers, List<int> jockerNumber) // PERNAEI TOUS DRAW NUMBERS STHN LISTA listAllDrawNumbers 
        {
            for (int i = 0; i < drawNumbers.Count; i++)
            {
                listAllDrawNumbers.Add(drawNumbers[i]);
            }

            for (int i = 0; i < jockerNumber.Count; i++)
            {
                listAllDrawNumbers.Add(jockerNumber[i]);
            }
        }

        public void HowManyPlayersWillJoin()
        {
            int nPlayers;
            listWithAllPlayers = new List<Player>();
            do //ELEGXOS INPUT
            {
                try
                {
                    Console.WriteLine("How many players will join?");
                    nPlayers = int.Parse(Console.ReadLine());
                    break;
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }
               
            } while (true);

            for (int i = 0; i < nPlayers; i++)
            {
                player = new Player();
                listWithAllPlayers.Add(player); // ADD TON KATHE PAIXTI STHN LISTA listWithAllPlayers
            }
        }

        public void Show_ListWithDrawNumbers()
        {
            Console.Write("DRAW NUMBERS: ");

            foreach (var number in listWithDrawNumbers)
            {
                Console.Write(number + " ");
            }

            foreach (var number in jockerDrawNumber)
            {
                Console.WriteLine(number + " " );
            }
        }

        public void Show_ListWithPlayersNumbers()
        {
            int i = 0;
            foreach (Player player in listWithAllPlayers)
            {
                i++;

                Console.Write($"Player {i} numbers: ");
                foreach (int number in player.playerNumbers)
                {
                    Console.Write(number + " ");
                }

                foreach (int number in player.playerJokerNumber)
                {
                    Console.WriteLine(number + " " );
                }
            }       
        }

        public void PlayersDrawResult() // vriskei to apotelesma tis klirosis tou kathe paixti
        {
            foreach (Player player in listWithAllPlayers)
            {
                int n1 = NumbersMachine.CheckHowManyNumbersOfTwoListsAreTheSame(player.playerNumbers, listWithDrawNumbers);
                int n2 = NumbersMachine.CheckHowManyNumbersOfTwoListsAreTheSame(player.playerJokerNumber, jockerDrawNumber);

                // TO APOTELESMA THS KLIROSIS GIA TON KATHE PAIXTI THA EINAI THS MORFHS 5 + 1 ... 5 ... 4 + 1... 4 ...
                if (n2 != 0)
                    player.DrawResult = $"{n1} + {n2}";
                else
                    player.DrawResult = $"{n1}"; // TO PROSOPIKO APOTELESMA THS KLIROSIS TOU PAIXTI

                findNumberOfResults(player.DrawResult);  // edo einai to event

            }
        }

        private static int GiveNumberDrawGames() // RETURNS AN INTEGER
        {
            int nDraws = 0;
            do
            {
                try
                {
                    Console.Write("How many draws? : ");
                    nDraws = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                }

            } while (true);

            return nDraws;
        }

        public static void PlayAdrawGame()
        {
            int nDraws = GiveNumberDrawGames();
            var draw = new Draw();

            draw.findNumberOfResults += new FIndNumberOfResults(draw.FinalDrawResults.IncreaseStatic_n_AndFindCaseBudget); // IncreaseStatic_n_AndFindBudget IS THE SUBSCRIBER

            for (int i=0; i< nDraws; i++)
            {
                Console.WriteLine();
                Console.Write($"PRESS ANY KEY TO START {i + 1} DRAW : ");
                Console.ReadLine();

                draw.Fill_ListWithDrawNumbersFill_JokerDrawNumber(); // gemizei tous klirothentes arithmous

                Console.WriteLine($"\r\n*DRAW {i + 1} ");

                draw.Show_ListWithDrawNumbers(); // emfanizei tou klirothentes arithmous
                draw.Show_ListWithPlayersNumbers();

                Console.WriteLine("\r\nDRAW RESULTS");
                draw.PlayersDrawResult();
                draw.FinalDrawResults.GetYourResult();
            }

            Console.WriteLine(draw.allDrawNumbersStatistics.GiveMostCommonNumbersAndHowManyTimesRepeatedFrom_givenList(listAllDrawNumbers));
            Console.WriteLine();
            Console.WriteLine(draw.allDrawNumbersStatistics.GiveLeastCommonNumbersAndHowManyTimesRepeatedFrom_givenList(listAllDrawNumbers));

        }
    }
}
