using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCreditsController : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  void Action(){
    Debug.Log("ButtonCreditsController.Action()");
    CanvasController.instance.LoadCredits();
  }
}
