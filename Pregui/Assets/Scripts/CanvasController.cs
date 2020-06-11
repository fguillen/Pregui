using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
  public static CanvasController instance;
  private Animator animator;
  private string nextScene;

  public GameObject menuScreens;

  void Awake() {
    instance = this;
    animator = gameObject.GetComponent<Animator>();
  }

  // Start is called before the first frame update
  void Start()
  {
    if(DataStorage.gameState == "init") {
      LoadSplash();
    } else {
      DeactivateScreens();
    }
  }

  // Update is called once per frame
  void Update()
  {
    // if(Input.GetKeyDown(KeyCode.M)) {
    //   LoadMenu();
    // }
  }

  private void DeactivateScreens() {
    menuScreens.SetActive(false);
    DataStorage.paused = false;
  }

  private void ActivateScreens() {
    menuScreens.SetActive(true);
  }

  private void WhiteFadeIn(){
    animator.SetTrigger("whiteFadeIn");
  }

  private void WhiteFadeOut(){
    animator.SetTrigger("whiteFadeOut");
  }

  public void LoadSceneForest() {
    DataStorage.gameState = "inForest";
    nextScene = "Forest";
    WhiteFadeIn();
  }

  public void LoadSceneInHouse() {
    DataStorage.gameState = "inHouse";
    nextScene = "InHouse";
    WhiteFadeIn();
  }

  public void LoadNextScene(){
    DeactivateScreens();
    DataStorage.paused = false;
    SceneManager.LoadScene(nextScene);
  }

  // Menu

  public void LoadCredits() {
    ActivateScreens();
    animator.SetTrigger("loadCredits");
  }

  public void ResetCredits() {
    CreditsController.instance.Reset();
  }

  public void LoadMenuFromSplash() {
    ActivateScreens();
    animator.SetTrigger("loadMenuFromSplash");
  }

  public void LoadMenu() {
    DataStorage.paused = true;
    ActivateScreens();
    animator.SetTrigger("loadMenu");
  }

  public void ResetMenu() {
    MenuController.instance.Reset();
  }

  public void LoadSplash() {
    ActivateScreens();
    animator.SetTrigger("loadSplash");
  }

  public void ButtonContinue() {
    DeactivateScreens();
  }

}
