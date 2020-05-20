using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool gameHasEnded = false;

    public float restartDelay = 1f;

    public Camera camera1;
    public Material cameraMat1;

    public Camera camera2;
    public Material cameraMat2;








    private void Start()
    {

        //if (camera1.targetTexture != null)
        //{
        //    camera1.targetTexture.Release();
        //}

        //camera1.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        //cameraMat1.mainTexture = camera2.targetTexture;


        if (camera1.targetTexture != null)
        {
            camera1.targetTexture.Release();
        }

        camera1.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat1.mainTexture = camera1.targetTexture;


        if (camera2.targetTexture != null)
        {
            camera2.targetTexture.Release();
        }

        camera2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat2.mainTexture = camera2.targetTexture;


    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            //Debug.Log("GAME OVER !");

            Invoke("RestartGame", restartDelay);

        }

    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

