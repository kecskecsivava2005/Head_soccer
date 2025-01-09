using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
        }

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        transform.rotation = Quaternion.identity;

        // Ugr�s csak akkor, ha a karakter a talajon van
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            isGrounded = false; // Ugr�s ut�n a karakter nem lesz a talajon
        }
    }

    // Ellen�rizz�k, ha a karakter a talajjal �rintkezik
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("isGrounded"))
        {
            isGrounded = true; // Talaj �rint�sekor vissza�ll�tjuk true-ra
        }
        
    }
}