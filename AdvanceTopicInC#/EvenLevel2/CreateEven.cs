using System;


public class clsCalculatorResult : EventArgs
{
        public int Result { get; }
        public int val1 { get; }
        public int val2 { get; }

        public clsCalculatorResult(int val1, int val2, int Result)
        {
            this.val1 = val1;
            this.val2 = val2;
            this.Result = Result;
        }
}

public class clsCalculator
{
    public event EventHandler<clsCalculatorResult> CalculatorResultChanged;

    public virtual void GetResult(int val1, int val2) 
    {
        GetResult(new clsCalculatorResult(val1,val2, val2+val1));
    }

    public void GetResult(clsCalculatorResult Result)
    {
        CalculatorResultChanged?.Invoke(this, Result);
    }
}

public class clsPrint
{

    public void Subscribe(clsCalculator Calculator)
    {
        Calculator.CalculatorResultChanged += Print;
    }

    public void Print(object sender, clsCalculatorResult e)
    {
        Console.WriteLine("val1 = " + e.val1);
        Console.WriteLine("val2 = " + e.val2);
        Console.WriteLine("Result = " + e.Result);
    }
}

public class clsCheck
{

    public void Subscribe(clsCalculator Calculator)
    {
        Calculator.CalculatorResultChanged += Print;
    }

    public void Print(object sender, clsCalculatorResult e)
    {
        if(e.Result > 5)
        {
            Console.WriteLine("Your Result is bigger !");
        }
    }

}

public class Logger
{
    public delegate void DGPrint(string message);

    private DGPrint _Logger;
    public Logger(DGPrint Logger)
    {
        _Logger = Logger;   
    }

    public void Log (string message) 
    {
        _Logger(message);
    }

}

