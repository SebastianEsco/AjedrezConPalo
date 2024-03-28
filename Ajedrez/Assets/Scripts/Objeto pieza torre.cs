using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class Objetopiezatorre : MonoBehaviour
{
    Torre torre;
    public GameObject tablero;
    public GameObject[] guiasArriba = new GameObject[7];
    public GameObject[] guiasAbajo = new GameObject[7];
    public GameObject[] guiasIzquierda = new GameObject[7];
    public GameObject[] guiasDerecha = new GameObject[7];
    Incializador inicializador;
    public float color;
    public bool movimiento;
    public float fila, columna;
    bool primerMovimiento = true;
    public bool encima;
    // Start is called before the first frame update
    void Start()
    {
        inicializador = tablero.GetComponent<Incializador>();
        for (int i = 0; i < guiasArriba.Length; i++)
        {
            guiasArriba[i].SetActive(false);
            guiasAbajo[i].SetActive(false);   
            guiasDerecha[i].SetActive(false);        
            guiasIzquierda[i].SetActive(false);        
        }
 
        torre = new Torre(color, 1, fila, columna);


        transform.position = new Vector2(torre.posicion[0], torre.posicion[1]);
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

    public void MovimientoTorre(int cantidad, bool[] comer)
    {
            float[] movimiento = torre.Mover(cantidad);
            transform.position = new Vector2(movimiento[0], movimiento[1]);
        
        Desactivar();
    }
    public void Desactivar()
    {
        for (int i = 0; i < guiasArriba.Length; i++)
        {
            guiasArriba[i].SetActive(false);
            guiasAbajo[i].SetActive(false);
            guiasDerecha[i].SetActive(false);
            guiasIzquierda[i].SetActive(false);
        }
    }
    void Activar()
    {
        float movimientosDeTorre = inicializador.HabilitacionDeMovimientoVertical(torre);

        if (movimientosDeTorre == 1 || movimientosDeTorre == 2)
        {
            guia1.SetActive(true);
        }
    }
}
