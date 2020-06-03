using System;

namespace CrackingCodingInterview.Moderate
{
    public class Task1610
    {
        public Task1610()
        {
            var people = new Person[100];
            var random = new Random();
            
            for (var i = 0; i < people.Length; i++)
            {
                var birthDate = random.Next(1900, 2000);
                var deathDate = random.Next(birthDate, 2000);
                
                people[i] = new Person()
                {
                    BirthDate = birthDate, 
                    DeathDate = deathDate,
                };
            }

            Console.WriteLine(Solution(people, 1900, 2000));
        }

        private int Solution(Person[] people, int min, int max)
        {
            var populationDeltas = GetPopulationDeltas(people, min, max);
            var maxAliveYear = GetMaxAliveYear(populationDeltas);

            return min + maxAliveYear;
        }

        private int[] GetPopulationDeltas(Person[] people, int min, int max)
        {
            var deltas = new int[max - min + 2];

            foreach (var person in people)
            {
                var birth = person.BirthDate - min;
                
                deltas[birth]++;

                var death = person.DeathDate - min;
                deltas[death + 1]--;
            }

            return deltas;
        }

        public int GetMaxAliveYear(int[] deltas)
        {
            var maxAliveYear = 0;
            
            var maxAlive = 0;
            var currentAlive = 0;

            for (var year = 0; year < deltas.Length; year++)
            {
                currentAlive += deltas[year];

                if (currentAlive > maxAlive)
                {
                    maxAlive = currentAlive;
                    maxAliveYear = year;
                }
            }

            return maxAliveYear;
        }
    }

    internal class Person
    {
        public int BirthDate;
        public int DeathDate;
    }
}