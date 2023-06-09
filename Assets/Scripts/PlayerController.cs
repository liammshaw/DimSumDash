using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// https://www.youtube.com/watch?v=R5yoBsZhdhA&ab_channel=xxRafaelProductions-RafaelVicuna
// https://www.youtube.com/watch?v=c9kxUvCKhwQ&ab_channel=GameDevBeginner
// https://www.youtube.com/watch?v=K1xZ-rycYY8&ab_channel=bendux

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpForce = 10;
    public float horizontal;
    public float moveSpeed;
    private Rigidbody2D rb;
    bool onGround = false;
    public AudioSource a;
    public AudioSource coinAudio;
    public CoinManager cm;
    public GameObject spawnpoint;
    public Animator animator;

    public float SteamForce;

    [SerializeField] Sprite OnLantern;

    public Text coinText;

    [HideInInspector] public PlayerController Instance;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //a = GetComponent<AudioSource>();
        horizontal = 0;
        Instance = this;
        cm.coinText = coinText;
    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && (onGround == true)) {
            rb.AddForce(Vector2.up*jumpForce, ForceMode2D.Impulse);
            onGround = false;
            animator.SetBool("onGround", onGround);
        }
        // horizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * moveSpeed * Time.deltaTime, rb.velocity.y);
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        a.Play(0);
        if (collision.gameObject.tag == "Ground") {
            onGround = true;
            animator.SetBool("onGround", onGround);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Steam"){
            Debug.Log("interacted with steam");
            rb.AddForce(Vector2.up * SteamForce, ForceMode2D.Impulse);
            onGround = false;
            animator.SetBool("onGround", onGround);
        }
        if (collision.gameObject.tag == "Coin") {
            Destroy(collision.gameObject);
            cm.coinCount++;
            coinAudio.Play(0);
        }
        if (collision.gameObject.tag == "Deathpoint") {
            Debug.Log("interacted with death point");
            transform.position = spawnpoint.transform.position;
        }
        if (collision.gameObject.tag == "Lantern" && cm.coinCount == 20){
            GameObject lantern = GameObject.FindGameObjectWithTag("Lantern");
            SpriteRenderer sr = lantern.GetComponent<SpriteRenderer>();
            sr.sprite = OnLantern;
            StartCoroutine(EndLevel());
        }
    }

    IEnumerator EndLevel(){
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Credits");
    }
}