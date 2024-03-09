using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enum;

public class Field : GameFunction
{
    static Transform ChessBoard;
    static Transform Player;
    static Enum.Character character;
    int PlayerNumber;
    int ClickedNumber;
    int PlayerLetter;
    int ClickedLetter;

    bool Up;
    bool Right;

    private void Awake()
    {
        ChessBoard = transform.parent.parent;

        Player = transform.parent.parent.GetComponent<ChessBoardArray>().Player;
        character = (Enum.Character)PlayerPrefs.GetInt("Player");
    }
    void OnMouseDown()
    {
        PlayerNumber = int.Parse(Player.parent.parent.name);
        ClickedNumber = int.Parse(this.gameObject.transform.parent.name);
        PlayerLetter = Player.parent.GetSiblingIndex();
        ClickedLetter = this.gameObject.transform.GetSiblingIndex();

        if (PlayerNumber == ClickedNumber && PlayerLetter == ClickedLetter) return;

        if (this.gameObject.transform.position.y < 9.5f)
        {
            switch (character)
            {
                case Enum.Character.Knight: Knight(); break;
                case Enum.Character.Bishop_L: Bishop(); break;
                case Enum.Character.Tower: Tower(); break;
                case Enum.Character.Hetman: Hetman(); break;
                case Enum.Character.King: King(); break;
                case Enum.Character.Bishop_R: Bishop(); break;
                default: Knight(); break;
            }
        }
    }
     void Hetman()
    {
        Bishop();
        Tower();
    }   
    void Knight()
    {
   
        if ((PlayerNumber + 1 == ClickedNumber || PlayerNumber - 1 == ClickedNumber)
           && (PlayerLetter + 2 == ClickedLetter || PlayerLetter - 2 == ClickedLetter))
            Player.SetParent(this.gameObject.transform);
        else if ((PlayerNumber + 2 == ClickedNumber || PlayerNumber - 2 == ClickedNumber)
        && (PlayerLetter - 1 == ClickedLetter || PlayerLetter + 1 == ClickedLetter))
            Player.SetParent(this.gameObject.transform);
        DebLog("knight");
    }
    void Bishop()
    {
        int diffNumber = ClickedNumber - PlayerNumber;
        Up = diffNumber >= 0 ? true : false;
        diffNumber = Mathf.Abs(diffNumber);

        Right = ClickedLetter - PlayerLetter >= 0 ? true : false;

        if(diffNumber == Mathf.Abs( ClickedLetter - PlayerLetter))
        {
            for (int i = 1; i < diffNumber; i++)
                if (IsChessman(ChessBoard, Player.parent.parent.GetComponent<ArrayNumber>().realNumber  + (Up ? i : -i ), PlayerLetter + (Right ? i : -i)) != null)
                    return;
            Player.SetParent(this.gameObject.transform);
        }
            

    }
    void Tower()
    { 
        if (PlayerNumber != ClickedNumber && PlayerLetter != ClickedLetter)
            return;

        if (PlayerNumber == ClickedNumber)
            for (int i = 1; i < Mathf.Abs(ClickedLetter - PlayerLetter); i++)
                if (IsChessman(ChessBoard, Player.parent.parent.GetComponent<ArrayNumber>().realNumber, PlayerLetter + (ClickedLetter > PlayerLetter ? i : -i)) != null)
                    return;
        if (PlayerLetter == ClickedLetter)
            for (int i = 1; i < Mathf.Abs(PlayerNumber - ClickedNumber); i++)
                if (IsChessman(ChessBoard, Player.parent.parent.GetComponent<ArrayNumber>().realNumber + (ClickedNumber > PlayerNumber ? i : -i), ClickedLetter) != null)
                    return;

        Player.SetParent(this.gameObject.transform);


    }
    void King()
    {
        if (PlayerNumber == ClickedNumber && (PlayerLetter  == ClickedLetter + 1 || PlayerLetter  == ClickedLetter - 1))
        {
            Player.SetParent(this.gameObject.transform);
        }
        else if (PlayerLetter == ClickedLetter && (PlayerNumber == ClickedNumber + 1 || PlayerNumber  == ClickedNumber - 1))
        {
            Player.SetParent(this.gameObject.transform);
        }
        else if(PlayerNumber == ClickedNumber + 1 && PlayerLetter == ClickedLetter + 1)
        {
            Player.SetParent(this.gameObject.transform);
        }
        else if(PlayerNumber == ClickedNumber - 1 && PlayerLetter  == ClickedLetter + 1)
        {
            Player.SetParent(this.gameObject.transform);
        }
        else if(PlayerNumber == ClickedNumber + 1 && PlayerLetter  == ClickedLetter - 1)
        {
            Player.SetParent(this.gameObject.transform);
        }
        else if(PlayerNumber == ClickedNumber - 1 && PlayerLetter == ClickedLetter - 1)
        {
            Player.SetParent(this.gameObject.transform);
        }
    }
}  
