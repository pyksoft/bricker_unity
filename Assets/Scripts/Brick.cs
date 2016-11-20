﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

  public Sprite[] hitSprites;

  private int timesHit;
  private LevelManager levelManager;
  // Use this for initialization
  void Start() {
    levelManager = GameObject.FindObjectOfType<LevelManager>();

    timesHit = 0;
  }
	
  // Update is called once per frame
  void Update() {
	  
  }

  void OnCollisionEnter2D(Collision2D collision) {
    bool isBreakable = (this.tag == "Breakable");
    if (isBreakable) {
      HandleHits();
    }
  }


  void HandleHits() {
    timesHit++;
    int maxHits = hitSprites.Length + 1;

    if (timesHit >= maxHits) {
      Destroy(gameObject);
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
    }
  }

}
