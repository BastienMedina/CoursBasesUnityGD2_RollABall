using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    private Rigidbody rb;
    private float HorizontalMovement;
    private float VerticalMovement;
    private Vector3 mouvement;
    [SerializeField] private float speed = 2f;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
    }


// Gere les mouvements de la sphere //
    void Update()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");
        mouvement = new Vector3(HorizontalMovement, 0.0f, VerticalMovement);
        mouvement.Normalize();
        mouvement *= speed;
        mouvement.y = rb.linearVelocity.y;

        if (rb != null)
        {
            rb.linearVelocity = mouvement;
        }
        else
        {
            Debug.LogError("No Rigidbody attached !");
        }
    }
}
