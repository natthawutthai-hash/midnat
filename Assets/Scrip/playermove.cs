using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 120f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isGrounded;

    public float damageCooldown = 1f;
    private float lastDamageTime;

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
        rb.MovePosition(rb.position + forwardMove * Time.fixedDeltaTime);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Time.time > lastDamageTime + damageCooldown)
            {
                GetComponent<PlayerHealth>().TakeDamage(10);
                lastDamageTime = Time.time;
            }
        }
    }
}