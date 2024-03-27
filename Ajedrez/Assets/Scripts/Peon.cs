using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peon : Pieza
{
    public Peon(float color, int valor, float fila, float columna ) : base(color, valor, fila, columna)
    {

    }

    public float[] Mover(int cantidad)
    {

        posicion[1] += 0.5f * color * cantidad;

        return posicion;


    }

    

}
