using UnityEngine;
using UnityEngine.UI;
public class Hero : MonoBehaviour
{
    // public int Life = 5;
    public float speed = 5.0f;

   
    private Rigidbody2D rb;
    public Animator CharAnimator;
    public SpriteRenderer sprite;
    public float jumpForse = 15.0f;
    private bool isGrounded = false;
    //ссылка на компонент Transform объекта
    //для определения соприкосновения с землей
    public Transform groundCheck;
    //радиус определения соприкосновения с землей
    private float groundRadius = 0.2f;
    //ссылка на слой, представляющий землю
 
    public LayerMask whatIsGround;
    
    protected int coins { get; set; }

     int namber = 1;
        

   
   
    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        CharAnimator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        
       
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //устанавливаем соответствующую переменную в аниматоре
        CharAnimator.SetBool("Ground", isGrounded);
        //устанавливаем в аниматоре значение скорости взлета/падения
      
        if (!isGrounded)
            return;



    }
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Move();
            CharAnimator.SetInteger("State", 1);
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //устанавливаем в аниматоре переменную в false
            CharAnimator.SetBool("Ground", false);
            //прикладываем силу вверх, чтобы персонаж подпрыгнул
            rb.AddForce(new Vector2(0, 280));
            CharAnimator.SetInteger("State", 2);
        }

       


        if (!Input.anyKey)
        {
            CharAnimator.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "evil")
        {
          
            MobDead();
        }
    }
    
    
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if (collision.gameObject.tag == "coins")
        {

            coins++;
           
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Finish")

        {
            if (Application.loadedLevel == 1 && coins == namber )
            {
                Application.LoadLevel("lvl2");
            }
            
           
             if  (Application.loadedLevel == 2 && coins == namber)
             {
                Application.LoadLevel("lvl3");
             }
            



        }
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 30), "Монетки:" + coins + " из " + namber);
        if (Application.loadedLevel == 1)
        {
            

        }

        if (Application.loadedLevel == 2)
        {
            namber = 2;

        }
      
    }


    void MobDead()
    {
        Application.LoadLevel(Application.loadedLevel);
      

    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
    }
   private  void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
    }
    void Move()
    {
       Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector,speed * Time.deltaTime);
        if (tempvector.x < 0)
        {
           sprite.flipX = true;
        }
        else
        {
           sprite.flipX = false;
        }
    }

  




}
