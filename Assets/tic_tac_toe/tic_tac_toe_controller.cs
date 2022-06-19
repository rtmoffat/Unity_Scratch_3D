using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class tic_tac_toe_controller : MonoBehaviour
{
    public GameObject player_o_Obj;
    public GameObject player_x_Obj;
    public int turn = 1; //1=x,2=o
    private void Start()
    {
        Debug.Log("Starting");
    }
    public void OnPlaceToken(InputValue inputValue)
    {
        Debug.Log("hi "+inputValue.ToString());
        Vector2 mousePos=Mouse.current.position.ReadValue();
        
        Vector3 objLoc = new Vector3(mousePos.x, mousePos.y, 1.0f);
        Vector3 newLoc = Camera.main.ScreenToWorldPoint(objLoc);
        Ray ray = Camera.main.ScreenPointToRay(objLoc);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if ((hit.collider != null) && (hit.collider.name.Contains("Cube")))
            {
                Debug.Log("hit " + hit.collider.name);
                newLoc = Camera.main.ScreenToViewportPoint(hit.collider.gameObject.transform.position);
                newLoc.z = -2;
                if (turn == 1)
                {
                    Instantiate(player_x_Obj, Camera.main.ViewportToScreenPoint(newLoc), player_x_Obj.transform.rotation);
                    turn = 2;
                }
                else
                {
                    Instantiate(player_o_Obj, Camera.main.ViewportToScreenPoint(newLoc), player_o_Obj.transform.rotation);

                    turn = 1;
                }
            }
        }
    }
}
