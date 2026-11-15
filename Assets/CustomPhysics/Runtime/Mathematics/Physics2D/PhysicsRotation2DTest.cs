
using UnityEngine;
using CustomPhysics;

public class PhysicsRotation2DTest : MonoBehaviour
{
    private void Start()
    {
        PhysicsRotation2D rotation =
            PhysicsRotation2D.FromDegrees(90f);

        PhysicsVector2 vector =
            new PhysicsVector2(1f, 0f);

        Debug.Log("Graus: " + rotation.Degrees);
        Debug.Log("Radianos: " + rotation.Radians);

        Debug.Log("Vetor rotacionado: " + rotation.Rotate(vector));

        Debug.Log("Rotação inversa: " +
            rotation.Inverse().Degrees);

        PhysicsRotation2D a =
            PhysicsRotation2D.FromDegrees(350f);

        PhysicsRotation2D b =
            PhysicsRotation2D.FromDegrees(10f);

        Debug.Log("Diferença angular: " +
            PhysicsRotation2D.DeltaAngle(a, b) *
            MathConstants.Rad2Deg);

        Debug.Log("Interpolação: " +
            PhysicsRotation2D.Lerp(a, b, 0.5f).Degrees);

        Debug.Log("Normalização: " +
            PhysicsRotation2D.FromDegrees(450f).Normalized.Degrees);
    }
}
