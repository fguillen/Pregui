using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{
  public static CreditsController instance;

  public Button buttonBack;

  void Awake() {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKeyDown(KeyCode.Space)) {
      buttonBack.onClick.Invoke();
    }
  }

  public void Reset() {
    buttonBack.Select();
  }
}
