using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private new Rigidbody2D rigidbody; 
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private Transform player;
    [SerializeField] private CircleCollider2D circleCollider;

    [Header("Horizontal Move Settings")]
    public float moveSpeed;
    private float xInput;

    [Header("Jump Settings")]
    private float yInput;
    public float jumpForce;
    private bool grounded;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
       
    }
    private void Update()
    {
        RotateBall();
        GroundMovement();
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
    void GroundMovement()
    {
        yInput=Input.GetAxis("Jump");
        grounded = Physics2D.OverlapCircle(player.position,circleCollider.radius,platformsLayerMask);

        if(yInput>0f &&grounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }        
    }
}
