// Advent of Code 2025: Day 2

var text = File.ReadAllText("input.txt");

Console.WriteLine($"Part 1: {Part1(text)}");
Console.WriteLine($"Part 2: {Part2(text)}");

long Part1(string text)
{
    var idParts = text.Split(',');
    long invalidIdSum = 0;

    foreach (var idPart in idParts)
    {
        var ids = idPart.Split('-').Select(long.Parse).ToArray();

        for (long id = ids[0]; id <= ids[1]; id++)
        {
            var idStr = id.ToString();
            if (idStr.Length % 2 == 0)
            {
                var halfLength = idStr.Length / 2;
                var firstHalf = idStr[..halfLength];
                var secondHalf = idStr[halfLength..];
                if (firstHalf == secondHalf)
                {
                    invalidIdSum += id;
                }
            }
        }
    }

    return invalidIdSum;
}

int Part2(string text)
{
    return 0;
}
