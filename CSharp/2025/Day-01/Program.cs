// Advent of Code 2025: Day 1

var lines = File.ReadAllLines("input.txt");

Console.WriteLine($"Part 1: {Part1(lines)}");
Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    int currentNumber = 50;
    int zeroCount = 0;

    foreach (var line in lines)
    {
        char direction = line[0];
        var dist = int.Parse(line[1..]);

        if (direction == 'L')
        {
            currentNumber = (currentNumber - dist) % 100;
            if (currentNumber < 0) { currentNumber += 100; }
        }
        else
        {
            currentNumber = (currentNumber + dist) % 100;
        }

        if (currentNumber == 0) { zeroCount++; }
    }

    return zeroCount;
}

int Part2(string[] lines)
{
    int currentNumber = 50;
    int zeroCount = 0;

    foreach (var line in lines)
    {
        char direction = line[0];
        int dist = int.Parse(line[1..]);

        zeroCount += dist / 100;

        int remainingSteps = dist % 100;

        for (int i = 0; i < remainingSteps; i++)
        {
            if (direction == 'L')
            {
                currentNumber--;
                if (currentNumber < 0) { currentNumber = 99; }
            }
            else
            {
                currentNumber++;
                if (currentNumber == 100) { currentNumber = 0; }
            }

            if (currentNumber == 0) { zeroCount++; }
        }
    }

    return zeroCount;
}
