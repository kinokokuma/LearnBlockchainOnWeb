using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.active)
        anim.SetBool("active", gameObject.active);
    }
}
