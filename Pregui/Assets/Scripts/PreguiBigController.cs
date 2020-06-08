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

  // Flowers
  public GameObject flowerTemplate;
  public List<GameObject> flowers;
  private float[] flowersRotations;
  public GameObject flowersHandler;

  void Awake() {
    direction = Vector2.zero;
    scale = new Vector3(1f, 1f, 1f);
    animator = gameObject.GetComponent<Animator>();
    state = "normal";
    // dataStorage = ScriptableObject.CreateInstance<DataStorage>();

    flowersRotations = new float[] { 0, -20, 20, -40, 40 };
  }
  // Start is called before the first frame update
  void Start()
  {
    if(DataStorage.HasFlowers()){
      state = "withFlowers";
      InitFlowers();
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
      if(state == "withFlowers") {
        ActionTryToPutFlowersInTheVase();
      } else {
        ActionTryOpenDoor();
      }
    }

    if(DataStorage.HasFlowers()) {
      CenterFlowers();
    }
  }

  void InitFlowers(){
    for(int n = 0; n < DataStorage.numOfFlowers; n++){
      var rotation = Quaternion.Euler(0f, 0f, flowersRotations[n]);
      var flower = Instantiate(flowerTemplate, flowersHandler.transform.position, rotation);
      flowers.Add(flower);
    }
  }

  void CenterFlowers(){
    foreach(var flower in flowers){
      flower.transform.position = flowersHandler.transform.position;
    }
  }

  void FinishOpenDoor(){
    state = "normal";
    RenderFigure();
  }

  void ActionTryOpenDoor(){
    state = "tryOpenDoor";
    RenderFigure();
    animator.SetTrigger("openDoor");
  }

  void ActionTryToPutFlowersInTheVase(){
    animator.SetTrigger("putFlowersinTheVase");
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
