using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class State4Contorl : MonoBehaviour
{
    public block[] block1, block2, block3;
    public getText[] data1, data2, data3;
      string[] text = { "สวัสดี", "test2", "test3", "step2", "step21", "step3", "step3.1", "8", "9", "10", "11" };
    public GameObject character;
    public Text readText;
    public int count = 0;
   
    public bool click = false;
    public int[] countInput = { 0,0,0};
    public string[] oldData = {"","","" };
    public getText[] blockData;
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
           int ran= Random.Range(0, 100);

            data1[i].blocktext = ran.ToString();
            data2[i].blocktext = ran.ToString();
            data3[i].blocktext = ran.ToString();
            block1[i].enabled = false;
            block2[i].enabled = false;
            block3[i].enabled = false;
            
            
        }
        oldData[0] = blockData[0].blocktext;
        oldData[1] = blockData[1].blocktext;
        oldData[2] = blockData[2].blocktext;
        readText.text = text[count];
    }

    // Update is called once per frame
    void Update()
    {
       if(count<4)
        {
            block1[1].enabled = true;
        }
        if (Input.GetMouseButtonDown(0) && !click)
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


            if (hit.collider.gameObject.tag == "Player")
            {
                count++;
                readText.text = text[count];
                StartCoroutine(resetClick());
            }
        }
        if (count == 3)
        {
            character.SetActive(false);
        }

        if (count == 5)
        {
            character.SetActive(false);
            block2[1].enabled = true;
        }
        if (count == 6)
        {
            SceneManager.LoadScene(3);
        }
        if (countInput[0] == 1 && count == 3)
        {
            character.SetActive(true);
        }
        if (data2[1].blocktext== data1[1].blocktext && count == 5)
        {
            character.SetActive(true);
        }
        if (oldData[0] != blockData[0].blocktext)
        {
            countInput[0]++;
            oldData[0] = blockData[0].blocktext;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            data1[1].showText = data1[1].noncetxt;
            data1[1].inputnonce = true;
        }
    }
    IEnumerator resetClick()
    {
        click = true;
        yield return new WaitForSeconds(1);
        click = false;
    }
}
