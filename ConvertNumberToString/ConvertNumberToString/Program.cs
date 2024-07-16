using System;

namespace ConvertNumberToString
{
    internal class Program
    {
        static string ConvertNumberToString(int  number)
        {
            if(number > 0 && number <= 20)
            {
                string[] arr = { "", "One", "Two", "Three", "Four", "Five",
                    "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", 
                    "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" }; 
                return arr[number] + " ";
            }
            if(number > 20  && number <= 99) 
            {
                string[] arr = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" }; 
                return arr[number / 10] + " " + ConvertNumberToString(number % 10);
            }
            if (number > 99 && number <= 199)
            {
                return ("One Hand") + ConvertNumberToString(number % 100);
            }
            if(number >= 200 && number <= 999)
            {
              return  ConvertNumberToString(number / 100) + "Hand" + ConvertNumberToString(number % 100);
            }
            if(number >= 1000 && number <= 1999)
            {
                return ConvertNumberToString(number / 1000) + "Thaw" + ConvertNumberToString(number % 1000);
            }
            if(number >= 2000 && number <= 999999)
            {
                return ConvertNumberToString(number/1000) + "Thaw" + ConvertNumberToString(number%1000);
            }
            if(number >= 1000000000 && number > 1999999999)
            {
                return "One Billion " + ConvertNumberToString(number % 1000000000);
            }


            return "";
        }
        static bool IsLeapYear(int year)
        {
            return ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0));
        }

        static int DayOfWeekOrder(int Day, int Month, int Year)
        {
            int a = (14 - Month) / 12;
            int y = Year - a;
            int m = Month + (12 * a) - 2; 
            return (Day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7;
            }
        static string DayShortName(short DayOfWeekOrder) 
        {   
            string []arrDayNames = { "Sun","Mon","Tue","Wed","Thu","Fri","Sat" }; 
            return arrDayNames[DayOfWeekOrder]; 
        }

        static int NumberOfDaysInAMonth(int Month, int Year) 
        { 
            if (Month < 1 || Month > 12) 
                return 0; 
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; 
            return (Month == 2) ? (IsLeapYear(Year) ? 29 : 28) : days[Month - 1]; 
        }

        static void MonthCalendar(int DayOrder ,int MonthDay)
        {
            Console.WriteLine("Sun" + "   " + "Mon" + "   " + "Tue" + "   " + "Wed" + "   " + "Thu" + "   " + "Fri" + "   " + "Sat");
            int i = 0;
            for (; i < DayOrder; i++) 
            {
                Console.Write("   ");
            }
            for(int j = 1; j <= MonthDay; j++)
            {
                Console.Write("   {0}",j);
                
                if(++i == 7)
                {   
                    Console.WriteLine();
                    i = 0;
                }
            }
        }
        static int DaysFromBeginnerOfYear(int Year,int Month , int Day)
        {
            int sum = 0;
            for(int i = 1; i < Month ; i++)
            {
                sum += NumberOfDaysInAMonth(i, Year);
            }
            return((sum+Day));
        }

        static void AddDaysToDate(int Year,int Month,int Day,int NewDays)
        {
            int DaysFromBeginnerOfYea = DaysFromBeginnerOfYear(Year, Month, Day);
            DaysFromBeginnerOfYea += NewDays;
            int month = 1;
            int DayInMonth = NumberOfDaysInAMonth(month, Year);
            while(DaysFromBeginnerOfYea > DayInMonth)
            {
                DaysFromBeginnerOfYea -= DayInMonth;
                DayInMonth = NumberOfDaysInAMonth(month, Year);
                ++month;
                if(month > 12)
                {
                    ++Year;
                    month = 1;
                }
            }
            Day = DaysFromBeginnerOfYea;
        }

        struct Man
        {
            public string FirstName;
            public string LastName;
        }

       // Man man = new Man();
        struct Date
        {
            public int Day;
            public int Month;
            public int Year;
        }

        static bool Date1GraterThanDate2(Date Date1, Date Date2)
        {
            return(Date1.Year>Date2.Year ? true 
            :(Date1.Year==Date2.Year) ? 
            ((Date1.Month > Date2.Month) ? true : (Date1.Month==Date2.Month) ? 
            ((Date1.Day>Date2.Day) ? true : false ): false) : false);
        }

        static bool Date1EqualThanDate2(Date Date1, Date Date2)
        {
            return(Date1.Year==Date2.Year && Date2.Month == Date1.Month &&  Date1.Day==Date2.Day);
        }

        bool Date1LessThanDate2(Date Date1, Date Date2)
        {
            return (!(Date1GraterThanDate2(Date1, Date2) || Date1EqualThanDate2(Date1, Date2)));
        }

        static bool LastMonth(int month)
        {
            return(month == 12);
        }
        static bool LastDay(int year , int month,int day) 
        {
            return (day == NumberOfDaysInAMonth(month, year));
        }
        static bool LastDay(Date date) 
        { 
            return(LastDay(date.Year, date.Month, date.Day));
        }
        static Date IcreaseDateByOne(Date Date)
        {
            if(NumberOfDaysInAMonth(Date.Month, Date.Year) == Date.Day)
            {
                if(Date.Month == 12)
                {
                    ++Date.Year;
                    Date.Month = 1;
                    Date.Day = 1;
                }
                else
                {
                    ++Date.Month;
                    Date.Day = 1;                    
                }
            }
            else
            {
                ++Date.Day;
            }
            return Date;
        }

        static int DiffBetweenDates(Date date1, Date date2) 
        {
            int Day = 0;
            int S = 1;
            if (!Date1GraterThanDate2(date1, date2))
            {
                Date date3 = date1;
                date1 = date2;
                date2 = date3;
                S = -1;
            }
            while (!Date1EqualThanDate2(date1, date2))
            {
                    ++Day;
                    date2 = IcreaseDateByOne(date2);
                
                
            }

            return (Day * S);
        }
        //Nullable<int> i = null;       
        static void Main(string[] args)
        {
            Date date1 = new Date();
        
            Date date2 = new Date();
            date1.Day = 31;
            date2.Day = 2;
            date1.Month = 1;
            date2.Month = 1;
            date1.Year = 2002;
            date2.Year = 2002;
            Date[] arr = {date1,date2}; 
            for(int i = 0;  i < arr.Length; i++) 
            {
                Console.WriteLine("Struct Day = " + arr[i].Day);
            }

            string Text = ConvertNumberToString(123);
            Console.WriteLine(Text);    
            Console.WriteLine(IsLeapYear(2004));
            Console.WriteLine(IsLeapYear(2012));
            Console.WriteLine(IsLeapYear(2006));
            Console.WriteLine(IsLeapYear(2010));
            Console.WriteLine(DaysFromBeginnerOfYear(2022, 4, 22));
            Console.WriteLine(Date1EqualThanDate2(date1,date2));
            Date date3 = new Date();
            Date date4 = new Date();
            date4.Year = 2002;
            date4.Month = 3;
            date4.Day = 22;
            date3.Year = 2023;
            date3.Month = 11;
            date3.Day = 13;
            date3 = IcreaseDateByOne(date1);
            Console.WriteLine(date3.Day);
            MonthCalendar(5, 28);
            Console.WriteLine();
            int day = DiffBetweenDates(date4,date3);
            Console.WriteLine("My Age Is : " + day);
            Console.ReadLine();
        }
    }
}
