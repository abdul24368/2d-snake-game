using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadNextSceneScript : MonoBehaviour
{
    public Snake lol;
    public Slider slide;
    
    
    //the function is attached to a buttton which loads the next scene
    public void LoadNextScene(int score)
    {
        Score.sto = score;
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
        
    }
    IEnumerator LoadAsynchronously (int num)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(num);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            float f = Mathf.Round(operation.progress);
            slide.value = operation.progress;
            yield return null;
        }
    }
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }

}
