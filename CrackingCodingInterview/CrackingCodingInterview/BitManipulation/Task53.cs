using System;
using System.Collections.Generic;

namespace CrackingCodingInterview.BitManipulation
{
    public class Task53
    {
        public Task53()
        {
            Console.WriteLine(8 == SolutionBruteForce(0b_0110_1110_1111));
        }

        private int SolutionBruteForce(int N)
        {
            if (N == -1)
            {
                return 32;
            }

            var sequences = GetAlternatingSequences(N);
            return FindLongestSequence(sequences);
        }

        private List<int> GetAlternatingSequences(int N)
        {
            var sequences = new List<int>();

            var searchingFor = 0;
            var counter = 0;

            for (var i = 0; i < 32; i++)
            {
                if ((N & 1) != searchingFor)
                {
                    sequences.Add(counter);
                    searchingFor = N & 1;
                    counter = 0;
                }

                counter++;
                N = N >> 1;
            }
            
            sequences.Add(counter);

            return sequences;
        }

        private int FindLongestSequence(List<int> sequences)
        {
            var maxSequence = 1;

            for (var i = 0; i < sequences.Count; i++)
            {
                var zerosSequence = sequences[i];
                var onesSequenceRight = i - 1 >= 0 ? sequences[i - 1] : 0;
                var onesSequenceLeft = i + 1 < sequences.Count ? sequences[i + 1] : 0;
                
                var thisSequence = 0;

                if (zerosSequence == 1)
                {
                    thisSequence = onesSequenceLeft + 1 + onesSequenceRight;
                } 
                else if (zerosSequence > 1)
                {
                    thisSequence = 1 + Math.Max(onesSequenceRight, onesSequenceLeft);
                } 
                else if (zerosSequence == 0)
                {
                    thisSequence = Math.Max(onesSequenceRight, onesSequenceLeft);
                }

                maxSequence = Math.Max(thisSequence, maxSequence);
            }

            return maxSequence;
        }
    }
}