using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Security.Cryptography;
using System.Text;


public class State2 : MonoBehaviour
{

    public string hashencode;
    public state2Contorl contorl;
    public blocktext inputField;
    public Text hashtxt, datatxt;
    public int index = 0;
    public int data;
    public int hash = 14, nonce = 0, oldhash = 14;
    public string blocktext;
    
    Text showText;
    void Start()
    {
        

          showText = GetComponent<Text>();
        
        hashencode = getHashSha256(hash.ToString());
        hashtxt.text = hashencode.Substring(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(data);
        if(data!=0)
        {
            datatxt.text = data.ToString();
        }
        Debug.Log("index    " + index);
        password();
    
    }

    public void chtxt(string x)
    {
        if (x != "" && x != null)
        {
            blocktext = x;


            showText.text = blocktext;
        }
    }
    void password()
    {
        if (blocktext != "" && blocktext != null)
        {
           
            hash = data + int.Parse(blocktext);
            datatxt.text = data.ToString();
            hashencode = getHashSha256(hash.ToString());
            hashtxt.text = hashencode.Substring(0, 4);
        }
        
    }
    public string getHashSha256(string text)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(text);
        SHA256Managed hashstring = new SHA256Managed();
        byte[] hash = hashstring.ComputeHash(bytes);
        string hashString = string.Empty;
        foreach (byte x in hash)
        {
            hashString += String.Format("{0:x2}", x);
        }

        return hashString;
    }
   
   
}
