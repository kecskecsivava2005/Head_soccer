using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementawsd : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce; // Az ugr�s ereje
    private Rigidbody2D body;
    private bool isGrounded; // Ellen�rzi, hogy a karakter a talajon van-e

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Horizont�lis mozg�s balra �s jobbra nyilak haszn�lat�val
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

        // Ugr�s "W" gombbal, csak ha a talajon van
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            isGrounded = false; // Ugr�s ut�n m�r nem a talajon van
        }
    }

    // Ellen�rzi, ha a karakter a talajjal �rintkezik
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("isGrounded"))
        {
            isGrounded = true; // Talaj �rint�sekor vissza�ll�tjuk
        }
    }
}