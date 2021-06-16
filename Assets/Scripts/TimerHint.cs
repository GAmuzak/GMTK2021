using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHint : MonoBehaviour
{
    [SerializeField] private GameObject hint;
    
    void Start()
    {
        StartCoroutine(HintTimer());
    }

    private IEnumerator HintTimer()
    {
        yield return new WaitForSeconds(15f);
        hint.SetActive(true);
    }
}
