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
        if (GameState.level == ELevelList.FACTORY) SceneManager.LoadScene("Factory_1");
        if (GameState.level == ELevelList.MARKET) SceneManager.LoadScene("Market_1");
        if (GameState.level == ELevelList.ENGINE) SceneManager.LoadScene("Engine_1");
    }
}
