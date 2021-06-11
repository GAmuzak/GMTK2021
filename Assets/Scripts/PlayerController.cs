using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;
    
    [Header("Clone Settings")]
    [SerializeField] private GameObject clone;
    [SerializeField] private float rejoinDistance;

    private float direction=0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
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
        rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
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
        }
        else
        {
            if (Vector2.Distance(clone.transform.position, transform.position)<rejoinDistance) clone.SetActive(false);
        }
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

}
