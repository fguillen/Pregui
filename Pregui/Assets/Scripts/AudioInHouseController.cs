using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInHouseController : MonoBehaviour
{
  public static AudioInHouseController instance;

  public AudioSource music;
  public AudioSource putFlowers;
  public AudioSource openDoor;
  public AudioSource closeDoor;

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

  public void PlayPutFlowers()
  {
    putFlowers.Play();
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

}
