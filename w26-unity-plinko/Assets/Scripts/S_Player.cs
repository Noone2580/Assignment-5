using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public Score score;
    public GameObject ballPrefab;
    private GameObject currentDisc = null;


    void Update()
    {
        // Move player horizontally
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        Vector3 position = transform.position;
        position.x += moveX;
        transform.position = position;

        // Drop disc
        if (Input.GetKeyDown(KeyCode.Space) && currentDisc == null)
        {
            // Clone prefab
            currentDisc = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            currentDisc.GetComponent<S_Ball>().score = score;
        }
    }
}
