
namespace CustomPhysics
{
    public struct PhysicsVector2
    {
        public float X;
        public float Y;

        public PhysicsVector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float SqrMagnitude
        {
            get
            {
                return (X * X) + (Y * Y);
            }
        }

        public float Magnitude
        {
            get
            {
                return PhysicsMath.Sqrt(SqrMagnitude);
            }
        }

        public PhysicsVector2 Normalized
        {
            get
            {
                PhysicsVector2 result = this;
                result.Normalize();
                return result;
            }
        }

        public void Normalize()
        {
            float magnitude = Magnitude;

            if (PhysicsMath.IsZero(magnitude))
            {
                X = 0f;
                Y = 0f;
                return;
            }

            X /= magnitude;
            Y /= magnitude;
        }

        public static PhysicsVector2 Zero => new PhysicsVector2(0f, 0f);
        public static PhysicsVector2 One => new PhysicsVector2(1f, 1f);
        public static PhysicsVector2 Up => new PhysicsVector2(0f, 1f);
        public static PhysicsVector2 Down => new PhysicsVector2(0f, -1f);
        public static PhysicsVector2 Left => new PhysicsVector2(-1f, 0f);
        public static PhysicsVector2 Right => new PhysicsVector2(1f, 0f);


        // Vector Addition
        public static PhysicsVector2 operator +(PhysicsVector2 a, PhysicsVector2 b)
        {
            return new PhysicsVector2(a.X + b.X, a.Y + b.Y);
        }

        // Vector Subtraction
        public static PhysicsVector2 operator -(PhysicsVector2 a, PhysicsVector2 b)
        {
            return new PhysicsVector2(a.X - b.X, a.Y - b.Y);
        }

        // Vector Negation
        public static PhysicsVector2 operator -(PhysicsVector2 vector)
        {
            return new PhysicsVector2(-vector.X, -vector.Y);
        }

        // Scalar Multiplication
        public static PhysicsVector2 operator *(PhysicsVector2 vector, float scalar)
        {
            return new PhysicsVector2(vector.X * scalar, vector.Y * scalar);
        }

        public static PhysicsVector2 operator *(float scalar, PhysicsVector2 vector)
        {
            return vector * scalar;
        }

        // Scalar Division
        public static PhysicsVector2 operator /(PhysicsVector2 vector, float scalar)
        {
            return new PhysicsVector2(vector.X / scalar, vector.Y / scalar);
        }

        // Equality
        public static bool operator ==(PhysicsVector2 a, PhysicsVector2 b)
        {
            return PhysicsMath.IsEqual(a.X, b.X) &&
                   PhysicsMath.IsEqual(a.Y, b.Y);
        }

        public static bool operator !=(PhysicsVector2 a, PhysicsVector2 b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is PhysicsVector2 other && this == other;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(X, Y);
        }


        // Dot Product
        public static float Dot(PhysicsVector2 a, PhysicsVector2 b)
        {
            return (a.X * b.X) + (a.Y * b.Y);
        }

        // Distance
        public static float Distance(PhysicsVector2 a, PhysicsVector2 b)
        {
            return (b - a).Magnitude;
        }

        // Distance Squared
        public static float SqrDistance(PhysicsVector2 a, PhysicsVector2 b)
        {
            return (b - a).SqrMagnitude;
        }

        // Linear Interpolation
        public static PhysicsVector2 Lerp(
            PhysicsVector2 a,
            PhysicsVector2 b,
            float t)
        {
            t = PhysicsMath.Clamp(t, 0f, 1f);
            return a + (b - a) * t;
        }

        // Reflection
        public static PhysicsVector2 Reflect(
            PhysicsVector2 direction,
            PhysicsVector2 normal)
        {
            return direction - 2f * Dot(direction, normal) * normal;
        }

        // Projection
        public static PhysicsVector2 Project(
            PhysicsVector2 vector,
            PhysicsVector2 onto)
        {
            float denominator = onto.SqrMagnitude;

            if (PhysicsMath.IsZero(denominator))
                return Zero;

            return onto * (Dot(vector, onto) / denominator);
        }

        // Clamp Magnitude
        public static PhysicsVector2 ClampMagnitude(
            PhysicsVector2 vector,
            float maxLength)
        {
            float sqrMagnitude = vector.SqrMagnitude;
            float maxLengthSquared = maxLength * maxLength;

            if (sqrMagnitude > maxLengthSquared)
                return vector.Normalized * maxLength;

            return vector;
        }


        // Angle Between Vectors (Radians)
        public static float Angle(PhysicsVector2 from, PhysicsVector2 to)
        {
            float denominator = from.Magnitude * to.Magnitude;

            if (PhysicsMath.IsZero(denominator))
                return 0f;

            float dot = Dot(from, to) / denominator;
            dot = PhysicsMath.Clamp(dot, -1f, 1f);

           return (float)System.Math.Acos(dot);
        }

        // Signed Angle Between Vectors (Radians)
        public static float SignedAngle(PhysicsVector2 from, PhysicsVector2 to)
        {
            float cross = (from.X * to.Y) - (from.Y * to.X);
            float dot = Dot(from, to);

           return (float)System.Math.Atan2(cross, dot);
        }

        // Perpendicular Vector
        public PhysicsVector2 Perpendicular()
        {
            return new PhysicsVector2(-Y, X);
        }

        // Component-wise Scale
        public static PhysicsVector2 Scale(
            PhysicsVector2 a,
            PhysicsVector2 b)
        {
            return new PhysicsVector2(a.X * b.X, a.Y * b.Y);
        }

        // Component-wise Min
        public static PhysicsVector2 Min(
            PhysicsVector2 a,
            PhysicsVector2 b)
        {
            return new PhysicsVector2(
                PhysicsMath.Min(a.X, b.X),
                PhysicsMath.Min(a.Y, b.Y));
        }

        // Component-wise Max
        public static PhysicsVector2 Max(
            PhysicsVector2 a,
            PhysicsVector2 b)
        {
            return new PhysicsVector2(
                PhysicsMath.Max(a.X, b.X),
                PhysicsMath.Max(a.Y, b.Y));
        }


        // Convert to Array
        public float[] ToArray()
        {
            return new float[] { X, Y };
        }

        // Set Components
        public void Set(float x, float y)
        {
            X = x;
            Y = y;
        }

        // Move Towards
        public static PhysicsVector2 MoveTowards(
            PhysicsVector2 current,
            PhysicsVector2 target,
            float maxDistanceDelta)
        {
            PhysicsVector2 difference = target - current;
            float distance = difference.Magnitude;

            if (distance <= maxDistanceDelta || PhysicsMath.IsZero(distance))
                return target;

            return current + difference / distance * maxDistanceDelta;
        }

        // Clamp Components
        public static PhysicsVector2 Clamp(
            PhysicsVector2 value,
            PhysicsVector2 min,
            PhysicsVector2 max)
        {
            return new PhysicsVector2(
                PhysicsMath.Clamp(value.X, min.X, max.X),
                PhysicsMath.Clamp(value.Y, min.Y, max.Y));
        }

        // String Representation
        public override string ToString()
        {
            return $"({X}, {Y})";
        }



    }

    
}
