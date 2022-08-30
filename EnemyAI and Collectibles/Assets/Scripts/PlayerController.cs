using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 3.0f;
    public float timeInvincible = 2.0f;
    public int playerMaxHealth = 5;

    float horizontal;
    float vertical;
    float invincibleTimer;
    int playerCurrentHealth;
    bool isInvincible;

    Rigidbody2D playerRb2D;

    public int Health { get { return playerCurrentHealth; } }

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

        //check for invicible
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    private void FixedUpdate()
    {
        //handling movement
        Vector2 position = playerRb2D.position;

        position.x += playerSpeed * horizontal * Time.deltaTime;
        position.y += playerSpeed * vertical * Time.deltaTime;

        playerRb2D.MovePosition(position);
    }

    //method to change health on collision with health collectibles and enemy
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        playerCurrentHealth = Mathf.Clamp(playerCurrentHealth + amount, 0, playerMaxHealth);
        Debug.Log(playerCurrentHealth + "/" + playerMaxHealth);
    }
}
