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
    }

    void Move()
    {
        rigidbody.AddForce(new Vector3(
            xInput,
            0f,
            0f
            )*moveSpeed);
    }
}
