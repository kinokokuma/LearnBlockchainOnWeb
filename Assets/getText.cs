using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Security.Cryptography;
using System.Text;

public class getText : MonoBehaviour
{
    public bool inputnonce = false;
    public blocktext inputField;
    public Text hashtxt, noncetxt, oldhashtxt;
    public int blockIndex=0;
    public string blockName = "blockdata";
    public getText oldBlock;
    public int nonce = 0, oldhash = 14;

    public string hash = "0";
    public string blocktext ;
    public Text showText;
    void Start()
    {
        if (blockIndex != 0)
        {
            oldBlock = GameObject.Find(blockName + (blockIndex-1) + "/blockData/data").GetComponent<getText>();
        }
       
        showText =GetComponent<Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        password();
    }
    
    public void chtxt(string x)
    {
        blocktext=x;

        Debug.Log("blocktext    "+ blocktext);
        Debug.Log(oldBlock);
        showText.text = blocktext;
        
    }
    void password()
    {
        showText.text = blocktext;
        if (blocktext != "" && blocktext != null)
        {
            int num = 0;
            if (blockIndex != 0)
            {
                Debug.Log("oldBlock.hash :" + oldBlock.hash);
                if (!inputnonce)
                {
                    int testNonce = 1;
                    while (getHashSha256((int.Parse(oldBlock.hash, System.Globalization.NumberStyles.HexNumber) + int.Parse(blocktext)+testNonce).ToString()).Substring(0, 1) != "1")
                    {
                        testNonce++;
                    }
                    nonce = testNonce;
                    noncetxt.text = nonce.ToString();
                }
                else
                {
                    //noncetxt.text =
                }

                num = int.Parse(oldBlock.hash, System.Globalization.NumberStyles.HexNumber) + int.Parse(blocktext) + nonce;
                Debug.Log("hash :" + num.ToString());
                Debug.Log("00000");
            }
            else
            {
                if (!inputnonce)
                { int testNonce=1;
                    while(getHashSha256((oldhash + int.Parse(blocktext) + testNonce).ToString()).Substring(0,1)!="1")
                    {
                        testNonce+=1;
                    }
                    nonce = testNonce;
                    noncetxt.text = nonce.ToString();
                }
                
                num = oldhash + int.Parse(blocktext) + nonce;

            }


            string hashencode = getHashSha256(num.ToString());
            hash = hashencode.Substring(0, 4);
            hashtxt.text = hash;
            if (oldhashtxt != null)
            {
                oldhashtxt.text = oldBlock.hash;
            }
        }
    }
    public  string getHashSha256(string text)
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
