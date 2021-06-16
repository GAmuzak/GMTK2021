using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int floorButtonCount=0;
    public bool doorsActivated=false;

    [SerializeField] private int numberPressed=0;

    public void CheckButtonCount()
    {
        Invoke(nameof(_CheckButtonCount), 0.1f);
    }
    private void _CheckButtonCount()
    {
        if (floorButtonCount == numberPressed)
        {
            LeanTween.scaleY(gameObject, 1f, 0.2f).setEase(LeanTweenType.easeOutQuad);
            doorsActivated = true;
        }
    }
}
