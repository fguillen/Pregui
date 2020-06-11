using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
  public GameObject seed;
  public GameObject flower;
  private float secondsToBorn;
  private string state;
  private Animator animator;

  // Start is called before the first frame update
  void Start()
  {
    animator = gameObject.GetComponent<Animator>();
    state = "unborn";
    flower.SetActive(false);
    secondsToBorn = Random.Range(5, 120);
    RenderOrder();
  }

  // Update is called once per frame
  void Update()
  {
    ShouldBorn();

    if(state == "unborn" && Random.Range(1, 50) == 1)
    {
      animator.SetTrigger("Bump");
    }
  }

  void ShouldBorn() {
    if(state == "unborn") {
      secondsToBorn -= Time.deltaTime;

      if(secondsToBorn <= 0){
        Born();
      }
    }
  }

  void RenderOrder() {
    SpriteRenderOrderSystem.instance.Order(gameObject);
  }

  void Born(){
    animator.SetTrigger("GiveBirth");
    state = "born";
  }

  void BornSound(){
    AudioController.instance.PlayFlowerBorn();
  }

  public void DeactivePickupCollider(){
    GetComponent<CircleCollider2D>().enabled = false;
  }
}
