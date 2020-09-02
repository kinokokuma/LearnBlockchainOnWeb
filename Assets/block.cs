using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class block : MonoBehaviour
{
    public GameObject inputtext;
    public InputField field;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
          
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
           
        
                if (hit.collider.gameObject == this.gameObject)
                {
                    inputtext.SetActive(true);
                field.ActivateInputField();
                Debug.Log("2");
                }
                else
                {
                    inputtext.SetActive(false);
               
                    Debug.Log("3");
                }
            
            
        }
        
    }
}
