using GenshinImpactMovementSystem;
using UnityEngine;

public class RigidbodyReciver : MonoBehaviour
{
    public Vector3 force = Vector3.zero;
    public ForceMode forceMode = ForceMode.Force;

    public void AddForce(Vector3 force, ForceMode forceMode)
    {
        this.force = force;
        this.forceMode = forceMode;
    }
}
