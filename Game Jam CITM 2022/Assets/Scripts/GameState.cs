using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ELevelList
{
    NULL,
    FACTORY,
    MARKET,
    POWER_PLANT,
    TOWER

}

public static class GameState
{
  
    public static ELevelList level = ELevelList.FACTORY;
    public static EScenes scene = EScenes.SCENE_INTRO;

}
