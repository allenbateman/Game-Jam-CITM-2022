using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EScenes
{
    SCENE_TITLE,
    SCENE_INTRO,
    LEVEL_SELECTION,
    FACTORY_1,
    MARKET_1,
    MARKET_2,
    POWER_PLANT_1,
    POWER_PLANT_2,
    TOWER_1,
    TOWER_2
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
