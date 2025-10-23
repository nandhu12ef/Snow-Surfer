using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float Delay = 3f;
    [SerializeField] ParticleSystem FinishParticle;

    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        

        if (collision.gameObject.layer == layerIndex)
        {
            FinishParticle.Play();
            Invoke("ReloadScene", Delay);

        }


    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
