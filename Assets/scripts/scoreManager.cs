using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;

    public void updateScore(int additionalScore)
    {
        score += additionalScore;
        scoreText.text = "Score: " + score;
    }


}
