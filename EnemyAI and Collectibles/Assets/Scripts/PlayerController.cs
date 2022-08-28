using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 3.0f;

    public int PlayerMaxHealth = 5;
    int PlayerCurrentHealth;
    public int Health { get { return PlayerCurrentHealth; } }

    Rigidbody2D rb2d;

    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        PlayerCurrentHealth = PlayerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 position = rb2d.position;

        position.x += PlayerSpeed * horizontal * Time.deltaTime;
        position.y += PlayerSpeed * vertical * Time.deltaTime;

        rb2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        PlayerCurrentHealth = Mathf.Clamp(PlayerCurrentHealth + amount, 0, PlayerMaxHealth);
        Debug.Log(PlayerCurrentHealth + "/" + PlayerMaxHealth);
    }
}
