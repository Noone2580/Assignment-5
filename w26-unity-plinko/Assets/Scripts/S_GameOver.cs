using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class S_GameOver : MonoBehaviour
{
    public Button next;
    public Score score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        next.onClick.AddListener(Next);
        score = FindFirstObjectByType(typeof(Score)).GetComponent<Score>();
    }

    void Next()
    {
        Scene scene = SceneManager.GetSceneByName("GameOver");
        SceneManager.UnloadSceneAsync(scene);
        score.player.lockControlls = false;
        score.round = 0;
        score.SetGoalScore();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
