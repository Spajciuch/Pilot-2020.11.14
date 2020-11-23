using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;

    public float dirX, moveSpeed, jumpSpeed;
    private Animator anim;

    private Rigidbody2D rb2d;
    private PolygonCollider2D polygonCollider2D;
    private BoxCollider2D boxCollider2D;

    private GameObject player;
    private SoundManage audioPlayer;

    public AudioClip footstepSound;
    void Start()
    {
        anim = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
        
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        player = GameObject.Find("Player");
        audioPlayer = FindObjectOfType<SoundManage>();
    }

    void FixedUpdate()
    {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);

        if (dirX != 0)
        {
            Vector3 turnLeft = new Vector3(-1, 1, 1);
            Vector3 turnRight = new Vector3(1, 1, 1);

            if (dirX < 0) transform.localScale = turnLeft;
            else transform.localScale = turnRight;

            if(IsGrounded()) anim.SetBool("isWalking", true);
        }
        else
        {
            if(IsGrounded()) anim.SetBool("isWalking", false);
        }

        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            if (IsGrounded() && !anim.GetBool("inAir"))
            {
                anim.SetBool("inAir", true);
                Vector2 jumpVector = new Vector2(0, 1);
                rb2d.AddForce(jumpVector * jumpSpeed);
            }
        }

        if (Input.GetKey("q")) KillPlayer();
        if (Input.GetKey("e")) RespawnPlayer(); 
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
        //player.SetActive(false);
        audioPlayer.DeathSound();
    }

    public void RespawnPlayer()
    {
        player.transform.position = new Vector2(-8.81f, -2.2f);
        player.SetActive(true);
    }
    private bool IsGrounded()
    {
        return boxCollider2D.IsTouchingLayers(platformLayerMask);
    }
}