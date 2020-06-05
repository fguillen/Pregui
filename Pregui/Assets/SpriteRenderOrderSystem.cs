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
    SpriteRenderer[] elements = gameObject.GetComponentsInChildren<SpriteRenderer>(true);

    Debug.Log("elements.Count: " + elements.Count());

    if(elements.Count() > 0) {
      int minSortingOrder = (int)elements.Min(element => element.sortingOrder);
      float minY = (float)elements.Min(element => BottomY(element));
      Debug.Log("minSortingOrder: " + minSortingOrder);
      Debug.Log("minY: " + minY);

      foreach(SpriteRenderer element in elements){
        BottomY(element);
        int finalSortingOrder = element.sortingOrder - minSortingOrder; // Normalize
        finalSortingOrder += (int)(minY * -1000);
        element.sortingOrder = finalSortingOrder;
      }
    }
  }

  static void OrderSpriteMeshInstances(GameObject gameObject){
    SpriteMeshInstance[] elements = gameObject.GetComponentsInChildren<SpriteMeshInstance>(true);
    if(elements.Count() > 0) {
      int minSortingOrder = (int)elements.Min(element => element.sortingOrder);
      float minY = (float)elements.Min(element => BottomY(element));

      foreach(SpriteMeshInstance element in elements){
        int finalSortingOrder = element.sortingOrder - minSortingOrder; // Normalize
        finalSortingOrder += (int)(minY * -1000);
        element.sortingOrder = finalSortingOrder;
      }
    }
  }

  static float BottomY(SpriteRenderer spriteRenderer){
    Renderer renderer = spriteRenderer.GetComponent<Renderer>();

    // Debug.Log("bounds: " + renderer.bounds.ToString());
    // Debug.Log("centerY: " + renderer.bounds.center.y);
    // Debug.Log("extents: " + renderer.bounds.extents.ToString());
    // Debug.Log("extentsY: " + renderer.bounds.extents.y);

    return renderer.bounds.center.y + renderer.bounds.extents.y;
  }

  static float BottomY(SpriteMeshInstance spriteRenderer){
    Renderer renderer = spriteRenderer.GetComponent<Renderer>();

    // Debug.Log("bounds: " + renderer.bounds.ToString());
    // Debug.Log("centerY: " + renderer.bounds.center.y);
    // Debug.Log("extents: " + renderer.bounds.extents.ToString());
    // Debug.Log("extentsY: " + renderer.bounds.extents.y);

    return renderer.bounds.center.y + renderer.bounds.extents.y;
  }
}
