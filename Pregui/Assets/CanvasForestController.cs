using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasForestController : MonoBehaviour
{
  public static CanvasForestController instance;
  private Animator animator;
  private string nextScene;


  void Awake() {
    instance = this;
    animator = gameObject.GetComponent<Animator>();
  }

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    // if(Input.GetKeyDown(KeyCode.M)) {
    //   LoadMenu();
    // }
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
    Debug.Log("LoadSceneInHouse");
    DataStorage.gameState = "inHouse";
    nextScene = "InHouse";
    // WhiteFadeIn();
    SceneManager.LoadScene("inHouse");
  }

  public void LoadNextScene(){
    SceneManager.LoadScene(nextScene);
  }
}
