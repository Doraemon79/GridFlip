using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Item
    {
        public int X;
        public int Y;
        public int DayCount;
    }

    class Solution2
    {

        public int minimalDays(int rows, int columns, int[,] grid)
        {
            var shifts = new[]
            {
                new {x = 0, y = 1 },
                new {x = 0, y = -1 },
                new {x = 1, y = 0 },
                new {x = -1, y = 0 },
            };

            int[,] days = new int[rows, columns];

            Queue<Item> queue = new Queue<Item>();

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    if (grid[y, x] == 1)
                    {
                        queue.Enqueue(new Item()
                        {
                            X = x,
                            Y = y,
                            DayCount = 0
                        });
                    }

                    days[y, x] = Int32.MaxValue;
                }
            }

            while (queue.Any())
            {
                var item = queue.Dequeue();

                if (item.X >= 0 && item.X < columns && item.Y >= 0 && item.Y < rows)
                {
                    if (days[item.Y, item.X] == Int32.MaxValue || item.DayCount < days[item.Y, item.X])
                    {
                        days[item.Y, item.X] = item.DayCount;

                        foreach (var shift in shifts)
                        {
                            queue.Enqueue(new Item()
                            {
                                X = item.X + shift.x,
                                Y = item.Y + shift.y,
                                DayCount = item.DayCount + 1
                            });
                        }
                    }
                }
            }

            int answer = 0;
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    answer = Math.Max(answer, days[y, x]);
                }
            }

            return answer;
        }

        static void Main()
        {
            var solution = new Solution2();

            int[,] grid = new int[,]
            {
                {0,1,1,0,1 },
                {0,1,0,1,0 },
                {0,0,0,0,1 },
                {0,1,0,0,0 },
            };
            solution.minimalDays(4, 5, grid);
        }
    }
}
