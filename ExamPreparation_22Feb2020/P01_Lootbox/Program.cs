using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            List<int> claimedItems = new List<int>();

            while (!(firstBox.Count == 0 || secondBox.Count == 0))
            {
               int currentItemOne = firstBox.Peek();
               int currentItemTwo = secondBox.Peek();
                int sum = currentItemOne + currentItemTwo;
                if (sum % 2 == 0)
                {
                    claimedItems.Add(sum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int sumOfClaimedItems = claimedItems.Sum();
            if (sumOfClaimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumOfClaimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumOfClaimedItems}");
            }
        }
    }
}
