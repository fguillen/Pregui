
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreguiGetInHouseController : MonoBehaviour
{
  public static PreguiGetInHouseController instance;
  public GameObject pregui;
  public SpriteRenderer houseBack;
  public SpriteRenderer houseFront;
  public GameObject position1;
  public GameObject position2;
  public float secondsToPosition1;
  public float secondsToPosition2;
  private string state;

  void Awake () {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
    state = "idle";
  }

  // Update is called once per frame
  void Update()
  {
    if(state == "towardsPosition1") {
      float nextX = Mathf.MoveTowards(pregui.transform.position.x, position1.transform.position.x, secondsToPosition1 * Time.deltaTime);
      float nextY = Mathf.MoveTowards(pregui.transform.position.y, position1.transform.position.y, secondsToPosition1 * Time.deltaTime);
      pregui.transform.position = new Vector3(nextX, nextY, pregui.transform.position.z);

      if(Vector3.Distance(pregui.transform.position, position1.transform.position) < 0.01f) {
        state = "towardsPosition2";
      }
    }

    if(state == "towardsPosition2") {
      pregui.transform.localScale = new Vector3(-1f, 1f, 1f);
      float nextX = Mathf.MoveTowards(pregui.transform.position.x, position2.transform.position.x, secondsToPosition1 * Time.deltaTime);
      float nextY = Mathf.MoveTowards(pregui.transform.position.y, position2.transform.position.y, secondsToPosition1 * Time.deltaTime);
      pregui.transform.position = new Vector3(nextX, nextY, pregui.transform.position.z);

      if(Vector3.Distance(pregui.transform.position, position2.transform.position) < 0.01f) {
        state = "towardsPosition3";
      }
    }

    if(state == "towardsPosition3") {
      pregui.transform.localScale = new Vector3(1f, 1f, 1f);;
      CanvasController.instance.LoadSceneInHouse();
    }
  }

  void OrderSpriteRenders(){
    int houseBackOrder = houseBack.sortingOrder;
    Debug.Log("OrderSpriteRenders.SortingOrderStartingFrom");
    SpriteRenderOrderSystem.SortingOrderStartingFrom(pregui, houseBackOrder + 1);
    int preguiMaxOrder = SpriteRenderOrderSystem.MaxSortingOrder(pregui);

    PreguiForestController.instance.RenderOrderFlowers();

    Debug.Log("houseBackOrder: " + houseBackOrder);
    Debug.Log("preguiMaxOrder: " + preguiMaxOrder);

    houseFront.sortingOrder = preguiMaxOrder + 1;
  }

  public void PreguiGetInHouseAnimation(){
    Debug.Log("PreguiGetInHouseAnimation");
    OrderSpriteRenders();
    state = "towardsPosition1";
  }
}
