using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] // allows vewing in inspect thought they are private
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private bool isGrounded;

    private float movementX;

    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    private void FixedUpdate() {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded = true;
        }
    }

    void PlayerMoveKeyboard(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;        
    }

    void PlayerJump(){
        if (Input.GetButtonDown("Jump") && isGrounded){ //--> when pressed  |   Input.GetButtonUp --> when released  |  Input.GetButton --> when holding
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log("Jumped");
        }
    }
    void AnimatePlayer(){

        if (movementX > 0){ //Walk right
            anim.SetBool(WALK_ANIMATION, true);   //Condition name SetBool("ANimator parameter", boolean)
            sr.flipX = false; //set direction of player facing
        }
        else if(movementX < 0){ //Walk Left
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else{ //Idle
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
}
