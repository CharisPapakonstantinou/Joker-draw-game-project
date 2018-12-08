using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDrawNumbersSecondStage
{
    class Statistics
    {

        public string GiveMostCommonNumbersAndHowManyTimesRepeatedFrom_givenList(List<int> givenList, int number_IfnumberIs_One_CalcuateMostDrawNumbers_Two_SecondMostDrawNumbers_Etc = 3)
        {
            /* H METHODOS AUTH IPOLOGIZEI KAI EPISTREFEI SE ENA STRING 
               TOUS MOST FREQUENT NUMBERS EAN UPARXOUN KAI EFOSON UPARXOUN POSES FORES UPARXOUN
               TOUS SECOND MOST FREQUENT NUMBERS ENA UPARXOUN KAI EFOSON UPARXOUN POSES FORES UPARXOUN
               TOUS THIRD MOST FREQUENT NUMBERS EAN UPARXOUN KAI EFOSON UPARXOUN POSES FORES UPARXOUN
               APO THN LISTA givenList
            */

            List<int> tempListAlldrawNumbers = new List<int>(); // EISAGONTAI TA STOIXEIA THS givenList se mia alli lista
            foreach (int number in givenList)
            {
                tempListAlldrawNumbers.Add(number);
            }
            tempListAlldrawNumbers.Sort();

            string s = "";
            List<int> ListWithCount = new List<int>(); // i lista pou tha periexetai o arithmos pou deixnei poses fores uparxoun oi koinoi arithmoi

            int frequentNumber;

            for (int m = 0; m < number_IfnumberIs_One_CalcuateMostDrawNumbers_Two_SecondMostDrawNumbers_Etc; m++)
            {
                int tempCount = 0;
                int count = 0;
                int tempNumber = 0;
                ListWithCount.Clear(); // KATHE FORA PRIN MPEI STHN do...while katharizei thn lista ListWithCount gia na min periexei elements 

                do
                {
                    count = 0;
                    frequentNumber = 0;
                    tempNumber = 0;

                    for (int l = 0; l < (tempListAlldrawNumbers.Count); l++)
                    {
                        tempNumber = tempListAlldrawNumbers[l];
                        tempCount = 0;

                        for (int j = 0; j < tempListAlldrawNumbers.Count; j++)
                        {
                            if (tempNumber == tempListAlldrawNumbers[j]) // elegxei ton kathe arithmo ths listas me olous tous ipoloipous
                                tempCount++;
                        }
                        if (tempCount >= count)
                        {
                            frequentNumber = tempNumber; // O MOST COMMON NUMBER
                            count = tempCount; // TO COUNT TOU MOST COMMON NUMBER
                        }

                    } //end of for

                    if (frequentNumber == 0) // EAN H SINTHIKI ISXUEI TOTE DEN VRETHIKE KAPOIOS FREQUENT NUMBER
                    {
                        break; // VGAINEI APO THN while
                    }
                    else // AN O frequentNumber DEN EINAI MHDEN TOTE SHMAINEI OTI EXEI VRETHEI KAPOIOS FREQUENT NUMBER 
                    {
                        ListWithCount.Add(count); // ADD count TO LIST
                    }


                    if (ListWithCount[0] == count) // ean to count einai iso me to proto count pou exei mpei sthn lista tote shmainei oti o arithmos pou exei vrethei iparxei oses fores iparxei kai o prohgoumrnos pou eixe vrethei 
                    {

                        for (int a = 0; a < count; a++) // aferei ton pio suxno arithmo apo thn tempListAllDrawNumbers
                        {
                            tempListAlldrawNumbers.Remove(frequentNumber);
                        }

                        if (m == 0)
                            s += "Most draw number: " + frequentNumber + " and exists " + count + " times  " + "\r\n";
                        if (m == 1)
                            s += "Second most draw number: " + frequentNumber + " and exists " + count + " times  " + "\r\n";
                        if (m == 2)
                            s += "Third most draw number: " + frequentNumber + " and exists " + count + " times " + "\r\n";

                    }
                    else // ean to count den einai iso tote shmainei oti o arithmos pou vrethike iparxei ligoteres fores apo ton proigoumeno pou eixe vrethei
                        break; // vgainei apo thn while             

                }
                while (true);

            }
            return s;

        }

        public string GiveLeastCommonNumbersAndHowManyTimesRepeatedFrom_givenList(List<int> givenList, int number_IfnumberIs_One_CalcuateLessDrawNumbers_Two_SecondLessDrawNumbers_Etc = 4)
        {
            /* H METHODOS AUTH IPOLOGIZEI KAI EPISTREFEI SE ENA STRING 
              TOUS LESS FREQUENT NUMBERS EAN UPARXOUN KAI EFOSON UPARXOUN POSES FORES UPARXOUN
              TOUS SECOND LESS FREQUENT NUMBERS ENA UPARXOUN KAI EFOSON UPARXOUN POSES FORES UPARXOUN
              TOUS THIRD LESS FREQUENT NUMBERS EAN UPARXOUN KAI EFOSON UPARXOUN POSES FORES UPARXOUN
              APO THN LISTA givenList
           */

            List<int> tempListAlldrawNumbers = new List<int>(); // EISAGONTAI TA STOIXEIA THS givenList se mia alli lista
            foreach (int number in givenList)
            {
                tempListAlldrawNumbers.Add(number);
            }

            tempListAlldrawNumbers.Sort();

            string s = "";
            List<int> ListWithCount = new List<int>(); // i lista pou tha periexetai o arithmos pou deixnei poses fores uparxoun oi koinoi arithmoi

            int lessFrequentNumber;

            for (int m = 0; m < number_IfnumberIs_One_CalcuateLessDrawNumbers_Two_SecondLessDrawNumbers_Etc; m++)
            {
                int tempCount = 0;
                int count = 0;
                int tempNumber = 0;
                ListWithCount.Clear(); // KATHE FORA PRIN MPEI STHN do...while katharizei thn lista ListWithCount gia na min periexei elements

                do
                {
                    count = 0;
                    lessFrequentNumber = 0;
                    tempNumber = 0;

                    for (int l = 0; l < (tempListAlldrawNumbers.Count); l++)
                    {
                        tempNumber = tempListAlldrawNumbers[l];
                        tempCount = 0;

                        for (int j = 0; j < tempListAlldrawNumbers.Count; j++)
                        {
                            if (tempNumber != tempListAlldrawNumbers[j]) // elegxei ton kathe arithmo ths listas me olous tous ipoloipous
                                tempCount++;
                        }
                        if (tempCount >= count)
                        {
                            lessFrequentNumber = tempNumber; // O MOST COMMON NUMBER
                            count = tempCount; // TO COUNT TOU MOST COMMON NUMBER
                        }

                    } //end of for


                    count = tempListAlldrawNumbers.Count - count;

                    if (lessFrequentNumber == 0) // EAN H SINTHIKI ISXUEI TOTE DEN VRETHIKE KAPOIOS LESSFREQUENT NUMBER
                    {
                        break; // VGAINEI APO THN while
                    }
                    else // VRETHIKE KAPOIOS LESSFREQUENT NUMBER
                    {
                        ListWithCount.Add(count); // ADD count TO LIST
                    }

                    if (ListWithCount[0] == count) // ean to count einai iso me to proto count pou exei mpei sthn lista tote shmainei oti o arithmos pou exei vrethei iparxei oses fores iparxei kai o prohgoumenos pou eixe vrethei 
                    {

                        for (int a = 0; a < count; a++) // aferei ton less suxno arithmo apo thn tempListAllDrawNumbers
                        {
                            tempListAlldrawNumbers.Remove(lessFrequentNumber);
                        }

                        if (m == 0)
                            s += "Less draw number: " + lessFrequentNumber + " and exists " + count + " times  " + "\r\n";
                        if (m == 1)
                            s += "Second less draw number: " + lessFrequentNumber + " and exists " + count + " times  " + "\r\n";
                        if (m == 2)
                            s += "Third less draw number: " + lessFrequentNumber + " and exists " + count + " times " + "\r\n";

                    }
                    else // ean to count den einai iso tote shmainei oti o arithmos pou vrethike iparxei diaforetikes fores apo ton proigoumeno pou eixe vrethei
                        break; // vgainei apo thn while             

                }
                while (true);

            }
            return s;
        }
    }
}

