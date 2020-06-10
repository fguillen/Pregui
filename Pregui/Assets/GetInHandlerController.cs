using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInHandlerController : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnTriggerEnter2D(Collider2D other) {
    Debug.Log("OnTriggerEnter2D");
    if(other.CompareTag("PreguiGetInHandler")){
      PreguiForestController.instance.GetInHouse();
    }
  }
}
