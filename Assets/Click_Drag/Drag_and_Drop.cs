using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Drag_and_Drop : MonoBehaviour
{
    private Plane plane;

    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(Vector3.up, Vector3.zero);
    }

    void OnFire(InputAction inputAction)
    {
        float distance;
        RaycastHit hit;
        Vector2 posv2 = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(posv2.x,posv2.y, 0));
        if (Physics.Raycast(ray,out hit)) {
            
            Debug.Log("Raypoint=" + hit.collider.name);

        }
    }
    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
