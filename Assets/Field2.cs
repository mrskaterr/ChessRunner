using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field2 : MonoBehaviour
{
    static Save save;
    int ClickedNumber;
    int ClickedLetter;

    
    private void Awake()
    {
        save = transform.parent.parent.GetComponent<Save>();
    }


    void OnMouseDown()
    {
        if (transform.childCount == 0)
        {
            ClickedNumber = int.Parse(this.gameObject.transform.parent.name);
            ClickedLetter = this.gameObject.transform.GetSiblingIndex();
            if (save.last() != null)
                Instantiate(save.last(), transform);

        }
        else Destroy(transform.GetChild(0).gameObject);


    }
}
