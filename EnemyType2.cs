using UnityEngine;

public class EnemyType2 : MonoBehaviour
{
    public float speed = 3f;       // Downward speed
    public float amplitude = 2f;   // Width of zigzag movement
    private float initialX;        

    void Start()
    {
        initialX = transform.position.x;
    }

    void Update()
    {
        // Move downward
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Optional zigzag movement
        float xOffset = Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(initialX + xOffset, transform.position.y, transform.position.z);

        // Destroy when off screen
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
