using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gem_Input_Controller : MonoBehaviour
{
    private float _moveSpeed = 10f;
    private Vector3 _moveVec = Vector3.zero;
    public void OnDrag(InputValue inputValue)
    {
        Debug.Log("Dragging" + "pressed=" + inputValue.isPressed);
        //_moveVec = new Vector3(Mouse.current.x,);
    }
    public void OnMove(InputValue inputValue)
    {
        Debug.Log("You pressed " + inputValue.ToString());
        Debug.Log("x="+inputValue.Get<Vector2>().x+"y="+inputValue.Get<Vector2>().y);
        
        Vector2 inputVec = inputValue.Get<Vector2>();

        //_moveVec = new Vector3(transform.position.x+inputVec.x, transform.position.y+inputVec.y);
        _moveVec = new Vector3(inputVec.x, inputVec.y, 0);
        transform.Translate(_moveVec);
    }
    void Update()
    {
        transform.Translate(_moveVec * _moveSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("i hit something");
    }
}
