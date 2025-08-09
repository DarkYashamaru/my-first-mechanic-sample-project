using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerVelocity
{
    public Vector3 Velocidad { get;}
    public Vector3 Axis { get;}
    public float Gravedad { get; }
    public float Velocidad_Salto { get; }
    public float Velocidad_Movimiento { get; }
    public bool Grounded { get; }
}
