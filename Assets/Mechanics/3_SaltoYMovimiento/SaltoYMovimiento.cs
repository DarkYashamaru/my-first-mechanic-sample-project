using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SaltoYMovimiento : MonoBehaviour, IPlayerVelocity
{
    private CharacterController _controlador;
    public float velocidad_movimiento = 3;
    public float velocidad_salto = 6;
    public float gravedad = 9.8f;
    public float multiplicador_gravedad = 1;
    private Vector3 velocidad;

    private void Awake()
    {
        _controlador = GetComponent<CharacterController>();
    }

    void Update()
    {
        velocidad.x = Input.GetAxis("Horizontal") * velocidad_movimiento;

        if (_controlador.isGrounded)
        {
            if(velocidad.y < 0)
                velocidad.y = -1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocidad.y = velocidad_salto;
            }  
        }
        else 
        {
            velocidad.y -= gravedad * multiplicador_gravedad * Time.deltaTime;
        }

        _controlador.Move(velocidad * Time.deltaTime);
    }










    public Vector3 Velocidad { get => velocidad; }
    public float Gravedad { get => gravedad; }
    public float Velocidad_Salto { get => velocidad_salto; }
    public float Velocidad_Movimiento { get => velocidad_movimiento; }
    public bool Grounded { get => _controlador.isGrounded; }
}
