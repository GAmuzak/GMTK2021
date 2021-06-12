using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    [SerializeField] private GameObject clone;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (clone.activeSelf) return;
        SceneManager.LoadScene(nextLevel);
    }
}
