using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private float xInput;
    private float yInput;

    private new Rigidbody2D rigidbody; 
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private Transform player;
    [SerializeField] private CircleCollider2D circleCollider;


    [Header("Horizontal Move Settings")]
    public float moveSpeed;

    [Header("Jump Settings")]
    public float jumpForce;
    private bool grounded;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        InputCaller();
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
        rigidbody.AddForce(new Vector3(
            xInput,
            0f,
            0f
            )*moveSpeed);
    }
    void GroundMovement()
    {
        grounded = Physics2D.OverlapCircle(player.position,circleCollider.radius,platformsLayerMask);
        if(yInput>0f &&grounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {

            GameManager.instance.NewGame();
        }
    }
}
