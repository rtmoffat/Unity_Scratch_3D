using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveVal;
    public Vector2 lookVal;
    public float moveSpeed;
    public PlayerVars playerVars;

    void OnLook(InputValue value)
    {
        lookVal = value.Get<Vector2>();
    }
    void OnMove(InputValue value)
    {
        //Get player state
        
        Debug.Log("Moving");
        moveVal=value.Get<Vector2>();
        if (playerVars.Alive)
        {
            Debug.Log("I'm still alive!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (playerVars.Alive)
        {
            transform.Translate(new Vector3(moveVal.x, 0, moveVal.y) * moveSpeed * Time.deltaTime);
            transform.Rotate(new Vector3(0, lookVal.y));
        }
    }
}
