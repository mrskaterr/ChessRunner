using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumHelp : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Character{
        Pawn,
        Knight,
        Bishop,
        Tower,
        Hetman
    }
    public Character character;
}
