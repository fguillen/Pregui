using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreguiForestController : MonoBehaviour
{

  public static PreguiForestController instance;
  private Rigidbody2D theRB;
  public float velocity;
  private Vector2 direction;
  private Vector3 scale;
  private Animator animator;
  public List<GameObject> flowers;
  public GameObject flowersHand;

  void Awake() {
    instance = this;
    direction = Vector2.zero;
    scale = new Vector3(1f, 1f, 1f);
    animator = gameObject.GetComponent<Animator>();
    theRB = gameObject.GetComponent<Rigidbody2D>();
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKey(KeyCode.RightArrow)) {
      direction = new Vector2(velocity, 0f);
      scale = new Vector3(1f, 1f, 1f);
      animator.SetBool("walking", true);
    } else if(Input.GetKey(KeyCode.LeftArrow)) {
      direction = new Vector2(-velocity, 0f);
      scale = new Vector3(-1f, 1f, 1f);
      animator.SetBool("walking", true);
    } else if(Input.GetKey(KeyCode.UpArrow)) {
      direction = new Vector2(0f, velocity);
      animator.SetBool("walking", true);
    } else if(Input.GetKey(KeyCode.DownArrow)) {
      direction = new Vector2(0f, -velocity);
      animator.SetBool("walking", true);
    } else {
      direction = Vector2.zero;
      animator.SetBool("walking", false);
    }

    theRB.velocity = direction;
    gameObject.transform.localScale = scale;

    if(Input.GetKeyDown(KeyCode.Space)) {
      animator.SetTrigger("pickFlower");
    }

    CenterFlowers();
  }

  void CenterFlowers(){
    foreach(var flower in flowers){
      flower.transform.position = flowersHand.transform.position;
    }
  }

  public void PickupFlower(GameObject flower){
    Debug.Log("PreguiForestController.PickupFlower");
    AudioController.instance.PlayPickupFlower();
    flowers.Add(flower);
  }
}
