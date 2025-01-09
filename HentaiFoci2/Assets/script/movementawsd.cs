using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementawsd : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce; // Az ugrás ereje
    private Rigidbody2D body;
    private bool isGrounded; // Ellenõrzi, hogy a karakter a talajon van-e

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Horizontális mozgás balra és jobbra nyilak használatával
        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }

        transform.rotation = Quaternion.identity;

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // Ugrás "W" gombbal, csak ha a talajon van
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            isGrounded = false; // Ugrás után már nem a talajon van
        }
    }

    // Ellenõrzi, ha a karakter a talajjal érintkezik
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("isGrounded"))
        {
            isGrounded = true; // Talaj érintésekor visszaállítjuk
        }
    }
}