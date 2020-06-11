using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
  public static AudioController instance;

  public AudioSource pickupFlower;
  public AudioSource flowerBorn;
  public AudioSource grunt;
  public AudioSource music;
  public AudioSource openDoor;
  public AudioSource closeDoor;
  public AudioSource no;

  private void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
    PlayMusic();
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

  public void PlayGrunt()
  {
    grunt.Play();
  }

  public void PlayMusic()
  {
    music.Play();
  }

  public void PlayOpenDoor()
  {
    openDoor.Play();
  }

  public void PlayCloseDoor()
  {
    closeDoor.Play();
  }

  public void PlayNo()
  {
    no.Play();
  }

}
