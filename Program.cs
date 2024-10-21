using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

       
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

     
        string birthDateInput = "";
        DateTime birthDate = DateTime.MinValue;
        bool isValidDate = false;

       
        while (!isValidDate)
        {
            Console.Write("Enter your birthdate (MM/dd/yyyy): ");
            birthDateInput = Console.ReadLine();

            
            if (Regex.IsMatch(birthDateInput, @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/([0-9]{4})$"))
            {
               
                if (DateTime.TryParseExact(birthDateInput, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate))
                {
                    isValidDate = true;
                }
                else
                {
                    Console.WriteLine("Invalid date. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid format. Please use MM/dd/yyyy.");
            }
        }

        
        int age = CalculateAge(birthDate);
        Console.WriteLine($"Hello {name}, you are {age} years old.");

        
        string filePath = "user_info.txt";
        File.WriteAllText(filePath, $"Name: {name}\nAge: {age}\nBirthdate: {birthDate.ToString("MM/dd/yyyy")}");
        Console.WriteLine($"User info saved to {filePath}");

       
        Console.Write("Enter a directory path: ");
        string directoryPath = Console.ReadLine();

        if (Directory.Exists(directoryPath))
        {
            string[] files = Directory.GetFiles(directoryPath);
            Console.WriteLine("Files in the directory:");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
        else
        {
            Console.WriteLine("Directory not found.");
        }

       
        Console.Write("Enter a string to convert to title case: ");
        string inputString = Console.ReadLine();
        string titleCaseString = ToTitleCase(inputString);
        Console.WriteLine($"Title case: {titleCaseString}");

        
        Console.WriteLine("Triggering garbage collection...");
        GC.Collect();
        GC.WaitForPendingFinalizers(); 
        Console.WriteLine("Garbage collection triggered.");
    

    
    static int CalculateAge(DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;

        
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }

    
    static string ToTitleCase(string str)
    {
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        return textInfo.ToTitleCase(str.ToLower());
    }

