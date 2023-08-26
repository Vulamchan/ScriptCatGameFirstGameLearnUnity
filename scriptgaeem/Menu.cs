using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void BatDau()
    {
        SceneManager.LoadScene(1);

    }
    public void RaNgoaiMenu()
    {
        SceneManager.LoadScene(0 );
    }
    public void Thoat()
    {
        Application.Quit();
    }
}
