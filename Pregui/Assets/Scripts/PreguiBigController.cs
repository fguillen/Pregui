using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreguiBigController : MonoBehaviour
{

  public Rigidbody2D theRB;
  public float velocity;
  private Vector2 direction;
  private Vector3 scale;
  private Animator animator;
  public GameObject figure;
  public GameObject figureWithFlowers;
  public GameObject armWithFlowers;
  public GameObject handOpen;
  public GameObject handClosed;
  private string state;
  // private DataStorage dataStorage;

  void Awake() {
    direction = Vector2.zero;
    scale = new Vector3(1f, 1f, 1f);
    animator = gameObject.GetComponent<Animator>();
    state = "normal";
    // dataStorage = ScriptableObject.CreateInstance<DataStorage>();
  }
  // Start is called before the first frame update
  void Start()
  {
    if(DataStorage.HasFlowers()){
      state = "withFlowers";
    }

    RenderFigure();
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKey(KeyCode.RightArrow)) {
      direction = new Vector2(velocity, 0f);
      scale = new Vector3(-1f, 1f, 1f);
      animator.SetBool("walking", true);
    } else if(Input.GetKey(KeyCode.LeftArrow)) {
      direction = new Vector2(-velocity, 0f);
      scale = new Vector3(1f, 1f, 1f);
      animator.SetBool("walking", true);
    } else {
      direction = Vector2.zero;
      animator.SetBool("walking", false);
    }

    theRB.velocity = direction;
    gameObject.transform.localScale = scale;

    if(Input.GetKeyDown(KeyCode.Space)) {
      TryOpenDoor();
    }
  }

  void TryOpenDoor(){
    state = "tryOpenDoor";
    RenderFigure();
    animator.SetTrigger("openDoor");
  }

  void FinishOpenDoor(){
    state = "normal";
    RenderFigure();
  }

  void RenderFigure(){
    if(state == "normal") {
      Debug.Log("normal");
      figure.SetActive(true);
      figureWithFlowers.SetActive(false);
      armWithFlowers.SetActive(false);
    }

    if(state == "withFlowers") {
      figure.SetActive(false);
      figureWithFlowers.SetActive(true);
      armWithFlowers.SetActive(true);
      handClosed.SetActive(true);
      handOpen.SetActive(false);
    }

    if(state == "tryOpenDoor") {
      Debug.Log("tryOpenDoor");
      figure.SetActive(false);
      figureWithFlowers.SetActive(true);
      armWithFlowers.SetActive(true);
      handClosed.SetActive(false);
      handOpen.SetActive(true);
    }

    if(state == "withFlowers") {
      Debug.Log("withFlowers");
      figure.SetActive(false);
      figureWithFlowers.SetActive(true);
      armWithFlowers.SetActive(true);
      handClosed.SetActive(true);
      handOpen.SetActive(false);
    }
  }
}
