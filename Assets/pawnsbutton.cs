using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pawnsbutton : MonoBehaviour
{
    public bool active=false;
    static pawnsbutton last;
    public GameObject pref;
    SpriteRenderer sp;
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (last != null) 
        {
            last.active = false;
            last.sp.color = Color.white;
        }
        active = true;
        sp.color = Color.red;
        last = this;


        
    }
}

