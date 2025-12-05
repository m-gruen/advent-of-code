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

long Part2(string text)
{
    var (ranges, _) = ConvertInput(text);
    var sortedRanges = ranges.OrderBy(r => r.from).ToList();

    List<(long from, long to)> mergedRanges = [];

    foreach (var current in sortedRanges)
    {
        if (mergedRanges.Count == 0)
        {
            mergedRanges.Add(current);
            continue;
        }

        var lastIndex = mergedRanges.Count - 1;
        var (lastFrom, lastTo) = mergedRanges[lastIndex];

        if (current.from > lastTo + 1)
        {
            mergedRanges.Add(current);
        }
        else
        {
            long newTo = Math.Max(lastTo, current.to);
            mergedRanges[lastIndex] = (lastFrom, newTo);
        }
    }

    long validIdsCount = 0;
    foreach (var (from, to) in mergedRanges)
    {
        validIdsCount += to - from + 1;
    }

    return validIdsCount;
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
