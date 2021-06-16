using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButtonController : MonoBehaviour
{
    [SerializeField] private List<BridgeController> bridgeController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (BridgeController bridge in bridgeController)
        {
            bridge.wallButtonCount++;
            bridge.CheckButtonCount();            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        LeanTween.moveLocalY(gameObject, -1f, 0.05f).setEase(LeanTweenType.easeOutQuad);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        LeanTween.moveLocalY(gameObject, 0f, 0.3f).setEase(LeanTweenType.easeOutQuad);
        foreach (BridgeController bridge in bridgeController)
        {
            bridge.wallButtonCount--;
            bridge.CheckButtonCount();            
        }
    }
}