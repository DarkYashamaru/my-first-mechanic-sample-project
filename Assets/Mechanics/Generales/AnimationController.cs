using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private IPlayerVelocity _velocidad_jugador;
    private Animator _animator;

    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _velocidad_jugador = player.GetComponent<IPlayerVelocity>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _animator.SetFloat("YDirection", _velocidad_jugador.Velocidad.y > 0 ? 0 : 1, 0.2f, Time.deltaTime);
        _animator.SetFloat("XDirection", _velocidad_jugador.Axis.x, 0.1f, Time.deltaTime);

        _animator.SetBool("IsGrounded", _velocidad_jugador.Grounded);
    }
}
