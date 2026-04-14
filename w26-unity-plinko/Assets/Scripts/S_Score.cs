using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private int baseGoal = 3000;
    private int goalScore = 0;
    private int totalScore = 0;
    private int ballScore = 0;
    public int round = 0;

    public float Mulitplyer = 1;

    public TMP_Text GoalDisplay;
    public TMP_Text ScoreDisplay;
    public TMP_Text BallDisplay;
    public TMP_Text MulitplyerDisplay;
    public Player player;

    private void Start()
    {
        

        SetGoalScore();

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
        if (totalScore >= goalScore)
        {
            loadShop();
        }
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
        round++;
        float goal = baseGoal * (round * 0.7f);
        goalScore = (int)goal;
        GoalDisplay.text = $"[GOAL]\n{goalScore}";

        player.ResetRow();

        ballScore = 0;
        Mulitplyer = 1;
        totalScore = 0;
        AddPoints(0);
        AddBallPoints(0, null);
        AddMulitplyer(0);
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

        if(totalScore >= goalScore) 
        {
            loadShop();
        }
    }

    public void loadShop() 
    {
        player.lockControlls = true;
        SceneManager.LoadSceneAsync("Shop", LoadSceneMode.Additive);
    }

    public void FixedUpdate()
    {
        
    }
}
