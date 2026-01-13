using System;

class SmartAccessControl
{
    static void Main()
    {
        string input = Console.ReadLine();

        string[] parts = input.Split('|');//splitting

        if (parts.Length != 5)
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        string gateCode = parts[0];//extraction
        string userInitialStr = parts[1];
        string accessLevelStr = parts[2];
        string isActiveStr = parts[3];
        string attemptsStr = parts[4];
        //validation of inputs
        if (gateCode.Length != 2 || !char.IsLetter(gateCode[0]) || !char.IsDigit(gateCode[1]))
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }
        // Validate user initial
        if (userInitialStr.Length != 1 || !char.IsUpper(userInitialStr[0]))
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }
        char userInitial = userInitialStr[0];

        if (!byte.TryParse(accessLevelStr, out byte accessLevel) || accessLevel < 1 || accessLevel > 7)
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }
        // Validate isActive
        if (!bool.TryParse(isActiveStr, out bool isActive))
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }

        if (!byte.TryParse(attemptsStr, out byte attempts) || attempts > 200)
        {
            Console.WriteLine("INVALID ACCESS LOG");
            return;
        }
        // Determine access status
        string status;
        if (!isActive)
        {
            status = "ACCESS DENIED – INACTIVE USER";
        }
        else if (attempts > 100)
        {
            status = "ACCESS DENIED – TOO MANY ATTEMPTS";
        }
        else if (accessLevel >= 5)
        {
            status = "ACCESS GRANTED – HIGH SECURITY";
        }
        else
        {
            status = "ACCESS GRANTED – STANDARD";
        }
        // Output the results
        Console.WriteLine($"Gate      : {gateCode}");
        Console.WriteLine($"User      : {userInitial}");
        Console.WriteLine($"Level     : {accessLevel}");
        Console.WriteLine($"Attempts  : {attempts}");
        Console.WriteLine($"Status    : {status}");
    }
}

