using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

  public void LoadLevel(string levelName) {
    SceneManager.LoadScene(levelName);
  }

  public void LoadNextLevel() {
    // Indexes are set in build settings
    int indexSC = SceneManager.GetActiveScene().buildIndex;
    int nextScene = indexSC + 1;
    SceneManager.LoadScene(nextScene);
  }

  public void QuitRequest() {

    // Application.Quit(); is an anti-pattern on mobile
    // the application state should be managed by the OS and the User
    Application.Quit();
  }


  public void BrickDestroyed() {
    if (Brick.breakableCount <= 0) {
      LoadNextLevel();
    }
  }
}
