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
        if(Mathf.Approximately(velocity.y, 0)) velocity.y=cloneRigidbody.velocity.y;
        cloneRigidbody.velocity = new Vector2(velocity.x*-1,velocity.y);
    }
}
