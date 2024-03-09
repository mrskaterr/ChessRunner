using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoardArray : GameFunction
{
    public Transform Player;
    Transform Character;
    void Start()
    {
        Board=new Transform[transform.childCount];
        for(int i=0;i<transform.childCount;i++){
            Board[i]=transform.GetChild(i);
            Board[i].GetComponent<ArrayNumber>().realNumber = i;
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
                if(Board[i].transform.GetComponent< ArrayNumber >())
                    Board[i].transform.GetComponent<ArrayNumber>().realNumber = i;
                if (Board[i].GetChild(j).childCount==1)
                {
                    Character=Board[i].GetChild(j).GetChild(0);

                    Character.GetComponent<EnemyBishop>()?.ChangeBishopNumber();
                    Character.GetComponent<EnemyHetman>()?.ChangeHetmanNumber();
                    Character.GetComponent<EnemyTower>()?.ChangeTowerNumber();
                    Character.GetComponent<EnemyPawn>()?.ChangePawnNumber();
                    Character.GetComponent<EnemyKnight>()?.ChangeKnightNumber();
                } 
            }
        }
    }
}
