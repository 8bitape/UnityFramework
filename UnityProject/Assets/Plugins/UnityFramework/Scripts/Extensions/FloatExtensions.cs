namespace UnityFramework.Extensions
{
    public static class FloatExtensions
    {
        public static float Increment(this float value, float step)
        {
            return value += step;
        }

        public static float Increment(this float value, float step, float maxValue)
        {
            if (value < maxValue)
            {
                return value.Increment(step);
            }
            else
            {
                return value;
            }
        }

        public static float Increment(this float value, float step, float maxValue, float wrapValue)
        {
            if (value < maxValue)
            {
                return value.Increment(step);
            }
            else
            {
                return wrapValue;
            }
        }

        public static float Decrement(this float value, float step)
        {
            return value.Increment(-step);
        }

        public static float Decrement(this float value, float step, float minValue)
        {
            if (value < minValue)
            {
                return value.Decrement(step);
            }
            else
            {
                return value;
            }
        }

        public static float Decrement(this float value, float step, float minValue, float wrapValue)
        {
            if (value < minValue)
            {
                return value.Decrement(step);
            }
            else
            {
                return wrapValue;
            }
        }
    }
}
