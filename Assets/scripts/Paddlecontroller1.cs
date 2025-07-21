using UnityEngine;

public class Paddlecontroller1 : MonoBehaviour
{
    public bool isPlayer1;
    public Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float movement;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (isPlayer1)
        {
            spriteRenderer.color = saveController.instance.colorPlayer;
        }
        else
        {
            spriteRenderer.color = saveController.instance.colorEnemy;
        }
    }

    void Update()
    {
        movement = 0f;

        if (isPlayer1)
        {
            if (Input.GetKey(KeyCode.W)) movement = 1f;
            else if (Input.GetKey(KeyCode.S)) movement = -1f;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) movement = 1f;
            else if (Input.GetKey(KeyCode.DownArrow)) movement = -1f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, movement * 5f);
    }
}
