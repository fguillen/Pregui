using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupPointController : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Flower"))
    {
      Debug.Log("PickupPointController.PickupFlower");
      PreguiForestController.instance.PickupFlower(other.gameObject);
    }
  }
}
