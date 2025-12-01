// Advent of Code 2025: Day 1

var lines = File.ReadAllLines("input.txt");

System.Console.WriteLine($"Part 1: {Part1(lines)}");
System.Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    int currentNumber = 50;
    int zeroCount = 0;

    foreach (var line in lines)
    {
        var dist = int.Parse(line[1..]);

        if (line[..1] == "L")
        {
            currentNumber = (currentNumber - dist) % 100;

            if (currentNumber < 0)
            {
                currentNumber += 100;
            }
        }
        else
        {
            currentNumber = (currentNumber + dist) % 100;
        }

        if (currentNumber == 0)
        {
            zeroCount++;
        }
    }

    return zeroCount;
}


int Part2(string[] lines)
{
    return 0;
}
