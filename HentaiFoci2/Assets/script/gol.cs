using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalDetection : MonoBehaviour
{
    public Transform ball; // A labda transformja
    public Vector3 initialPosition; // A labda kiinduló pozíciója
    public Text goalCounterText; // A UI szöveg eleme, ahol a gólok száma jelenik meg
    private int goalCount = 0; // Gólok száma

    void Start()
    {
        // A labda kiinduló pozícióját tároljuk el
        initialPosition = ball.position;
        UpdateGoalCounter();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) // Ellenõrizzük, hogy a labda lépett-e be a triggerbe
        {
            goalCount++; // Gólok száma növelése
            UpdateGoalCounter(); // Számláló frissítése
            ResetBallPosition(); // Labda visszaállítása középre
        }
    }

    void ResetBallPosition()
    {
        ball.position = initialPosition;
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Sebesség nullázása
            rb.angularVelocity = 0; // Forgás megállítása
        }
    }

    void UpdateGoalCounter()
    {
        goalCounterText.text = " "+goalCount;
    }
}
