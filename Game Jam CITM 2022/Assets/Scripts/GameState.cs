using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ELevelList
{
    FACTORY,
    MARKET,
    ENGINE

}

public static class GameState
{
  
    public static ELevelList level = ELevelList.FACTORY;
   

}
