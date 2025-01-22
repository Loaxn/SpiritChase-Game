using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.1f;   //champs
    [SerializeField] private Rigidbody rgbd;
    [SerializeField] private float jumpHeight;

   
    //private CharacterController characterController;
    private Vector2 MoveVector;
    private bool Jump;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    //private void OnEnable()
    //{
    //    characterController = gameObject.AddComponent<CharacterController>();
    //    characterController.radius = 1f;
    //    characterController.detectCollisions = true;

    //}

    //private void OnDisable()
    //{
    //   Destroy(characterController);
    //}

    private void FixedUpdate()
    {
        Move();
    }

    #region Input Reading
    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        MoveVector = context.ReadValue<Vector2>();
    }

    public void ReadJumpInput(InputAction.CallbackContext context)
    {
        Jump = context.ReadValue<float>() > 0.1f;
        Jumpp();       
    }
    #endregion

    private void Move()
    {
        // Find the direction
        Vector3 direction = new Vector3(MoveVector.x, 0f, MoveVector.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
           
            // Use normalized vector to move the character
            Vector3 moveDirection = direction;

            // Apply the movement
            //characterController.Move(moveDirection.normalized * _speed * Time.deltaTime);
            rgbd.position += moveDirection * _speed * Time.deltaTime;
        }
        else
        {
            // If the character don't move, set the isWalkin parameter to false
            
        }
    }
    private void Jumpp()
    {
        if (Jump && Mathf.Abs(rgbd.velocity.y) < 0.01f) // Vérifie que le joueur est au sol
        {
            Debug.Log("Jumping");
            rgbd.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }



}
