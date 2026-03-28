using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 120f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        transform.Rotate(0, h * turnSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {

    Vector3 forwardMove = transform.forward * moveSpeed;

    Vector3 newPosition = rb.position + forwardMove * Time.fixedDeltaTime;

    newPosition.y = rb.position.y;

    rb.MovePosition(newPosition);
    }


    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }
}