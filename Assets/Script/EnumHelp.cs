using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumHelp : MonoBehaviour
{
    public Sprite [] Pawns;
    public enum Character{
        Pawn,
        Knight,
        Bishop,
        Tower,
        Hetman
    }
    public Character character;
    private void Start()
    {
        if (GetComponent<Player>())
        {
            character = (Character)PlayerPrefs.GetInt("Player");
            GetComponent<SpriteRenderer>().sprite = Pawns[(int)character];
        }
    }
}
