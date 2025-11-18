using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
       
        Player player = other.GetComponentInParent<Player>();
        if (player != null)
        {
       
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(1);
            }
            else
            {
                Debug.LogError("ScoreManager instance is null!");
            }

       
            Destroy(gameObject);
        }
    }

    void Update()
    {
       
        if (transform.position.y < -6f) 
        {
            Destroy(gameObject);
        }
    }
}
