using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTower : GameOver
{
    // Start is called before the first frame update
    Transform ChessBoard;
    int Count;
    int TowerLetter;
    int TowerNumber;
    void Start()
    {
        ChessBoard=transform.parent.parent.parent;
        TowerLetter=transform.parent.GetSiblingIndex();
        TowerNumber=17;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y,-1);//AutoPosition
        for(int i=0;i<8;i++){
            if(ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[TowerNumber].GetChild(i).childCount==1 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[TowerNumber].GetChild(i).GetChild(0).name=="Knight")
                Die();
        }
        for(int i=0;i<ChessBoard.childCount;i++){
            if(ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[i].GetChild(TowerLetter).childCount==1 
            && ChessBoard.GetComponent<ChessBoardArray>().ChessBoard[i].GetChild(TowerLetter).GetChild(0).name=="Knight" )
                Die();
            /*if(transform.parent.parent.parent.GetChild(i).GetChild((int)TowerLetter-65).childCount==1 
            && transform.parent.parent.parent.GetChild(i).GetChild((int)TowerLetter-65).GetChild(0).name=="Knight")
                SceneManager.LoadScene("Game");*/
        }
    }
    public void ChangeTowerNumber(){
        --TowerNumber;
    }

}
