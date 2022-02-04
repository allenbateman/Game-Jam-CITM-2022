using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EScenes
{
    SCENE_TITLE,
    LEVEL_SELECTION,
    FACTORY_1,
    MARKET_1,
    POWER_PLANT_1
}
public class Scene_Manager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadNextScene(EScenes nextScene)
    {
        SceneManager.LoadScene(nextScene.ToString());
    }

}
