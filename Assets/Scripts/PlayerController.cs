using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed = 8f, runSpeed = 12f, mouseSens = 2f, smoothTime = 4f;
    public float gravityMod, jumpForce;
    CharacterController controller;
    private Vector3 moveInput;
    public new Transform camera;

    private bool canJump, canDoubleJump;
    Animator anim;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool canMove = true;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (canMove)
        {
            MouseLook();
            MovePlayer();
        }
    }

    public void MovePlayer()
    {
        float yStore = moveInput.y;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 horiMove = transform.right * x;
        Vector3 vertMove = transform.forward * z;

        moveInput = horiMove + vertMove;
        moveInput.Normalize();

        //Sprint
        if(Input.GetKey(KeyCode.LeftShift))
        {
            //runSpeed = Mathf.Lerp(moveSpeed, runSpeed, smoothTime * Time.deltaTime);
            moveInput *= runSpeed;
        }
        else
        {
            moveInput *= moveSpeed;
        }

        //Gravity
        moveInput.y = yStore;
        moveInput.y += Physics.gravity.y * gravityMod * Time.deltaTime;

        if (controller.isGrounded)
        {
            moveInput.y =  Physics.gravity.y * gravityMod * Time.deltaTime;
        }

        //Jumping
        canJump = Physics.OverlapSphere(groundCheck.position, 0.25f, groundLayer).Length > 0;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            moveInput.y = jumpForce;
            canDoubleJump = true;
        }
        else if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
        {
            moveInput.y = jumpForce;
            canDoubleJump = false;
        }

        //Move Player Controller
        controller.Move(moveInput * Time.deltaTime);

        //Animator
        anim.SetFloat("moveSpeed", moveInput.magnitude);
        anim.SetBool("IsGrounded", canJump);
    }

    public void MouseLook()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSens;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        camera.rotation = Quaternion.Euler(camera.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));
    }
}
