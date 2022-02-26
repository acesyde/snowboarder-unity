using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float sceneLoadDelay = 2f;
    [SerializeField] private ParticleSystem _finishEffect;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _finishEffect.Play();
            Invoke(nameof(LoadNextLevel), sceneLoadDelay);
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
