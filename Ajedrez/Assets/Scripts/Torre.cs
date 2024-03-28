using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : Pieza
{
    public Torre (float color, int valor, float fila, float columna) : base(color, valor, fila, columna)
    {

    }
    public float[] Mover(int cantidad, bool horizontal)
    {

        if (horizontal)
        {
            posicion[1] += 1 * color * cantidad;
        }
        else
        {
            posicion[0] += 1 * color * cantidad;
        }



        return posicion;


    }

}
