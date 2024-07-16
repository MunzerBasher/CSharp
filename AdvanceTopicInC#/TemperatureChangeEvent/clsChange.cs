using System;

public class TemperatureChangeEventArgs : EventArgs
{
    public double OldTemperature { get; }
    public double NewTemperature { get; }
    public double Difference { get; }

    public TemperatureChangeEventArgs(double oldTemperature, double newTemperature)
    {
        this.OldTemperature = oldTemperature;
        this.NewTemperature = newTemperature;
        this.Difference = NewTemperature - OldTemperature;
    }
}

public class Thermostats
{
    public event EventHandler<TemperatureChangeEventArgs> TemperatureChange;

    private double OldTemperature ;
    private double CurrentTemperature = 0;

    public void SetTemperature(double NewTemperature)
    {
        if(CurrentTemperature != NewTemperature)
        {
            OldTemperature = CurrentTemperature;
            CurrentTemperature = NewTemperature;
            OnTemperatureChange(OldTemperature, CurrentTemperature);
        }
    }

    public void OnTemperatureChange(double OldTemperature, double CurrentTemperature)
    {
        OnTemperatureChange(new TemperatureChangeEventArgs(OldTemperature,CurrentTemperature));
    }

    public virtual void OnTemperatureChange(TemperatureChangeEventArgs e)
    {
        if(TemperatureChange != null)
            TemperatureChange?.Invoke(this, e);
    }
}

public class Display
{
    public void Subscribe(Thermostats thermostats)
    {
        thermostats.TemperatureChange += HandleTemperatureChange;
    }

    public void HandleTemperatureChange(object sender, TemperatureChangeEventArgs e)
    {
        Console.WriteLine("Temperature Change :");
        Console.WriteLine($"Temperature Change From {e.OldTemperature } C");
        Console.WriteLine($"Temperature Change to {e.NewTemperature } C");
        Console.WriteLine($"Temperature Change { e.Difference } C");
        Console.WriteLine("_________________________________________________");
    }

}

public class OrderData : EventArgs
{
    public string Title { get; }
    public string Description { get; }
    public string Date { get; }

    public OrderData(string title, string description, string date)
    {
        Title = title;
        Description = description;
        Date = date;
    }
}

public class Order
{
    public event EventHandler<OrderData> OrderChanged;

    public void CreateOrder(string title, string description, string date)
    {
        OnEvenRaise( new OrderData(title,description,date) );
    }

    private void OnEvenRaise(OrderData data) 
    {
        OrderChanged(this, data);
    }
}

public class Client
{

    public void Subscribe(Order order)
    {
        order.OrderChanged += SendToClient;
    }
    public void SendToClient(object sender, OrderData e) 
    {
        Console.WriteLine("New Order Created Successfully ?");
        Console.WriteLine("Title :" + e.Title);
        Console.WriteLine("Description :" + e.Description);
        Console.WriteLine("Date :" + e.Date);
    }

}

public class SMS
{

    public void Subscribe(Order order)
    {
        order.OrderChanged += SendToSMS;
    }
    public void SendToSMS(object sender, OrderData e)
    {
        Console.WriteLine("New Order Created Successfully ! We will Send You in SMS");
        Console.WriteLine("Title :" + e.Title);
        Console.WriteLine("Description :" + e.Description);
        Console.WriteLine("Date :" + e.Date);
    }

}

public class EMAIL
{

    public void Subscribe(Order order)
    {
        order.OrderChanged += SendToEMAIL;
    }
    public void SendToEMAIL(object sender, OrderData e)
    {
        Console.WriteLine("New Order Created Successfully ! We will Send You in EMAIL");
        Console.WriteLine("Title :" + e.Title);
        Console.WriteLine("Description :" + e.Description);
        Console.WriteLine("Date :" + e.Date);
    }

}
