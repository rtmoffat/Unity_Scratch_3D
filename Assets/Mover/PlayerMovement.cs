using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMove(InputValue value)
    {
        Debug.Log("Moving");
        Vector3 moveVal;
        moveVal = value.Get<Vector2>();
        transform.Translate(new Vector3 (moveVal.x,moveVal.y,0) * 5 * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
