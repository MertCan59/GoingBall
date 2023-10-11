using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private new Rigidbody2D rigidbody;
    public float moveSpeed;
    private float xInput;
    private float yInput;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        RotateBall();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void RotateBall( )
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void Move()
    {
        rigidbody.AddForce(new Vector2(
            xInput,
            yInput
            )*moveSpeed);
    }
}
