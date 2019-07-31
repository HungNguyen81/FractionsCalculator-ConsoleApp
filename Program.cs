using System;
using System.Text;
using System.Threading;

namespace Fraction2
{
    public class CurrentTime
    {
        public CurrentTime (DateTime dt)
        {
            hour = dt.Hour;
            min = dt.Minute;
            sec = dt.Second;
        }
        public void DisplayCurrentTime()
        {
            Console.WriteLine("\t\t\t\t{0}:{1}:{2}", hour, min, sec);
        }
        private readonly int hour, min, sec;
    }
    public class Fraction
    {
        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        public Fraction(int wholeNum)
        {
            numerator = wholeNum;
            denominator = 1;
        }
        public static implicit operator Fraction(int theInt)  //toán tử chuyển đổi implicit
        {
            return new Fraction(theInt);
        }
        public static explicit operator int(Fraction theFract) //toán tử chuyển đổi explicit 
        {
            return theFract.numerator / theFract.denominator;
        }
        public static bool operator ==(Fraction leftSide, Fraction rightSide)
        {
            if (leftSide.numerator * rightSide.denominator == rightSide.numerator * leftSide.denominator)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Fraction leftSide, Fraction rightSide)
        {
            return !(leftSide == rightSide);
        }
        // alternate method for ==, !=                         // 'Fraction' defines operator == or != but does not override 
        public override bool Equals(object o)                  // Object.Equals(object o)
        {
            if (o is Fraction)
                return true;
            return this == (Fraction)o;
        }
        public static bool operator >(Fraction f1, Fraction f2)
        {
            if (f1.numerator * f2.denominator > f2.numerator * f1.denominator)
                return true;
            return false;
        }
        public static bool operator <(Fraction f1, Fraction f2)
        {
            if (f1.numerator * f2.denominator < f2.numerator * f1.denominator)
                return true;
            return false;
        }
        public static bool operator >=(Fraction f1, Fraction f2)
        {
            if (f1.numerator * f2.denominator >= f2.numerator * f1.denominator)
                return true;
            return false;
        }
        public static bool operator <=(Fraction f1, Fraction f2)
        {
            if (f1.numerator * f2.denominator <= f2.numerator * f1.denominator)
                return true;
            return false;
        }
        //---------------------------------------------------------------------
        public override int GetHashCode()   // override GetHashCode() method
        {
            return base.GetHashCode();
        }
        //---------------------------------------------------------------------
        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            if (f1.denominator == f2.denominator)
                return new Fraction(f1.numerator + f2.numerator, f1.denominator);
            return new Fraction(f1.numerator * f2.denominator + f2.numerator * f1.denominator,
                f1.denominator * f2.denominator);
        }
        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            if (f1.denominator == f2.denominator)
                return new Fraction(f1.numerator - f2.numerator, f1.denominator);
            return new Fraction(f1.numerator * f2.denominator - f2.numerator * f1.denominator,
                f1.denominator * f2.denominator);
        }
        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.numerator * f2.numerator, f1.denominator * f2.denominator);
        }
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.numerator * f2.denominator, f1.denominator * f2.numerator);
        }

        //---------------------------------------------------------
        private int UCLN(int a, int b)
        {
            if (a == 0) return b;
            return UCLN(b % a, a);
        }
        //---------------------------------------------------------
        public void CompactFract(Fraction f)
        {
            int temp = f.UCLN(f.numerator, f.denominator);
            Fraction fr = new Fraction(f.numerator / temp, f.denominator / temp);
            Console.WriteLine("\tCompact Fraction of {0}/{1} is {2}/{3}", f.numerator, f.denominator,
                fr.numerator, fr.denominator);
        }
        public override string ToString()
        {
            int temp = UCLN(numerator, denominator);
            numerator /= temp;
            denominator /= temp;
            string str = numerator.ToString() + "/" + denominator.ToString();
            return str;
        }
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }
        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; }
        }
        private int numerator;
        private int denominator;
    }
    class Program
    {
        static void Main()
        {
            int choice = 0;
            int num1 = 1, num2 = 1, den1 = 1, den2 = 1;
            Fraction f1 = new Fraction(num1, den1);
            Fraction f2 = new Fraction(num2, den2);
            Fraction f31 = f1 + f2;
            Fraction f32 = f1 - f2;
            Fraction f33 = f1 * f2;
            Fraction f34 = f1 / f2;
            Console.OutputEncoding = Encoding.UTF8;

        reset:
            DateTime current = DateTime.Now;
            CurrentTime time = new CurrentTime(current);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n------------------------------------------------------------------------------");
            Console.WriteLine("                  CHƯƠNG TRÌNH TÍNH TOÁN VỚI PHÂN SỐ                          ");
            Console.WriteLine("                            Wrote by N.N.H                                    ");
            Console.WriteLine("                              25.07.2019                                      ");
            time.DisplayCurrentTime();
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.ResetColor();

            Console.Write("\tPhân số thứ nhất,  nhập tử số:   ");
            num1 = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("\t       nhập mẫu số khác không:   ");
                den1 = int.Parse(Console.ReadLine());
            } while (den1 == 0);
            f1 = new Fraction(num1, den1);
            Console.Write("\tPhân số thứ hai,   nhập tử số:   ");
            num2 = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("\t       nhập mẫu số khác không:   ");
                den2 = int.Parse(Console.ReadLine());
            } while (den2 == 0);
            f2 = new Fraction(num2, den2);

            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n------------------------------------------------------------------------------");
                Console.WriteLine("                  CHƯƠNG TRÌNH TÍNH TOÁN VỚI PHÂN SỐ                          ");
                Console.WriteLine("                            Wrote by N.N.H                                    ");
                Console.WriteLine("                              25.07.2019                                      ");
                time.DisplayCurrentTime();
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\t\t\tYour Fractions are: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("{0} and {1}", f1.ToString(), f2.ToString());
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\t\t\tBạn muốn tôi làm gì ? ");
                Console.ResetColor();
                Console.WriteLine("\t\t\t1. Cộng hai phân số");
                Console.WriteLine("\t\t\t2. Trừ hai phân số");
                Console.WriteLine("\t\t\t3. Nhân hai phân số");
                Console.WriteLine("\t\t\t4. Chia hai phân số");
                Console.WriteLine("\t\t\t5. Rút gọn phân số");
                Console.WriteLine("\t\t\t6. So sánh hai phân số");
                Console.WriteLine("\t\t\t7. Nhập hai phân số khác");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t8. Thoát chương trình");
                Console.ResetColor();
                Console.Write("\t\t\t\tYour Choice: \t");
                choice = int.Parse(Console.ReadLine());
                Console.Write("\n");

                switch (choice)
                {
                    case 1:
                     
                        f31 = f1 + f2;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t\t\t{0} + {1} = {2}", f1.ToString(), f2.ToString(), f31.ToString());
                        Console.ResetColor();
                        break;
                    case 2:
                        
                        f32 = f1 - f2;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t\t\t{0} - {1} = {2}", f1.ToString(), f2.ToString(), f32.ToString());
                        Console.ResetColor();
                        break;
                    case 3:
                        
                        f33 = f1 * f2;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t\t\t{0} x {1} = {2}", f1.ToString(), f2.ToString(), f33.ToString());
                        Console.ResetColor();
                        break;
                    case 4:
                        while(num2 == 0)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\t\tPhân số thứ hai phải KHÁC KHÔNG !");
                            Console.ResetColor();
                            Console.Write("\tPhân số thứ hai,   nhập tử số:   ");
                            num2 = int.Parse(Console.ReadLine());
                            do
                            {
                                Console.Write("\t       nhập mẫu số khác không:   ");
                                den2 = int.Parse(Console.ReadLine());
                            } while (den2 == 0);
                            f2 = new Fraction(num2, den2);
                        }
                        f34 = f1 / f2;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\t\t\t\t{0} : {1} = {2}", f1.ToString(), f2.ToString(), f34.ToString());
                        Console.ResetColor();
                        break;
                    case 5:
                        Console.Write("\tPhân số cần rút gọn,  nhập tử số:   ");
                        num1 = int.Parse(Console.ReadLine());
                        do
                        {
                            Console.Write("\t          nhập mẫu số khác không:   ");
                            den1 = int.Parse(Console.ReadLine());
                        } while (den1 == 0);
                        f1 = new Fraction(num1, den1);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        f1.CompactFract(f1);
                        Console.ResetColor();
                        break;
                    case 6:
                        if (f1 > f2)
                        {
                            Console.WriteLine("\t\t\t{0} lớn hơn {1}", f1.ToString(), f2.ToString());
                        }
                        else
                        {
                            if (f1 == f2)
                                Console.WriteLine("\t\t\t{0} bằng {1}", f1.ToString(), f2.ToString());
                            Console.WriteLine("\t\t\t{0} bé hơn {1}", f1.ToString(), f2.ToString());
                        }
                        break;
                    case 7:
                        goto reset;
                    case 8:
                        char ch;
                        do
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\n\n\tBẠN CÓ CHẮC LÀ MUỐN THOÁT CHƯƠNG TRÌNH ? (Y/N)\t");
                            Console.ResetColor();
                            ch = char.Parse(Console.ReadLine());
                        } while (!(ch == 'y' || ch == 'n' || ch == 'Y' || ch == 'N'));
                        if (ch == 'n' || ch == 'N')
                            goto reset;
                        else
                            for(int i = 0; i < 5; i++)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("\n\n\t\t\tEXIT IN {0} SECOND(S)!", 5-i);
                                Thread.Sleep(1000);
                                Console.ResetColor();
                            }
                            goto end;
                }
                Console.ReadKey();
                Thread.Sleep(1000);
            }
        end:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n\n\tPRESS ANY KEY TO EXIT PROGRAM !\n\n");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
