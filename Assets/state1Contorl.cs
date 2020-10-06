using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class state1Contorl : MonoBehaviour
{
    // Start is called before the first frame update
    string[] text = { "สวัสดีครับ ผมชื่อแซม ", "วันนี้ผมจะมาแนะนำให้คุณรู้จักวิธีการเก็บข้อมูลแบบ Blockchain"
            , "ในขั้นแรกผมจะให้คุณลองใส่ข้อมูลลงในblock โดยกรอกตัวเลขอะไรก็ได้ลงในกล่องข้อความแล้วกด enter"
            ,"นั่นไง! ข้อมูลที่คุณใส่ถูกบันทึกลงไปแล้ว และจะถูกเข้ารหัสเรียกว่า hash","โดยทุกครั้งที่เราบันทึกข้อมูล ข้อมูลและการเข้ารหัสจะถูกเก็บไว้รวมกันเรียกว่า 1 Block","ลองใส่ข้อมูลอีก 3 ครั้ง แล้วสังเกตการเปลี่ยนแปลงสิ"
            , "ดูซิ ข้อมูลที่ใส่แต่ละครั้งไม่เหมือนกันพอเข้ารหัสแล้วก็ไม่เหมือนกัน","แต่การเข้ารหัสจริงๆแล้วยังมีส่วนอื่นๆอีกไปดูกันเลย", "" };
    string[] missionText = { "ลองกรอกข้อมูลดูสิ!(กรอกเป็นตัวเลข)", "ลองกรอกข้อมูลอีก 3 ครั้ง" };
    public GameObject character;
    public Text readText, header;
    public int countInput = 0;
    public string olddata;
    public getText block;
    public GameObject input, button;
    public int count=0;
    public bool click = false;
    public AudioClip[] voice;
    private AudioSource voiceSource;
    public GameObject[] objAnimation;
    public GameObject nextButton;

    void Start()
    {
        header.text = "";
        readText.text = text[count];
        voiceSource = GetComponent<AudioSource>();
        StartCoroutine(resetClick());
    }

    // Update is called once per frame
    void Update()
    {
        nextButton.SetActive(!click);
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
            header.text = missionText[0];
            character.SetActive(false);
        }
        
        if (count == 6)
        {
            header.text = missionText[1];
            character.SetActive(false);
        }
        if (count == 8)
        {
            SceneManager.LoadScene(1);
        }

        if (countInput==1&&count==3)
        {
            character.SetActive(true);
            
        }
        if (countInput == 4 && count == 6)
        {
            character.SetActive(true);
        }
        if (olddata != block.blocktext)
        {
            countInput++;
            olddata = block.blocktext;
        }
        playObjAnimation();
        if (voiceSource.clip!=voice[count]&&voice.Length>count&&character.active)
        {
            voiceSource.clip = voice[count];
            voiceSource.Play();
        }

        input.SetActive(!character.active);
        button.SetActive(!character.active);
        
    }
    IEnumerator resetClick()
    {
        click = true;
        yield return new WaitForSeconds(voice[count].length);
        click = false;
    }

    void playObjAnimation()
    {
        if (count == 3&&character.active)
        {
            objAnimation[1].active = true;
        }
        else
        {
            objAnimation[1].active = false;
        }
        if (count == 4 && character.active)
        {
            objAnimation[0].active = true;
        }
        else
        {
            objAnimation[0].active = false;
        }
    }
}
