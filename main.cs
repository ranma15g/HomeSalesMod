using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
  public static void Main(string[] args)
  {
    int cont = 1; // Continuous flag (1 to start, increments for each salesperson)

    // We create a list to store names here
    List<string> namesList = new List<string>();

    // We create a list to store sales here
    List<string> salesList = new List<string>();

    // Over here we explain to the user how to exit the prgram
    Console.WriteLine("** Please note to end this program enter the letter z, lowercase or uppercase it does not matter. **\n\n");


      /* *****************************
          This is where we gather data
        ****************************** */


    // We use a continuous flag in a while loop to keep asking questions
    while (cont >= 1)
    {

        // Add data to the lists
         Console.WriteLine("Please enter the sales person's name: ");

        // We ask the user to input an initial
         string initialInput = Console.ReadLine();

        // We create a sentinel here
        int stop_gap = 0;

        // If we do not enter the correct initial character
        while (initialInput != "d" && initialInput != "D" && initialInput != "e" && initialInput != "E" && initialInput != "f" && initialInput != "F")
            {   // We check to see if they want to break the program and see totals
                if (initialInput == "Z" || initialInput == "z") // If the user enters Z or z
                {   // Terminate this functions lifespan
                    stop_gap = 1;
                    break;
                }

                // They did not enter the correct initial
                Console.WriteLine ("Error, Invalid Sales Person, please try again.");
                // Ask them for valid input again
                initialInput = Console.ReadLine();
            }


        if (stop_gap == 1) // If they want to stop the program
            { 
                break; // end the program and get results
            }
        
        
        
     

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
      salesList.Add(salesInput);

      cont++; // Increment continuous flag
    }




    /* *****************************
        This is where we create the array
      ****************************** */
      
      
    // We get the size of the names list to define the size of our array
    int listSize = namesList.Count;

    // Using that size we create an array to store the names and sales
    string[,] dataArray = new string[listSize,2];

    // We use a for loop to fill the array with the names and sales
    for (int i = 0; i < listSize; i++)
      {
        // dataArray i , 0 is the name of the seller
        dataArray[i, 0] = namesList[i];

        // dataArray i , 1 is the sales of the seller
        dataArray[i, 1] = salesList[i];
      }





      
      
      /* ****************************************
          This is where we add the sale together
        ***************************************** */
      
    // We create a placeholder for the total amount of sales
    int sum = 0;

        // We will loop through our dataArray and add the sales to the sum
        for (int i = 0; i < dataArray.GetLength(0); i++)  
        {
            /* for each iteration of the foor loop this will pull sales from the 
               corresponding index of the outer most dimension of the array */
            int num1 = int.Parse(dataArray[i, 1]);

             // using that data we pulled from the array we can add it to the sum
             sum += num1; // Adding it to the sum gives us a total once all the sales are added

        }

    // This is where the audience learns the total sales
    Console.WriteLine("Your sum is " + sum);  





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

     // And now we can use the highestSale int to tell the audience what the highest sale was
     Console.WriteLine("The highest sale was " + highestSale + " made by " + dataArray[highest, 0]);
                        // The highest int variable can reference the index of the highest sale 
                        // through its place in the outer most array to pull all the values from 
                        // that dimensions index
      
    }
}
