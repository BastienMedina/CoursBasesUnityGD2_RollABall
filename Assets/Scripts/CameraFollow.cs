using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject RotationPoint;

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
        transform.rotation = RotationPoint.transform.rotation;
    }
}
