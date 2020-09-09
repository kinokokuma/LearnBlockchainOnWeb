using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class state3Contorl : MonoBehaviour
{
    public block[] block;
        public getText[] data,nonce;
    string[] text = { "test1", "test2", "test3", "step2", "step21", "step3", "step3.1", "8", "9", "10", "11" };
    public GameObject character;
    public Text readText;
    public int count = 0;
    public GameObject input, button;
    public bool click = false;
    public int countInput = 0;
    public string oldData = "0";
    public getText blockData;
    void Start()
    {
        block[0].enabled = false;
        block[2].enabled = false;
        data[0].blocktext = "23";
        data[1].blocktext = "0";
        data[2].blocktext = "43";
        
        readText.text = text[count];
        oldData = blockData.blocktext;
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
        }
        if (count == 6)
        {
            SceneManager.LoadScene(3);
        }
        if (countInput == 1 && count == 3)
        {
            character.SetActive(true);

        }
        if (countInput == 4 && count == 5)
        {
            character.SetActive(true);
        }
        if (oldData != blockData.blocktext)
        {
            countInput++;
            oldData = blockData.blocktext;
        }
       
    }
    IEnumerator resetClick()
    {
        click = true;
        yield return new WaitForSeconds(1);
        click = false;
    }
}
