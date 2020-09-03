using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State4Contorl : MonoBehaviour
{
    public block[] block1, block2, block3;
    public getText[] data1, data2, data3;
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
           int ran= Random.Range(0, 100);

            data1[i].blocktext = ran.ToString();
            data2[i].blocktext = ran.ToString();
            data3[i].blocktext = ran.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        block1[0].enabled = false;
        block1[2].enabled = false;
     
        if (Input.GetKeyDown(KeyCode.Q))
        {
            data1[1].showText = data1[1].noncetxt;
            data1[1].inputnonce = true;
        }
    }
}
