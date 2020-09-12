using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class button : MonoBehaviour
{
    int index = 0;
    public GameObject block,origin;
    public InputField input;
    public GameObject[] blockstate2;
   public void addData()
    {
        if (input.text != "")
        {
            GameObject thisBlock = Instantiate(block, new Vector3(origin.transform.position.x, origin.transform.position.y - (origin.transform.localScale.y * 2), origin.transform.position.z), Quaternion.identity);
            thisBlock.name = "blockdata" + index;
            origin = thisBlock;
            getText blockData = GameObject.Find("blockdata" + index + "/blockData/data").GetComponent<getText>();
            blockData.blockIndex = index;
            blockData.blocktext = input.text;
            input.text = "";
            index++;
        }
    }
   
}
