using UnityEngine;

public class ballController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float launchForce = 5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-0.5f, 0.5f);


        if (y > -0.2f && y < 0.2f)
            y = y < 0 ? -0.5f : 0.5f;

        Vector2 direction = new Vector2(x, y).normalized;
        rb2d.linearVelocity = direction * launchForce;
    }

    public void ResetBall()
    {

        CancelInvoke(nameof(LaunchBall));

        transform.position = Vector2.zero;
        rb2d.linearVelocity = Vector2.zero;

        Invoke(nameof(LaunchBall), 1f);
    }
}
