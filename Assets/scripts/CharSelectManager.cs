using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject dinoSprite;
    [SerializeField] GameObject frogSprite;

    void Start()
    {
        Time.timeScale = 0f;
    }

    void beginGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
    public void chooseDino()
    {
        dinoSprite.SetActive(true);
        beginGame();
    }
    public void chooseFrog()
    {
        frogSprite.SetActive(true);
        beginGame();
    }

}
