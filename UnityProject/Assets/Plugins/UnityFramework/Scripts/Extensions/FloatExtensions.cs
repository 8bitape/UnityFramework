namespace UnityFramework.Extensions
{
    public static class FloatExtensions
    {
        public static void Increment(this float value, float step)
        {
            value += step;
        }

        public static void Increment(this float value, float step, float maxValue)
        {
            if (value < maxValue)
            {
                value.Increment(step);
            }
        }

        public static void Increment(this float value, float step, float maxValue, float wrapValue)
        {
            if (value < maxValue)
            {
                value.Increment(step);
            }
            else
            {
                value = wrapValue;
            }
        }

        public static void Decrement(this float value, float step)
        {
            value.Increment(-step);
        }

        public static void Decrement(this float value, float step, float minValue)
        {
            if (value > minValue)
            {
                value.Decrement(step);
            }
        }

        public static void Decrement(this float value, float step, float minValue, float wrapValue)
        {
            if (value < minValue)
            {
                value.Decrement(step);
            }
            else
            {
                value = wrapValue;
            }
        }
    }
}
