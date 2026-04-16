using Unity.VisualScripting;
using UnityEngine;

public class S_Peg : MonoBehaviour
{
    public Score score;
    public int points = 10;
    public float bounceForce = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            score.AddBallPoints(points, collision.gameObject.GetComponent<S_Ball>());


            Vector2 bounce = Vector2.Normalize( collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity);

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(50, 0), ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
