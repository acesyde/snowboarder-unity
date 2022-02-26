using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float sceneReloadDelay = 2f;
    [SerializeField] private ParticleSystem _crashEffect;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            _crashEffect.Play();
            Invoke(nameof(ReloadScene), sceneReloadDelay);
        }
    }

    private void ReloadScene()
    {
        var buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }
}
