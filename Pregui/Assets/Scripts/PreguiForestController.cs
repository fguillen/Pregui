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
  public GameObject flowersArm;
  private float[] flowersRotations;
  private string state;

  void Awake() {
    instance = this;
    direction = Vector2.zero;
    scale = new Vector3(1f, 1f, 1f);
    animator = gameObject.GetComponent<Animator>();
    theRB = gameObject.GetComponent<Rigidbody2D>();
    flowersRotations = new float[] { 0, -20, 20, -40, 40 };
    state = "idle";
  }
  // Start is called before the first frame update
  void Start()
  {
    RenderOrder();
  }

  // Update is called once per frame
  void Update()
  {
    Move();
  }

  void Move() {
    if(state != "gettingInHouse") {

      direction = Vector2.zero;
      animator.SetBool("walking", false);
      state = "idle";

      if(Input.GetKey(KeyCode.RightArrow)) {
        direction = new Vector2(1, direction.y);
        scale = new Vector3(1f, 1f, 1f);
        animator.SetBool("walking", true);
        state = "walking";
      }

      if(Input.GetKey(KeyCode.LeftArrow)) {
        direction = new Vector2(-1, direction.y);
        scale = new Vector3(-1f, 1f, 1f);
        animator.SetBool("walking", true);
        state = "walking";
      }

      if(Input.GetKey(KeyCode.UpArrow)) {
        direction = new Vector2(direction.x, 1);
        animator.SetBool("walking", true);
        state = "walking";
      }

      if(Input.GetKey(KeyCode.DownArrow)) {
        direction = new Vector2(direction.x, -1);
        animator.SetBool("walking", true);
        state = "walking";
      }

      direction.Normalize();
      theRB.velocity = direction * velocity;
      gameObject.transform.localScale = scale;

      if(Input.GetKeyDown(KeyCode.Space)) {
        BendDown();
      }
    }

    CenterFlowers();
    ShowFlowersArm();

    if(state == "walking") {
      RenderOrder();
    }
  }

  void RenderOrder() {
    SpriteRenderOrderSystem.instance.Order(gameObject);
    RenderOrderFlowers();
  }

  void ShowFlowersArm() {
    // if(!flowersArm.gameObject.active && flowers.Count > 0) {
    //   Debug.Log("ShowFlowersArm");
      // flowersArm.gameObject.SetActive(true);
    // }
  }

  public void RenderOrderFlowers() {
    int minOrder = SpriteRenderOrderSystem.MinSortingOrder(gameObject);
    foreach(var flower in flowers){
      SpriteRenderOrderSystem.SortingOrderStartingFrom(flower, minOrder);
    }
  }

  void CenterFlowers(){
    foreach(var flower in flowers){
      flower.transform.position = flowersHand.transform.position;
    }
  }

  void BendDown(){
    AudioController.instance.PlayGrunt();
    animator.SetTrigger("pickFlower");
  }

  public void PickupFlower(GameObject flower){
    Debug.Log("PreguiForestController.PickupFlower");
    if(flowers.Count < flowersRotations.Length) {
      AudioController.instance.PlayPickupFlower();
      ((FlowerController)flower.GetComponent(typeof(FlowerController))).DeactivePickupCollider();
      flower.transform.rotation = Quaternion.Euler(flower.transform.rotation.x, flower.transform.rotation.y, flowersRotations[flowers.Count]);
      flowers.Add(flower);
      DataStorage.IncreaseNumOfFlowers();
    } else {
      AudioController.instance.PlayNo();
    }
  }

  public void GetInHouse() {
    if(state != "gettingInHouse") {
      state = "gettingInHouse";
      animator.SetBool("walking", true);
      theRB.velocity = Vector2.zero;
      PreguiGetInHouseController.instance.PreguiGetInHouseAnimation();
    }
  }
}
