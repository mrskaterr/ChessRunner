using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enum : MonoBehaviour
{
    public enum Character{
        Tower=  0,
        Knight= 1,
        Bishop_L= 2,
        Hetman= 3,
        King =  4,
        Bishop_R = 5,
        Pawn =   6

    }
    public Character character;
}
