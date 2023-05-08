using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=R5yoBsZhdhA&ab_channel=xxRafaelProductions-RafaelVicuna
// https://www.youtube.com/watch?v=c9kxUvCKhwQ&ab_channel=GameDevBeginner
// https://www.youtube.com/watch?v=K1xZ-rycYY8&ab_channel=bendux

public class person : MonoBehaviour
{
    [SerializeField] float jumpForce = 10;
    public float horizontal;
    public float moveSpeed;
    private Rigidbody2D rb;
    bool onGround = false;
    public AudioSource a;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //a = GetComponent<AudioSource>();
        horizontal = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && (onGround == true)) {
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
            onGround = false;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        a.Play(0);
        if (collision.gameObject.tag == "Ground") {
            onGround = true;
        }

    }
}
