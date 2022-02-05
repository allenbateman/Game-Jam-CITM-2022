using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue_Button : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (GameState.level == ELevelList.FACTORY) SceneManager.LoadScene("FACTORY_1");
        if (GameState.level == ELevelList.MARKET) SceneManager.LoadScene("MARKET_1");
        if (GameState.level == ELevelList.POWER_PLANT) SceneManager.LoadScene("POWER_PLANT_1");
        if (GameState.level == ELevelList.TOWER) SceneManager.LoadScene("TOWER_1");
    }
}
