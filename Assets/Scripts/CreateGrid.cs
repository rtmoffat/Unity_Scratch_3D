using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public int G_width;
    public int G_height;
    public GameObject BackgroundTile;
    public int spacer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<(G_width*spacer);i+=spacer)
        {
            for (int j=0;j<(G_height*spacer);j+=spacer)
            {
                Debug.Log("X=" + i + "Y=" + j);
                Instantiate(BackgroundTile, new Vector3(i, j, 0), BackgroundTile.transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
