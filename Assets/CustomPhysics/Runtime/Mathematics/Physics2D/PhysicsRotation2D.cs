
using System;

namespace CustomPhysics
{
    public struct PhysicsRotation2D
    {
        private float radians;

        public float Radians => radians;

        public float Degrees => radians * MathConstants.Rad2Deg;

        public PhysicsRotation2D(float radians)
        {
            this.radians = radians;
        }

        public static PhysicsRotation2D FromRadians(float radians)
        {
            return new PhysicsRotation2D(radians);
        }

        public static PhysicsRotation2D FromDegrees(float degrees)
        {
            return new PhysicsRotation2D(
                degrees * MathConstants.Deg2Rad);
        }

        public static PhysicsRotation2D Identity =>
            new PhysicsRotation2D(0f);

        
        // Normalize Angle (-PI to PI)
        public void Normalize()
        {
            radians %= MathConstants.TwoPi;

            if (radians > MathConstants.Pi)
                radians -= MathConstants.TwoPi;
            else if (radians < -MathConstants.Pi)
                radians += MathConstants.TwoPi;
        }

        public PhysicsRotation2D Normalized
        {
            get
            {
                PhysicsRotation2D result = this;
                result.Normalize();
                return result;
            }
        }

        // Rotate Vector
        public PhysicsVector2 Rotate(PhysicsVector2 vector)
        {
            float cos = (float)Math.Cos(radians);
            float sin = (float)Math.Sin(radians);

            return new PhysicsVector2(
                vector.X * cos - vector.Y * sin,
                vector.X * sin + vector.Y * cos
            );
        }

        // Inverse Rotation
        public PhysicsRotation2D Inverse()
        {
            return new PhysicsRotation2D(-radians);
        }

        // Angular Difference
        public static float DeltaAngle(
            PhysicsRotation2D from,
            PhysicsRotation2D to)
        {
            float difference = (to.radians - from.radians)
                % MathConstants.TwoPi;

            if (difference > MathConstants.Pi)
                difference -= MathConstants.TwoPi;
            else if (difference < -MathConstants.Pi)
                difference += MathConstants.TwoPi;

            return difference;
        }


        // Rotation Addition
        public static PhysicsRotation2D operator +(
            PhysicsRotation2D a,
            PhysicsRotation2D b)
        {
            return new PhysicsRotation2D(a.radians + b.radians);
        }

        // Rotation Subtraction
        public static PhysicsRotation2D operator -(
            PhysicsRotation2D a,
            PhysicsRotation2D b)
        {
            return new PhysicsRotation2D(a.radians - b.radians);
        }

        // Scalar Multiplication
        public static PhysicsRotation2D operator *(
            PhysicsRotation2D rotation,
            float scalar)
        {
            return new PhysicsRotation2D(rotation.radians * scalar);
        }

        // Equality
        public static bool operator ==(
            PhysicsRotation2D a,
            PhysicsRotation2D b)
        {
            return PhysicsMath.Approximately(
                DeltaAngle(a, b), 0f);
        }

        public static bool operator !=(
            PhysicsRotation2D a,
            PhysicsRotation2D b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is PhysicsRotation2D other && this == other;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        // Linear Interpolation
        public static PhysicsRotation2D Lerp(
            PhysicsRotation2D a,
            PhysicsRotation2D b,
            float t)
        {
            t = PhysicsMath.Clamp(t, 0f, 1f);

            float difference = DeltaAngle(a, b);

            return new PhysicsRotation2D(
                a.radians + difference * t);
        }

        // Move Towards
        public static PhysicsRotation2D MoveTowards(
            PhysicsRotation2D current,
            PhysicsRotation2D target,
            float maxRadiansDelta)
        {
            float difference = DeltaAngle(current, target);

            if (Math.Abs(difference) <= maxRadiansDelta)
                return target;

            return new PhysicsRotation2D(
                current.radians +
                Math.Sign(difference) * maxRadiansDelta);
        }


    }
}
