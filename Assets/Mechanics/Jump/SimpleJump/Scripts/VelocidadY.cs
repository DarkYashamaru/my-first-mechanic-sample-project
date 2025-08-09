using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VelocidadY : MonoBehaviour
{
    private IPlayerVelocity _velocidad_jugador;
    public TextMeshProUGUI texto_velocidad;
    public TextMeshProUGUI texto_vector;
    public Image vector_positivo;
    public Image vector_negativo;
    private float _initial_height;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _velocidad_jugador = player.GetComponent<IPlayerVelocity>();
        _initial_height = vector_positivo.rectTransform.sizeDelta.y;
    }

    void Update()
    {
        texto_velocidad.text = _velocidad_jugador.Velocidad.y.ToString("F2");
        texto_vector.text = $"{_velocidad_jugador.Velocidad.x.ToString("F2")}, {_velocidad_jugador.Velocidad.y.ToString("F2")}, {_velocidad_jugador.Velocidad.z.ToString("F2")}";

        float yValue = (_velocidad_jugador.Velocidad.y / _velocidad_jugador.Velocidad_Salto) * _initial_height;

        Vector2 positivo = vector_positivo.rectTransform.sizeDelta;
        positivo.y = yValue;
        vector_positivo.rectTransform.sizeDelta = positivo;

        Vector2 negativo = vector_negativo.rectTransform.sizeDelta;
        negativo.y = -yValue;
        vector_negativo.rectTransform.sizeDelta = negativo;
    }
}
