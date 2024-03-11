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
    public pawnsbutton Last()
    {
        if (last != null) { return last; }
        return null;
    }
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (active == true)
        {
            active = false;
            sp.color = Color.white;
            last = null; 
            return;
        }
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

