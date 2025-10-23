using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    [SerializeField] float RestartDelay = 0.5f;
    [SerializeField] ParticleSystem GameoverParticles;
    PlayerController playerController;

    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");
        if (collision.gameObject.layer == layerIndex)
        {
            playerController.disableControls();
            GameoverParticles.Play();
            Invoke("ReloadScene", RestartDelay);
        }

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
