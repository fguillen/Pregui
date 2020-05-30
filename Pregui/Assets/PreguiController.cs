using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreguiController : MonoBehaviour
{
  public float velocity = 3f;
  public Vector2 direction;
  public Rigidbody2D theRB;
    
  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    direction = GetDirection();
    theRB.velocity = direction * velocity;
  }

  Vector2 GetDirection()
  {
    Vector2 result;

    if (Input.GetKey(KeyCode.LeftArrow)) {
      result = new Vector2(-1, 0);
    } else if (Input.GetKey(KeyCode.RightArrow))
    {
      result = new Vector2(1, 0);
    } else {
      result = Vector2.zero;
    }

    return result;
  }
}
