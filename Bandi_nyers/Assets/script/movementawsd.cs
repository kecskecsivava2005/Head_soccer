using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class movementawsd : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce; // Az ugrás ereje
    private Rigidbody2D body;
    private bool isGrounded; // Ellenõrzi, hogy a karakter a talajon van-e
    private byte player1Index;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

        //Megnézzük, hogy az aktuális karakter a választott karakter vagy sem
        int[] indexes = CharacterSelector.GetIndex();
        if (indexes[0] == 0)
        {
            UnityEngine.Debug.Log("A bal oldali karakter Dominik");
            player1Index = 0;

        }
        else if (indexes[0] == 2)
        {
            UnityEngine.Debug.Log("A bal oldali karakter Laci");
            player1Index = 2;
        }
        else
        {
            UnityEngine.Debug.Log("Index:" + indexes[0]);
            UnityEngine.Debug.Log(this.tag);
            player1Index = 255;
        }
    }
    void Start()
    {
        if (this.tag == "Dominik" && player1Index == 0)
            transform.position = new Vector3(-8, -2.6f, 0);
        else if (this.tag == "Laci" && player1Index == 2)
            transform.position = new Vector3(-8, -2.6f, 0);
        else
            transform.position = new Vector3(-2, -20, 0);
    }
    private void Update()
    {

        if ((this.tag == "Dominik" && player1Index == 0) || (this.tag == "Laci" && player1Index == 2))
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
