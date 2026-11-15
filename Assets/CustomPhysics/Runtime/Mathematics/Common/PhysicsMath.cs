
using System;

namespace CustomPhysics
{
    public static class PhysicsMath
    {
        public static float Clamp(float value, float min, float max)
        {
            return MathF.Max(min, MathF.Min(value, max));
        }

        public static float Min(float a, float b)
        {
            return MathF.Min(a, b);
        }

        public static float Max(float a, float b)
        {
            return MathF.Max(a, b);
        }

        public static float Abs(float value)
        {
            return MathF.Abs(value);
        }

        public static float Sqrt(float value)
        {
            return MathF.Sqrt(value);
        }

        public static float Pow(float value, float power)
        {
            return MathF.Pow(value, power);
        }

        public static float Sign(float value)
        {
            return MathF.Sign(value);
        }

        public static bool Approximately(float a, float b)
        {
            return Approximately(a, b, MathConstants.Epsilon);
        }

        public static bool Approximately(float a, float b, float epsilon)
        {
            return MathF.Abs(a - b) <= MathF.Abs(epsilon);
        }

        public static bool IsZero(float value)
        {
            return IsZero(value, MathConstants.Epsilon);
        }

        public static bool IsZero(float value, float epsilon)
        {
            return MathF.Abs(value) <= MathF.Abs(epsilon);
        }

        public static bool IsEqual(float a, float b)
        {
            return Approximately(a, b);
        }

        public static bool IsEqual(float a, float b, float epsilon)
        {
            return Approximately(a, b, epsilon);
        }
    }
}
