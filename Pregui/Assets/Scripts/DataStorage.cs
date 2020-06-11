using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : ScriptableObject
{
  public static int numOfFlowers = 0;
  public static string gameState = "init";
  public static bool paused = true;

  public static void IncreaseNumOfFlowers(){
    numOfFlowers ++;
  }

  public static bool HasFlowers(){
    return numOfFlowers > 0;
  }
}
