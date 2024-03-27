using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjetoPieza : MonoBehaviour
{
    // Start is called before the first frame update
    Peon peon;
    public GameObject Peon;
    public GameObject guia1, guia2,guia3, guia4, tablero;
    Incializador inicializador;
    public float color;
    public bool movimiento;
    public float fila, columna;
    bool primerMovimiento = true;
    public bool encima;
    public bool comerIzquierda, comerDerecha;
    void Start()
    {
        inicializador = tablero.GetComponent<Incializador>();
        guia1.SetActive(false);
        guia2.SetActive(false);
        guia3.SetActive(false);
        guia4.SetActive(false);
        peon = new Peon(color, 1, fila, columna);

        transform.position = new Vector2(peon.posicion[0], peon.posicion[1]);
    }
    
    public void OnMouseDown()
    {
        Debug.Log("Click");
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
        guia3.SetActive(false);
        guia4.SetActive(false);
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

        if (inicializador.HabilitacionDeComerPeon(peon)[2]) //izquierda
        {
            guia4.SetActive(true);
            comerIzquierda = true;
        }
        if (inicializador.HabilitacionDeComerPeon(peon)[1]) //Derecha
        {
            comerDerecha= true;
            guia3.SetActive(true);
        }



    }

    public void Comer(bool derecha)
    {
        if (inicializador.HabilitacionDeComerPeon(peon)[1])
        {
            transform.position = new Vector2(peon.Comer(true)[0], peon.Comer(true)[1]); //comer a la derecha
            inicializador.FichaComida(Peon);
            Desactivar();
        }
        else if(inicializador.HabilitacionDeComerPeon(peon)[2])
        {
            transform.position = new Vector2(peon.Comer(false)[0], peon.Comer(false)[1]);
            inicializador.FichaComida(Peon);
            Desactivar();
        }
    }
    
}
