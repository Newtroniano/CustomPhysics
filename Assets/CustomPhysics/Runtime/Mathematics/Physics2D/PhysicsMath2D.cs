
using System;

namespace CustomPhysics
{
    public static class PhysicsMath2D
    {
        // Degrees to Radians
        public static float ToRadians(float degrees)
        {
            return degrees * MathConstants.Deg2Rad;
        }

        // Radians to Degrees
        public static float ToDegrees(float radians)
        {
            return radians * MathConstants.Rad2Deg;
        }

        // Cross Product (2D)
        public static float Cross(
            PhysicsVector2 a,
            PhysicsVector2 b)
        {
            return (a.X * b.Y) - (a.Y * b.X);
        }

        // Signed Area of Triangle
        public static float SignedTriangleArea(
            PhysicsVector2 a,
            PhysicsVector2 b,
            PhysicsVector2 c)
        {
            return Cross(b - a, c - a) * 0.5f;
        }

        // Direction Between Two Points
        public static PhysicsVector2 Direction(
            PhysicsVector2 from,
            PhysicsVector2 to)
        {
            return (to - from).Normalized;
        }

        // Distance Between Two Points
        public static float Distance(
            PhysicsVector2 a,
            PhysicsVector2 b)
        {
            return PhysicsVector2.Distance(a, b);
        }

        // Angle From Direction
        public static float AngleFromDirection(
            PhysicsVector2 direction)
        {
            return (float)Math.Atan2(direction.Y, direction.X);
        }

        // Closest Point On Segment
        public static PhysicsVector2 ClosestPointOnSegment(
            PhysicsVector2 point,
            PhysicsVector2 a,
            PhysicsVector2 b)
        {
            PhysicsVector2 ab = b - a;
            float denominator = ab.SqrMagnitude;

            if (PhysicsMath.IsZero(denominator))
                return a;

            float t = PhysicsVector2.Dot(point - a, ab) / denominator;

            t = PhysicsMath.Clamp(t, 0f, 1f);

            return a + ab * t;
        }

        // Point On Segment
        public static bool IsPointOnSegment(
            PhysicsVector2 point,
            PhysicsVector2 a,
            PhysicsVector2 b,
            float epsilon)
        {
            PhysicsVector2 closest =
                ClosestPointOnSegment(point, a, b);

            return PhysicsVector2.SqrDistance(point, closest)
                <= epsilon * epsilon;
        }

        // Point In Circle
        public static bool IsPointInCircle(
            PhysicsVector2 point,
            PhysicsVector2 center,
            float radius)
        {
            float radiusSquared = radius * radius;

            return PhysicsVector2.SqrDistance(point, center)
                <= radiusSquared;
        }

        // Circle Overlap
        public static bool CirclesOverlap(
            PhysicsVector2 centerA,
            float radiusA,
            PhysicsVector2 centerB,
            float radiusB)
        {
            float radiusSum = radiusA + radiusB;

            return PhysicsVector2.SqrDistance(centerA, centerB)
                <= radiusSum * radiusSum;
        }

        // Point In AABB
        public static bool IsPointInAABB(
            PhysicsVector2 point,
            PhysicsVector2 min,
            PhysicsVector2 max)
        {
            return point.X >= min.X &&
                   point.X <= max.X &&
                   point.Y >= min.Y &&
                   point.Y <= max.Y;
        }

    }


        
}
