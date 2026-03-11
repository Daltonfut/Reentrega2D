using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject PanelCreditos;
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Salir()
    {
        Application.Quit();
    }


    public void MostrarCreditos()
    {
        PanelCreditos.SetActive(true);
    }
    public void OcultarCreditos()
    {
        PanelCreditos.SetActive(false);
    }
}
