using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDrawNumbersSecondStage
{
    public abstract class NumbersMachine
    {
        private static List<int> ListWithNumbers = new List<int>();

        private static List<int> GivetempListAllDrawNumbersndClear_ListWithNumbers() // KANEI TON KATALLILO ELEGXO EPISTREFEI MIA tempListAllDrawNumbers KAI KANEI CLEAR THN STATIC listWithNumbers
        {
            var listWithRandomNumbers = new List<int>();

            //checkListWithNumbersCounter++;
            if (ListWithNumbers.Count == 6)
            {   
                ListWithNumbers.Reverse();

                listWithRandomNumbers.Add(ListWithNumbers[0]);
                ListWithNumbers.Clear();
               // checkListWithNumbersCounter = 0;
            }
            else
            {
                foreach (int number in ListWithNumbers)
                {
                    listWithRandomNumbers.Add(number);
                }
            }

            return listWithRandomNumbers;
        }

        public static List<int> GetListWithUniqueRandomNumbers(int howManyNumbersToGet, int minValue, int maxValue) // PERNAEI TYXAIOUS ARITHMOUS STH tempListAllDrawNumbers RESULT NUMBERS
        {          
            var r = new Random();
            int randomNumber = 0;

            for (int i = 0; i < howManyNumbersToGet; i++)
            {
                do
                {
                    randomNumber = r.Next(minValue, maxValue);

                    if (!NumberExists(randomNumber, ListWithNumbers))
                    {
                        ListWithNumbers.Add(randomNumber);
                        break;
                    }
                } while (true);
            }

            var listWithRandomNumbers = GivetempListAllDrawNumbersndClear_ListWithNumbers();

            return listWithRandomNumbers; // EPISTREFEI TI tempListAllDrawNumbers POU EXEI RANDOM ARITHMOUS
        } // end

        public static List<int> GetListWithUniqueNumbersFromUser(int howManyNumbers, int minValue, int maxValue)
        {
            int givenNumber;
            for (int i = 0; i < howManyNumbers; i++)
            {
                do
                {
                    try
                    {
                        Console.Write("Give a number between {0} and {1}: ", minValue, maxValue);
                        givenNumber = int.Parse(Console.ReadLine());
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Invalid Input!");
                        continue;
                    }
                  

                    if (!NumberExists(givenNumber, ListWithNumbers) && (givenNumber >= minValue && givenNumber <= maxValue))
                    {
                        ListWithNumbers.Add(givenNumber);
                        break;
                    }
                }
                while (true);
            }

            List<int> listWithUserNumbers = GivetempListAllDrawNumbersndClear_ListWithNumbers();

            return listWithUserNumbers; // EPISTREFEI TH tempListAllDrawNumbers POU EXEI TOUS ARITHMOUS POU EGINAN INPUT APO TON USER
        } // end

        private static  bool NumberExists(int existNumber, List<int> listWithNumbers) // ELEGXEI AN O ARITHMOS YPARXEI STH tempListAllDrawNumbers 
        {
            if (listWithNumbers.Exists(p => p.Equals(existNumber)))
                return true;
            else
                return false;
        } // end  

        public static int CheckHowManyNumbersOfTwoListsAreTheSame(List<int> userlistInt, List<int> drawlistInt) // checkarei tous arithmous KAI EPISTREFEI SE STRING MORFI TO APOTELESMA
        {
           
            if (userlistInt.Count != drawlistInt.Count)
                throw new Exception("Lists count must be tha same!");

            int n = 0;
            for (int i = 0; i < drawlistInt.Count ; i++)
            {
                for (int j = 0; j < userlistInt.Count; j++)
                {
                    if (drawlistInt[i] == userlistInt[j])
                        n++;
                }              
            }
            return n ; 
        } // end
    }
}
