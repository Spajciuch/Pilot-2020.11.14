using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private LayerMask movingLayerMask;

    public float dirX, moveSpeed, jumpSpeed, scale;
    private Animator anim;

    private Rigidbody2D rb2d;
    private PolygonCollider2D polygonCollider2D;
    private BoxCollider2D boxCollider2D;

    private GameObject player;
    private SoundManage audioPlayer;
    private GameActions game;
    private CameraScript cameraScript;

    public AudioClip footstepSound;
    
    public int keyNumber = 0;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        cameraScript = FindObjectOfType<CameraScript>();

        player = GameObject.Find("Player");
        audioPlayer = FindObjectOfType<SoundManage>();
        game = player.AddComponent<GameActions>();
    }

    private void Update()
    {
        if (Input.GetKey("q")) KillPlayer();
        if (Input.GetKey("e")) RespawnPlayer();
    }

    void FixedUpdate()
    {
        Movement();

        if (Input.GetKey("q")) KillPlayer();
        if (Input.GetKey("e")) RespawnPlayer();
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * moveSpeed;

        if(x < 0)
        {
            Vector2 reScale = new Vector2(-1, 1);
            transform.localScale = reScale;
        } 
        
        else if (x > 0)
        {
            Vector2 reScale = new Vector2(1, 1);
            transform.localScale = reScale;
        }

        rb2d.velocity = new Vector2(moveBy, rb2d.velocity.y);

        if(Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            if(IsGrounded())
            {
                if (IsGrounded() && !anim.GetBool("inAir"))
                {
                    anim.SetBool("inAir", true);
                    Vector2 jumpVector = new Vector2(0, 1);
                    rb2d.AddForce(jumpVector * jumpSpeed);
                }
            }
        }

        if (x != 0)
        {
            if (IsGrounded()) anim.SetBool("isWalking", true);
        }

        else
        {
            anim.SetBool("isWalking", false);
        }
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            collision.gameObject.SetActive(false);
            keyNumber ++;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Moving")
        { 
            anim.SetBool("inAir", false);
        }

        if (collision.gameObject.tag == "Moving")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moving")
        {
            transform.parent = null;
        }
    }

    public void KillPlayer()
    {
        anim.SetBool("Dead", true);
        audioPlayer.DeathSound();

        cameraScript.cameraDistance = Mathf.SmoothStep(50, 20, 10);

        game.PauseGame();
    }

    public void RespawnPlayer()
    {
        game.ResumeGame();
        
        anim.SetBool("Dead", false);
        cameraScript.cameraDistance = 50;
        player.transform.position = new Vector2(-45.8f, 5.6f);
    }
    private bool IsGrounded()
    {
        return boxCollider2D.IsTouchingLayers(platformLayerMask) || boxCollider2D.IsTouchingLayers(movingLayerMask);
    }
}