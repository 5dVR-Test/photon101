using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Speed")]
    public float walkSpeed = 4f;
    public float sprintSpeed = 14f;
    public float maxVelocityChange = 18f;
    [Space]
    public float jumpHeight = 30f;
    

    private Vector2 input;
    private Rigidbody rb;

    private bool sprinting;


    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();

        sprinting = Input.GetButton("Sprint");

    }

    private void FixedUpdate()
    {
        rb.AddForce(CalculateMovement(sprinting ? sprintSpeed : walkSpeed), ForceMode.VelocityChange);
    }

    Vector3 CalculateMovement(float _speed)
    {
        Vector3 targetVelocity = new Vector3(input.x, 0, input.y);
        targetVelocity = transform.TransformDirection(targetVelocity);
        targetVelocity *= _speed;
        Vector3 velocity = rb.linearVelocity;
        if (input.magnitude > 0.5f)
        {
            Vector3 velocityChange = targetVelocity - velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            return (velocityChange);
        }

        else
        {
            return new Vector3();
        }
            

    
    }
    
}
