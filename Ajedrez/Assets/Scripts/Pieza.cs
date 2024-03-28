using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza
{
    public float color;
    public int valor;
    public float[] posicion = new float[2];
    


    public Pieza(float color, int valor, float fila, float columna)
    {
        this.color = color;
        this.valor = valor;
        posicion[0] = fila;
        posicion[1] = columna;
    }

    public float[] IMover()
    {
        return posicion;
    }

    public void IComer()
    {

    }
}
