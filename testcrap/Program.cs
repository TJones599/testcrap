using System;
using System.IO;
using System.Reflection;

namespace testcrap
{
    class Program
    {
        private static readonly string textFile = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


        private static void WriteLongStrings(string message)
        {
            string[] str = message.Split(' ');

            for(int i = 0; i < str.Length; i ++)
            {
                if(Console.CursorLeft>60)
                {
                    Console.WriteLine();
                }

                Console.Write(str[i]);
            }

        }


        private static void WriteLongStringsToFile(string message)
        {
            StreamWriter sw = new StreamWriter(textFile+@"\test.txt");

            for (int i = 0; i < message.Length; i++)
            {
                if (i%80 == 0 && i != 0 && message[i] == ' ')
                {
                    sw.WriteLine();
                }

                sw.Write(message[i]);
            }
            sw.Close();
            sw.Dispose();

        }

        static void Main(string[] args)
        {



            string message = "aasdjf;lk asdf jklasflads jfkle jal;sdjf lzxnfopewin as,dmcn lzxf nas hdlfkje;oasd fljen akjlsd fjken aiusdbf kjzsdbglaeabkhsf fdlgu adsvv" +
                "asdf hean lsdfnelaje";

            WriteLongStringsToFile(message);

            Console.ReadKey();

            //substring
            /*
            string test = "how does this work";
            string firstWord = test.Substring(4,4);
            Console.WriteLine(firstWord);
            Console.ReadKey();

            */
            /*string right = "Right";
            string left = "Left";

            Console.WriteLine(string.Format("{0, 10}\n{1,-10} see", right, left));
            Console.ReadKey();*/

            /*
             * string format coding practice
             * 
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            //9/17/2018 3:44pm
            //September, 2018
            Console.WriteLine(string.Format("{0:y}", dt));   
            //18
            Console.WriteLine(string.Format("{0:yy}", dt));  
            //2018
            Console.WriteLine(string.Format("{0:yyy}", dt)); 
            //2018
            Console.WriteLine(string.Format("{0:yyyy}", dt));

            // month, day
            Console.WriteLine(string.Format("{0:m}", dt));   
            //minutes of the day
            Console.WriteLine(string.Format("{0:mm}", dt));  
            //12 hour clock output for hour
            Console.WriteLine(string.Format("{0:hh}", dt));  
            //military clock output for hour
            Console.WriteLine(string.Format("{0:HH}", dt));

            //full standard time 03:48 pm
            Console.WriteLine(string.Format("{0:hh}:{0:mm} {0:tt}", dt));

            //September 17, 2018, 3:59 PM
            Console.WriteLine(string.Format("{0:MMMM dd, yyyy, hh:mm tt}",dt));
          

            Console.ReadKey();
            */

            /*
             * integer formating practice
             * 
            int one = 80;
            int two = 100;
          
            //results in a 0. cannont implicitly convert int to decimal
            decimal number2 = one / two;
            //force convert int one and int two to decimal, resulting in a decimal answer
            decimal number = Convert.ToDecimal(one)/Convert.ToDecimal(two);

            decimal number3 = Convert.ToDecimal(1234.54);

            //p makes it percentage
            Console.WriteLine("{0:p} is the percentage form of {0}",number);
            //x turns an int into a hexidecimal number. ONLY WORKS ON INTS!!!!!!!!
            Console.WriteLine("{0} = {0:x} in hex", one);
            Console.WriteLine("{1} = {0:x} in hex", Convert.ToInt32(number3),number3);
            Console.ReadKey();
            */

            /*--- wtf is this?!? so much to learn to little comments to do it in! D:
             * weird stuff
             * 
            CultureInfo CI = new CultureInfo("en-US");
            */

            /*
             * format practice
            writes a percentage using format to apply appropriet signs
            int test = 1504277;
            int testpt2 = 1970358;
            //need (double) to force a double type output
            string s = string.Format("{0,10:P1}", (testpt2-test)/(double)test);
            Console.WriteLine(s);
            Console.ReadLine();
            */


            /*
             * learning DateTime manipulation
             * 
            string hour = DateTime.Now.Hour.ToString("hh");
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            //string hour = Convert.ToString(currentTime.Hours);
            // hour = hour.Substring(0, 2);
            Console.WriteLine(hour);
            Console.WriteLine(currentTime.Hours+":"+currentTime.Minutes+":"+currentTime.Seconds);
            hour = Convert.ToString(currentTime.Hours-9);
            Console.WriteLine(hour);
            Console.ReadKey();
            */




        }
    }

    //Custom formatting example... to much to break down atm
    /*
    public class AcctNumberFormat : IFormatProvider, ICustomFormatter
    {
        private const int ACCT_LENGTH = 12;

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {
            // Provide default formatting if arg is not an Int64.
            if (arg.GetType() != typeof(Int64))
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }

            // Provide default formatting for unsupported format strings.
            string ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
            if (!(ufmt == "H" || ufmt == "I"))
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }

            // Convert argument to a string.
            string result = arg.ToString();

            // If account number is less than 12 characters, pad with leading zeroes.
            if (result.Length < ACCT_LENGTH)
                result = result.PadLeft(ACCT_LENGTH, '0');
            // If account number is more than 12 characters, truncate to 12 characters.
            if (result.Length > ACCT_LENGTH)
                result = result.Substring(0, ACCT_LENGTH);

            if (ufmt == "I")                    // Integer-only format. 
                return result;
            // Add hyphens for H format specifier.
            else                                         // Hyphenated format.
                return result.Substring(0, 5) + "-" + result.Substring(5, 3) + "-" + result.Substring(8);
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }
    }
    */
}
