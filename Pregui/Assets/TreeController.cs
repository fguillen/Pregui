using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
  public Animator animator;

  void Awake() {
    animator = GetComponent<Animator>();
  }
  // Start is called before the first frame update
  void Start()
  {
    SpriteRenderOrderSystem.Order(gameObject);
  }

  // Update is called once per frame
  void Update()
  {
    if(Random.Range(1, 50) == 1)
    {
      // Change wind
      var random = (int)Mathf.Round(Random.Range(0, 2));
      animator.SetInteger("wind", random);
    }
  }
}
