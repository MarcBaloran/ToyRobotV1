using System;
using System.IO;

namespace ToyRobotV1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"The correct command formats are as follows:
                    PLACE X,Y,DIRECTION
                    MOVE
                    RIGHT
                    LEFT
                    REPORT
                    -------------
                    Please review your input file before entering the file path.
                    ");

            Console.WriteLine(@"The correct file path is as follows: 
            C:\Users\<Username>\Desktop\web\testv1.txt
            ");

            bool shouldContinueUsingApp = false;

            do
            {
                Console.Write("Please enter file path: ");
                string path = Console.ReadLine();

                if (!IsPathValid(path))
                {
                    throw new Exception("Invalid file path, please check if file path exists");
                }

                if (!IsFileExtensionValid(path))
                {
                    throw new Exception("Not a .txt file. Please try again.");
                }

                string[] commands = File.ReadAllLines(path);
                Console.WriteLine(Commander(commands));

                Console.WriteLine(@"Do you want to continue using the app? 
                                Answer Y - to continue 
                                Answer N - to stop
                ");
                Console.Write(@"Answer: ");
                string answer = Console.ReadLine();

               shouldContinueUsingApp = answer.ToLower() == "y" ? true : false;

            } while (shouldContinueUsingApp);


        }

        public static bool IsPathValid(string path)
        {
            return (!string.IsNullOrEmpty(path) && File.Exists(path));
        }

        public static bool IsFileExtensionValid(string path)
        {
            return Path.GetExtension(path) == ".txt";
        }

        public static string Commander(string[] commands)
        {
            string message = "";
            Command obj = new Command();
            if (obj != null)
            {
                message = obj.Start(commands);
            }
            return message;
        }
    }
}
