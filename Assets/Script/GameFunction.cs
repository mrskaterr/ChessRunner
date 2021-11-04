using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFunction : MonoBehaviour
{
    Transform[] Board;
    string Knight="Knight";
    string Tower="Tower(Clone)";
    string Bishop="Bishop(Clone)";
    public void Die(){
        //SceneManager.LoadScene("Game");
        Debug.Log("YOU DIE");
    }
    public void AutoPosition(Transform Pion){
        Pion.position=new Vector3(Pion.parent.transform.position.x, Pion.parent.transform.position.y,-1);
    }
    public void krzywyatak(Transform ChessBoard,int Number,int Letter){
        Board=ChessBoard.GetComponent<ChessBoardArray>().ChessBoard;
        for(int i=Letter,j=0;i<8;i++,j++){
            //if(Number+j<18)Board[Number+j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
            //if(Number-j>=0)Board[Number-j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
            if(Number+j<18 && Board[Number+j].GetChild(i).childCount==1){
                if( Board[Number+j].GetChild(i).GetChild(0).name==Knight)Die();
                else if(Board[Number+j].GetChild(i).GetChild(0).name==Tower)break;
            } 
        }
        for(int i=Letter,j=0;i<8;i++,j++){
            //if(Number+j<18)Board[Number+j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
            //if(Number-j>=0)Board[Number-j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
            if(Number-j>=0 && Board[Number-j].GetChild(i).childCount==1){
                if( Board[Number-j].GetChild(i).GetChild(0).name==Knight)Die();
                else if(Board[Number-j].GetChild(i).GetChild(0).name==Tower)break;
            } 
        }

        // for(int i=Letter,j=0;i<8;i++,j++){
        //     //if(Number+j<18)Board[Number+j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
        //     //if(Number-j>=0)Board[Number-j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
        //     if((Number+j<18
        //     && Board[Number+j].GetChild(i).childCount==1
        //     && Board[Number+j].GetChild(i).GetChild(0).name==Knight)
        //     ||
        //     (Number-j>=0
        //     && Board[Number-j].GetChild(i).childCount==1 
        //     && Board[Number-j].GetChild(i).GetChild(0).name==Knight))
        //         Die();
        // }
        for(int i=Letter,j=0;i>=0;i--,j++){
            //if(Number+j<18)Board[Number+j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
            //if(Number-j>=0)Board[Number-j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
            if(Number+j<18 && Board[Number+j].GetChild(i).childCount==1){
                if(Board[Number+j].GetChild(i).GetChild(0).name==Knight)Die();
                else if(Board[Number+j].GetChild(i).GetChild(0).name==Tower)break;
            }
        }
        for(int i=Letter,j=0;i>=0;i--,j++){
            //if(Number+j<18)Board[Number+j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
            //if(Number-j>=0)Board[Number-j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
            if(Number-j>=0 && Board[Number-j].GetChild(i).childCount==1){
                if(Board[Number-j].GetChild(i).GetChild(0).name==Knight)Die();
                else if(Board[Number-j].GetChild(i).GetChild(0).name==Tower)break;
            
            }
        }
        // for(int i=Letter,j=0;i>=0;i--,j++){
        //     //if(Number+j<18)Board[Number+j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
        //     //if(Number-j>=0)Board[Number-j].GetChild(i).localScale=new Vector3(.5f,.5f,.5f);
        //     if((Number+j<18
        //     && Board[Number+j].GetChild(i).childCount==1
        //     && Board[Number+j].GetChild(i).GetChild(0).name==Knight)
        //     ||
        //     (Number-j>=0
        //     && Board[Number-j].GetChild(i).childCount==1 
        //     && Board[Number-j].GetChild(i).GetChild(0).name==Knight))
        //         Die();
             
        // }
    }
    public void prostyatak(Transform ChessBoard,int Number,int Letter){
        Board=ChessBoard.GetComponent<ChessBoardArray>().ChessBoard;
        for(int i=Letter;i<8;i++){
            if(Board[Number].GetChild(i).childCount==1){
                if( Board[Number].GetChild(i).GetChild(0).name==Knight)Die();
                else if(Board[Number].GetChild(i).GetChild(0).name==Bishop) break;
            }
        }
        for(int i=Letter;i>=0;i--){
            if(Board[Number].GetChild(i).childCount==1){
                if( Board[Number].GetChild(i).GetChild(0).name==Knight)Die();
                else if(Board[Number].GetChild(i).GetChild(0).name==Bishop) break;
            }
        }
        for(int i=Number;i<Board.Length;i++){
            //Board.GetComponent<ChessBoardArray>().ChessBoard[i].GetChild(Letter)..localscale=new vector3(.5f,.5f,.5f);
            if(Board[i].GetChild(Letter).childCount==1){
                if(Board[i].GetChild(Letter).GetChild(0).name==Knight) Die();
                else if(Board[i].GetChild(Letter).GetChild(0).name==Bishop) break;
            }
        }
        for(int i=Number;i>=0;i--){
            //Board.GetComponent<ChessBoardArray>().ChessBoard[i].GetChild(Letter)..localscale=new vector3(.5f,.5f,.5f);
            if(Board[i].GetChild(Letter).childCount==1) {
                if(Board[i].GetChild(Letter).GetChild(0).name==Knight) Die();
                else if(Board[i].GetChild(Letter).GetChild(0).name==Bishop) break;
            }
        }
        
        // for(int i=0;i<Board.Length;i++){
        //     //Board.GetComponent<ChessBoardArray>().ChessBoard[i].GetChild(Letter)..localscale=new vector3(.5f,.5f,.5f);
        //     if(Board[i].GetChild(Letter).childCount==1 
        //     && Board[i].GetChild(Letter).GetChild(0).name!=Knight)
        //         break;
        //     if(Board[i].GetChild(Letter).childCount==1 
        //     && Board[i].GetChild(Letter).GetChild(0).name==Knight)
        //         Die();
        // }
    }
}