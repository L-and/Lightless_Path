using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextScriptManager : MonoBehaviour
{   
    private static TextScriptManager instance = null;

    // Singleton Instance에 접근하기 위한 프로퍼티
    public static TextScriptManager Instance
    {
        get
        {
            return instance;
        }
    }
    // 스크립트 대본들을 string으로 가져와 저장해두는 스크립트

    string[] fileNmaes;

    [SerializeField]
    string[] storyText;

    string[] tipText;

    string[] missionText;

    void Start()
    {
        loadScript("\\Assets\\Scripts\\Text Scripts\\"); // 스크립트파일경로의 텍스트들 가져옴
    }

    private void loadScript(string filePath)
    {
        filePath = Directory.GetCurrentDirectory() + filePath;

        DirectoryInfo directoryInfo = new DirectoryInfo(filePath);

        fileNmaes = Directory.GetFiles(filePath, "*.txt");

        FileInfo fileInfo = new FileInfo(fileNmaes[0]);
        

        storyText = new string[10];

        if (fileInfo.Exists)
        {
            StreamReader reader = new StreamReader(filePath + fileInfo.Name);
            
            int index = 0;

            while(reader.EndOfStream != true)
            {
                storyText[index++] = reader.ReadLine();
            }

            reader.Close();           
        }
    }


    public string getStoryText(int index)
    {
        return storyText[index];
    }

    public string getTipText(int index)
    {
        return tipText[index];
    }

    public string getMissionText(int index)
    {
        return missionText[index];
    }

}
