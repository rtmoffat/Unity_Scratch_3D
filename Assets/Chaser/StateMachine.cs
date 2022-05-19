using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public bool playerAlive;
    // Start is called before the first frame update
    void Start()
    {
        this.playerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void killPlayer()
    {
        this.playerAlive = false;
    }
}
