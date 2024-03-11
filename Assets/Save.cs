using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public pawnsbutton [] pb;
    // Start is called before the first frame update
    public string save;
    [SerializeField] TMP_InputField text;
    public GameObject last()
    {
        foreach (var pb in pb)
        {
            if (pb.active)return pb.pref;
            
        }
        return null;
    }
    public void SAVE(string txt)
    {
        text.text += txt;
        save += txt;
    }
    public void play()
    {
        PlayerPrefs.SetString("level", save);
        SceneManager.LoadScene("Play");

    }
}
