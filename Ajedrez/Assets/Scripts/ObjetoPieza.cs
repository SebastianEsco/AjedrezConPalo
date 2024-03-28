using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoPieza : MonoBehaviour
{
    // Start is called before the first frame update
    Peon peon;
    public GameObject guia1, guia2,guiaDerecha, guiaIzquierda, tablero;
    Incializador inicializador;
    public float color;
    public bool movimiento;
    public float fila, columna;
    bool primerMovimiento = true;
    public bool encima;
    void Start()
    {
        inicializador = tablero.GetComponent<Incializador>();
        guia1.SetActive(false);
        guia2.SetActive(false);
        guiaDerecha.SetActive(false);
        guiaIzquierda.SetActive(false);
        peon = new Peon(color, 1, fila, columna);

        transform.position = new Vector2(peon.posicion[0], peon.posicion[1]);
    }
    
    public void OnMouseDown()
    {
        inicializador.DesactivacionMasiva();
        Invoke("Activar", 0.1f);
    }

    private void OnMouseEnter()
    {
        encima = true;
    }

    private void OnMouseExit()
    {
        encima = false;
    }


    public void Desactivar()
    {
        guia1.SetActive(false);
        guia2.SetActive(false);
        guiaDerecha.SetActive(false);
        guiaIzquierda.SetActive(false);
    }
    

    public void MovimientoPeon(int cantidad, bool[] comer)
    {
        if (comer[0])
        {
            transform.position = new Vector2(peon.Mover(true)[0], peon.Mover(true)[1]);
        }
        else if (comer[1])
        {
            transform.position = new Vector2(peon.Mover(false)[0], peon.Mover(false)[1]);
        }
        else
        {
            transform.position = new Vector2(peon.Mover(cantidad)[0], peon.Mover(cantidad)[1]);
        }
        primerMovimiento = false;
        Desactivar();
    }

    void Activar()
    {
        float movimientosDelPeon = inicializador.HabilitacionDeMovimientoVertical(peon);
        bool[] ladoAComer = inicializador.HabilitarParaComer(peon);

        if (movimientosDelPeon == 1 || movimientosDelPeon == 2)
        {
            guia1.SetActive(true);
        }
        if (movimientosDelPeon == 2 && primerMovimiento)
        {
            guia2.SetActive(true);
        }

        if (ladoAComer[0]) //PONER QUE SI PUEDE COMER A LA DERECHA
        {
            guiaDerecha.SetActive(true);
        }

        if (ladoAComer[1]) //PONER QUE SI PUEDE COMER A LA Izquierda
        {
            guiaIzquierda.SetActive(true);
        }


    }
}
