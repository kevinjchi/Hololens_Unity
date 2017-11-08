using UnityEngine;

public class EnableGravityBehaviour : MonoBehaviour
{
	void OnSelect()
    {
        var rigidBodyComponent = GetComponent<Rigidbody>();
        if (rigidBodyComponent)
        {
            rigidBodyComponent.useGravity = true;
        }
    }
}
