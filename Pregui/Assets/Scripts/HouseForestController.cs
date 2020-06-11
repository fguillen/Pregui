﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseForestController : MonoBehaviour
{
  private string state;
  public GameObject doorHandler;
  public GameObject pregui;
  public GameObject bottomHandler;
  private Animator animator;

  void Awake() {
    state = "doorOpen";
    animator = gameObject.GetComponent<Animator>();
  }

  // Start is called before the first frame update
  void Start()
  {
    SpriteRenderOrderSystem.instance.Order(gameObject, bottomHandler);
  }

  // Update is called once per frame
  void Update()
  {
    CheckDoorStatus();
  }

  void CheckDoorStatus() {
    if(state == "doorClosed" && DistanceWithPregui() < 0.5f) {
      OpenDoor();
    }

    if(state == "doorOpen" && DistanceWithPregui() > 0.5f) {
      CloseDoor();
    }
  }

  void CloseDoor() {
    AudioController.instance.PlayCloseDoor();
    animator.SetBool("doorClosed", true);
    state = "doorClosed";
  }

  void OpenDoor() {
    AudioController.instance.PlayOpenDoor();
    animator.SetBool("doorClosed", false);
    state = "doorOpen";
  }

  float DistanceWithPregui(){
    float distance = Vector3.Distance(doorHandler.transform.position, pregui.transform.position);
    return distance;
  }
}
