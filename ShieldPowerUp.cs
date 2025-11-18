using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float shieldDuration = 5f; // How long the shield lasts

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("ShieldPowerUp triggered");
                player.ActivateShield(shieldDuration);
                Destroy(gameObject);
            }
        }
    }
}

