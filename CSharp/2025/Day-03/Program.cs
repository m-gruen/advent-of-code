// Advent of Code 2025: Day 3

var lines = File.ReadAllLines("input.txt");

Console.WriteLine($"Part 1: {Part1(lines)}");
Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    int sum = 0;

    foreach (var line in lines)
    {
        int[] numbers = [.. line.Select(c => c - '0')];

        int max = numbers.Max();
        int secondMax;
        int indexOfMax = Array.IndexOf(numbers, max);
        if (indexOfMax == numbers.Length - 1)
        {
            numbers[indexOfMax] = -1;
            secondMax = numbers.Max();
            sum += secondMax * 10 + max;
        }
        else
        {
            secondMax = numbers[(indexOfMax + 1)..].Max();
            sum += max * 10 + secondMax;
        }
    }

    return sum;
}

int Part2(string[] lines)
{
    return 0;
}

