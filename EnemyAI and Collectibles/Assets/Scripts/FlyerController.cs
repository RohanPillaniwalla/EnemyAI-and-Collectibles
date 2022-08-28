using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerController : MonoBehaviour
{
    Rigidbody2D flyerRB2D;
 
    public bool vertical;
    float timer;
    public float flyerSpeed = 3.0f;
    public float flyerChangeTime = 3.0f;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        flyerRB2D = GetComponent<Rigidbody2D>();

        timer = flyerChangeTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = flyerChangeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = flyerRB2D.position;

        if(vertical)
        {
            position.y += Time.deltaTime * flyerSpeed * direction;
        }
        else 
            position.x += Time.deltaTime * flyerSpeed * direction;

        flyerRB2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if(player != null)
        {
            player.ChangeHealth(-1);
            Destroy(gameObject);
        }
    }
}
