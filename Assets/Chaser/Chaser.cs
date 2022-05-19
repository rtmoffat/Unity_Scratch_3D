using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public PlayerVars test;
    // Start is called before the first frame update
    void Start()
    {
        test.Alive = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Debug.Log("Got 'em!");
            test.Alive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (test.Alive)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, (3.0f * Time.deltaTime));
            
        }
    }
}
