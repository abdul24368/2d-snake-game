using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{

    public Snake lol;
    public Text sctext;
    public static int sto;
    //check this error
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex==2) { sto = lol.score; }
        sctext.text = sto.ToString();
    }
}
