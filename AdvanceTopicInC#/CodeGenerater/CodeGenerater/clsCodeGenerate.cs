
using System;

class clsCodeGenerate
{

    private static string GenerateProperties()
    {
        Console.WriteLine("Enter Properties Names With (,) :");
        string propertyName = Console.ReadLine();
        string[] propertiesNames = propertyName.Split(',');
        Console.WriteLine("Enter Properties typies With (,)  :");
        string propertyType = Console.ReadLine();
        string[] PropertiesTypies = propertyType.Split(',');

        string properties = "\t";
        if (propertiesNames.Length == PropertiesTypies.Length)
        {
            for (int i = 0; i < propertiesNames.Length; i++)
                properties += $"public {PropertiesTypies[i]} {propertiesNames[i]} {{ get; set; }};\n\t\t";
        }
        return properties;
    }

    private static string GenerateMethod(string Modfi, string methodName, string returnType, string[] parameterNames, string[] parameterTypes, string Body = "//")
    {
        // Build method signature
        string methodSignature = $"\n\t\t{Modfi} {returnType} {methodName}(";
        for (int i = 0; i < parameterNames.Length; i++)
        {
            methodSignature += $"{parameterTypes[i]} {parameterNames[i]}";
            if (i < parameterNames.Length - 1)
                methodSignature += ", ";
        }
        methodSignature += ")";
        string Result = "";
        if (returnType != "void")
            Result = $"\t return {(Body)}";
        Body = Result;
        // Method body (for demonstration purposes, you can customize this)
        string methodBody = "\t\t" + $@"
        {"\t"}{{
                // Method body goes here
                // Implement your logic
                {Body} 
                
       {"\n\t\t"}}}";
        // Combine method signature and body
        string generatedMethod = methodSignature + methodBody;

        return generatedMethod + ";";
    }

    private static string GenerateMethods()
    {
        string Methods = "";
        string value = null;
        do
        {
            Console.WriteLine("Enter method Modifer ");
            string Modi = Console.ReadLine();
            Console.WriteLine("Enter method name:");
            string methodName = Console.ReadLine();
            Console.WriteLine("Enter return type:");
            string returnType = Console.ReadLine();
            Console.WriteLine("Enter parameter names (comma-separated):");
            string[] parameterNames = Console.ReadLine().Split(',');
            Console.WriteLine("Enter parameter types (comma-separated):");
            string[] parameterTypes = Console.ReadLine().Split(',');
            Console.WriteLine("Enter method Body :");
            string Body = Console.ReadLine();
            Methods += GenerateMethod(Modi, methodName, returnType, parameterNames, parameterTypes, Body) + "\n\n";
            Console.WriteLine("Do You Want To Add More method ?");
            value = Console.ReadLine();
        } while (value.ToUpper() == "Y");
        return Methods;
    }

    public static string GenerateClass()
    {
        Console.WriteLine("Enter class name:");
        string className = Console.ReadLine();

        string Head = $@"
        using System;

        public class {className}
        {{
            
        ";
        string properties = GenerateProperties();
        string Methods = GenerateMethods();

        return Head + properties + Methods + "\t}";
    }

}