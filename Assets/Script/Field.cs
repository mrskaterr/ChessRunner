using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enum;

public class Field : GameFunction
{
    public enum Letter
    {
        A=const_0, B, C, D, E, F, G, H
    }
    
    [SerializeField] 
    private Letter letter;
    private Row row;
    static ChessBoardArray ChessBoard;
    static Player player;
    static bool Up;
    static bool Right;
    static int PlayerNumber;
    static int PlayerLetter;
    static int buff;

    public int GetLetter()
    {
        return (int)letter;
    }
    public int GetNumber()
    {
        return row.realNumber;
    }
    public int GetDistance()
    {
        return row.distanceNumber;
    }

    private void Awake()
    {
        ChessBoard = transform.parent.parent.GetComponent<ChessBoardArray>();
        row = transform.parent.GetComponent<Row>();
        player = ChessBoard.Player();
    }
    void OnMouseDown()
    {
        PlayerNumber = player.GetFieldNumber();
        PlayerLetter = player.GetFieldLetter();

        if (PlayerDead || PlayerNumber == GetNumber() && PlayerLetter == GetLetter())
            return;
        if (transform.position.y < 9.5f)
        {
            switch (player.GetCharacter())
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
        Tower();
        Bishop();

    }   
    void Knight()
    {
        
        if ((PlayerNumber + const_1 == GetNumber() || PlayerNumber - const_1 == GetNumber())
           && (PlayerLetter + const_2 == GetLetter() || PlayerLetter - const_2 == GetLetter()))
            player.transform.SetParent(transform);
        else if ((PlayerNumber + const_2 == GetNumber() || PlayerNumber - const_2 == GetNumber())
        && (PlayerLetter - const_1 == GetLetter() || PlayerLetter + const_1 == GetLetter()))
            player.transform.SetParent(transform);
        DebLog("knight");
    }
    void Bishop()
    {
        buff = GetNumber() - PlayerNumber;
        Up = buff >= const_0 ? true : false;
        buff = Mathf.Abs(buff);

        Right = GetLetter() - PlayerLetter >= const_0 ? true : false;

        if(buff == Mathf.Abs(GetLetter() - PlayerLetter)) //(buff = Mathf.Abs(buff))==
        {
            for (int i = const_1; i < buff; i++)
                if (IsChessman(PlayerNumber + (Up ? i : -i ), (int)PlayerLetter + (Right ? i : -i)) != null)
                    return;
            player.transform.SetParent(transform);
        }
            

    }
    void Tower()
    {
        if (PlayerNumber != GetNumber() && PlayerLetter != GetLetter())
            return;

        if (PlayerNumber == GetNumber())
            for (int i = const_1; i < Mathf.Abs(GetLetter() - PlayerLetter); i++)
                if (IsChessman( PlayerNumber, PlayerLetter + (GetLetter() > PlayerLetter ? i : -i)) != null)
                    return;
        if (PlayerLetter == GetLetter())
            for (int i = const_1; i < Mathf.Abs(PlayerNumber - GetNumber()); i++)
                if (IsChessman( PlayerNumber + (GetNumber() > PlayerNumber ? i : -i), GetLetter()) != null)
                    return;

        player.transform.SetParent(transform);

    }
    void King()
    {
        if((PlayerNumber == GetNumber() + const_1 || PlayerNumber == GetNumber() - const_1 || PlayerNumber == GetNumber())  
        && (PlayerLetter == GetLetter() + const_1 || PlayerLetter == GetLetter() - const_1 || PlayerLetter == GetLetter()))
        {
            player.transform.SetParent(transform);
        }
    }
}  
