using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FieldMove : MonoBehaviour
{
    Transform Fields;
    private const float StartSpeed=0.001f;
    private int StartHowMany;
    public GameObject Abcdefgh;
    public GameObject ScoreTxt;
    private Transform Last;
    int HowMany;
    public float Speed;
    void Start()
    {
        Last=transform.GetChild(transform.childCount-1);
        StartHowMany=transform.childCount;
        HowMany=StartHowMany;
        ScoreTxt.GetComponent<Text>().text=(HowMany-StartHowMany).ToString();
    }
    void FixedUpdate()
    {
        //StartCoroutine(Wait(1));
        if(Abcdefgh.activeSelf){
            if(Abcdefgh.transform.position.y<=-2)
            {
                Abcdefgh.gameObject.SetActive(false);
            }
            else
            {
                Abcdefgh.transform.position=new Vector3(Abcdefgh.transform.position.x,
                                                        Abcdefgh.transform.position.y-StartSpeed*Speed,
                                                        Abcdefgh.transform.position.z);
            }
        }
        for(int i=0;i<transform.childCount;i++){
            Fields=gameObject.transform.GetChild(i);
            Fields.position=new Vector3(Fields.position.x,Fields.position.y-StartSpeed*Speed,Fields.position.z);
            if(Fields.position.y<=-1){
                GetComponent<ChessBoardArray>().UpdateArray();
                for(int j=0;j<Fields.childCount;j++){
                    if(Fields.GetChild(j).childCount==1)//if chessman on field 
                    {
                        if(Fields.GetChild(j).GetChild(0).gameObject.GetComponent<PlayerKnight>())
                            SceneManager.LoadScene("Game");

                        Destroy(Fields.GetChild(j).GetChild(0).gameObject);
                    }
                }
                Fields.position=new Vector3(Fields.position.x,Last.position.y+1f,Fields.position.z); 

                Last=Fields;
                GetComponent<SpawnEnemy>().Spawn(Fields);
                ++HowMany;
                if(HowMany%10==0)
                {
                    ++Speed;
                }
                if(((HowMany-StartHowMany-1)%16==0) || HowMany-StartHowMany-1==0)
                {
                    Fields.position-=new Vector3(0,StartSpeed*Speed,0);
                }
                Fields.name=HowMany.ToString();
                ScoreTxt.GetComponent<Text>().text=(HowMany-StartHowMany).ToString();
            }
            //Fields.position=new Vector3(Fields.position.x,Fields.position.y-StartSpeed*Speed,Fields.position.z);
        }
    }
    IEnumerator Wait(float second)
    {
        yield return new WaitForSecondsRealtime(1f);
        ////
        
    }
}