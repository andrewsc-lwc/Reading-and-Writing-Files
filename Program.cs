using System;
using System.IO;

namespace Reading_and_Writing_Files
{
    class Program
    {
        static string folder = Directory.GetCurrentDirectory();
        static string filename = "\\leaderboard.txt";

        static void Main(string[] args)
        {
            //Console.WriteLine(folder);
            ReadFile();
            //WriteToFile();
            
        }

        private static void ReadFile()
        {
            string[] csvLines = File.ReadAllLines(folder + filename);
            Console.WriteLine(csvLines[0]);
            for (int x = 0; x < csvLines.Length; x++)
            {
                Console.WriteLine(csvLines[x]);
            }
            string[,] Array2D = new string[50,2];
            for (int i = 0; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split(',');
                Array2D[i,0] = rowData[0];
                Array2D[i, 1] = rowData[1];
            }
            //Console.WriteLine(Array2D[1, 0]);
            //for (int i = 0; i< csvLines.Length; i++){
            //Console.WriteLine("Player " + i + " is called " + Array2D[i, 0] + " and scored " + Array2D[i, 1]);
            //}
            Console.WriteLine("What is your username?");
            string username = Console.ReadLine();
            Console.WriteLine("What is your Password?");
            string password = Console.ReadLine();
            bool loginSuccess = false;
            for (int i = 0; i < csvLines.Length; i++)
            {
                if ((username == Array2D[i,0])&&(password == Array2D[i, 1]))
                {
                    Console.WriteLine("Login successful");
                    loginSuccess = true;
                }
            }
            if (loginSuccess == true)
            {
                Console.WriteLine("Username: " + username + " has successfully logged in");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Login unsuccessful");
                Environment.Exit(1);
            }
        }

        public static void WriteToFile()
        {
            TextWriter writeResults = new StreamWriter(folder + filename, false);
            writeResults.WriteLine("Bob,1");
            writeResults.WriteLine("Chris,2");
            writeResults.WriteLine("Steve,3");
            writeResults.WriteLine("Clive,4");
            writeResults.Flush();
            writeResults.Close();
        }

        //    for (int i = 0; i<csvLines.Length; i++)
        //    {
        //        writeResults.WriteLine(csvLines[i]);
        //    }
        //      
    }
}
