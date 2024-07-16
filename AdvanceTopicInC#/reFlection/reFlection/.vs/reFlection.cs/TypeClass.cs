using System;
using System.Linq;
using System.Reflection;

public class clsMyClass
    {
        public int Property1 { get; set; }

        public void Method1()
        {
            Console.WriteLine("\tMethod1 is Executed");
        }

        public void Method2(int value1, string value2)
        {
            Console.WriteLine($"\tMethod2 is Executed with parameters: {value1}, {value2}");
        }
    }

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class MyCustomAttribute : Attribute
{
    public string Description { get; }


    public MyCustomAttribute(string description)
    {
        Description = description;
    }
}

[MyCustom("This is a class attribute")]
class MyClass
{
    [MyCustom("This is a method attribute")]
    public void MyMethod()
    {
        // Method implementation
    }
}

public class clsTypes
{
    public static void GetTypeInfo(Type type)
    {
        Console.WriteLine($"Type Information : ");
        Console.WriteLine($"Name {type.Name}");
        Console.WriteLine($"Full Name : {type.FullName} ");
        Console.WriteLine($"is Class : {type.IsClass}");

    }

    public static void GetAssemblyInfo(Assembly assembly, string TypeName)
    {
        Type ClassType = assembly.GetType(TypeName);

        if(ClassType != null) 
        {
            Console.WriteLine($"Method of the {TypeName} class :");
            var TypeNameMethods = ClassType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .OrderBy(method => method.Name);
            foreach (var Method in TypeNameMethods)
            {
                Console.WriteLine($"\t{Method.ReturnType}{Method.Name}({GetParametersList(Method.GetParameters())}) ");
            }
        }
        else
        {
            Console.WriteLine($"{TypeName} type not found !");
        }
    }

    private static string GetParametersList(ParameterInfo[] parameters)
    {
        return string.Join(", ", parameters.Select(parameter=> $"{parameter.ParameterType} {parameter.Name}"));
    }

    public static void CreateInst(Type myClassType)
    {
        // Create an instance of MyClass
        object myClassInstance = Activator.CreateInstance(myClassType);
        // Set the value of Property1 using reflection
        myClassType.GetProperty("Property1").SetValue(myClassInstance, 42);
        Console.WriteLine("\nSet Property1 to 42 using reflection:");
        // Get the value of Property1 using reflection
        Console.WriteLine("\nGetting Property1 is value using reflection:");
        int Property1Value = (int)myClassType.GetProperty("Property1").GetValue(myClassInstance);
        Console.WriteLine($"\tProperty1 Value: {Property1Value}");
        //now how to execute methods using reflection:
        Console.WriteLine("\nExecuting Methods using reflection:\n");
        // Invoke the Method1 using reflection
        myClassType.GetMethod("Method1").Invoke(myClassInstance, null);
        // Invoke Method2 with parameters using reflection
        object[] parameters = { 100, "Mohammed Abu-Hadhoud" };
        myClassType.GetMethod("Method2").Invoke(myClassInstance, parameters);
    }

    public static void GetAttributeDescription(Type type) 
    {
        // Get class-level attributes
        object[] classAttributes = type.GetCustomAttributes(typeof(MyCustomAttribute), false);
        foreach (MyCustomAttribute attribute in classAttributes)
        {
            Console.WriteLine($"Class Attribute: {attribute.Description}");
        }
        // Get method-level attributes
        MethodInfo methodInfo = type.GetMethod("MyMethod");
        object[] methodAttributes = methodInfo.GetCustomAttributes(typeof(MyCustomAttribute), false);
        foreach (MyCustomAttribute attribute in methodAttributes)
        {
            Console.WriteLine($"Method Attribute: {attribute.Description}");
        }
    }
}