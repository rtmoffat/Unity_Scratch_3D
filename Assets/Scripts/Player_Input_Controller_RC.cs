using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Input_Controller_RC : MonoBehaviour
{
    public GameObject Player;
    private bool moving = false;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnFire(InputValue inputValue)
    {
        Ray myRay = Camera.main.ScreenPointToRay(new Vector3(Mouse.current.position.x.ReadValue(),Mouse.current.position.y.ReadValue(),100f));
        Debug.Log(myRay.ToString());
        if ((Physics.Raycast(myRay, out hit) && hit.collider.name.Equals("Target_Sphere")))
        {
            Debug.Log(hit.collider.name);
            Debug.Log("State="+hit.collider.gameObject.GetComponent<Target_Controller_RC>().isOn);

            if (hit.collider.gameObject.GetComponent<Target_Controller_RC>().isOn)
            {
                hit.collider.gameObject.GetComponent<Target_Controller_RC>().isOn = false;
                hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                moving = false;
                //Vector3.MoveTowards(Player.transform.position, hit.point, 0.0f);
            }
            else
            {
                hit.collider.gameObject.GetComponent<Target_Controller_RC>().isOn = true;
                hit.collider.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                moving = true;
                //Vector3.MoveTowards(Player.gameObject.transform.position, hit.point, 0.5f * Time.deltaTime);
            }
            
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            Player.transform.position=Vector3.MoveTowards(Player.gameObject.transform.position, hit.point, 0.5f * Time.deltaTime);
        }
    }
}
