using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardArray : GameFunction
{
    Transform Character;
    // Start is called before the first frame update
    void Start()
    {
        Board=new Transform[transform.childCount];
        for(int i=0;i<transform.childCount;i++){
            Board[i]=transform.GetChild(i);
        }
    }
    public void UpdateArray(){
        Transform[] NewBoard=new Transform[transform.childCount];
        for(int i=1;i<transform.childCount;i++)
        {
            NewBoard[i-1]=Board[i];
        }
        NewBoard[transform.childCount-1]=Board[0];
        Board=NewBoard;
        for(int i=0;i<transform.childCount;i++){
            for(int j=0;j<8;j++){
                if(Board[i].GetChild(j).childCount==1)
                {
                    Character=Board[i].GetChild(j).GetChild(0);

                    if(Character.GetComponent<EnemyBishop>())
                        Character.GetComponent<EnemyBishop>().ChangeBishopNumber();
                    if(Character.GetComponent<EnemyHetman>())
                        Character.GetComponent<EnemyHetman>().ChangeHetmanNumber();
                    if(Character.GetComponent<EnemyTower>())
                        Character.GetComponent<EnemyTower>().ChangeTowerNumber();
                    if(Character.GetComponent<EnemyPawn>())
                        Character.GetComponent<EnemyPawn>().ChangePawnNumber();
                    if(Character.GetComponent<EnemyKnight>())
                        Character.GetComponent<EnemyKnight>().ChangeKnightNumber();
                }
                
                
            }
        }
    }
}
