// Advent of Code 2025: Day 5

var text = File.ReadAllText("input.txt");

Console.WriteLine($"Part 1: {Part1(text)}");
Console.WriteLine($"Part 2: {Part2(text)}");

int Part1(string text)
{
    var (ranges, ids) = ConvertInput(text);
    var freshId = 0;

    foreach (var id in ids)
    {
        foreach (var (from, to) in ranges)
        {
            if (id >= from && id <= to)
            {
                freshId++;
                break;
            }
        }
    }

    return freshId;
}

int Part2(string text)
{
    return 0;
}

((long from, long to)[], long[]) ConvertInput(string text)
{
    var parts = text.Split("\n\n");

    (long from, long to)[] ranges = [.. parts[0].Split('\n').Select(line =>
    {
        long[] num = [.. line.Split('-').Select(long.Parse)];
        return (num[0], num[1]);
    })];

    long[] ids = [.. parts[1].Split('\n').Select(long.Parse)];

    return (ranges, ids);
}