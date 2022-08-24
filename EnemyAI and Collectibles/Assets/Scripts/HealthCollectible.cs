using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Object that entered the trigger : " + collision);
        PlayerController controller = collision.GetComponent<PlayerController>();
        if(controller != null)
        {
            if(controller.currentHealth < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
        
    }
}
