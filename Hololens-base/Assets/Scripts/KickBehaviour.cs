using UnityEngine;

public class KickBehaviour : MonoBehaviour
{
    public float Force;
    void OnSelect()
    {
        var rigidBodyComponent = GetComponent<Rigidbody>();
        if (rigidBodyComponent)
        {
            rigidBodyComponent.AddForce(0, Force, Force, ForceMode.VelocityChange);
        }
    }
}
