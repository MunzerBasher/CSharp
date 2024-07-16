using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace reFlection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type t1 = DateTime.Now.GetType();   //at runtime        
            Console.WriteLine(t1);
            Type t2 = typeof(DateTime); // at compile time
            Console.WriteLine(t2);
            Console.WriteLine($"FullName {t2.FullName}");
            Console.WriteLine($"NameSpace {t2.Namespace}");
            Console.WriteLine($"BaseType {t2.BaseType}");
            Console.WriteLine($"IsPublic {t2.IsPublic}");
            Console.WriteLine($"Assembly {t2.Assembly}");

            Type t3 = typeof(int[,]);
            Console.WriteLine($"T3 Type {t3.Name}");
            var nestType = typeof(clsEmploye).GetNestedTypes();
            for (int i = 0; nestType.Length > i; i++)
            {
                Console.WriteLine(nestType[i]);
            }

            var t4 = typeof(int);
            var Interface = t4.GetInterfaces();
            for (int i = 0; Interface.Length > i; i++)
            {
                Console.WriteLine(Interface[i]);
            }

            var i2 = new Int32();
            i2 = 5;
            var i3 = Activator.CreateInstance(typeof(int));

            DateTime dt = (DateTime)Activator.CreateInstance(typeof(DateTime));

            Console.WriteLine(dt);
            BankAcount bankAcount = new BankAcount("A1234","Monzer",1000);
            bankAcount.AcountChanged += BankAcount_AcountChanged;
            bankAcount.Withdrow(500);
            Console.WriteLine(bankAcount);
            bankAcount.Withdrow(1000);
            Console.WriteLine("**********MemberInfo********");
            MemberInfo[] members = typeof(BankAcount).GetMembers(BindingFlags.Public | BindingFlags.NonPublic| BindingFlags.Instance); 
            foreach(var member in members)
            {
                Console.WriteLine(member);
            }
            Console.WriteLine("**********FieldInfo**************");
            FieldInfo[] Fields = typeof(BankAcount).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var Field in Fields)
            {
                Console.WriteLine(Field);
            }
            Console.WriteLine("**********PropertyInfo**************");
            PropertyInfo[] Properties = typeof(BankAcount).GetProperties();
            foreach (var Property in Properties)
            {
                Console.WriteLine(Property);
            }
            Console.WriteLine("**********EventsInfo**************");
            EventInfo[] Events = typeof(BankAcount).GetEvents();

            foreach (var Event in Events)
            {
                Console.WriteLine(Event);
            }

            Console.WriteLine("**********ConstructorInfo**************");
            ConstructorInfo[] Constructors = typeof(BankAcount).GetConstructors();

            foreach (var Constructor in Constructors)
            {
                Console.WriteLine(Constructor);
            }
            // Invoke Method
            var account = new BankAcount("A12345", "mohammed", 1200);
            //account.Deposit(1000);
            Type t = typeof(BankAcount);
            //Type[] types =  { typeof(decimal)};
            MethodInfo Method = t.GetMethod("Deposit");
            Method.Invoke(account, new object[] {500m });
            Console.WriteLine(account);

            do
            {
                Console.Write("Enemy : ");
                var input = Console.ReadLine();
                object obj = null;
                try
                {
                    var assemb = typeof(Program).Assembly.GetName().Name;
                    var N = assemb + "." + input;
                    var enemy = Activator.CreateInstance(assemb, N);
                    obj = enemy.Unwrap();
                }
                catch { }
                switch (obj)
                {
                    case Goon g:
                        {
                            Console.WriteLine(g);
                            break;
                        }
                    case Agar agar:
                        {
                            Console.WriteLine(agar);
                            break;
                        }
                    case Bigsa B:
                        {
                            Console.WriteLine(B);
                            break;
                        }
                }
            } while (true);
            Console.ReadKey();
        }

        private static void BankAcount_AcountChanged(object sender, BankAcount e)
        {
            var bankacount = (BankAcount)sender;
            Console.WriteLine("NEGATIVE BALANCE!!!");
        }
    }

    public class Goon
    {
        public override string ToString()
        {
            return $"{{Speed : {20}, HitPower : {13}, Strength : {7}}}";

        }
    }
    public class Bigsa
    {
        public override string ToString()
        {
            return $"{{Speed : {10}, HitPower : {23}, Strength : {5}}}";

        }
    }
    public class Agar
    {
        public override string ToString()
        {
            return $"{{Speed : {14}, HitPower : {8}, Strength : {4}}}";

        }
    }

    public class BankAcount
    {
        private string _AcountNo;
        private string _Holder;
        private decimal _Balance;

        public string Acount => _AcountNo;
        public string Holder => _Holder;
        public decimal Balance => _Balance;
        public event EventHandler<BankAcount> AcountChanged;

        public BankAcount(string acountNo, string holder, decimal balance)
        {
            _AcountNo = acountNo;
            _Holder = holder;
            _Balance = balance;
        }
        public void Deposit(decimal amount)
        {
            this._Balance += amount;
        }
        public void Withdrow(decimal amount)
        {
            this._Balance -= amount;
            if (this._Balance < 0)
            {
                this.AcountChanged?.Invoke(this, null);
            }

        }

        public override string ToString()
        {
            return $"{{ Account No : {_AcountNo} , Holder : {_Holder}, Balance : {_Balance}}}";
        }
    }
}