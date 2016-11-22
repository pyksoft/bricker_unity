using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
  private static MusicPlayer instance = null;

 

  public static MusicPlayer Instance { 
    get { 
      return instance; 
    } 
  }

  void Awake() {
    if (instance != null && instance != this) {
      Destroy(this.gameObject);
      return;
    } else {
      instance = this;
      DontDestroyOnLoad(this.gameObject);
    }

  }

  //UNTESTED

  //  public bool canPlay;
  //
  //
  //  void PlayAudio(Audioclip clip) {
  //
  //    if (canPlay) {
  //      canPlay = false;
  //    }
  //
  //    GetComponent<AudioSource>().PlayOneShot(clip);
  //    StartCoroutine(Reset());
  //  }
  //
  //  IEnumerator Reset() {
  //    yield return new WaitForSeconds (.2f);
  //    canPlay = true;
  //  }

}
