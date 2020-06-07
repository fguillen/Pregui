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

  void OrderSpriteRenderers(GameObject gameObject){
    SpriteRenderer[] elements = gameObject.GetComponentsInChildren<SpriteRenderer>(true);

    if(elements.Count() > 0) {
      int minSortingOrder = (int)elements.Min(element => element.sortingOrder);
      float minY = (float)elements.Min(element => BottomY(element));

      // Instantiate(baseLine, new Vector3(gameObject.transform.position.x, minY, gameObject.transform.position.z), gameObject.transform.rotation);

      foreach(SpriteRenderer element in elements){
        BottomY(element);
        int finalSortingOrder = element.sortingOrder - minSortingOrder; // Normalize
        finalSortingOrder += (int)(minY * -1000);
        element.sortingOrder = finalSortingOrder;
      }
    }
  }

  void OrderSpriteMeshInstances(GameObject gameObject){
    SpriteMeshInstance[] elements = gameObject.GetComponentsInChildren<SpriteMeshInstance>(true);
    if(elements.Count() > 0) {
      int minSortingOrder = (int)elements.Min(element => element.sortingOrder);
      float minY = (float)elements.Min(element => BottomY(element));

      // Instantiate(baseLine, new Vector3(gameObject.transform.position.x, minY, gameObject.transform.position.z), gameObject.transform.rotation);

      foreach(SpriteMeshInstance element in elements){
        int finalSortingOrder = element.sortingOrder - minSortingOrder; // Normalize
        finalSortingOrder += (int)(minY * -1000);
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
