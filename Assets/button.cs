using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    int index = 0;
    public GameObject block,origin;
   public void addData()
    {
    
        GameObject thisBlock = Instantiate(block, new Vector3(origin.transform.position.x, origin.transform.position.y- (origin.transform.localScale.y*2), origin.transform.position.z), Quaternion.identity);
        thisBlock.name = "blockdata" + index;
        origin = thisBlock;
        GameObject.Find("blockdata" + index + "/blockData/data").GetComponent<getText>().blockIndex = index;
   
        index++;
    }
}
