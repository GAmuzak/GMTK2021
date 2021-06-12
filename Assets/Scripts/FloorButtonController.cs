using UnityEngine;

public class FloorButtonController : MonoBehaviour
{
    [SerializeField] private DoorController doorController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        doorController.floorButtonCount++;
        doorController.CheckButtonCount();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        LeanTween.moveLocalY(gameObject, -1f, 0.05f).setEase(LeanTweenType.easeOutQuad);
    }

    private void OnTriggerExit2D(Collider2D other)  
    {
        LeanTween.moveLocalY(gameObject, 0f, 0.3f).setEase(LeanTweenType.easeOutQuad);
        doorController.floorButtonCount--;
        doorController.CheckButtonCount();
    }
}
