using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    Button _titleButton;
    public void StartScene()
    {
        DontDestroyOnLoad(gameObject);
        _titleButton = transform.GetComponentInChildren<Button>();
        _titleButton.onClick.AddListener(()=> AsyncSceneChange().Forget());
    }
    private async UniTask AsyncSceneChange()
    {
        try
        {
            await UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("GameScene").ToUniTask();
            Debug.Log("Scene changed successfully");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to load scene: {e.Message}");
        }
        finally
        {
            //GameObject.Find("GameScene").GetComponent<GameScene>().StartScene();
            DestroyImmediate(gameObject);
        }
    }
}
