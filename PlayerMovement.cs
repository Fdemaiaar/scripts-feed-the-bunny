using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource audio;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (movement.sqrMagnitude > 1)
        {
            movement.Normalize();
        }

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coletavel"))
        {
            if (audio != null)
            {
                audio.Play();
            }
            GameController.Collect();
            Destroy(collision.gameObject);
        }
    }
}
// <-- Não deve haver mais nada após esta chave
