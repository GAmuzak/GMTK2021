using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;

    [Header("Jump Settings")] 
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius=0f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private int extraJumps=1;
    
    [Header("Clone Settings")]
    [SerializeField] private GameObject clone;
    [SerializeField] private float rejoinDistance;

    private float direction=0f;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private bool canExtraJump=true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGrounded();
        Move();
    }

    #region PlayerMovement

    private void Move()
    {
        Vector2 velocity = rb.velocity;
        velocity = new Vector2(velocity.x + (direction * playerSpeed), velocity.y);
        velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
        rb.velocity = velocity;
        
    }
    private void Jump()
    {
        if (!canExtraJump)
        {
            if (!isGrounded) return;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        else
        {
            if (!isGrounded && extraJumps <= 0) return;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            extraJumps--;
        }
    }

    #endregion

    #region Splitting
    
    private void Split()
    {
        if (clone.activeSelf == false)
        {
            clone.SetActive(true);
            Vector3 position = transform.position;
            clone.transform.position = new Vector3(position.x - 5f, position.y);
            canExtraJump = false;
        }
        else
        {
            if (!(Vector2.Distance(clone.transform.position, transform.position) < rejoinDistance)) return;
            clone.SetActive(false);
            canExtraJump = true;
        }
    }

    #endregion

    #region Collision Detection

    private void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (!isGrounded) return;
        extraJumps = 1;
    }

    #endregion
    
    #region Input Handling

    public void MoveInput(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<float>();
    }

    public void JumpInput(InputAction.CallbackContext context)
    {
        if(context.performed) Jump();
    }

    public void SplitInput(InputAction.CallbackContext context)
    {
        if(context.performed) Split();
    }

    public void EscapeInput(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Gizmos

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = new Color(1f, 0.46f, 0f);
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    #endregion

}
