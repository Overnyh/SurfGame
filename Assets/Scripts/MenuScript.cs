using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript: MonoBehaviour
{
    public void LoadLevel(int lvlId)
    {
        SceneManager.LoadScene(lvlId);
    }
}
