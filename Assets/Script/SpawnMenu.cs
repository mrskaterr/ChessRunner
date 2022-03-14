using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenu : MonoBehaviour
{
    
    Transform Fields;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            Fields=gameObject.transform.GetChild(i);
            GetComponent<SpawnEnemy>().Spawn(Fields);
        }
    }
}
