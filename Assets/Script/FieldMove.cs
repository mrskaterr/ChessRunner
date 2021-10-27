using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMove : MonoBehaviour
{
    Transform Fields;
    int HowMany;
    void Start()
    {
        HowMany=transform.childCount;
    }
    void Update()
    {
        for(int i=0;i<transform.childCount;i++){
            Fields=gameObject.transform.GetChild(i);
            Fields.position=new Vector3(Fields.position.x,Fields.position.y-0.002f,Fields.position.z);
            if(Fields.position.y<=-2){
                GetComponent<ChessBoardArray>().UpdateArray();
                for(int j=0;j<Fields.childCount;j++){
                    if(Fields.GetChild(j).childCount==1){
                        Destroy(Fields.GetChild(j).GetChild(0).gameObject);
                    }
                }
                Fields.position=new Vector3(Fields.position.x,16f,Fields.position.z);
                GetComponent<SpawnEnemy>().Spawn(Fields);
                ++HowMany;
                Fields.name=HowMany.ToString();
            }

        }
    }
}
