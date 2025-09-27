using UnityEngine;

public class DeadZoneDestroy : MonoBehaviour
{
    void OnTriggerEnter(Collider Collider)
    {
        if (Collider.gameObject.GetComponent<Player>() == null)
        {
            Destroy(Collider.gameObject);
        }
        else
        {
            Collider.gameObject.GetComponent<Player>().Death();
        }
    }
}
