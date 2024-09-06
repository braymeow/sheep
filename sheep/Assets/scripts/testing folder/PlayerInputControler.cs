using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInputControler : MonoBehaviour
{
    //data numbers for running
    [SerializeField] private float Speed;

    private PlayerMovementControls playerMovementControls;


    private void Awake()
    {
        playerMovementControls = new PlayerMovementControls();
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
        transform.position.x += 3f
    }
}
