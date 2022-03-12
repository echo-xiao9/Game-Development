using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
  public static class Common // static 不是必须
  {
    private static float bgSpeed=-0.5f;
    
    public static float BgSpeed
    {
      get { return bgSpeed; }
      set { bgSpeed = value; }
    }

    
  }
}