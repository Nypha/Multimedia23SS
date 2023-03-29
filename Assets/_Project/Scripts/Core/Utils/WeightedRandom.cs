// Thank you: https://stackoverflow.com/questions/46563490/c-sharp-weighted-random-numbers

using System.Collections.Generic;
using System.Linq;

namespace Dreihaus.Utils
{
    public interface IWeightedRandomValue<T>
    {
        T Element { get; }
        float Weight { get; }
    }
    public class WeightedRandomValue<T> : IWeightedRandomValue<T>
    {
        public T Element { get; }
        public float Weight { get; }

        public WeightedRandomValue(T element, float weight)
        {
            Element = element;
            Weight = weight;
        }
    }
    public class WeightedRandomHandler<T>
    {
        public List<IWeightedRandomValue<T>> Parameters { get; }
        public float WeightSum => Parameters.Sum(p => p.Weight);


        private System.Random r;
        public WeightedRandomHandler(List<IWeightedRandomValue<T>> paramters)
        {
            Parameters = paramters;
            r = new System.Random();
        }
        public WeightedRandomHandler(Dictionary<T, float> parameters)
        {
            Parameters = new List<IWeightedRandomValue<T>>();
            r = new System.Random();
            foreach (var par in parameters)
            {
                Parameters.Add(new WeightedRandomValue<T>(par.Key, par.Value));
            }
        }


        public virtual T Get()
        {
            var numericValue = (float)(r.NextDouble() * WeightSum);
            foreach (var parameter in Parameters)
            {
                numericValue -= parameter.Weight;

                if (numericValue > 0)
                {
                    continue;
                }

                return parameter.Element;
            }

            return default;
        }
    }
    public class UniqueWeightedRandomHandler<T> : WeightedRandomHandler<T>
    {
        public UniqueWeightedRandomHandler(List<IWeightedRandomValue<T>> paramters) : base(paramters) { }
        public UniqueWeightedRandomHandler(Dictionary<T, float> parameters) : base(parameters) { }

        public override T Get()
        {
            var t = base.Get();
            for (int i = 0; i < Parameters.Count; i++)
            {
                if (Parameters[i].Element.Equals(t))
                {
                    Parameters.RemoveAt(i);
                    break;
                }
            }
            return t;
        }
    }
}