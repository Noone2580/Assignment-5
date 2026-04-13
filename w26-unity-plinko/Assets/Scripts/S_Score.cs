using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int totalScore = 0;
    public TMP_Text ScoreDisplay;

    private void Start()
    {
        // Update UI
        AddPoints(0);
    }

    public void AddPoints(int points)
    {
        totalScore += points;
        ScoreDisplay.text = $"\n{totalScore}";
        //Debug.Log($"Total score: {totalScore}");
    }
}
