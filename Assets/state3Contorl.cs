using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class state3Contorl : MonoBehaviour
{
    public block[] block;
        public getText[] data,nonce;
    string[] text = { "ครั้งนี้ผมจะยังไม่เฉลยแล้วกันแต่จะให้คุณลองเปลี่ยนข้อมูลใน Block ตรงกลาง", "ให้ทำการคลิ๊กที่ Block แล้วกรอกตัวเลขได้เลย"
            ,"เพื่อให้ง่ายผมจะช่วยคำนวน Hash ให้แล้วกัน", "อย่าลิมสังเกตความเปลี่ยนแปลงหลังกรอกตัวเลขด้วยนะ"
            , "เห็นมั้ยว่าพอ Hash ของ Block ที่ 2 เปลี่ยน ก็ทำให้ hash ของ Blockถัดมาเปลี่ยนด้วย", "เพราะว่าการคำนวน hash จะนำ Hash ของ Block ก่อนหน้ามาคำนวนด้วย"
            , "เราถึงเรียกว่า Blockchain ยังไงละ", "ถ้ายังไม่เข้าใจก็ลองเปลี่ยนข้อมูลอีก 3 รอบดูแล้วกัน"
            , "เก่งมาก ทีนี้ก็เข้าใจแล้วสินะว่าทำไมเราถึงเรียกว่า Blockchain", "ต่อไปจะเป็นบทเรียนสุดท้ายแล้ว ผมจะแสดงให้เห็นว่า ทำไม Blockchain ถึงปลอดภัยกว่าการเก็บข้อมูลแบบเก่า","" };
    string[] missionText = { "กรอกข้อมูลใน Block ที่ 2 และสังเกตุความเปลี่ยนแปลง", "ลองกรอกข้อมูลอีก 3 ครั้ง" };
    public GameObject character;
    public Text readText, header;
    public int count = 0;
    public GameObject input, button;
    public bool click = false;
    public int countInput = 0;
    public string oldData = "0";
    public getText blockData;
    public AudioClip[] voice;
    private AudioSource voiceSource;
    public GameObject nextButton;
    public GameObject[] objAnimation;
    void Start()
    {
        header.text = "";
        block[0].enabled = false;
        block[2].enabled = false;
        data[0].blocktext = "23";
        data[1].blocktext = "0";
        data[2].blocktext = "43";
        
        readText.text = text[count];
        oldData = blockData.blocktext;
        voiceSource = GetComponent<AudioSource>();
        StartCoroutine(resetClick());
    }

    // Update is called once per frame
    void Update()
    {
        nextButton.SetActive(!click);
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
        if (count == 4)
        {
            header.text = missionText[0];
            character.SetActive(false);
        }

        if (count == 8)
        {
            header.text = missionText[1];
            character.SetActive(false);
        }
        if (count == 10)
        {
            SceneManager.LoadScene(4);
        }
        if (countInput == 1 && count == 4)
        {
            character.SetActive(true);

        }
        if (countInput == 4 && count == 8)
        {
            character.SetActive(true);
        }
        if (oldData != blockData.blocktext)
        {
            countInput++;
            oldData = blockData.blocktext;
        }
        if (voiceSource.clip != voice[count] && voice.Length > count && character.active)
        {
            voiceSource.clip = voice[count];
            voiceSource.Play();
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

        if (count == 0 && character.active)
        {
            objAnimation[0].active = true;
        }
        else
        {
            objAnimation[0].active = false;
        }

        if (count == 4 && character.active)
        {
            objAnimation[1].active = true;
        }
        else
        {
            objAnimation[1].active = false;
        }

        if (count == 5 && character.active)
        {
            objAnimation[2].active = true;
        }
        else
        {
            objAnimation[2].active = false;
        }

    }
}
