using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public pawnsbutton [] pb;
    // Start is called before the first frame update
    private string save;
    public GameObject last()
    {
        foreach (var pb in pb)
        {
            if (pb.active)return pb.pref;
            
        }
        return null;
    }
}
