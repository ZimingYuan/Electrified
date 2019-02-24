using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChoose : MonoBehaviour {
    public void Level1_1() {
        SceneManager.LoadScene("Level1-1");
    }
    public void Level1_2() {
        SceneManager.LoadScene("Level1-2");
    }
    public void Level1_3() {
        SceneManager.LoadScene("Level1-3");
    }
    public void Level1_4()
    {
        SceneManager.LoadScene(5);
    }
}
