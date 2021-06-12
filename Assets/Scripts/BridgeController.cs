using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public int wallButtonCount;

    [SerializeField] private int numberPressed=0;
    [SerializeField] private float finalLength;

    private bool bridgeOpen=false;
    public void CheckButtonCount()
    {
        if (wallButtonCount != numberPressed) return;
        Debug.Log(wallButtonCount);
        if (bridgeOpen == false)
        {
            LeanTween.scaleY(gameObject, finalLength, 0.2f).setEase(LeanTweenType.easeOutQuad);
            bridgeOpen = true;
        }
        else
        {
            LeanTween.scaleY(gameObject, 1f, 0.2f).setEase(LeanTweenType.easeOutQuad);
            bridgeOpen = false;
        }

    }
}
