using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : ScriptableObject
{
  public static int numOfFlowers = 0;

  public static void IncreaseNumOfFlowers(){
    numOfFlowers ++;
    Debug.Log("increase numOfFlowers: " + numOfFlowers);
  }

  public static bool HasFlowers(){
    return numOfFlowers > 0;
  }
}
