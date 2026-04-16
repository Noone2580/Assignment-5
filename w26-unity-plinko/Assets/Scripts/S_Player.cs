using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int[] Balls = new int[5];
    private GameObject[] leftBalls = new GameObject[5];
    public int currentBall = 0;
    public float speed = 5;
    public bool lockControlls = false;
    public float distanceBetween = 3;
    public float distanceBetweenStart = 4;
    private bool gameOver = false;

    public Score score;
    public GameObject ballPrefab;
    private GameObject currentDisc = null;
    public GameObject ballRow;
    public GameObject imageBall;


    private void Start()
    {

    }

    public void RemoveIndex(int index)
    {
        Destroy(leftBalls[index]);
    }

    public void UpdateRow()
    {
        Vector3 position = ballRow.transform.position;

        for (int i = 0; i < Balls.Length; i++)
        {
            if (leftBalls[i] != null || !leftBalls[i].IsDestroyed())
            {
                if (i == currentBall)
                {
                    leftBalls[i].transform.position = position;
                    position -= new Vector3(0, 4, 0);
                }
                else
                {
                    leftBalls[i].transform.position = position;
                    position -= new Vector3(0, distanceBetween, 0);
                }

            }
        }
    }

    public void ResetRow()
    {
        gameOver = false;
        currentBall = 0;
        Vector3 position = ballRow.transform.position;

        for (int j = 0; j < leftBalls.Length; j++)
        {
            if (leftBalls[j] != null)
            {
                Destroy(leftBalls[j]);
            }
        }

        leftBalls = new GameObject[Balls.Length];

        for (int i = 0; i < Balls.Length; i++)
        {
            if (i == 0)
            {
                leftBalls[i] = Instantiate(imageBall, position, Quaternion.identity);
                position -= new Vector3(0, 4, 0);
            }
            else
            {
                leftBalls[i] = Instantiate(imageBall, position, Quaternion.identity);
                position -= new Vector3(0, distanceBetween, 0);
            }
        }
    }

    void CanGameOver() 
    {
        if (currentBall >= Balls.Length && currentDisc == null && !gameOver && !score.CheckIfWin())
        {
            score.GameOver();
            gameOver = true;
        }
    }

    void Update()
    {
        if (lockControlls) { return; }

        // Move player horizontally
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        Vector3 position = transform.position;
        position.x += moveX;
        transform.position = position;

        // Drop disc
        if (Input.GetKeyDown(KeyCode.Space) && currentDisc == null && currentBall < Balls.Length)
        {
            // Clone prefab
            currentDisc = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            currentDisc.GetComponent<S_Ball>().score = score;
            RemoveIndex(currentBall);
            currentBall++;
            UpdateRow();

        }

        CanGameOver();
    }
}
