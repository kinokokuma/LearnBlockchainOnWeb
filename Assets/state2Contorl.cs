using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class state2Contorl : MonoBehaviour
{
    // Start is called before the first frame update
    string[] text = { "หลังจากที่เราได้ลองบันทึกข้อมูลแล้ว ต่อมาผมจะแนะนำให้รู้จักกับ Nonce", "Nonce คือ number used once ในการเข้ารหัส hash เราจะต้องนำ data และ Nonce ที่อยู่ใน Block มาคำนวณ ด้วย ","โดย hash จะถูกยอมรับก็ต่อเมื่อรูปแบบของรหัสเป็นไปตามข้อตกลง" 
            , "ถ้าอย่างนั้นเรามาตกลงกันก่อนดีกว่า เพื่อให้ง่ายต่อการเรียนรู้เราจะกำหนดว่าเงื่อนไขคือ ตัวแรกของ hash จะต้องเป็นเลข 1 เท่านั้น", "แต่จะทำยังไงให้ตรงเงื่อนไขละในเมื่อข้อมูล คือ สิ่งที่ต้องบันทึก โดยไม่ไปปรับเปลี่ยน"
            , "เราก็จะไปแก้ที่ Nonce นั่นเอง โดย Nonce ไม่มีวิธีคิด ต้องลองสุ่มดูเท่านั้น แต่ในการฝึกผมใบ้ให้แล้วกันว่า Nonce อยู่ระหว่าง 1-10", " งั้นเรามาลองดูกันเลย", "เก่งมากเลยหาเจอจนได้" ,"","ในการเก็บข้อมูลใน blockchain นั้น ใน 1 block อาจจะไม่ได้มีแค่ data ของเราคุณรู้จัก Bitcoin มั้ย? "
            ,"โดยเราสามารถจ่ายเงินเพื่อให้คนอื่นสุ่มหา nonce ให้ ","ซึ่งเราเรียกคนที่มาสุ่มหา nonce ว่านักขุด cryptocurrency","ถ้าอย่างนั้นลองสุ่ม Nonce ให้ถูกอีก 2 รอบละกัน","ในความเป็นจริงมันไม่ง่ายแบบนี้หรอกนะ","",""
            ,"ตอนนี้ก็พอเข้าใจการทำงานของ block แต่ละ block แล้วใช่มั้ย","แล้วสงสัยมั้ยว่า chain ของ block chain คืออะไร?","เรามาดูกันดีกว่า",""};
    // moc data : ในการจะเก็บข้อมูลใน blockchain นั้น ใน 1 block อาจจะไม่ได้มีแค่ data ของเรา , โดยเราสามารถจ่ายเงินเพื่อให้คนอื่นสุ่มหา nonce ให้, ซึ่งเราเรียกคนที่มาสุ่มหา nonce ว่านักขุด cryptocurrency
    string[] missionText = { "ลองใส่ Nonce ที่ทำให้ Hash ตัวแรกเป็นเลข 1 (Nonce อยู่ระหว่าง 1-10)", "ลองสุ่ม Nonce อีก 2 ครั้ง" };
    public GameObject character;
    public Text readText, header;
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
    public AudioClip[] voice;
    public AudioClip error;
    private AudioSource voiceSource;
    public GameObject[] objAnimation;
    public GameObject nextButton;
    public string oldHash;
    public string hash;
    public int oldIndex=0;
    void Start()
    {
        header.text = "";
        readText.text = text[count];
        for(int i=0;i<3; i++)
        {
            block[i].data = data[i];
        }
        blockstate2[1].SetActive(false);
        blockstate2[2].SetActive(false);
        Debug.Log(text.Length);
        voiceSource = GetComponent<AudioSource>();
        StartCoroutine(resetClick());
        addBlock();
        oldIndex = index;
    }

    // Update is called once per frame
    void Update()
    {
        nextButton.SetActive(!click);
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

        if (count == 7)
        {
            header.text = missionText[0];
            character.SetActive(false);
            blockstate2[index].SetActive(true);
            inputBox.GetComponent<inputtext>().get = block[index];
        }

        if (count == 13)
        {
            header.text = missionText[1];
            character.SetActive(false);
            blockstate2[index].SetActive(true);
            inputBox.GetComponent<inputtext>().get = block[index];
        }
        if (count == 19)
        {
            SceneManager.LoadScene(3);
        }

        if (voiceSource.clip != voice[count] && voice.Length > count && character.active)
        {
            voiceSource.clip = voice[count];
            voiceSource.Play();
        }
        input.SetActive(!character.active);
        button.SetActive(!character.active);
        playObjAnimation();
    }
    IEnumerator resetClick()
    {
        click = true;
        yield return new WaitForSeconds(voice[count].length);
        click = false;
    }
    public void addBlock()
    {
     
        hash = block[index].hashencode;
            if (block[index].hashencode.Substring(0, 1) == "1")
            {

                if (!character.active && count <= 14)
                {
                    count++;
                }
                if (count == 8 || count == 15)
                {
                Debug.Log("7");
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
            oldHash = hash;

        }
        else if(oldHash != hash && oldIndex == index)
        {
            oldHash = hash;
            voiceSource.clip = error;
            voiceSource.Play();
        }
        else if (oldHash != hash && oldIndex != index)
        {
           oldIndex = index;
            oldHash = hash;
        }
        
    }

    void playObjAnimation()
    {
        
        if ((count == 2|| count == 3) && character.active)
        {
            objAnimation[0].active = true;
        }
        else
        {
            objAnimation[0].active = false;
        }
        if (count == 5 && character.active)
        {
            objAnimation[1].active = true;
        }
        else
        {
            objAnimation[1].active = false;
        }
    }
}

   

