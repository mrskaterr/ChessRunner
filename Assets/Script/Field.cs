using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enum;

public class Field : MonoBehaviour
{
    static Transform Player;
    static Enum.Character character;
    int PlayerNumber;
    int ClickedNumber;
    int PlayerLetter;
    int ClickedLetter;
    private void Awake()
    {
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
                case Enum.Character.Bishop: Bishop(); break;
                case Enum.Character.Tower: Tower(); break;
                case Enum.Character.Hetman: Hetman(); break;
                case Enum.Character.King: King(); break;
                default: Knight(); break;
            }
        }
    }
    
    void Knight()
    {
   
        if ((PlayerNumber + 1 == ClickedNumber || PlayerNumber - 1 == ClickedNumber)
           && (PlayerLetter + 2 == ClickedLetter || PlayerLetter - 2 == ClickedLetter))
            Player.SetParent(this.gameObject.transform);
        else if ((PlayerNumber + 2 == ClickedNumber || PlayerNumber - 2 == ClickedNumber)
        && (PlayerLetter - 1 == ClickedLetter || PlayerLetter + 1 == ClickedLetter))
            Player.SetParent(this.gameObject.transform);
        Debug.Log("knight");
    }
    void Bishop()
    {
        if (Mathf.Abs(ClickedNumber - PlayerNumber) == Mathf.Abs(ClickedLetter - PlayerLetter))
            Player.SetParent(this.gameObject.transform);

    }
    void Tower()
    { 
        if (PlayerNumber != ClickedNumber && PlayerLetter != ClickedLetter)
            return;
        else Player.SetParent(this.gameObject.transform);
    }
    void Hetman()
    {
        Bishop();
        Tower();
    }
    void King()
    {
        if (PlayerNumber == ClickedNumber && (PlayerLetter  == ClickedLetter + 1 || PlayerLetter  == ClickedLetter - 1))
        {
            Debug.Log(1);
            Player.SetParent(this.gameObject.transform);
        }
        else if (PlayerLetter == ClickedLetter && (PlayerNumber == ClickedNumber + 1 || PlayerNumber  == ClickedNumber - 1))
        {
            Debug.Log(2);
            Player.SetParent(this.gameObject.transform);
        }
        else if(PlayerNumber == ClickedNumber + 1 && PlayerLetter == ClickedLetter + 1)
        {
            Debug.Log(3);
            Player.SetParent(this.gameObject.transform);
        }
        else if(PlayerNumber == ClickedNumber - 1 && PlayerLetter  == ClickedLetter + 1)
        {
            Debug.Log(4);
            Player.SetParent(this.gameObject.transform);
        }
        else if(PlayerNumber == ClickedNumber + 1 && PlayerLetter  == ClickedLetter - 1)
        {
            Debug.Log(5);
            Player.SetParent(this.gameObject.transform);
        }
        else if(PlayerNumber == ClickedNumber - 1 && PlayerLetter == ClickedLetter - 1)
        {
            Debug.Log(6);
            Player.SetParent(this.gameObject.transform);
        }
    }
}  
