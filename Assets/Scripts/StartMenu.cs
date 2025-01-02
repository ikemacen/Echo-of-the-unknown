using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    public Slider loadingBar; 
    public GameObject loadingScreen;
    public void PlayGame()
    {
        //StartCoroutine(LoadAsyncScene());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadAsyncScene()
    {
        loadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            loadingBar.value = operation.progress;

            if (operation.progress >= 0.9f)
            {
                loadingBar.value = 1f;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        loadingScreen.SetActive(false);
    }
}
