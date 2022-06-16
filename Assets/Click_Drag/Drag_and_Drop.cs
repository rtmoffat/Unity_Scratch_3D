using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Drag_and_Drop : MonoBehaviour
{
    private Plane plane;
    private bool moving;
    private GameObject clickedObject;

    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(Vector3.up, Vector3.zero);
    }

    void OnFire(InputValue inputValue)
    {
        Debug.Log("Firing");
        float distance;
        RaycastHit hit;
        Vector3 posv2 = Mouse.current.position.ReadValue();
        posv2.z = Camera.main.nearClipPlane;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(posv2);
        worldPos.z = 0;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(posv2.x,posv2.y, 0));
        if (Physics.Raycast(ray,out hit)) {
            
            Debug.Log("Raypoint=" + hit.collider.name);
            clickedObject = hit.collider.gameObject;
            clickedObject.transform.Translate(worldPos);
            moving = true;
        }
    }
    private void FixedUpdate()
    {
        if (moving)
        {
            Vector3 posv2 = Mouse.current.position.ReadValue();
            posv2.z = Camera.main.nearClipPlane;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(posv2);
            worldPos.z = 0;
            clickedObject.transform.Translate(worldPos);
            Debug.Log("moving");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
