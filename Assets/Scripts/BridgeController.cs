using System.Collections;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public int wallButtonCount;

    [SerializeField] private int numberPressed=0;
    [SerializeField] private float finalLength;

    private bool bridgeOpen=false;
    private bool canControl = true;
    public void CheckButtonCount()
    {
        if (wallButtonCount != numberPressed || !canControl) return;
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
        canControl = false;
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1.5f);
        canControl = true;
    }
}
