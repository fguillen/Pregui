using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
  public static MenuController instance;

  public Button buttonStartNewGame;
  public Button buttonContinue;
  public Button buttonCredits;
  public Button buttonQuit;
  public int buttonSelected;
  public List<Button> buttons;

  void Awake (){
    instance = this;
    buttons = new List<Button>();
  }

  // Start is called before the first frame update
  void Start()
  {
    Reset();
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetKeyDown(KeyCode.DownArrow)) {
      buttonSelected ++;
      if(buttonSelected >= buttons.Count) {
        buttonSelected = buttons.Count - 1;
      }

      Debug.Log("buttonSelected: " + buttonSelected);
    }

    if(Input.GetKeyDown(KeyCode.UpArrow)) {
      buttonSelected --;
      if(buttonSelected < 0) {
        buttonSelected = 0;
      }

      Debug.Log("buttonSelected: " + buttonSelected);
    }

    SelectButton();

    if(Input.GetKeyDown(KeyCode.Space)) {
      buttons[buttonSelected].onClick.Invoke();;
    }
  }

  void SelectButton(){
    for(int n = 0; n < buttons.Count; n++) {
      if(n == buttonSelected) {
        buttons[n].Select();
      }
    }
  }

  public void Reset() {
    Debug.Log("MenuController.Reset()");

    buttons.Clear();

    if(DataStorage.gameState == "init") {
      buttonStartNewGame.gameObject.SetActive(true);
      buttonContinue.gameObject.SetActive(false);
      buttons.Add(buttonStartNewGame);
    } else {
      buttonStartNewGame.gameObject.SetActive(false);
      buttonContinue.gameObject.SetActive(true);
      buttons.Add(buttonContinue);
    }

    buttons.Add(buttonCredits);
    buttons.Add(buttonQuit);

    buttonSelected = 0;

    SelectButton();
  }
}
