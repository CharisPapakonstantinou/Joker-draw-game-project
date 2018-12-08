using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDrawNumbersSecondStage
{ 
    public class Category
    {
        private static double budget = 1000;

        static int n1 = 0, n2 = 0, n3 = 0, n4 = 0, n5 = 0, n6 = 0, n7 = 0, n8 = 0, n9 = 0, n10 = 0; // THE NUMBERS OF PLAYERS OF EVERY CASE

        static double n1budget = 0, n2budget = 0, n3budget = 0, n4budget = 0, n5budget = 0; // THE BUDGET OF EVERY CASE 
        static double n6budget = 0, n7budget = 0, n8budget = 0, n9budget = 0, n10budget = 0;

        public void IncreaseStatic_n_AndFindCaseBudget (string playerResult) // SUBSCRIBER OF findNumberOfResults
        {         
                switch (playerResult)
                {
                    case "5 + 1":
                        n1++;
                        n1budget = budget * 0.4;
                        break;
                    case "5":
                        n2++;
                        n2budget = budget * 0.25;
                        break;
                    case "4 + 1":
                        n3++;
                        n3budget = budget * 0.15;
                        break;
                    case "4":
                        n4++;
                        n4budget = budget * 0.05;
                        break;
                    case "3 + 1":
                        n5++;
                        n5budget = budget * 0.05;
                        break;
                    case "3":
                        n6++;
                        n6budget = budget * 0.04;
                        break;
                    case "2 + 1":
                        n7++;
                        n7budget = budget * 0.035;
                        break;
                    case "2":
                        n8++;
                        n8budget = budget * 0.015;
                        break;
                    case "1 + 1":
                        n9++;
                        n9budget = budget * 0.01;
                        break;
                    default:
                        n10++;
                        n10budget = 0;
                        break;
                }
        }// end of method

        private void FindNewBudgetAndInitializeToZeroStaticMembers()
        {
            budget = 1000 + (budget - n1budget - n2budget - n3budget - n4budget // THE BADGET AFTER A DRAW
                - n5budget - n6budget - n7budget - n8budget - n9budget - n10budget);

            n1 = 0; n2 = 0; n3 = 0; n4 = 0; n5 = 0; n6 = 0; n7 = 0; n8 = 0; n9 = 0; n10 = 0; // THE NUMBER OF PLAYERS THAT HAVE A RESULT AFTER A DRAW

            n1budget = 0; n2budget = 0; n3budget = 0; n4budget = 0; n5budget = 0; // THESE ARE THE BUDGETS OF EVERY DRAW RESULT 
            n6budget = 0; n7budget = 0; n8budget = 0; n9budget = 0; n10budget = 0;
        }


        public void GetYourResult()
        {
            StringBuilder myBuilder = new StringBuilder();

            myBuilder
                .AppendLine($"BUDGET {budget}")
                .AppendLine($"{n1} Players -> RESULT : 5 + 1 -> Won {n1budget}")
                .AppendLine($"{n2} Players -> RESULT : 5 -> Won {n2budget}")
                .AppendLine($"{n3} Players -> RESULT : 4 + 1 -> Won {n3budget}")
                .AppendLine($"{n4} Players -> RESULT : 4 -> Won {n4budget}")
                .AppendLine($"{n4} Players -> RESULT : 3 + 1 -> Won {n5budget}")
                .AppendLine($"{n6} Players -> RESULT : 3 -> Won {n6budget}")
                .AppendLine($"{n7} Players -> RESULT : 2 + 1 -> Won {n7budget}")
                .AppendLine($"{n8} Players -> RESULT : 2 -> Won {n8budget}")
                .AppendLine($"{n9} Players -> RESULT : 1 + 1 -> Won {n9budget}")
                .AppendLine($"{n10} Players Tipota");

            this.FindNewBudgetAndInitializeToZeroStaticMembers();

            Console.WriteLine(myBuilder);
        }
    }
}
