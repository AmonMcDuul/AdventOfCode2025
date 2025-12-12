namespace AdventOfCode.Days
{
    public static class Day1
    {
        public static void Part1()
        {
            string[] lines = File.ReadAllLines("Input/day1.txt");
            int value = 50;
            int result = 0;

            foreach (var line in lines)
            {
                char direction = line[0];
                int amount = int.Parse(line[1..]);

                int delta = direction == 'L' ? -amount : amount;
                value = (value + delta) % 100;

                if (value < 0)
                {
                    value += 100;
                }

                if (value == 0)
                {
                    result++;
                }
            }

            Console.WriteLine("Day 1 - Part 1: " + result);
        }

        public static void Part2()
        {
            string[] lines = File.ReadAllLines("Input/day1.txt");
            int value = 50;
            long result = 0;

            foreach (var line in lines)
            {
                char direction = line[0];
                int amount = int.Parse(line[1..]);

                int delta = direction == 'L' ? -amount : amount;
                int steps = Math.Abs(amount);

                int distanceToZero =
                    direction == 'R'
                    ? (100 - value) % 100
                    : value % 100;

                if (distanceToZero == 0)
                {
                    distanceToZero = 100;
                }

                if (steps >= distanceToZero)
                {
                    result += 1 + (steps - distanceToZero) / 100;
                }

                value = ((value + delta) % 100 + 100) % 100;
            }

            Console.WriteLine("Day 1 - Part 2: " + result);
        }
    }
}
