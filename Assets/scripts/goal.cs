using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isLeftGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            ballController ball = collision.GetComponent<ballController>();

            if (ball != null)
            {
                if (isLeftGoal)
                {
                    GameManager.instance.AddPointToRight();
                }
                else
                {
                    GameManager.instance.AddPointToLeft();
                }

                ball.ResetBall();
            }
        }
    }
}
