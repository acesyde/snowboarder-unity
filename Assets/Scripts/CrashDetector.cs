using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class CrashDetector : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _crashSound;
    [SerializeField] private float sceneReloadDelay = 2f;
    [SerializeField] private ParticleSystem _crashEffect;

    private bool hasCrashed = false;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ground") && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            _crashEffect.Play();
            _audioSource.PlayOneShot(_crashSound);
            Invoke(nameof(ReloadScene), sceneReloadDelay);
        }
    }

    private void ReloadScene()
    {
        var buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }
}
