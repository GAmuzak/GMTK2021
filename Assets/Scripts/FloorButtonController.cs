using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class FloorButtonController : MonoBehaviour
{
    [SerializeField] private List<DoorController> doorController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (DoorController door in doorController)
        {
            door.floorButtonCount++;
            door.CheckButtonCount();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        LeanTween.moveLocalY(gameObject, -1f, 0.05f).setEase(LeanTweenType.easeOutQuad);
    }

    private void OnTriggerExit2D(Collider2D other)  
    {
        foreach (DoorController door in doorController)
        {
            door.floorButtonCount--;
            door.CheckButtonCount();
        }

        if (doorController[0].doorsActivated) return;
        LeanTween.moveLocalY(gameObject, 0f, 0.3f).setEase(LeanTweenType.easeOutQuad);
    }
}
