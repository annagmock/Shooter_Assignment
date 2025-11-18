using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;       
    public float fixedY = -3f;     
    public float horizontalLimit = 5f; 

    [Header("Shooting Settings")]
    public GameObject bulletPrefab;    
    public float bulletSpeed = 10f;    

    [Header("Shield Settings")]
    public GameObject shieldVisual;   
    private bool shieldActive = false;

    void Start()
    {
        
        if (shieldVisual != null)
            shieldVisual.SetActive(false);
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    
    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");

        Vector3 newPos = transform.position + new Vector3(moveX * speed * Time.deltaTime, 0f, 0f);

        
        newPos.y = fixedY;

        
        if (newPos.x > horizontalLimit) newPos.x = -horizontalLimit;
        if (newPos.x < -horizontalLimit) newPos.x = horizontalLimit;

        transform.position = newPos;
    }

   
    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.up * bulletSpeed;
            }
        }
    }

   
    public void ActivateShield(float duration)
    {
        if (shieldVisual != null)
            shieldVisual.SetActive(true);

        shieldActive = true;

      
        Invoke("DeactivateShield", duration);
    }

    void DeactivateShield()
    {
        if (shieldVisual != null)
            shieldVisual.SetActive(false);

        shieldActive = false;
    }

    public bool IsShieldActive()
    {
        return shieldActive;
    }
}


