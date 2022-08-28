using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 3.0f;

    public int playerMaxHealth = 5;
    int playerCurrentHealth;
    public int Health { get { return playerCurrentHealth; } }

    Rigidbody2D playerRb2D;

    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        playerRb2D = GetComponent<Rigidbody2D>();

        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 position = playerRb2D.position;

        position.x += playerSpeed * horizontal * Time.deltaTime;
        position.y += playerSpeed * vertical * Time.deltaTime;

        playerRb2D.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth + amount, 0, playerMaxHealth);
        Debug.Log(playerCurrentHealth + "/" + playerMaxHealth);
    }
}
