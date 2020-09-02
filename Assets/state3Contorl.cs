using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state3Contorl : MonoBehaviour
{
    public block[] block;
        public getText[] data,nonce;
    void Start()
    {
        block[0].enabled = false;
        block[2].enabled = false;
        data[0].blocktext = "23";
        data[2].blocktext = "43";
        data[1].blocktext = "0";
    }

    // Update is called once per frame
    void Update()
    {
        block[0].enabled=false;
        block[2].enabled = false;
        data[0].blocktext = "23";
        data[2].blocktext = "43";
        if(Input.GetKeyDown(KeyCode.Q))
        {
            data[1].showText = data[1].noncetxt;
            data[1].inputnonce = true;
        }
    }
}
