using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private float xInput;
    private float yInput;

    private new Rigidbody2D rigidbody;
    private CircleCollider2D circleCollider;
    private Transform player;

    [SerializeField] private LayerMask platformsLayerMask;
    
    [Header("Horizontal Move Settings")]
    public float moveSpeed;

    [Header("Jump Settings")]
    public float jumpForce;
    private bool grounded;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        player=GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        GroundMovement();
        Move();
    }

    void InputCaller()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Jump");
    }
    void Move()
    {
        InputCaller();
        rigidbody.AddForce(new Vector3(
            xInput * moveSpeed,
            0f,
            0f
            ));
    }
    void GroundMovement()
    {
        InputCaller();
        grounded = Physics2D.OverlapCircle(player.position,circleCollider.radius,platformsLayerMask);
        if(yInput>0f &&grounded)
        {
            
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }        
    }
}
