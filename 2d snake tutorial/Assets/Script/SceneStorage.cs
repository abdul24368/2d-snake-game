using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneStorage : MonoBehaviour
{
    public Snake lol;
    static int qwe;

    private void Update()
    {
        qwe = lol.score;
    }
}
