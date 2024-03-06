/***************************************************************
* Name         : Console App: Read Write File
* Author       : Jessica Hamilton
* Created      : 02/28/2024
* Course       : CIS 169 - C#
* Version      : 1.0
* OS           : Windows 11
* IDE          : Visual Studio 2022 Community
* Copyright    : This is my own original work based on
*                      specifications issued by our instructor
* Description  : reads a file named cities.txt and returns a file with formatted names
*                      Input :  file
*                      Output: formatted names in a file
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.        
***************************************************************/









namespace ConsoleApp2
{
     class ReadWriteFile
    {
        static void Main(string[] args)
        {
            string inputFilePath = "cities.txt";
            string outputFilePath = "citynames.txt";

            try
            {
                string[] cityNames = File.ReadAllLines(inputFilePath);

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (string cityName in cityNames)
                    {
                        writer.WriteLine(FormatName(cityName));
                    }

                    writer.WriteLine(FormatName("Hobart"));
                    writer.WriteLine(FormatName("des moines"));
                }

                Console.WriteLine("Formatted city names: ");
                string[] formattedCityNames = File.ReadAllLines(outputFilePath);

                foreach (string formattedCityName in formattedCityNames)
                {
                    Console.WriteLine(formattedCityName);
                }
            }

            catch (Exception e) 
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(e.Message);
            }
        }

        static string FormatName(string name) 
        {
            if (string.IsNullOrEmpty(name)) 
                return name;

            string[] words = name.Split(' ');

            for (int i = 0; i < words.Length; i++) 
            
            {
                if (words[i].Length > 0)
                {
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            return string.Join(" ", words);
        }
    }
}
