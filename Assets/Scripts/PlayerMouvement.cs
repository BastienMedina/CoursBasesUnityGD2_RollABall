 using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    private Rigidbody rb;
    private float HorizontalMovement;
    private float VerticalMovement;
    private Vector3 mouvement;
    private bool IsGrounded = true;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float JumpHeight = 5f;




    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    
    }


// Gere les mouvements de la sphere //
    void Update()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");
        mouvement = new Vector3(HorizontalMovement, 0f, VerticalMovement);
        mouvement.Normalize();
        mouvement *= speed;
        mouvement.y = rb.linearVelocity.y;
        

        if (rb != null)
        {
            Vector3 lv = rb.linearVelocity;   // récupère la vitesse actuelle
            lv.x = mouvement.x;     // remplace seulement la vitesse horizontal x
            lv.z = mouvement.z;     // remplace seulement la vitesse horizontal z
            rb.linearVelocity = lv;     // applique une nouvelle vitesse
        }
        else
        {
            Debug.LogError("No Rigidbody attached !");
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            Vector3 lv = rb.linearVelocity;
            lv.y = JumpHeight;                // applique la vitesse verticale directement
            rb.linearVelocity = lv;     // applique la vitesse au rigid body
            IsGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            IsGrounded = false;
        }
    }
}
