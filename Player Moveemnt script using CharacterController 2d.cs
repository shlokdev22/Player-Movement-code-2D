//make sure to add a CharacterController to the thing that you want to move
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;

    // player jump
    public float jumpSpeed = 8.0f;
    //player gravity
    public float gravity = 20.0f;
    //player speed
    public float speed = 9.0f;
    //moveDirection Vector
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        //charactercontroller
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));

        if (characterController.isGrounded)
        {

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            //Jump
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}