using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public uint playerIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.GetComponent<Ball>();
        if (ball)
        {
            ball.ResetPosition();
            int currentScore = GameManager.instance.GetIndexPuntiacion((int)playerIndex);
            GameManager.instance.
                setIndexPuntuacion((int)playerIndex, currentScore + 1);
        }
    }
}
