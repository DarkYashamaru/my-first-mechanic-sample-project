using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovimientoSimple : MonoBehaviour, IPlayerVelocity
{
    private CharacterController _controlador;
    public float velocidad_movimiento = 3;
    private Vector3 velocidad;

    private void Awake()
    {
        _controlador = GetComponent<CharacterController>();
    }

    void Update()
    {
        velocidad.x = Input.GetAxis("Horizontal") * velocidad_movimiento;

        _controlador.Move(velocidad * Time.deltaTime);
    }
















    public Vector3 Velocidad { get => velocidad; }
    public Vector3 Axis { get => velocidad; }
    public float Gravedad { get => 0; }
    public float Velocidad_Salto { get => 0; }
    public float Velocidad_Movimiento { get => velocidad_movimiento; }
    public bool Grounded { get => true; }
}
