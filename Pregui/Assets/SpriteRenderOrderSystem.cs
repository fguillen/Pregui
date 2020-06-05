using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Anima2D;

public class SpriteRenderOrderSystem : MonoBehaviour
{

  public static void Order(GameObject gameObject){
    Debug.Log("Order --------- ");
    OrderSpriteRenderers(gameObject);
    OrderSpriteMeshInstances(gameObject);
  }

  static void OrderSpriteRenderers(GameObject gameObject){
    SpriteRenderer[] elements = gameObject.GetComponentsInChildren<SpriteRenderer>();

    Debug.Log("elements.Count: " + elements.Count());

    if(elements.Count() > 0) {
      int minSortingOrder = (int)elements.Min(element => element.sortingOrder);
      Debug.Log("minSortingOrder: " + minSortingOrder);

      foreach(SpriteRenderer element in elements){
        int finalSortingOrder = element.sortingOrder - minSortingOrder; // Normalize
        finalSortingOrder += (int)(gameObject.transform.position.y * -100);
        element.sortingOrder = finalSortingOrder;
      }
    }
  }

  static void OrderSpriteMeshInstances(GameObject gameObject){
    SpriteMeshInstance[] elements = gameObject.GetComponentsInChildren<SpriteMeshInstance>();
    if(elements.Count() > 0) {
      int minSortingOrder = (int)elements.Min(element => element.sortingOrder);

      foreach(SpriteMeshInstance element in elements){
        int finalSortingOrder = element.sortingOrder - minSortingOrder; // Normalize
        finalSortingOrder += (int)(gameObject.transform.position.y * -100);
        element.sortingOrder = finalSortingOrder;
      }
    }
  }
}
