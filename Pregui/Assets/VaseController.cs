using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseController : MonoBehaviour
{
  public GameObject flowersHandler;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  void DepositFlowers(List<GameObject> flowers) {
    foreach(GameObject flower in flowers){
      flower.transform.position = flowersHandler.transform.position;
      var renderSprite = flower.GetComponentsInChildren<SpriteRenderer>()[0];
      renderSprite.sortingOrder = 0;
      renderSprite.sortingLayerName = "House";
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    Debug.Log("VaseController collision");

    if(other.CompareTag("PutFlowersHand")) {
      DepositFlowers(PreguiBigController.instance.GetFlowers());
    }
  }
}
