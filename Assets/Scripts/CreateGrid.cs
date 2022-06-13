using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public int G_width;
    public int G_height;
    public GameObject BackgroundTile;
    public GameObject Gem;
    public float spacer;
    public Material brown;
    public Material blue;
    public Material acqua;

    // Start is called before the first frame update
    void Start()
    {
        Material[] colors= { brown, blue, acqua };
        GameObject board = GameObject.FindWithTag("BoardTag");
        GameObject GemsArray = GameObject.FindWithTag("GemsArray");
        for (float i=0;i<(G_width*spacer);i+=spacer)
        {
            for (float j=0;j<(G_height*spacer);j+=spacer)
            {
                Debug.Log("X=" + i + "Y=" + j);
                GameObject g = Instantiate(Gem, new Vector3(i, j, 0), BackgroundTile.transform.rotation);
                g.tag = "Gemtag";
                g.transform.SetParent(GemsArray.transform);
                g.GetComponent<Renderer>().material = colors[Random.Range(0,3)];
          
                GameObject p = Instantiate(BackgroundTile, new Vector3(i, j, 0), BackgroundTile.transform.rotation);
                p.tag = "TileTag";
                p.transform.SetParent(board.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
