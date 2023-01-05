using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player movement speed")]
    public float speed = 5f;

    [Header("Player acceleration speed")]
    public float runspeed = 7f;

    [Header("Jump Force")]
    public float jumpVelocity = 5f;

    public float distanceToGround = 0.1f;

    public LayerMask groundLayer;

    private CapsuleCollider _col;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (IsGrounded() && Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.forward * runspeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.forward * speed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (IsGrounded() && Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += -transform.forward * runspeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += -transform.forward * speed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (IsGrounded() && Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += -transform.right * runspeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += -transform.right * speed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (IsGrounded() && Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.right * runspeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.right * speed * Time.deltaTime;
            }
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
}