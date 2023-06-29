using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    // Singleton Instance에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    

    public void exitApp() // 프로그램 종료
    {
        Application.Quit();
    }

    public void sceneMove(string sceneName)
    {
        Cursor.visible = false;
        SceneManager.LoadScene(sceneName);
    }
    
    
}
