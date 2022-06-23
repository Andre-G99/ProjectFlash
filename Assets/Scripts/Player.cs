using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //animation variables
    public SpriteRenderer playerSR;
    public Rigidbody2D rb;

    //movement variables
    public float moveSpeed;
    private float horizontalMove;

    //jump movement variables
    public float jumpForce;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimerCounter;
    public float jumpTime;
    private bool isJumping;

    //health variables
    public int currentHP;
    public const int MAXHP = 30;
    public const int MINHP = 0;

    //health UI variables
    public Image heartOne;
    public Image heartTwo;
    public Image heartThree;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite halfHeart;
    public GameObject losePanel;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        setCurrentHP(MAXHP);
    }

    // Update is called once per frame
    // Fixed update is used for rigidbody component
    void FixedUpdate()
    {
        //Store
        horizontalMove = Input.GetAxisRaw("Horizontal");

        // Move our character
       rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
       
       getCurrentHP();

       updateHP_UI(this.currentHP);

       if(getCurrentHP() == 0){
           death();
       }
    }
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        
        if(isGrounded && Input.GetButtonDown("Jump")){
            isJumping = true;
            jumpTimerCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetButton("Jump") && isJumping){

            if(jumpTimerCounter > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimerCounter -=Time.deltaTime;
            }

        }

        if(Input.GetButtonUp("Jump")){
            isJumping = false;
        }
    }

    public void gainHP(int heal){

        currentHP = getCurrentHP();

        if((currentHP + heal) > 30)
        {
            setCurrentHP(30);
        } else {
            setCurrentHP(currentHP + heal);
        }

    }

    public void loseHP(int dmg){

        currentHP = getCurrentHP();

        if((currentHP - dmg) < 0)
        {
            setCurrentHP(0);
        } else {
            setCurrentHP(currentHP - dmg);
        }

    }

    private void setCurrentHP(int hp){
        currentHP = hp;
    }

    public int getCurrentHP(){
        return this.currentHP;
    }

    public void death(){
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void unPause(){
        Time.timeScale = 1;
    }

    public void _retry(){
        setCurrentHP(MAXHP);
        losePanel.SetActive(false);
        Time.timeScale = 1;
    } 

    public void killPlayer(){
        Destroy(gameObject);
    }

    public void updateHP_UI(int currentHP){

        if(currentHP == 30){
            heartOne.sprite = fullHeart;
            heartTwo.sprite = fullHeart;
            heartThree.sprite = fullHeart;
        }
        else if (currentHP >= 25 && currentHP < 30){
            heartOne.sprite = fullHeart;
            heartTwo.sprite = fullHeart;
            heartThree.sprite = halfHeart;
        }
        else if (currentHP >= 20 && currentHP < 25){
            heartOne.sprite = fullHeart;
            heartTwo.sprite = fullHeart;
            heartThree.sprite = emptyHeart;
        }
        else if (currentHP >= 20 && currentHP < 25){
            heartOne.sprite = fullHeart;
            heartTwo.sprite = fullHeart;
            heartThree.sprite = emptyHeart;
        }
        else if (currentHP >= 15 && currentHP < 20){
            heartOne.sprite = fullHeart;
            heartTwo.sprite = halfHeart;
            heartThree.sprite = emptyHeart;
        }
        else if (currentHP >= 10 && currentHP < 15){
            heartOne.sprite = fullHeart;
            heartTwo.sprite = emptyHeart;
            heartThree.sprite = emptyHeart;
        }
        else if (currentHP > 0 && currentHP < 10){
            heartOne.sprite = halfHeart;
            heartTwo.sprite = emptyHeart;
            heartThree.sprite = emptyHeart;
        }
        else if (currentHP == 0){
            heartOne.sprite = emptyHeart;
            heartTwo.sprite = emptyHeart;
            heartThree.sprite = emptyHeart;
        }
    }
}
