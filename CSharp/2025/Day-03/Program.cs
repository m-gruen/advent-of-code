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

long Part2(string[] lines)
{
    List<int> findhighest12Digits(List<int> remainingNumbers, List<int> shouldBeTwelveNumbers)
    {
        if (shouldBeTwelveNumbers.Count == 12)
        {
            return shouldBeTwelveNumbers;
        }

        int max = remainingNumbers[..^(12 - shouldBeTwelveNumbers.Count - 1)].Max();

        int idx = remainingNumbers.IndexOf(max);
        shouldBeTwelveNumbers.Add(max);
        remainingNumbers.RemoveRange(0, idx + 1);
        return findhighest12Digits(remainingNumbers, shouldBeTwelveNumbers);
    }

    long sum = 0;
    foreach (var line in lines)
    {
        List<int> numbers = [.. line.Select(c => c - '0')];


        var highest12Digits = findhighest12Digits(numbers, []);
        long number = 0;
        foreach (var digit in highest12Digits)
        {
            number = number * 10 + digit;
        }

        sum += number;
    }

    return sum;
}
