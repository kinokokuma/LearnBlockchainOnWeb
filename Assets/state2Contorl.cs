using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class state2Contorl : MonoBehaviour
{
    // Start is called before the first frame update
    string[] text = { "test1", "test2", "test3", "step2", "step21", "step3", "step3.1" ,"8","9","10","11"};
    public GameObject character;
    public Text readText;
    int[] data = { 254, 43, 21 };
    public int countInput = 0;
    public string olddata;
    public State2[] block;
    public GameObject input, button;
    public int count = 0;
    public bool click = false;
    public InputField inputBox;
    public GameObject[] blockstate2;
    public int index = 0;
    void Start()
    {
        readText.text = text[count];
        for(int i=0;i<3; i++)
        {
            block[i].data = data[i];
        }
        blockstate2[1].SetActive(false);
        blockstate2[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
            addBlock();
        

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
            blockstate2[index].SetActive(true);
            inputBox.GetComponent<inputtext>().get = block[index];
        }

        if (count == 6)
        {
            
            character.SetActive(false);
            blockstate2[index].SetActive(true);
            inputBox.GetComponent<inputtext>().get = block[index];
        }
        if (count == 10)
        {
            SceneManager.LoadScene(2);
        }

       
        input.SetActive(!character.active);
        button.SetActive(!character.active);
    }
    IEnumerator resetClick()
    {
        click = true;
        yield return new WaitForSeconds(1);
        click = false;
    }
    public void addBlock()
    {
       

            if (block[index].hashencode.Substring(0, 1) == "1")
            {

                if (!character.active && count <= 7)
                    count++;
                if (count == 4 || count == 8)
                {
                    character.SetActive(true);
                }
                else
                {
                    index++;
                    if (index > 2)
                    {
                        index = 2;
                    }
                    blockstate2[index].SetActive(true);
                    inputBox.GetComponent<inputtext>().get = block[index];
                }
               
            }
        
    }
}

   

