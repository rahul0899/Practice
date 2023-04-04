using System;
using System.Collections.Generic;
namespace ConsoleApp2
{
    class Equipment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Equipment(string name,string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
    //class  List
    //{
    //    public List<Equipment> numbers = new List<Equipment>();
    //}
    class Program
    {

        static void Main(string[] args)
        {
            var list = new List<Equipment>();
            while (true)
            {
                Console.WriteLine("1. Add numbers");
                Console.WriteLine("2. Print the List of Numbers");
                Console.WriteLine("3. Exit");
                int command = int.Parse(Console.ReadLine());
                
                
                switch(command)
                {
                    case 1:
                        Console.WriteLine("Enter the name of the Equipment");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the description of the Equipment");
                        string description = Console.ReadLine();
                        var equipment = new Equipment(name, description);
                        list.Add(equipment);
                        break;
                    case 2:
                        Console.WriteLine("The List of numbers are :");
                        foreach (var items in list)
                        {
                            Console.WriteLine($"Equipment Name:{items.Name}, Equipment Description:{items.Description}");
                        }
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                       

                }                
            }
            

        }
    }
}
