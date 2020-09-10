using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class state2Contorl : MonoBehaviour
{
    // Start is called before the first frame update
    string[] text = { "หลังจากที่เราได้ลองบันทึกข้อมูลแล้ว ต่อมาผมจะแนะนำให้รู้จักกับ Nonce", "Nonce คือ number use once ในการเข้ารหัส hash จะถูกยอมรับก็ต่อเมื่อ รูปแบบของรหัสเป็นำปตามข้อตกลง "
            , "ถ้าอย่างนั้นเรามาตกลงกันก่อนดีกว่า เพื่อให้ง่ายต่อการเรียนรู้เราจะกำหนดว่าเงื่อนไขคือ ตัวแรกของ hash จะต้องเป็นเลข 1 เท่านั้น", "แต่จะทำยังไงให้ตรงเงือนไขละในเมื่อเราไม่อยากแก้ไขข้อมูล"
            , "เราก็จะไปแก้ที่ Nonce นั่นเอง โดย Nonce ไม่มีวิธีคิด ต้องลองสุ่มดูเท่านั้น แต่ในการฝึกผมใบให้แล้วกันว่า Nonce ไม่เกิน 10", " งั้นเรามาลองดูกันเลย", "เก่งมากเลยหาเจอจนได้" ,"","คุณรู้จัก Bitcoin มั้ย? "
            ,"ในการขุด Bitcoin นั้น ก็เป็นการให้คอมพิวเตอร์ สุ่มหา Nonce แบบนี้เมือนกัน ","ซึ่งถ้าสุ่มถูกก็จะได้ Bitcoin เป็นรางวัล","ถ้าอย่างนั้นลองสุ่ม Nonce ให้ถูกอีก 2 รอบละกัน","ในความเป็นจริงมันไม่ง่ายแบบนี้หรอกนะ","",""
            ,"ตอนนี้ก็พอเข้าใจการทำงานของ block แต่ละ block แล้วใช่มั้ย","แล้วสงสัยมั้ยว่า chain ของ block chain คืออะไร?","เรามาดูกันดีกว่า"};
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
        Debug.Log(text.Length);
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

        if (count == 6)
        {
            character.SetActive(false);
            blockstate2[index].SetActive(true);
            inputBox.GetComponent<inputtext>().get = block[index];
        }

        if (count == 12)
        {
            
            character.SetActive(false);
            blockstate2[index].SetActive(true);
            inputBox.GetComponent<inputtext>().get = block[index];
        }
        if (count == 18)
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

            if (!character.active && count <= 13)
            {
                count++;
            }
                if (count == 7 || count == 14)
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

   

