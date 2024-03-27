using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoPieza : MonoBehaviour
{
    // Start is called before the first frame update
    Peon peon;
    public GameObject guia1, guia2, tablero;
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
    }
    

    public void MovimientoPeon(int cantidad)
    {
        transform.position = new Vector2(peon.Mover(cantidad)[0], peon.Mover(cantidad)[1]);
        primerMovimiento = false;
        Desactivar();
    }

    void Activar()
    {
        if (inicializador.HabilitacionDeMovimientoVertical(peon) == 1 || inicializador.HabilitacionDeMovimientoVertical(peon) == 2)
        {
            guia1.SetActive(true);
        }
        if (inicializador.HabilitacionDeMovimientoVertical(peon) == 2 && primerMovimiento)
        {
            guia1.SetActive(true);
            guia2.SetActive(true);
        }
        
        
    }
}
