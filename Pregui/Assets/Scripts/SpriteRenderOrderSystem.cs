using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Anima2D;

public class SpriteRenderOrderSystem : MonoBehaviour
{
  public static SpriteRenderOrderSystem instance;
  public GameObject baseLine;

  void Awake() {
    instance = this;
  }

  public void Order(GameObject gameObject){
    OrderSpriteRenderers(gameObject);
    OrderSpriteMeshInstances(gameObject);
  }

  public void Order(GameObject gameObject, GameObject bottomHandler){
    OrderSpriteRenderers(gameObject, bottomHandler);
    OrderSpriteMeshInstances(gameObject);
  }

  void OrderSpriteRenderers(GameObject gameObject){
    SpriteRenderer[] elements = gameObject.GetComponentsInChildren<SpriteRenderer>(true);

    if(elements.Count() > 0) {
      float minY = (float)elements.Min(element => BottomY(element));
      // Instantiate(baseLine, new Vector3(gameObject.transform.position.x, minY, gameObject.transform.position.z), gameObject.transform.rotation);

      SortingOrderStartingFrom(gameObject, (int)(minY * -1000));
    }
  }

  void OrderSpriteRenderers(GameObject gameObject, GameObject bottomHandler){
    SpriteRenderer[] elements = gameObject.GetComponentsInChildren<SpriteRenderer>(true);

    if(elements.Count() > 0) {
      float minY = bottomHandler.transform.position.y;
      // Instantiate(baseLine, new Vector3(gameObject.transform.position.x, minY, gameObject.transform.position.z), gameObject.transform.rotation);

      SortingOrderStartingFrom(gameObject, (int)(minY * -1000));
    }
  }

  void OrderSpriteMeshInstances(GameObject gameObject){
    SpriteMeshInstance[] elements = gameObject.GetComponentsInChildren<SpriteMeshInstance>(true);
    if(elements.Count() > 0) {
      float minY = (float)elements.Min(element => BottomY(element));
      // Instantiate(baseLine, new Vector3(gameObject.transform.position.x, minY, gameObject.transform.position.z), gameObject.transform.rotation);

      int minSortingOrder = (int)elements.Min(element => element.sortingOrder);

      foreach(SpriteMeshInstance element in elements){
        int finalSortingOrder = element.sortingOrder - minSortingOrder; // Normalize
        finalSortingOrder += (int)(minY * -1000);
        element.sortingOrder = finalSortingOrder;
      }
    }
  }

  public static int MinSortingOrder(GameObject gameObject){
    SpriteRenderer[] elements = gameObject.GetComponentsInChildren<SpriteRenderer>(true);

    if(elements.Count() > 0) {
      return (int)elements.Min(element => element.sortingOrder);
    } else {
      return 0;
    }
  }

  public static int MaxSortingOrder(GameObject gameObject){
    SpriteRenderer[] elements = gameObject.GetComponentsInChildren<SpriteRenderer>(true);

    if(elements.Count() > 0) {
      return (int)elements.Max(element => element.sortingOrder);
    } else {
      return 0;
    }
  }

  public static void SortingOrderStartingFrom(GameObject gameObject, int minOrder){
    SpriteRenderer[] elements = gameObject.GetComponentsInChildren<SpriteRenderer>(true);

    if(elements.Count() > 0) {
      int minSortingOrder = (int)elements.Min(element => element.sortingOrder);

      foreach(SpriteRenderer element in elements){
        int finalSortingOrder = element.sortingOrder - minSortingOrder; // Normalize
        finalSortingOrder += minOrder;
        element.sortingOrder = finalSortingOrder;
      }
    }
  }

  static float BottomY(SpriteRenderer spriteRenderer){
    Renderer renderer = spriteRenderer.GetComponent<Renderer>();
    return renderer.bounds.center.y - renderer.bounds.extents.y;
  }

  static float BottomY(SpriteMeshInstance spriteRenderer){
    Renderer renderer = spriteRenderer.GetComponent<Renderer>();
    return renderer.bounds.center.y - renderer.bounds.extents.y;
  }
}
