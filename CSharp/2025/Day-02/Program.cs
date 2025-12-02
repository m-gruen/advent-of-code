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

long Part2(string text)
{
    var idParts = text.Split(',');
    long invalidIdSum = 0;

    foreach (var idPart in idParts)
    {
        var ids = idPart.Split('-').Select(long.Parse).ToArray();

        for (long id = ids[0]; id <= ids[1]; id++)
        {
            var idStr = id.ToString();

            for (int seqLength = 1; seqLength <= idStr.Length / 2; seqLength++)
            {
                if (idStr.Length % seqLength == 0)
                {
                    var sequence = idStr[..seqLength];
                    var repeatedSequence = string.Concat(Enumerable.Repeat(sequence, idStr.Length / seqLength));
                    
                    if (repeatedSequence == idStr)
                    {
                        invalidIdSum += id;
                        break;
                    }
                }
            }
        }
    }

    return invalidIdSum;
}
