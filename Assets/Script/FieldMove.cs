using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FieldMove : MonoBehaviour
{
    bool save=false;
    Transform Row;
    Transform LastRow;
    const float StartSpeed=0.001f;
    //int HowManyRowsStart;
    int HowManyRows;
    [SerializeField] GameObject Abcdefgh;

    public float Speed;
    void Start()
    {
        if (gameObject.GetComponent<Save>())
            save = true;
        LastRow=transform.GetChild(transform.childCount-1);
        HowManyRows = transform.childCount;
        //HowManyRowsStart=transform.childCount;
        //HowManyRows=HowManyRowsStart;
    }
    void FixedUpdate()
    {
        if(Abcdefgh.activeSelf)//ABCDEFGH Move
        {
            if(Abcdefgh.transform.position.y<=-2)
                Abcdefgh.SetActive(false);
            else
                Abcdefgh.transform.position+=Vector3.down*StartSpeed* Speed;
        }

        for(int i=0;i<transform.childCount;i++)//Chessboard Move
        {
            Row=transform.GetChild(i);
            Row.position += Vector3.down * StartSpeed * Speed;
            if (Row.position.y<=-1)
            {
                GetComponent<ChessBoardArray>().UpdateArray();
                for(int j=0;j<Row.childCount;j++)//Delete chessman or kill player
                {
                    if(Row.GetChild(j).childCount==1)
                    {
                        if(Row.GetChild(j).GetChild(0).gameObject.GetComponent<Player>())
                            SceneManager.LoadScene("Game");

                        if (save)
                            gameObject.GetComponent<Save>().SAVE(Row.name+ Row.GetChild(j).name+ (int)Row.GetChild(j).GetChild(0).gameObject.GetComponent<Enum>().character+";");
                        Destroy(Row.GetChild(j).GetChild(0).gameObject);
                    }
                }

                Row.position=new Vector3(Row.position.x,LastRow.position.y+1f,Row.position.z);//ChessBoard Speed Fixed
                LastRow=Row;//ChessBoard Speed Fixed

                if(!save)GetComponent<SpawnEnemy>().Spawn(Row);
                ++HowManyRows;

                if(Row.GetComponent<Row>().distanceNumber%10==0)//Faster
                    ++Speed;

                if (((Row.GetComponent<Row>().distanceNumber - 1) % 16 == 0))//ChessBoard Speed Fixed
                    Row.position += Vector3.down*StartSpeed * Speed;

                //Row.name=HowManyRows.ToString();
                //if(ScoreTxt.active)
                //{
                //    ScoreTxt.GetComponent<Text>().text = (HowManyRows - HowManyRowsStart).ToString();
                //    if (HowManyRows - HowManyRowsStart > RecordInt)
                //    {
                //        RecordInt = HowManyRows - HowManyRowsStart;
                //        RecordTxt.GetComponent<Text>().text = RecordInt.ToString();
                //        PlayerPrefs.SetInt("Record" + PlayerPrefs.GetInt("Player"), RecordInt);
                //    }
                //}
                
            }

        }
    }
}