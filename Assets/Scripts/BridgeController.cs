using System.Collections;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public int wallButtonCount;

    [SerializeField] private int numberPressed=0;
    [SerializeField] private float finalLength;

    [SerializeField] private bool bridgeOpen = false;
    private bool canControl = true;

    public void CheckButtonCount()
    {
        Invoke(nameof(_CheckButtonCount),0.1f);
    }
    private void _CheckButtonCount()
    {
        
        if (wallButtonCount != numberPressed || !canControl) return;
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
        canControl = false;
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        canControl = true;
    }
}
