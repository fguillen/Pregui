using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
  public static CanvasController instance;
  private Animator animator;

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

  public void WhiteFadeIn(){
    animator.SetTrigger("whiteFadeIn");
  }

  public void WhiteFadeOut(){
    animator.SetTrigger("whiteFadeOut");
  }

  public void LoadSceneForest() {
    SceneManager.LoadScene("Forest");
  }
}
