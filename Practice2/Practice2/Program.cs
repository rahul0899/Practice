using System;

namespace Question1_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the value: ");
            var a = Console.ReadLine();
            Console.WriteLine("The user input is of type:" + a.GetType());
            //Boolean Conversion
            try
            {
                bool i = bool.Parse(a);
                Console.WriteLine("Boolean Conversion using bool.parse method: " + i);
                bool j = Convert.ToBoolean(a);
                Console.WriteLine("Boolean Conversion using Convert.ToBoolean method: " + j);

            }
            catch
            {
                Console.WriteLine($"{a} can not be converted to Boolean");
            }
            bool n = bool.TryParse(a, out bool r);
            Console.WriteLine($"Boolean output to check whether {a} "+
                "can be converted to Boolean or not using bool.Tryparse method:" + n);


            //Integer Conversion
            try
            {

                int i = int.Parse(a);
                Console.WriteLine("Integer Conversion using int.parse method: " + i);
                int j = Convert.ToInt32(a);
                Console.WriteLine("Integer Conversion using Convert.ToInt32 method: " + j);
            }
            catch
            {
                Console.WriteLine($"{a} can not be coverted to Integer ");
            }
            bool k = int.TryParse(a, out int result);
            Console.WriteLine($"Bolean output to check whether {a} can be converted to Integer or not " +
                "using Tryparse method:" + k);


            //Float conversion
            try
            {
                float i = float.Parse(a);
                Console.WriteLine("Float conversion using float.parse method: " + i);
                float j = Convert.ToSingle(a);
                Console.WriteLine("Float conversion using Convert.ToSingle method: " + j);

            }
            catch
            {
                Console.WriteLine($"{a} can not be converted to Float");
            }
            bool m = float.TryParse(a, out float res);
            Console.WriteLine($"Bolean output to check whether {a} can be converted to Float or not " +
                "using Tryparse method:" + m);



        }
    }
}

