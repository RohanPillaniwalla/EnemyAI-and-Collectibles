using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerController : MonoBehaviour
{
    Rigidbody2D flyerRB2D;
 
    public bool vertical;
    public float flyerSpeed = 3.0f;
    public float flyerChangeTime = 2.5f;

    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        flyerRB2D = GetComponent<Rigidbody2D>();

        timer = flyerChangeTime;
    }

    void Update()
    {
        //changing flyer direction after every 2.5 seconds
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

        //moving the flyer either vertically or horizotally
        if(vertical)
        {
            position.y += Time.deltaTime * flyerSpeed * direction;
        }
        else 
            position.x += Time.deltaTime * flyerSpeed * direction;

        flyerRB2D.MovePosition(position);
    }

    // checking for player trigger collison with flyer
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if(player != null)
        {
            Debug.Log("Player collided with a flyer.");
            player.ChangeHealth(-1);
            Destroy(gameObject);
        }
    }
}
