using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(CharacterController))]
public class FuerzasTemporales : MonoBehaviour, IPlayerVelocity, IPlayerInteraction
{
    private CharacterController _controlador;
    public float velocidad_movimiento = 3;
    public float velocidad_salto = 6;
    public float gravedad = 9.8f;
    public float multiplicador_gravedad = 1;
    private Vector3 axis;
    private Vector3 velocidad_final;
    public Vector3 fuerzas_externas;
    public Vector3 fuerzas_temporales;
    public float velocidad_reduccion_fuerzas = 1;

    private void Awake()
    {
        _controlador = GetComponent<CharacterController>();
    }

    public void Empujar_Jugador(Vector3 fuerza)
    {
        fuerzas_temporales += fuerza;
    }

    void Update()
    {
        velocidad_final = Vector3.zero;

        axis.x = Input.GetAxis("Horizontal") * velocidad_movimiento;

        if (_controlador.isGrounded)
        {
            if(axis.y < 0)
                axis.y = -1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                axis.y = velocidad_salto;
            }  
        }
        else 
        {
            axis.y -= gravedad * multiplicador_gravedad * Time.deltaTime;
        }

        velocidad_final += axis;
        velocidad_final += fuerzas_externas;
        velocidad_final += fuerzas_temporales;

        fuerzas_temporales = Vector3.MoveTowards(fuerzas_temporales, Vector3.zero, velocidad_reduccion_fuerzas * Time.deltaTime);

        _controlador.Move(velocidad_final * Time.deltaTime);
    }

    public Vector3 Velocidad { get => velocidad_final; }
    public Vector3 Axis { get => axis; }
    public float Gravedad { get => gravedad; }
    public float Velocidad_Salto { get => velocidad_salto; }
    public float Velocidad_Movimiento { get => velocidad_movimiento; }
    public bool Grounded { get => _controlador.isGrounded; }
}
