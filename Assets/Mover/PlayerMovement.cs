using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveVal;
    public float moveSpeed;
    public PlayerVars test2;

    void OnMove(InputValue value)
    {
        //Get player state
        
        Debug.Log("Moving");
        moveVal=value.Get<Vector2>();
        if (test2.Alive)
        {
            Debug.Log("I'm still alive!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (test2.Alive)
        {
            transform.Translate(new Vector3(moveVal.x, 0, moveVal.y) * moveSpeed * Time.deltaTime);
        }
    }
}
