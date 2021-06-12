using UnityEngine;

public class WallButtonController : MonoBehaviour
{
    [SerializeField] private BridgeController bridgeController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        bridgeController.wallButtonCount++;
        bridgeController.CheckButtonCount();
        Debug.Log("pressed");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        LeanTween.moveLocalY(gameObject, -1f, 0.05f).setEase(LeanTweenType.easeOutQuad);
    }

    private void OnTriggerExit2D(Collider2D other)  
    {
        LeanTween.moveLocalY(gameObject, 0f, 0.3f).setEase(LeanTweenType.easeOutQuad);
        bridgeController.wallButtonCount--;
        bridgeController.CheckButtonCount();
        Debug.Log("Released");
    }
}