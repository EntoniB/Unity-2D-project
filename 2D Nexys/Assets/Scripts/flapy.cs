using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flapy : MonoBehaviour
{
    public float speed = 5.0f;


    private Rigidbody2D rb;
    public Animator CharAnimator;
    public SpriteRenderer sprite;
    public float jumpForse = 15.0f;
    protected int coins { get; set; }

    int namber = 3;
    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        CharAnimator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();

    }
    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), "Монетки:" + coins + " из " + namber);
        if (Application.loadedLevel == 3)
        {
            

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Move();
            CharAnimator.SetInteger("State", 1);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            CharAnimator.SetInteger("State", 2);
        }
        if (!Input.anyKey)
        {
            CharAnimator.SetInteger("State", 0);
        }

    }

    void Move()
    {
        Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);
        if (tempvector.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coins")
        {

            coins++;

            Destroy(collision.gameObject);
        }

        if (Application.loadedLevel == 3 && coins == namber)
        {
            Application.LoadLevel("lvl0");
        }
    }
    void MobDead()
    {
        Application.LoadLevel(Application.loadedLevel);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "evil")
        {

            MobDead();
        }
    }
   
}
