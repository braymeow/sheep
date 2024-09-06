using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInputControler : MonoBehaviour
{
    //data numbers for running
    [SerializeField] private float Speed,jumpspeed;
    [SerializeField] private LayerMask ground; 

    private PlayerMovementControls playerMovementControls;
    private Rigidbody rigidbody;
    private Collider collider;


    private void Awake()
    {
        playerMovementControls = new PlayerMovementControls();
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        playerMovementControls.Enable();
    }

    private void OnDisable()
    {
        playerMovementControls.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerMovementControls.CharacterMovement.croutch.performed += _ => Crountch();
    }

    private void Croutch()
    {
        if (IsGrounded()) { 
            rigidbody.AddForce(new Vector3 (0, jumpspeed), ForceMode.Impulse)

        }
            
    }

    private bool IsGrounded()
    {
        Vector3 

        return Physics.OverlapBox();
    }


    // Update is called once per frame
    void Update()
    {
        //Read the movement value
        float movementinput = playerMovementControls.CharacterMovement.move.ReadValue<float>();
        //Move the player
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementinput * Speed * Time.deltaTime;
        transform.position = currentPosition;
    }
}
