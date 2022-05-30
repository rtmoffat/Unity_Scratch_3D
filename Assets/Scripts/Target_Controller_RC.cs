using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Controller_RC : MonoBehaviour
{
    public bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
