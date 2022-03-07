using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
  public static class Common // static 不是必须
  {
    private static float bgSpeed=-2.0f;
    private static string name = "cc";
    public static float BgSpeed
    {
      get { return bgSpeed; }
      set { bgSpeed = value; }
    }
  }
}