using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FieldMove : MonoBehaviour
{
    Transform Row;
    Transform LastRow;
    const float StartSpeed=0.001f;
    int HowManyRowsStart;
    int HowManyRows;
    [SerializeField] GameObject Abcdefgh;
    [SerializeField] GameObject ScoreTxt;
    [SerializeField] GameObject RecordTxt;
    int RecordInt;
    public float Speed;
    void Start()
    {
        LastRow=transform.GetChild(transform.childCount-1);
        HowManyRowsStart=transform.childCount;
        HowManyRows=HowManyRowsStart;
        if(ScoreTxt.active)
        {
            ScoreTxt.GetComponent<Text>().text = (HowManyRows - HowManyRowsStart).ToString();
            RecordInt = PlayerPrefs.GetInt("Record" + PlayerPrefs.GetInt("Player"));
            RecordTxt.GetComponent<Text>().text = RecordInt.ToString();
        }
    }
    void FixedUpdate()
    {
        if(Abcdefgh.activeSelf)//ABCDEFGH Move
        {
            if(Abcdefgh.transform.position.y<=-2)
                Abcdefgh.SetActive(false);
            else
                Abcdefgh.transform.position-=new Vector3(0,StartSpeed*Speed,0);
        }

        for(int i=0;i<transform.childCount;i++)//Chessboard Move
        {
            Row=transform.GetChild(i);
            Row.position-=new Vector3(0,StartSpeed*Speed,0);
            if(Row.position.y<=-1)
            {
                GetComponent<ChessBoardArray>().UpdateArray();
                for(int j=0;j<Row.childCount;j++)//Delete chessman or kill player
                {
                    if(Row.GetChild(j).childCount==1)
                    {
                        if(Row.GetChild(j).GetChild(0).gameObject.GetComponent<Player>())
                            SceneManager.LoadScene("Game");

                        Destroy(Row.GetChild(j).GetChild(0).gameObject);
                    }
                }

                Row.position=new Vector3(Row.position.x,LastRow.position.y+1f,Row.position.z);//ChessBoard Speed Fixed
                LastRow=Row;//ChessBoard Speed Fixed

                GetComponent<SpawnEnemy>().Spawn(Row);
                ++HowManyRows;

                if(HowManyRows%10==0)//Faster
                    ++Speed;

                if(((HowManyRows-HowManyRowsStart-1)%16==0))//ChessBoard Speed Fixed
                    Row.position-=new Vector3(0,StartSpeed*Speed,0);

                Row.name=HowManyRows.ToString();
                ScoreTxt.GetComponent<Text>().text=(HowManyRows-HowManyRowsStart).ToString();
                if(HowManyRows - HowManyRowsStart> RecordInt)
                {
                    RecordInt = HowManyRows - HowManyRowsStart;
                    RecordTxt.GetComponent<Text>().text = RecordInt.ToString();
                    PlayerPrefs.SetInt("Record" + PlayerPrefs.GetInt("Player"), RecordInt);
                }
                
            }

        }
    }
}