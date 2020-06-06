using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
  public static AudioController instance;

  public AudioSource pickupFlower;
  public AudioSource flowerBorn;

  private void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void PlayPickupFlower()
  {
    pickupFlower.Play();
  }

  public void PlayFlowerBorn()
  {
    flowerBorn.Play();
  }

}
