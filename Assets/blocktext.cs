using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class blocktext : MonoBehaviour
{
    // Start is called before the first frame update
    public getText get;
    public bool active =false;
    public InputField inputBox;
    public button button;
  
    // Start is called before the first frame update
    void Start()
    {
        //inputBox = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (button == null)
            {
                returnText();
            }
            else
            {
                button.addData();
               
            }

           
        }
    }

    public void returnText()
    {
        string txt = inputBox.text;
        if (txt != "")
        {

            get.chtxt(txt);
            inputBox.text = "";


            gameObject.SetActive(active);
        }
    }
}
