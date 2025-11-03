using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;           // Player movement speed
    public float fixedY = -3f;         // Y position for the player (bottom half)
    public float horizontalLimit = 5f; // Half-width of screen for horizontal wrap

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;    // Assign your Bullet prefab in Inspector
    public float bulletSpeed = 10f;    // Speed of the bullet

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    // Move player left/right and wrap horizontally
    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");

        // Move player horizontally
        Vector3 newPos = transform.position + new Vector3(moveX * speed * Time.deltaTime, 0f, 0f);

        // Keep player at fixed Y position
        newPos.y = fixedY;

        // Wrap horizontally
        if (newPos.x > horizontalLimit) newPos.x = -horizontalLimit;
        if (newPos.x < -horizontalLimit) newPos.x = horizontalLimit;

        transform.position = newPos;
    }

    // Shoot bullets straight up
    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletPrefab != null)
            {
                // Spawn bullet at player position with no rotation
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.up * bulletSpeed; // Moves straight up along Y-axis
                }
            }
            else
            {
                Debug.LogWarning("Bullet prefab not assigned in Inspector!");
            }
        }
    }
}
