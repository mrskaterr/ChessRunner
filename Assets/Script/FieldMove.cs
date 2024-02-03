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
    [SerializeField] abcdefgh Abcdefgh;
    [SerializeField] GameObject ScoreTxt;
    [SerializeField] GameObject HighscoreTxt;
    private int  Highscore;
    public float Speed;
    void Start()
    {
        Highscore = PlayerPrefs.GetInt("Highscore");
        HighscoreTxt.GetComponent<Text>().text = Highscore.ToString();
        LastRow =transform.GetChild(transform.childCount-1);
        HowManyRowsStart=transform.childCount;
        HowManyRows=HowManyRowsStart;
        ScoreTxt.GetComponent<Text>().text=(HowManyRows-HowManyRowsStart).ToString();
        Abcdefgh.SetSpeed(StartSpeed * Speed);
    }
    void FixedUpdate()
    {
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
                        if(Row.GetChild(j).GetChild(0).gameObject.GetComponent<PlayerKnight>())
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



                if (((HowManyRows-HowManyRowsStart-1)%16==0))//ChessBoard Speed Fixed
                    Row.position-=new Vector3(0,StartSpeed*Speed,0);

                Row.name=HowManyRows.ToString();
                ScoreTxt.GetComponent<Text>().text=(HowManyRows-HowManyRowsStart).ToString();
                if(HowManyRows - HowManyRowsStart > Highscore)
                {
                    Highscore=HowManyRows - HowManyRowsStart;
                    PlayerPrefs.SetInt("Highscore", Highscore);
                    HighscoreTxt.GetComponent<Text>().text= Highscore.ToString();
                }
            }

        }
    }
}