using System;

namespace Assignment2.Question4
{
    public enum TypeOfEquipment
    {
        Mobile,
        Immobile,
    }
    abstract class Variables
    {

        public string NameOfEquipment;
        public string DescriptionOfEquipment;
        public int DistanceMovedTillDate = 0;
        public int MaintainenceCost = 0;
        public int NumberOfWheels;
        public int weight;
        public bool isValid = false;
        public void getDetails()
        {
            Console.WriteLine("Name of Equipment");
            NameOfEquipment = Console.ReadLine();
            Console.WriteLine("Description of Equipment");
            DescriptionOfEquipment = Console.ReadLine();
        }
        public void showDetails()
        {
            Console.WriteLine("------------------------!");
            Console.WriteLine("Name of Equipment:" + NameOfEquipment);
            Console.WriteLine("Desciption of Equipment:" + DescriptionOfEquipment);
            Console.WriteLine("Distance moved Till Date:" + DistanceMovedTillDate);
            Console.WriteLine("Maintainence Cost for Mobile Equipments:" + MaintainenceCost);
        }
    }
    class Execution : Variables
    {
        public void moveBy(int Distance)
        {
            this.DistanceMovedTillDate += Distance;

        }
        public void operation()
        {
            Console.WriteLine("Enter the type of Equipment"); 
            TypeOfEquipment t;
            do
            {
                if (Enum.TryParse(Console.ReadLine(), out t))
                {
                    switch (t)
                    {
                        case TypeOfEquipment.Mobile:
                            Console.WriteLine("Number of Wheels of Equipment");
                            do
                            {
                                if (int.TryParse(Console.ReadLine(), out NumberOfWheels))
                                {
                                    isValid = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input!..Please Enter the valid input");
                                }
                            } while (!isValid);
                            isValid = false;
                            MaintainenceCost = NumberOfWheels * DistanceMovedTillDate;
                            break;
                        case TypeOfEquipment.Immobile:
                            Console.WriteLine("Weight of Equipment");
                            do
                            {
                                if (int.TryParse(Console.ReadLine(), out weight))
                                {
                                    isValid = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input!..Please Enter the valid input");
                                }
                            } while (!isValid);
                            isValid = false;
                            MaintainenceCost = weight * DistanceMovedTillDate;
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                    isValid = true;

                }
            
                else
                {
                    Console.WriteLine("Invalid Input!..Please Enter the valid input");
                    
                }
                
            } while (!isValid);
       

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Execution();
            obj.getDetails();
            Console.WriteLine("Distance moved so far");  
            obj.moveBy(6);
            bool isvalid = false;
            int distance;
            do
            {
                if (int.TryParse(Console.ReadLine(), out distance))
                {
                    obj.moveBy(distance);
                    
                    isvalid = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input!!..Please enter the valid input");
                }
            } while (!isvalid);
            isvalid = false;
            obj.operation();
            obj.showDetails();
        }
    }
}


