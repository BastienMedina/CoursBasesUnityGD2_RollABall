using UnityEngine;

public class DeadZoneDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider Collider)
    {
        Destroy(Collider.gameObject);
    }
}
