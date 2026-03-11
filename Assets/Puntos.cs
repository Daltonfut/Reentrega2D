using TMPro;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    public static Puntos instance; // Instancia estática para acceder desde otras clases
    public TMP_Text textoPuntos; // Referencia al componente de texto para mostrar los puntos
    private int puntos;

    private void Awake()
    {
        instance = this; // Asigna la instancia en el método Awake para asegurar que esté disponible antes de Start
    }
    void Start()
    {
        puntos = 0; // Inicializa los puntos a 0
        textoPuntos.text = "0"; // Muestra los puntos iniciales en el texto
    }

   public void SumaPuntos()
    {
        puntos++;
        textoPuntos.text=puntos.ToString(); // Actualiza el texto con el nuevo valor de puntos
    }
}
