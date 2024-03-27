using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieza
{
    public bool color;
    public int valor;
    public int[] posicion = new int[2];


    public Pieza(bool color, int valor, int fila, int columna)
    {
        this.color = color;
        this.valor = valor;
        posicion[0] = fila;
        posicion[1] = columna;
    }

    public void IMover()
    {

    }

    public void IComer()
    {

    }
}
