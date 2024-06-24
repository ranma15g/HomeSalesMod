using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
  public static void Main(string[] args)
  {

    // We create a list to store names here
    List<string> namesList = new List<string>();

    // We create an array to check against bad initials that may get entered
    char[] initials = { 'D', 'd', 'E', 'e', 'F', 'f' };

    // We create a list to store sales here
    List<string> salesList = new List<string>();

    // Over here we explain to the user how to exit the prgram
    Console.WriteLine("** Please note to end this program enter the letter z, lowercase or uppercase it does not matter. **\n\n");


      /* *****************************
          This is where we gather data
        ****************************** */


    // We use a continuous flag in a while loop to keep asking questions
    while (true)
    {

        // Add data to the lists
        Console.WriteLine("Please enter the sales person's initial: ");

        // We ask the user to input an initial
        string initialInput = Console.ReadLine();

        // We convert the letter entered into an array for comparison
        char firstChar = initialInput.ToCharArray()[0];

        if (initialInput == "Z" || initialInput == "z") // If the user enters Z or z
        {   // Terminate this while loop
            break;
        }

        // We create a bool tell the program if the initial is valid
        bool found = false;

        // For each initial in the initials Array
        foreach (char ini in initials)
        {
          // If the initial is found in the array
          if (ini == firstChar)
          {  // the found boolean will be true
            found = true;
          }
        }

        // If found is not true
        if (!found)
        { // We tell the user that the initial is invalid
          Console.WriteLine("intermediate output: error, Invalid sales person selected, please try again : ");

          // We ask the user once again to input an initial
          // initialInput = Console.ReadLine();
          continue;
        }

        if (found) {
        // Now we ask them how successful they were in life  
        Console.WriteLine ("Okay Great, now please enter that person's sales:");

        // We ask them to input their life's value here
        string salesInput = Console.ReadLine();

        // Now we find out if the user still knows how to follow instruction
        while (int.TryParse(salesInput, out int salesFail) == false)

            {

            // Reprimand the individual for not follow instructions
            Console.WriteLine ("I asked for a monetary value.");

            // Record their input here
            salesInput = Console.ReadLine();

            }
      
      // We add the sales persons initial to the namesList
      namesList.Add(initialInput);

      // We add the sales persons sales to the salesList
      salesList.Add(salesInput); }

    }




    /* *****************************
        This is where we create the array
      ****************************** */
      
      
    // We get the size of the names list to define the size of our array
    int listSize = namesList.Count;

    // Using that size we create an array to store the names and sales
    string[,] dataArray = new string[listSize,3];

    // We use a for loop to fill the array with the names and sales
    for (int i = 0; i < listSize; i++)
      {
        // dataArray i , 0 is the name of the seller
        dataArray[i, 0] = namesList[i];

        // dataArray i , 1 is the sales of the seller
        dataArray[i, 1] = salesList[i];

        // if they entered D we save their name to the dataArray
        if (namesList[i] == "D" || namesList[i] == "d")
          { dataArray[i, 2] = "Danielle"; }

        // if they entered E we save their name to the dataArray
        if (namesList[i] == "E" || namesList[i] == "e")
        { dataArray[i, 2] = "Edward"; }

        // if they entered F we save their name to the dataArray
        if (namesList[i] == "F" || namesList[i] == "f")
        { dataArray[i, 2] = "Francis"; }
      }





      
      
      /* ****************************************
          This is where we add the sale together
        ***************************************** */
      
    // We create a placeholder for the total amount of sales
    int sumCashMoney = 0;

        // We will loop through our dataArray and add the sales to the sum
        for (int i = 0; i < dataArray.GetLength(0); i++)  
        {
            /* for each iteration of the foor loop this will pull sales from the 
               corresponding index of the outer most dimension of the array */
            int num1 = int.Parse(dataArray[i, 1]);

             // using that data we pulled from the array we can add it to the sum
             sumCashMoney += num1; // Adding it to the sum gives us a total once all the sales are added

        }

  // And our free accountant translate that numer into something the audience might understand
    string formattedAmount1 = sumCashMoney.ToString("C0", CultureInfo.CurrentCulture);
    // We are converting the currency into a dollar amount with a us capital symbol and commas


      
    // This is where the audience learns the total sales
    Console.WriteLine("Grand Total:" + formattedAmount1);  





      /* *****************************************
          This is where we find the highest sale
        ****************************************** */

    // We create a placeholder for the highest sale index association
    int highest = 0;

    // We create a placeholder for the highest sale
    int highestSale = 0;

      // We use a for loop to run through all of the sales stored in the array
      for (int i = 0; i < dataArray.GetLength(0); i++)

      {     // Because the data is stored as a string we have to parse it to an int data type
            int thisSale = int.Parse(dataArray[i, 1]);

            // Now we compare it to the current record holder of highestSale
            if (thisSale > highestSale)
            {
                // If thisSale is greater than the current highestSale 
                // then we update the highestSale
                highestSale = thisSale;

                // And we remember the index of the highest sale on the left outer most
                // dimension of our array
                highest = i;
            }
          
     }


      // And our free accountant translate that numer into something the audience might understand
      string formattedAmount2 = highestSale.ToString("C0", CultureInfo.CurrentCulture);
      // We are converting the currency into a dollar amount with a us capital symbol and commas
      
      
     // And now we can use the highestSale int to tell the audience what the highest sale was
     Console.WriteLine("\nHighest Sale:" + dataArray[highest, 0]);
     Console.WriteLine("\nCongratulations " + dataArray[highest, 2] + "!");
                        // The highest int variable can reference the index of the highest sale 
                        // through its place in the outer most array to pull all the values from 
                        // that dimensions index
      
    }
}
