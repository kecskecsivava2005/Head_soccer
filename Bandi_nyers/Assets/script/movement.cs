using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
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
        if (indexes[1] == 3)
        {
            UnityEngine.Debug.Log("A jobb oldali karakter Dominik");
            player1Index = 3;

        }
        else if (indexes[1] == 1)
        {
            UnityEngine.Debug.Log("A jobb oldali karakter Laci");
            player1Index = 1;
        }
        else
        {
            UnityEngine.Debug.Log("Valami nem jó... Index:" + indexes[1]);
            UnityEngine.Debug.Log(this.tag);
            player1Index = 255;
        }
    }

    void Start()
    {
        if (this.tag == "Dominik" && player1Index == 3)
            transform.position = new Vector3(8, -2.6f, 0);
        else if (this.tag == "Laci" && player1Index == 1)
            transform.position = new Vector3(8, -2.6f, 0);
        else
            transform.position = new Vector3(-2, -20, 0);
    }

    private void Update()
    {
        if ((this.tag == "Dominik" && player1Index == 3) || (this.tag == "Laci" && player1Index == 1))
        {
            // Horizontális mozgás balra és jobbra nyilak használatával
            float horizontalInput = 0f;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Joystick1Button15))
            {
                horizontalInput = -1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Joystick1Button16))
            {
                horizontalInput = 1f;
            }

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            transform.rotation = Quaternion.identity;

            // Ugrás csak akkor, ha a karakter a talajon van
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button13) && isGrounded)
            {
                body.velocity = new Vector2(body.velocity.x, jumpForce);
                isGrounded = false; // Ugrás után a karakter nem lesz a talajon
            }
        }
    }

    // Ellenõrizzük, ha a karakter a talajjal érintkezik
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("isGrounded"))
        {
            isGrounded = true; // Talaj érintésekor visszaállítjuk true-ra
        }

    }
}