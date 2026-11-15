
using UnityEngine;
using CustomPhysics;

public class PhysicsVector2Test : MonoBehaviour
{
    private void Start()
    {
        PhysicsVector2 a = new PhysicsVector2(3f, 4f);
        PhysicsVector2 b = new PhysicsVector2(1f, 2f);

        Debug.Log("Magnitude: " + a.Magnitude);
        Debug.Log("SqrMagnitude: " + a.SqrMagnitude);

        Debug.Log("Soma: " + (a + b));
        Debug.Log("Subtração: " + (a - b));

        Debug.Log("Dot Product: " + PhysicsVector2.Dot(a, b));

        Debug.Log("Distância: " + PhysicsVector2.Distance(a, b));

        Debug.Log("Normalizado: " + a.Normalized);

        Debug.Log("Lerp: " + PhysicsVector2.Lerp(a, b, 0.5f));

        Debug.Log("Ângulo: " + PhysicsVector2.Angle(a, b));

        Debug.Log("Perpendicular: " + a.Perpendicular());
    }
}
