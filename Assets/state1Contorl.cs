using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class state1Contorl : MonoBehaviour
{
    // Start is called before the first frame update
    string[] text = { "สวัสดีครับ ผมชื่อแซม ", "วันนี้ผมจะมาแนะนำให้คุณรู้จักวิธีการเก็บข้อมูลแบบ blockchain", "ในขั้นแรกผมจะให้คุณลองใส่ข้อมูลลงในblock โดยกรอกตัวเลขอะไรก็ได้ลงในกล่องข้อความแล้วกด enter","นั่นไง! ข้อมูลที่คุณใส่ถูกบันทึกลงไปแล้ว และจะถูกเข้ารหัสเรียกว่า hash","ลองใส่ข้อมูลอีก 3 ครั้ง แล้วสังเกตการเปลี่ยนแปลงสิ", "step3", "step3.1" };
    public GameObject character;
    public Text readText;
    public int countInput = 0;
    public string olddata;
    public getText block;
    public GameObject input, button;
    public int count=0;
    public bool click = false;
    void Start()
    {
        readText.text = text[count];
    }

    // Update is called once per frame
    void Update()
    {
        countInput = GameObject.FindGameObjectsWithTag("blockS1").Length;
        if (Input.GetMouseButtonDown(0) && !click)
        {

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


            if (hit.collider.gameObject.tag =="Player")
            {
                count++;
                readText.text = text[count];
                StartCoroutine(resetClick());
            }
            


        }
        
        if(count==3)
        {
            character.SetActive(false);
        }
        
        if (count == 5)
        {
            character.SetActive(false);
        }
        if (count == 6)
        {
            SceneManager.LoadScene(1);
        }

        if (countInput==1&&count==3)
        {
            character.SetActive(true);
            
        }
        if (countInput == 4 && count == 5)
        {
            character.SetActive(true);
        }
        if (olddata != block.blocktext)
        {
            countInput++;
            olddata = block.blocktext;
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
