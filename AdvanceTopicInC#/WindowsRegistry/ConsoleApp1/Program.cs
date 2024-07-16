using Microsoft.Win32;
using System;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
class Program1
{
    static void Main()
    {
        // Specify the Registry key and path
        string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\YourSoftware";
        string valueName = "YourValueName";
        string valueData = "YourValueData";
        try
        {
            // Write the value to the Registry
            Registry.SetValue(keyPath, valueName, valueData, RegistryValueKind.String);
            Console.WriteLine($"Value {valueName} successfully written to the Registry.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        Console.ReadKey();
    }
}


class Program2
{
    static void Main()
    {
        // Specify the Registry key and path
        string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\YourSoftware";
        string valueName = "YourValueName";
        try
        {
            // Read the value from the Registry
            string value = Registry.GetValue(keyPath, valueName, null) as string;
            if (value != null)
            {
                Console.WriteLine($"The value of {valueName} is: {value}");
            }
            else
            {
                Console.WriteLine($"Value {valueName} not found in the Registry.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        Console.ReadKey();
    }
}