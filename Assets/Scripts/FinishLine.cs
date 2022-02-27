using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class FinishLine : MonoBehaviour
{
    private AudioSource _finishAudio;
    [SerializeField] private float sceneLoadDelay = 2f;
    [SerializeField] private ParticleSystem _finishEffect;

    private void Awake()
    {
        _finishAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _finishEffect.Play();
            _finishAudio.Play();
            Invoke(nameof(LoadNextLevel), sceneLoadDelay);
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
