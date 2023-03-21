using System;

namespace Question3_Assignment1
{
    class Prime
    {
        static void Main(string[] args)
        {
            int start, end;
            bool isValid = false;
            Console.WriteLine("Enter the First number:");
            do
            {
                if (int.TryParse(Console.ReadLine(), out start))
                {
                    if (start < 2 || start>1000)
                    {
                        Console.WriteLine("Invalid Input!!..Please enter number equal or greater than 2 and less than 1000");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input!!.. Please enter an Integer Value");
                }
            } while (!isValid);
            isValid = false;
            Console.WriteLine("Enter the second number:");
            do
            {
                if (int.TryParse(Console.ReadLine(), out end))
                {
                    if (end < start || end > 1000)
                    {
                        Console.WriteLine("Invalid Input!!..Please enter the value greater than First Number and less than 1000");
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input!!..Please enter an Integer Value");
                }
            } while (!isValid);
            Console.WriteLine($"The prime numbers between {start} and {end} are: ");

            for (int j = start; j <= end; j++)
            {
                int count = 0;
                for (int i = 2; i <= j / 2; i++)
                {
                    if (j % i == 0)
                    {
                        count++;
                        break;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine(j);

                }
            }
        }
    }
} 
            
            
        
