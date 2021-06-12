using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int floorButtonCount=0;
    
    [SerializeField] private int numberPressed=0;

    public void CheckButtonCount()
    {
        if (floorButtonCount == numberPressed)
        {
            LeanTween.scaleY(gameObject, 1f, 0.2f).setEase(LeanTweenType.easeOutQuad);
        }
    }
}
