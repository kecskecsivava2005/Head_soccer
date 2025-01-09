using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalDetection : MonoBehaviour
{
    public Transform ball; // A labda transformja
    public Vector3 initialPosition; // A labda kiindul� poz�ci�ja
    public Text goalCounterText; // A UI sz�veg eleme, ahol a g�lok sz�ma jelenik meg
    private int goalCount = 0; // G�lok sz�ma

    void Start()
    {
        // A labda kiindul� poz�ci�j�t t�roljuk el
        initialPosition = ball.position;
        UpdateGoalCounter();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) // Ellen�rizz�k, hogy a labda l�pett-e be a triggerbe
        {
            goalCount++; // G�lok sz�ma n�vel�se
            UpdateGoalCounter(); // Sz�ml�l� friss�t�se
            ResetBallPosition(); // Labda vissza�ll�t�sa k�z�pre
        }
    }

    void ResetBallPosition()
    {
        ball.position = initialPosition;
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Sebess�g null�z�sa
            rb.angularVelocity = 0; // Forg�s meg�ll�t�sa
        }
    }

    void UpdateGoalCounter()
    {
        goalCounterText.text = " "+goalCount;
    }
}
