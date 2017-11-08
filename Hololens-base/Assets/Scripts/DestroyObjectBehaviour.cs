using UnityEngine;

public class DestroyObjectBehaviour : MonoBehaviour
{
    public GameObject DestroyMe;

    void OnSelect()
    {
        Destroy(DestroyMe);
    }
}
