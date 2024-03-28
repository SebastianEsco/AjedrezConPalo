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
        Debug.Log("Ta encima");
    }

    private void OnMouseExit()
    {
        encima = false;
        Debug.Log("No Ta encima");
    }


    public void Desactivar()
    {
        guia1.SetActive(false);
        guia2.SetActive(false);
        guia3.SetActive(false);
        guia4.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(movimiento)
        {
            transform.position = new Vector2(peon.Mover()[0], peon.Mover()[1]);
            primerMovimiento = false;
            movimiento = false;
            Desactivar();
        }
    }

    void Activar()
    {
        if (primerMovimiento)
        {
            guia2.SetActive(true);
        }
<<<<<<< HEAD

        if (inicializador.HabilitacionDeComerPeon(peon)[0]) //Derecha
        {
            comerDerecha = true;
            guia3.SetActive(true);
        }

        if (inicializador.HabilitacionDeComerPeon(peon)[1]) //izquierda
        {
            guia4.SetActive(true);
            comerIzquierda = true;
        }
        



=======
        guia1.SetActive(true);
>>>>>>> parent of b979e2a (Melo los movimientos de los peon, falta que coman)
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
