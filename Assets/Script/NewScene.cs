using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
   public string m_Scene;
    public GameObject m_MyGameObject;
    

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadYourAsyncScene());
        }
    }
    IEnumerator LoadYourAsyncScene()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);

     
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

 
        SceneManager.MoveGameObjectToScene(m_MyGameObject, SceneManager.GetSceneByName(m_Scene));
  
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
