using System;
using System.Collections.Generic;
using System.Linq;

namespace CrackingCodingInterview.Hard
{
    public class Task1708
    {
        public Task1708()
        {
            var input = new Tuple<int, int>[]
            {
                new Tuple<int, int>(65, 100), 
                new Tuple<int, int>(70, 150), 
                new Tuple<int, int>(56, 90), 
                new Tuple<int, int>(75, 190), 
                new Tuple<int, int>(60, 95), 
                new Tuple<int, int>(68, 110), 
            };

            Console.WriteLine(6 == Solution(input));
        }

        private int Solution(Tuple<int, int>[] input)
        {
            Array.Sort(input, (tuple, tuple1) => tuple1.Item2.CompareTo(tuple.Item2));

            var maxSequence = 0;
            var solutions = new List<Tuple<int, int>>[input.Length];
            
            for (var i = 0; i < input.Length; i++)
            {
                var currentSequence = BestSequenceAtIndex(input, solutions, i);
                solutions[i] = currentSequence;
                maxSequence = Math.Max(maxSequence, currentSequence.Count);

            }
            
            return maxSequence;
        }

        private List<Tuple<int, int>> BestSequenceAtIndex(Tuple<int, int>[] input, List<Tuple<int, int>>[] solutions, int index)
        {
            var value = input[index];
            
            var bestSequence = new List<Tuple<int, int>>();

            for (var i = 0; i < index; i++)
            {
                var solution = solutions[i];

                if (CanAppend(solution, value))
                {
                    if (solution.Count > bestSequence.Count)
                    {
                        bestSequence = solution;
                    }
                }
            }
            
            var best = new List<Tuple<int, int>>();
            foreach (var tuple in bestSequence)
            {
                best.Add(tuple);
            }
            
            best.Add(value);

            return best;
        }

        private bool CanAppend(List<Tuple<int, int>> solution, Tuple<int, int> value)
        {
            if (solution.Count == 0)
            {
                return true;
            }

            var last = solution.Last();
            return last.Item2 > value.Item2 && last.Item1 > value.Item1;
        }
    }
}