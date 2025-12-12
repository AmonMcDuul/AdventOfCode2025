using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public static class Day2
    {
        public static void Part1()
        {
            string[] lines = File.ReadAllLines("Input/day2.txt");
            long result = 0;

            foreach (var line in lines)
            {
                var parts = line.Split('-');

                long start = Int64.Parse(parts[0]);
                long end = Int64.Parse(parts[1]);
                for (long i = start; i <= end; i++)
                {
                    result += GetRepeatedDigit(i.ToString());
                }
            }

            Console.WriteLine("Day 2 - Part 1: " + result);
        }


        public static void Part2()
        {
            string[] lines = File.ReadAllLines("Input/day2.txt");
            long result = 0;

            foreach (var line in lines)
            {
                var parts = line.Split('-');

                long start = Int64.Parse(parts[0]);
                long end = Int64.Parse(parts[1]);

                result += GetRepeatedDigitValueInRange(start, end);
            }

            Console.WriteLine("Day 2 - Part 1: " + result);
        }


        public static long GetRepeatedDigit(string sequence)
        {
            if (sequence.Length > 1 && sequence[0] == '0')
            {
                return 0;
            }

            if (sequence.Length % 2 != 0)
            {
                return 0;
            }

            int halfLength = sequence.Length / 2;
            string firstHalf = sequence.Substring(0, halfLength);
            string secondHalf = sequence.Substring(halfLength, halfLength);

            if (firstHalf == secondHalf)
            {
                long val = Int64.Parse(sequence);
                return val;
            }

            return 0;
        }

        public static long GetRepeatedDigitValueInRange(long start, long end)
        {
            long sum = 0;

            for (long i = start; i <= end; i++)
            {
                sum += GetRepeatedSequenceValue(i.ToString());
            }

            return sum;
        }

        public static long GetRepeatedSequenceValue(string sequence)
        {
            if (sequence.Length > 1 && sequence[0] == '0')
            {
                return 0;
            }

            for (int len = 1; len <= sequence.Length / 2; len++)
            {
                if (sequence.Length % len != 0) continue;

                string prefix = sequence.Substring(0, len);
                int times = sequence.Length / len;

                string built = string.Concat(Enumerable.Repeat(prefix, times));

                if (built == sequence)
                {
                    return Int64.Parse(sequence); 
                }
            }

            return 0;
        }
    }
}
