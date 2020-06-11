using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForestController : MonoBehaviour
{
  public GameObject pregui;
  private float maxDistantToPreguiX = 6f;
  private float maxDistantToPreguiY = 2f;
  private float cameraVelocity = 0.01f;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    float preguiDistantX = Mathf.Abs(gameObject.transform.position.x - pregui.transform.position.x);
    float preguiDistantY = Mathf.Abs(gameObject.transform.position.y - pregui.transform.position.y);

    Debug.Log("preguiDistantX: " + preguiDistantX);
    Debug.Log("preguiDistantY: " + preguiDistantY);

    if(preguiDistantX > maxDistantToPreguiX) {
      gameObject.transform.position = new Vector3(Mathf.MoveTowards(gameObject.transform.position.x, pregui.transform.position.x, cameraVelocity), gameObject.transform.position.y, gameObject.transform.position.z);
    }

    if(preguiDistantY > maxDistantToPreguiY) {
      gameObject.transform.position = new Vector3(gameObject.transform.position.x, Mathf.MoveTowards(gameObject.transform.position.y, pregui.transform.position.y, cameraVelocity), gameObject.transform.position.z);
    }
  }
}
