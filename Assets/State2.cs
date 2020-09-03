using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Security.Cryptography;
using System.Text;


public class State2 : MonoBehaviour
{
    int[] data = { 254, 43, 21 };
    string hashencode;
    public state2Contorl contorl;
    public blocktext inputField;
    public Text hashtxt, noncetxt;
    public int index = 0;
    
    public int hash = 14, nonce = 0, oldhash = 14;
    public string blocktext;
    Text showText;
    void Start()
    {
      

        showText = GetComponent<Text>();
        noncetxt.text = data[index].ToString();
        hashencode = getHashSha256(hash.ToString());
        hashtxt.text = hashencode.Substring(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("index    " + index);
        password();
        point();
    }

    public void chtxt(string x)
    {
        blocktext = x;

       
        showText.text = blocktext;

    }
    void password()
    {
            hash = data[index] + int.Parse(blocktext);
        noncetxt.text = data[index].ToString();
         hashencode = getHashSha256(hash.ToString());
        hashtxt.text = hashencode.Substring(0, 4);
        
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
    void point()
    {
       if(hashencode.Substring(0, 1) == "1")
        {
            if (!contorl.character.active&& contorl.count<=7)
                contorl.count++;
            if (contorl.count==4|| contorl.count == 8)
            {
                contorl.character.SetActive(true);
            }
            else
            {
                index++;
                if(index>2)
                {
                    index = 2;
                }
            }
           

        }
    }
}
