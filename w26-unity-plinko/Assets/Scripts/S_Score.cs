using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Score : MonoBehaviour
{
    public int goalScore = 0;
    private int totalScore = 0;
    public int ballScore = 0;

    public float Mulitplyer = 1;

    public TMP_Text ScoreDisplay;
    public TMP_Text BallDisplay;
    public TMP_Text MulitplyerDisplay;

    private void Start()
    {
        // Update UI
        AddPoints(0);
        AddBallPoints(0, null);
        AddMulitplyer(0);
    }

    /// <summary>
    ///     Used for adding points to the round
    /// </summary>
    /// <param name="points"></param>
    public void AddPoints(int points)
    {
        totalScore += points;
        ScoreDisplay.text = $"[SCORE]\n{totalScore}";
    }

    public void AddBallPoints(int points, S_Ball ball)
    {
        if (ball != null)
        {
            float MulitPoints = ball.Mulitplyer * points;
            points = (int)MulitPoints;
        }

        ballScore += points;
        BallDisplay.text = $"[BALL SCORE]\n{ballScore}";
    }

    public void AddMulitplyer(float mulitplyer)
    {
        Mulitplyer += mulitplyer;
        MulitplyerDisplay.text = $"x{Mulitplyer}";
    }

    public void SetGoalScore()
    {

    }

    public void AddUpPoints()
    {
        float score = ballScore * Mulitplyer;

        ballScore = 0;
        Mulitplyer = 1;
        AddBallPoints(0, null);
        AddMulitplyer(0);

        totalScore += (int)score;
        ScoreDisplay.text = $"[SCORE]\n{totalScore}";
    }
}
