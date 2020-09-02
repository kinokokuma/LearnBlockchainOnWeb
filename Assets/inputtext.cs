using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputtext : MonoBehaviour
{

    // Start is called before the first frame update
    public State2 get;
    public bool active = false;
    
    public InputField inputBox;
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
            returnText();

            Debug.Log("xxxxxxx");
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
