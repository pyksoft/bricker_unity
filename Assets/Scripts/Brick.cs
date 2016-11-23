using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {



  public static int breakableCount = 0;
  public Sprite[] hitSprites;
  public AudioClip brickHitSound;
  public GameObject smoke;

  private GameObject smokePuff;
  private int timesHit;
  private LevelManager levelManager;
  private bool isBreakable;

 


  void Start() {
    isBreakable = (this.tag == "Breakable");

    if (isBreakable) {
      breakableCount++;
    }

    timesHit = 0;
    levelManager = GameObject.FindObjectOfType<LevelManager>();
   
  }


  void OnCollisionEnter2D(Collision2D collision) {
    if (isBreakable) {
      AudioSource.PlayClipAtPoint(brickHitSound, transform.position, 1f);
      HandleHits();
    }
  }


  void PuffSmoke() {
    
    GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;

    // Make puff smoke color as brick initial color
    // smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
  }

 
  void HandleHits() {
    timesHit++;
    int maxHits = hitSprites.Length + 1;

    if (timesHit >= maxHits) {
     
      PuffSmoke();

      breakableCount--;
      Destroy(gameObject);

      // Check level state
      levelManager.BrickDestroyed();
 
    } else {
      LoadSprites();
    }
  }

  void SimulateWin() {

    levelManager.LoadNextLevel();
  }

  void LoadSprites() {
    int spriteIndex = timesHit - 1;

    // change sprite to the one in hitSprites Array (See in Unity)

    if (hitSprites[spriteIndex]) {
      this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    } else {
      Debug.LogError("A Sprite is missing on a Brick");
    }
  }




}
