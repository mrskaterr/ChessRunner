using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mouse : MonoBehaviour
{
  Transform Knight;
  // Start is called before the first frame update
  void Start()
  {
    Knight=gameObject.transform.parent.parent.GetChild(0).GetChild(0).GetChild(0).transform;
  }
  void OnMouseDown()
  {
    int KnightNumber=int.Parse(Knight.parent.parent.name);
    int ClickedNumber=int.Parse(this.gameObject.transform.parent.name);
    char KnightLetter=Knight.parent.name[0];
    char ClickedLetter=this.gameObject.name[0];

    if((KnightNumber+1==ClickedNumber || KnightNumber-1==ClickedNumber) 
    && (KnightLetter+2==ClickedLetter || KnightLetter-2==ClickedLetter))
      Knight.SetParent(this.gameObject.transform);
    if((KnightNumber+2==ClickedNumber || KnightNumber-2==ClickedNumber) 
    && (KnightLetter-1==ClickedLetter || KnightLetter+1==ClickedLetter))
      Knight.SetParent(this.gameObject.transform);
  }  
}