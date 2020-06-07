using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpressionController : MonoBehaviour
{
  public Animator animator;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

    if(Random.Range(1, 50) == 1)
    {
      // Change expression
      var random = (int)Mathf.Round(Random.Range(1, 4));
      animator.SetInteger("expression", random);
    }
  }
}
