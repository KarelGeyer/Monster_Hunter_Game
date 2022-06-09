using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private bool isGrounded = true; 
    private float movementX;

    public static Player instance;
    private int _isPlayerAlive = 1;
    public int IsPlayerAlive
    {
        get { return _isPlayerAlive; }
    }

    // Unity Tags and Variables
    private readonly string walkAnimation = "Walk"; // This has to be set exactly (case sensitive) as the *variable* set in the animation tab in Unity
    private readonly string groundTag = "Ground"; // This has to be set exactly (case sensitive) as the *tag* set on the ground object in Unity
    private readonly string rock = "Rock"; // - || -
    private readonly string enemy = "Enemy"; // - || -
    private readonly string door = "Door"; // - || -

    // Components fields
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator anim;
    private Scene sc;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        if(instance == null)
        {
            instance = this;
        }

        sc = GameManager.sc;
    }

    // Update is called once per frame
    void Update()
    {
        PlayMoveKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }


    void PlayMoveKeyboard()
    {
        // GetAxisRaw targets the (horizontal) position of an object and returns its value
        movementX = Input.GetAxisRaw("Horizontal");

        // Through transform we can control the position of an object
        transform.position += moveForce * Time.deltaTime * new Vector3(movementX, 0f, 0f);
    }

    void AnimatePlayer()
    {
        if (movementX > 0 || movementX < 0)
        {
            // We have set a bool variable in Unity that is connected to animation switch between "Idle" and "Walk" states
            anim.SetBool(walkAnimation, true);

            // sr.flipx targets the Flip (x axis) checker property in Rigid Body component and switch between checked and unchecked states
            var movingRight = movementX <= 0;
            sr.flipX = movingRight;
        } else
        {
            anim.SetBool(walkAnimation, false);
        }   
    }

    void PlayerJump()
    {
        // GetButtonDown -> This recognizes when we press button down and Unity utilizes "Jump" to be Space for PC and other buttons for different hardware (consoles, mobiles)
        // There is for instance GetButtonUP(when the button is let go) and GetButton(when button is hold) that behaves a little differently
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2 (0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag) || collision.gameObject.CompareTag(rock))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(enemy))
        {
            _isPlayerAlive = 0;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag(door))
        {
            if (sc.name == "Gameplay")
            {
                SceneManager.LoadScene("Gameplay_2");
            } 
            else if (sc.name == "Gameplay_2")
            {
                SceneManager.LoadScene("Main_Menu");
            }

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemy))
        {
            Destroy(gameObject);
        }
    }
}
