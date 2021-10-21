using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMove : MonoBehaviour
{
    Transform Field;
    int Count;
    int HowMany;
    void Start()
    {
        Count=gameObject.transform.childCount;
        HowMany=Count;
    }
    void Update()
    {
        for(int i=0;i<Count;i++){
            Field=gameObject.transform.GetChild(i).gameObject.transform;
            Field.position=new Vector3(Field.position.x,Field.position.y-0.001f,Field.position.z);
            if(Field.position.y<=-2){
                Field.position=new Vector3(Field.position.x,18f,Field.position.z);
                ++HowMany;
                Field.name=HowMany.ToString();
            }

        }
    }
}
