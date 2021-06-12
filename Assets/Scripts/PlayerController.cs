using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Variables

    [Header("Player Movement")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float counterForce;


    [Header("Jump Settings")] 
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius=0f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private int extraJumps=1;


    [Header("Clone Settings")]
    [SerializeField] private GameObject clone;
    [SerializeField] private float cloneDistance;

    private float direction=0f;
    private bool isGrounded = false;
    private Rigidbody2D rb;
    private bool canExtraJump=true;
    private Vector2 counterMovement;

    #endregion

    #region UnityFunctions
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckGrounded();
        Move();
    }

    #endregion

    #region PlayerMovement

    private void Move()
    {
        Vector2 moveForce = Vector2.right * (direction * playerSpeed);
        rb.AddForce(moveForce);
        float xVel = rb.velocity.x;
        xVel = Mathf.Clamp(xVel, -maxSpeed, maxSpeed);
        rb.velocity=new Vector2(xVel, rb.velocity.y);
        counterMovement = new Vector2(-rb.velocity.x, 0f);
        if (!Mathf.Approximately(direction,0f) || Mathf.Approximately(rb.velocity.x,0)||rb.velocity.x*direction>0) return;
        rb.AddForce(counterMovement*counterForce);
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
    
    private void Split(float cloneDirection)
    {
        if (clone.activeSelf == false)
        {
            clone.SetActive(true);
            Vector3 position = transform.position;
            clone.transform.position = new Vector3(position.x + cloneDistance*cloneDirection, position.y);
            canExtraJump = false;
        }
        else
        {
            if (!(Vector2.Distance(clone.transform.position, transform.position) < cloneDistance*1.5f)) return;
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
        if(context.performed) Split(context.ReadValue<float>());
    }

    public void EscapeInput(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void ReloadScene(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    #endregion
    
    #region Gizmos

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.12f, 0.16f, 1f);
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    #endregion

}
