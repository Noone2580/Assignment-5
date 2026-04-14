using UnityEngine;

public class S_Peg : MonoBehaviour
{
    public Score score;
    public int points = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null) 
        {
            score.AddBallPoints(points, collision.gameObject.GetComponent<S_Ball>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
