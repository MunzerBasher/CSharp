using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        // Generate the code
        string classCode = clsCodeGenerate.GenerateClass();
        // Output the generated code
        Console.WriteLine("Generated code:");
        Console.WriteLine(classCode);
        
        // Write the generated code to a file
        string Path = "C:\\Users\\munzer\\Documents\\DateProblmes\\AdvanceTopicInC#\\CodeGenerater\\CodeGenerater\\";
        File.WriteAllText(Path+"GeneratedClass.cs", classCode);
        Console.ReadKey();  
    }

}