using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

  public void LoadLevel(string levelName) {
    SceneManager.LoadScene(levelName);
  }

  public void LoadNextLevel() {

    // Indexes are set in build settings
    Application.LoadLevel(Application.loadedLevel + 1);
  }

  public void QuitRequest() {

    // Application.Quit(); is an anti-pattern on mobile
    // the application state should be managed by the OS and the User
    Application.Quit();
  }

}
