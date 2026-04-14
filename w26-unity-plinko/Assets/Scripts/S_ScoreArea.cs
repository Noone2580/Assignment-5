using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public int points = 1;
    public Score score;

    private void OnTriggerEnter2D(Collider2D collider2d)
    {
        score.AddBallPoints(points, collider2d.gameObject.GetComponent<S_Ball>());
    }

    private void OnTriggerExit2D(Collider2D collider2d)
    {
        Destroy(collider2d.gameObject);
    }
}
