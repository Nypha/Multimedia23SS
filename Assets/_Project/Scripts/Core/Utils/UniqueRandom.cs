using System.Collections.Generic;

namespace Dreihaus.Utils
{
    public class UniqueRandom<T>
    {
        public bool HasElements { get => elements != null && elements.Count > 0; }


        protected List<T> elements;


        /// <summary>
        /// Creates a pool with unique random elements from <c>min</c> to <c>max</c>.
        /// </summary>
        /// <param name="options">The options to use.</param>
        public UniqueRandom(params T[] options)
        {
            elements = new List<T>(options);
        }

        /// <summary>
        /// Creates a pool with unique random elements from <c>min</c> to <c>max</c>.
        /// </summary>
        /// <param name="options">The options to use.</param>
        public UniqueRandom(List<T> options)
        {
            elements = new List<T>(options);
        }


        public T Get()
        {
            if (!HasElements)
            {
                return default;
            }

            var r = elements[UnityEngine.Random.Range(0, elements.Count)];
            elements.Remove(r);
            return r;
        }

        public void Remove(T i)
        {
            if (elements.Contains(i))
            {
                elements.Remove(i);
            }
        }
    }

    public class UniqueRandom : UniqueRandom<int>
    {
        /// <summary>
        /// Creates a pool with unique random elements from <c>min</c> to <c>max</c> using int values.
        /// </summary>
        /// <param name="min">The lowest value (inclusive).</param>
        /// <param name="max">The highest value (inclusive).</param>
        public UniqueRandom(int min, int max)
        {
            elements = new List<int>();
            for (int i = min; i < max + 1; i++)
            {
                elements.Add(i);
            }
        }
    }
}