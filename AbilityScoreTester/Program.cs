using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbilityScoreTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbilityScoreCalculator calculator = new AbilityScoreCalculator();

            while (true)
            {
                calculator.RollResult = AbilityScoreCalculator.ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.Divideby = AbilityScoreCalculator.ReadDouble(calculator.Divideby, "Divided by");
                calculator.AddAmount = AbilityScoreCalculator.ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = AbilityScoreCalculator.ReadInt(calculator.Minimum, "Minimum");

                calculator.CalculateAbilityScore();
                Console.WriteLine("Calculated ability score: " + calculator.Score);
                Console.WriteLine("Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;

                if ((keyChar == 'Q') || (keyChar == 'q')) return;

            }
        }


    }

    public class AbilityScoreCalculator
    {
        public int RollResult = 14;
        public double Divideby = 1.75;
        public int AddAmount = 2;
        public int Minimum = 3;
        public int Score;

        public void CalculateAbilityScore()
        {
            //Divide the roll result by the DivideBy field
            double divided = RollResult / Divideby;

            // Add AddAmount to the result of that division
            int added = AddAmount + (int)divided;

            // If the result is too small, use Minimum
            if (added < Minimum)
            {
                Score = Minimum;
            }
            else
            {
                Score = added;
            }
        }

        public static int ReadInt(int lastUsedValue,string prompt)
        {
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            string line = Console.ReadLine();
            if(int.TryParse(line,out int value))
            {
                Console.WriteLine(" using value " + value);
                return value;
            }
            else
            {
                Console.WriteLine(" using default value " + lastUsedValue);
                return lastUsedValue;
            }
        }

        public static double ReadDouble(double lastUsedValue, string prompt)
        {
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            string line = Console.ReadLine();
            if (double.TryParse(line, out double value))
            {
                Console.WriteLine(" using value " + value);
                return value;
            }
            else
            {
                Console.WriteLine(" using default value " + lastUsedValue);
                return lastUsedValue;
            }
        }
    }
}
