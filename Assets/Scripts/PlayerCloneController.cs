using UnityEngine;

public class PlayerCloneController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject sprite;
    
    private Rigidbody2D cloneRigidbody;
    private Vector3 spriteX;
    private bool isWalking=false;

    private void Start()
    {
        cloneRigidbody = GetComponent<Rigidbody2D>();
        spriteX=sprite.transform.localScale;

    }

    private void FixedUpdate()
    {
        Vector2 velocity = playerRigidbody.velocity;
        if(velocity.y<=0f) velocity.y=cloneRigidbody.velocity.y;
        if (Mathf.Approximately(velocity.x, 0)) velocity.x = cloneRigidbody.velocity.x;
        cloneRigidbody.velocity = new Vector2(velocity.x*-1f,velocity.y);

        if (cloneRigidbody.velocity.x > 0)
        {
            spriteX.x = 2.5f;
            sprite.transform.localScale = spriteX;
        }
        else if (cloneRigidbody.velocity.x < 0)
        {
            spriteX.x = -2.5f;
            sprite.transform.localScale = spriteX;
        }
        isWalking = !(Mathf.Abs(cloneRigidbody.velocity.x)<0.5f);
        anim.SetBool("isWalking", isWalking);
    }
}
