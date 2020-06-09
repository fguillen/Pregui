using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
  private Animator animator;
  private string state;
  public GameObject doorFrame;
  public GameObject preguiFrame;
  private BoxCollider2D doorFrameCollider;
  private BoxCollider2D preguiFrameCollider;

  void Awake(){
    animator = gameObject.GetComponent<Animator>();
    doorFrameCollider = doorFrame.GetComponent<BoxCollider2D>();
    preguiFrameCollider = preguiFrame.GetComponent<BoxCollider2D>();
  }
  // Start is called before the first frame update
  void Start()
  {
    state = "closed";
  }

  // Update is called once per frame
  void Update()
  {
    CheckIfPreguiIsInTheDoor();
  }

  void OnTriggerEnter2D(Collider2D other){
    if(state == "closed" && other.CompareTag("PreguiHand")) {
      Open();
    }
  }

  void Open(){
    animator.SetBool("open", true);
    state = "open";
  }

  void CheckIfPreguiIsInTheDoor() {
    if(state == "open"){
      if(doorFrameCollider.bounds.Intersects(preguiFrameCollider.bounds)) {
        CanvasController.instance.WhiteFadeIn();
      }
    }
  }
}
