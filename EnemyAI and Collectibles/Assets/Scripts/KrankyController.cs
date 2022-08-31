using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrankyController : MonoBehaviour
{
    public bool vertical;
    public float krankySpeed = 3.0f;
    public float krankyChangeTime = 2.5f;

    float timer;
    int krankyDirection = 1;

    Rigidbody2D krankyRB2D;

    // Start is called before the first frame update
    void Start()
    {
        krankyRB2D = GetComponent<Rigidbody2D>();
        timer = krankyChangeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            krankyDirection = -krankyDirection;
            timer = krankyChangeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = krankyRB2D.position;

        //moving kranky either vertically or horizotally
        if (vertical)
        {
            position.y += Time.deltaTime * krankySpeed * krankyDirection;
        }
        else
            position.x += Time.deltaTime * krankySpeed * krankyDirection;

        krankyRB2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            Debug.Log("Player collided with a flyer.");
            player.ChangeHealth(-2);
        }
    }
}
