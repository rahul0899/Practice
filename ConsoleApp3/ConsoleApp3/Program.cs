using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    public abstract class Equipment
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Equipment(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
    public class MobileEquipment : Equipment
    {
        int distance = 0;
        double maintainenceCost = 0.0;
        public MobileEquipment(string name, string description) : base(name, description)
        {

        }
        public int MoveBy(int distance)
        {
            distance += distance;
            return distance;
        }
        public double MaintainenceCost(int numberOfWheels)
        {
            maintainenceCost = numberOfWheels * distance;
            return maintainenceCost;
        }
    }
    public class ImmobileEquipment : Equipment
    {
        int distance = 0;
        double maintainenceCost = 0.0;
        public ImmobileEquipment(string name, string description) : base(name, description)
        {

        }
        public int MoveBy(int distance)
        {
            distance += distance;
            return distance;
        }
        public double MaintainenceCost(double weight)
        {
            maintainenceCost = weight * distance;
            return maintainenceCost;
        }
    }
    public class AllEquipmentFunctions
    {
        static List<Equipment> EquipmentList = new List<Equipment>();
        Equipment equipment;
        public void CreateEquipment()
        {
            Console.WriteLine("Enter the Name of Equipment");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Description of Equipment");
            string description = Console.ReadLine();
            Console.WriteLine("Is this a Mobile Equipment(y/n)");
            string isMobilestr = Console.ReadLine();
            bool isMobile;
            while (true)
            {
                if (isMobilestr == "y")
                {
                    isMobile = true;
                    break;
                }
                else if (isMobilestr == "n")
                {
                    isMobile = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Command");
                }
            }

            if (isMobile)
            {
                equipment = new MobileEquipment(name, description);
            }
            else
            {
                equipment = new ImmobileEquipment(name, description);
            }
            EquipmentList.Add(equipment);
        }

        public void DeleteEquipment()
        {
            Console.WriteLine("Enter the name of the Equipment");
            string name = Console.ReadLine();
            equipment = EquipmentList.Find(e => e.Name == name);
            if(equipment!=null)
            {
                EquipmentList.Remove(equipment);
                Console.WriteLine("Element deleted Successfully");
            }
            else
            {
                Console.WriteLine("Element not Found");
            }
        }
        public void DeleteAllMobileEquipment()
        {
            Console.WriteLine("All Mobile Equipment is deleted");
            EquipmentList.RemoveAll(e => e is MobileEquipment);          
        }
        public void DeleteAllImmobileEquipment()
        {
            Console.WriteLine("All Immobile Equipment is deleted");
            EquipmentList.RemoveAll(e => e is ImmobileEquipment);
        }
        public void ListMobileEquipment()
        {

        }
    }
        


    class Program
    {       
        static void Main(string[] args)
        {           
               
        }
    }
}
