using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript: MonoBehaviour
{
    public void LoadLevel(int lvlId)
    {
        SceneManager.LoadScene(lvlId);
    }

    public void DoAnim(GameObject gameObject)
    {
        gameObject.transform.DOScale(new Vector3(1.03f, 1.03f, 1.03f), 0.3f);
    }
    
    public void BackAnim(GameObject gameObject)
    {
        gameObject.transform.DOScale(new Vector3(1.0f, 1.0f, 1.0f), 0.1f);
    }
}
