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
    public int countInput = 0;
    public string olddata;
    public State2 block;
    public GameObject input, button;
    public int count = 0;
    public bool click = false;
    void Start()
    {
        readText.text = text[count];
    }

    // Update is called once per frame
    void Update()
    {

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

        if (count == 6)
        {
            block.index=1;
            character.SetActive(false);
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
}
