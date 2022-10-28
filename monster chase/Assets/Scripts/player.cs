using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movmentX;
    [SerializeField]
    private Rigidbody2D mybody;
    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private Animator anim;
    private string WALK_ANIMATION = "walk";
    private string JUMP_ANIMATION = "jump";
    private bool isGrounded = false;
    private string GROUND_TAG = "Ground";
    private string ENEMIES_TAG = "Enemies";


    private void Awake(){
      mybody = GetComponent<Rigidbody2D>();
      sr = GetComponent<SpriteRenderer>();
      anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        AnimatePlayer();
    }

     void playerMovement(){
       movmentX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movmentX, 0f, 0f) * Time.deltaTime * moveForce;
     }
    private void FixedUpdate()
    {
        Playerjump();
    }

    void AnimatePlayer()
    {
        if(movmentX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movmentX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void Playerjump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            mybody.AddForce(new Vector2 (0f, jumpForce),ForceMode2D.Impulse);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMIES_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMIES_TAG)) 
            Destroy(gameObject);
    }

}








