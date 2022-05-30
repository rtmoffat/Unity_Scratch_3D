using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller_RC : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos=new Vector3();
        pos.Set(3.0f, 2.0f, 3.0f);
        Quaternion rot = new Quaternion();
        for (int i=1;i<600;i+=10)
        {
            pos.z = i;
            Instantiate(target, pos, rot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
