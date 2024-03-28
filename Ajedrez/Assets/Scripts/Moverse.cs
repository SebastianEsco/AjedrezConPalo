using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moverse : MonoBehaviour
{
    public int cantidad;
    public bool[] comer = new bool [2];
    ObjetoPieza scriptPieza;
    public GameObject pieza;
    void Start()
    {
        scriptPieza = pieza.GetComponent<ObjetoPieza>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        scriptPieza.MovimientoPeon(cantidad, comer);
    }
}
