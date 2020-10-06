using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class State4Contorl : MonoBehaviour
{
    public block[] block1, block2, block3;
    public Sprite[] blockColor;
    public GameObject[] blockOutline1, blockOutline2, blockOutline3;
    public getText[] data1, data2, data3;
      string[] text = { "เรามาดูกันดีกว่าว่าในอดีตเราเก็บข้อมูลกันอย่างไร", "ยกตัวอย่างธนาคาร การที่เราฝากเงินในธนาคารนั้น ธนาคารจะทำการจดบันทึกข้อมูลไว้เพี่ยงผู้เดียว"
            , "ซึ่ง ถ้าธนาคารจดผิด หรือแอบเปลี่ยนข้อมูลเราก็ไม่สามารถโต้แย้งได้เพราะเราไม่ใช่คนจดข้อมูล", "แต่ Blockchain นั้นทุกคนเวลามีคนจะบันทึกข้อมูล ต้องบอกให้ทุกคนรู้"
            , "แล้วทุกคนจะทำการจดข้อมูลของตนเอง และทำการตรวจสอบซึ่งกันและกัน", "ถ้าไม่เชื่อก็ลองไปแก้ข้อมูลในตารางแรกดูสิ" , "เห็นไหมว่าระบบไม่ยอมรับ จริงๆมันก็สามารถแก้ได้นะ แต่เราต้องทำให้ข้อมูลส่วนใหญ่เหมือนกับเรา"
            , "ลองแก้ข้อมูลในตารางที่ 2 ดูสิ", "จากที่ลองมารู้สึกมั้ยว่าการแก้ข้อมูลใน Blockchain นั้นยุ่งยาก", "ในความเป็นจริง Blockchain ที่เป็น public นั้น มีหลายล้านคนที่คอยจดข้อมูลอยู่"
            , "ดังนั้นเราจึงไม่สามารถแก้ข้อมูลครึ่งนึงของระบบให้เหมือนกับเราได้","Blockchain ถึงปลอดภัยยังไงหละ","ซึ่งเราสามารถตรวจสอบข้อมูลว่าตรงกันหรือไม่ง่ายๆด้วยการ ดู Hash ตัวสุดท้ายว่าตรงกันหรือไม่"
            ,"โดยไม่จำเป็นต้องตรวจสอบข้อมูลทุกตัว","จบแล้ว Blockchain เบื่องต้น ขอบคุณที่มาเล่นด้วยกันนะ","" };
    string[] missionText = { "เปลี่ยนข้อมูล Block ที่ 2 ของตารางแรก","แก้ข้อมูลตารางที่ 2 ให้เหมือนตารางแรก"};
    public GameObject character;
    public Text readText,header;
    public int count = 0;
   
    public bool click = false;
    public int[] countInput = { 0,0,0};
    public string[] oldData = {"","","" };
    public getText[] blockData;
    public AudioClip[] voice;
    private AudioSource voiceSource;
    public GameObject nextButton;
    public GameObject[] objAnimation;
    void Start()
    {
        header.text = "";
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
        voiceSource = GetComponent<AudioSource>();
        StartCoroutine(resetClick());

        for(int i=0; i<blockOutline1.Length;i++)
        {
            blockOutline1[i].GetComponent<SpriteRenderer>().sprite = blockColor[0];
            blockOutline2[i].GetComponent<SpriteRenderer>().sprite = blockColor[0];
            blockOutline3[i].GetComponent<SpriteRenderer>().sprite = blockColor[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        nextButton.SetActive(!click);
        if (count == 15)
        {
            SceneManager.LoadScene(4);
        }
        if (count<4)
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
        if (count == 6)
        {
            header.text = missionText[0];
            character.SetActive(false);
        }

        if (count == 8)
        {
            header.text = missionText[1];
            character.SetActive(false);
            block2[1].enabled = true;
        }
        
        if (countInput[0] == 1 && count == 6)
        {
            for (int i = 0; i < blockOutline1.Length; i++)
            {
                blockOutline1[i].GetComponent<SpriteRenderer>().sprite = blockColor[1];
               
            }
            
            character.SetActive(true);

        }
        if (data2[1].blocktext== data1[1].blocktext && count ==8)
        {
            for (int i = 0; i < blockOutline1.Length; i++)
            {
                blockOutline1[i].GetComponent<SpriteRenderer>().sprite = blockColor[0];
                blockOutline2[i].GetComponent<SpriteRenderer>().sprite = blockColor[0];
                blockOutline3[i].GetComponent<SpriteRenderer>().sprite = blockColor[1];
            }

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
        if (voiceSource.clip != voice[count] && voice.Length > count && character.active)
        {
            voiceSource.clip = voice[count];
            voiceSource.Play();
        }

        if(data2[1].blocktext != data1[1].blocktext && data2[1].blocktext != data3[1].blocktext)
        {
            for (int i = 0; i < blockOutline1.Length; i++)
            {
               
                blockOutline2[i].GetComponent<SpriteRenderer>().sprite = blockColor[1];
              
            }
        }
        else if (data2[1].blocktext != data3[1].blocktext)
        {
            for (int i = 0; i < blockOutline1.Length; i++)
            {

                blockOutline2[i].GetComponent<SpriteRenderer>().sprite = blockColor[0];

            }
        }
        playObjAnimation();
    }
    IEnumerator resetClick()
    {
        click = true;
        yield return new WaitForSeconds(voice[count].length);
        click = false;
    }


    void playObjAnimation()
    {

        if ((count == 1|| count == 2) && character.active)
        {
            objAnimation[0].active = true;
        }
        else
        {
            objAnimation[0].active = false;
        }
        if ((count == 3 || count == 4) && character.active)
        {
            objAnimation[1].active = true;
        }
        else
        {
            objAnimation[1].active = false;
        }

        if (count == 12  && character.active)
        {
            objAnimation[2].active = true;
        }
        else
        {
            objAnimation[1].active = false;
        }
    }

}
