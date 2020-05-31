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

  void Awake() {
    direction = Vector2.zero;
    scale = new Vector3(1f, 1f, 1f);
    animator = gameObject.GetComponent<Animator>();
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
  }
}
