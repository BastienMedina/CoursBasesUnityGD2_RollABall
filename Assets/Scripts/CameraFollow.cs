using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            transform.position = _player.transform.position;
        }
    }

    public void SetTarget(GameObject newTarget)
    {
        _player = newTarget;
    }
}
