using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseForestController : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    SpriteRenderOrderSystem.instance.Order(gameObject);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
