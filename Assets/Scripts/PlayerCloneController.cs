using UnityEngine;

public class PlayerCloneController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    
    private Rigidbody2D cloneRigidbody;

    private void Start()
    {
        cloneRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = playerRigidbody.velocity;
        if(velocity.y<=0f) velocity.y=cloneRigidbody.velocity.y;
        if (Mathf.Approximately(velocity.x, 0)) velocity.x = cloneRigidbody.velocity.x;
        cloneRigidbody.velocity = new Vector2(velocity.x*-1f,velocity.y);
    }
}
