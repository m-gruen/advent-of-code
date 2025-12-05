// Advent of Code 2025: Day 4

var lines = File.ReadAllLines("input.txt");

Console.WriteLine($"Part 1: {Part1(lines)}");
Console.WriteLine($"Part 2: {Part2(lines)}");

int Part1(string[] lines)
{
    return GetCountOfFourOrLessAdjacent(lines);
}

int Part2(string[] lines)
{
    int total = 0;
    int count;
    
    do
    {
        count = GetCountOfFourOrLessAdjacent(lines, true);
        total += count;
    } while (count > 0);

    return total;
}

int GetCountOfFourOrLessAdjacent(string[] lines, bool replace = false)
{
    int count = 0;
    int rows = lines.Length;
    int cols = lines[0].Length;

    int[] dx = [-1, -1, -1, 0, 0, 1, 1, 1];
    int[] dy = [-1, 0, 1, -1, 1, -1, 0, 1];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (lines[i][j] == '@')
            {
                int adjacentCount = 0;

                for (int k = 0; k < 8; k++)
                {
                    if (adjacentCount >= 4)
                    {
                        break;
                    }

                    int ni = i + dx[k];
                    int nj = j + dy[k];

                    if (ni >= 0 && ni < rows && nj >= 0 && nj < cols && lines[ni][nj] == '@')
                    {
                        adjacentCount++;
                    }
                }

                if (adjacentCount < 4)
                {
                    count++;

                    if (replace)
                    {
                        char[] lineChars = lines[i].ToCharArray();
                        lineChars[j] = '.';
                        lines[i] = new string(lineChars);
                    }
                }
            }
        }
    }

    return count;
}
