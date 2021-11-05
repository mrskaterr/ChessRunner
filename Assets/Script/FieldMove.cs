using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMove : MonoBehaviour
{
    Transform Fields;
    public GameObject Abcdefgh;
    int HowMany;
    public int Speed;
    void Start()
    {
        HowMany=transform.childCount;
    }
    void Update()
    {
        if(Abcdefgh){
            if(transform.position.y<=-2){
                Destroy(Abcdefgh);
            }
            else
            {
                Abcdefgh.transform.position=new Vector3(Abcdefgh.transform.position.x,
                                                        Abcdefgh.transform.position.y-0.001f*Speed,
                                                        Abcdefgh.transform.position.z);
            }
        }
        for(int i=0;i<transform.childCount;i++){
            Fields=gameObject.transform.GetChild(i);
            Fields.position=new Vector3(Fields.position.x,Fields.position.y-0.001f*Speed,Fields.position.z);
            if(Fields.position.y<=-1){
                GetComponent<ChessBoardArray>().UpdateArray();
                for(int j=0;j<Fields.childCount;j++){
                    if(Fields.GetChild(j).childCount==1){
                        Destroy(Fields.GetChild(j).GetChild(0).gameObject);
                    }
                }
                Fields.position=new Vector3(Fields.position.x,transform.childCount-1,Fields.position.z);
                GetComponent<SpawnEnemy>().Spawn(Fields);
                ++HowMany;
                Fields.name=HowMany.ToString();
            }

        }
    }
}
