using Unity.VisualScripting;
using UnityEngine;

public class S_Ball : MonoBehaviour
{
    public Score score;
    public int type = 0;
    public float Mulitplyer = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnDestroy()
    {
        score.AddUpPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
