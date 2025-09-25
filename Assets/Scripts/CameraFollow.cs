using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
    }
}
