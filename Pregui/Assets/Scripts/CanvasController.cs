using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
  public static CanvasController instance;
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

  }

  private void WhiteFadeIn(){
    animator.SetTrigger("whiteFadeIn");
  }

  private void WhiteFadeOut(){
    animator.SetTrigger("whiteFadeOut");
  }

  public void LoadSceneForest() {
    nextScene = "Forest";
    WhiteFadeIn();
  }

  public void LoadSceneInHouse() {
    nextScene = "InHouse";
    WhiteFadeIn();
  }

  public void LoadNextScene(){
    SceneManager.LoadScene(nextScene);
  }
}
