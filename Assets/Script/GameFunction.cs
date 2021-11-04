﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFunction : MonoBehaviour
{
    Transform[] Board;
    string Knight="Knight";
    public void Die(){
        SceneManager.LoadScene("Game");
    }
    public void AutoPosition(Transform Pion){
        Pion.position=new Vector3(Pion.parent.transform.position.x, Pion.parent.transform.position.y,-1);
    }
    public void krzywyatak(Transform ChessBoard,int Number,int Letter){
        Board=ChessBoard.GetComponent<ChessBoardArray>().ChessBoard;
        for(int i=Letter,j=0;i<8;i++,j++){
            if((Number+j<18 
            && Board[Number+j].GetChild(i).childCount==1
            && Board[Number+j].GetChild(i).GetChild(0).name!=Knight)
            || (Number-j>=0
            && Board[Number-j].GetChild(i).childCount==1 
            && Board[Number-j].GetChild(i).GetChild(0).name!=Knight))
            {
                break;//Do Nothing
            }
            else if((Number+j<18 
            && Board[Number+j].GetChild(i).childCount==1
            && Board[Number+j].GetChild(i).GetChild(0).name==Knight)
            || (Number-j>=0
            && Board[Number-j].GetChild(i).childCount==1 
            && Board[Number-j].GetChild(i).GetChild(0).name==Knight))
                Die();    
        }
        for(int i=Letter,j=0;i>=0;i--,j++){
            if((Number+j<18 //)Board[Number+j].GetChild(i).localscale=new vector3(.5f,.5f,.5f);
            && Board[Number+j].GetChild(i).childCount==1
            && Board[Number+j].GetChild(i).GetChild(0).name!=Knight)
            || (Number-j>=0
            && Board[Number-j].GetChild(i).childCount==1
            && Board[Number-j].GetChild(i).GetChild(0).name!=Knight))
            {
                break;//Do nothing
            }
            else if((Number+j<18 //)Board[Number+j].GetChild(i).localscale=new vector3(.5f,.5f,.5f);
            && Board[Number+j].GetChild(i).childCount==1
            && Board[Number+j].GetChild(i).GetChild(0).name==Knight)
            || (Number-j>=0
            && Board[Number-j].GetChild(i).childCount==1
            && Board[Number-j].GetChild(i).GetChild(0).name==Knight))
                Die();
        }
    }
    public void prostyatak(Transform ChessBoard,int Number,int Letter){
        Board=ChessBoard.GetComponent<ChessBoardArray>().ChessBoard;
        for(int i=0;i<8;i++){
            //Board.GetComponent<ChessBoardArray>().ChessBoard[Number].GetChild(i).localscale=new vector3(.5f,.5f,.5f);
            if(Board[Number].GetChild(i).childCount==1 
            && Board[Number].GetChild(i).GetChild(0).name!=Knight)
            {
                break;//Do nothing
            }
            else if(Board[Number].GetChild(i).childCount==1 
            && Board[Number].GetChild(i).GetChild(0).name==Knight)
                Die();
        }
        for(int i=0;i<Board.Length;i++){
            //Board.GetComponent<ChessBoardArray>().ChessBoard[i].GetChild(Letter)..localscale=new vector3(.5f,.5f,.5f);
            if(Board[i].GetChild(Letter).childCount==1 
            && Board[i].GetChild(Letter).GetChild(0).name==Knight)
                Die();
            if(Board[i].GetChild(Letter).childCount==1 
            && Board[i].GetChild(Letter).GetChild(0).name!=Knight)
            {
                break;//Do nothing
            }
        }
    }
}