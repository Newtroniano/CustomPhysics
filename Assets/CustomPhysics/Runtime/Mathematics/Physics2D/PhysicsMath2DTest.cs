
using UnityEngine;
using CustomPhysics;

public class PhysicsMath2DTest : MonoBehaviour
{
    private void Start()
    {
        PhysicsVector2 a = new PhysicsVector2(0f, 0f);
        PhysicsVector2 b = new PhysicsVector2(4f, 0f);

        Debug.Log("Graus para radianos: " +
            PhysicsMath2D.ToRadians(180f));

        Debug.Log("Cross: " +
            PhysicsMath2D.Cross(
                new PhysicsVector2(1f, 0f),
                new PhysicsVector2(0f, 1f)));

        Debug.Log("Área do triângulo: " +
            PhysicsMath2D.SignedTriangleArea(
                a,
                b,
                new PhysicsVector2(0f, 3f)));

        Debug.Log("Direção: " +
            PhysicsMath2D.Direction(a, b));

        Debug.Log("Distância: " +
            PhysicsMath2D.Distance(a, b));

        Debug.Log("Ponto mais próximo: " +
            PhysicsMath2D.ClosestPointOnSegment(
                new PhysicsVector2(2f, 3f),
                a,
                b));

        Debug.Log("Ponto dentro do círculo: " +
            PhysicsMath2D.IsPointInCircle(
                new PhysicsVector2(1f, 0f),
                a,
                2f));

        Debug.Log("Círculos sobrepostos: " +
            PhysicsMath2D.CirclesOverlap(
                a, 2f,
                new PhysicsVector2(3f, 0f), 2f));

        Debug.Log("Ponto dentro do AABB: " +
            PhysicsMath2D.IsPointInAABB(
                new PhysicsVector2(2f, 2f),
                new PhysicsVector2(0f, 0f),
                new PhysicsVector2(4f, 4f)));
    }
}
