using UnityEngine;

public class EmpujarJugador : MonoBehaviour
{
    public float fuerza_empuje = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            IPlayerInteraction interaction = other.GetComponent<IPlayerInteraction>();
            interaction.Empujar_Jugador(transform.forward * fuerza_empuje);
        }
    }
}
