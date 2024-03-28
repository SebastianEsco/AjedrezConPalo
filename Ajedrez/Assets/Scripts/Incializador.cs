using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;

public class Incializador : MonoBehaviour
{
    public GameObject[] piezas = new GameObject[32];
    ObjetoPieza[] scriptPieza = new ObjetoPieza[32];

    private void Start()
    {
        for (int i = 0; i < 16; i++)
        {
            if (piezas[i] != null)
            {
                scriptPieza[i] = piezas[i].GetComponent<ObjetoPieza>();
            }
        }
    }

    public void DesactivacionMasiva()
    {
        for (int i = 0; i < piezas.Length; i++)
        {
            if (scriptPieza[i] != null)
            {
                scriptPieza[i].Desactivar();
            }
        }
    }

    private void OnMouseDown()
    {
        DesactivacionMasiva();
    }

    public int HabilitacionDeMovimientoVertical(Pieza pieza)
    {

        //BLANCAS AL LIMITE
        if(pieza.color == 1)
        {
            if(pieza.posicion[1] == 4)
            {
                return 0;
            }
            
            
        }

        //NEGRAS AL LIMITE
        if(pieza.color == -1 )
        {
            if(pieza.posicion[1] == -3)
            {
                return 0;
            }
            
            
        }


        for (int i = 0; i < 32; i++)
        {
            if (piezas[i] != null)
            {
                if (pieza.posicion[1] + 1f == piezas[i].transform.position.y)
                {
                    return 0;
                }
            }
        }
        for (int i = 0; i < 32; i++)
        {
            if (piezas[i] != null)
            {
                if (pieza.posicion[1] + 2f == piezas[i].transform.position.y)
                {
                    return 1;
                }
            }
        }
        return 2;

    }

    public bool[] HabilitacionDeComerPeon(Pieza pieza)
    {
        bool[] comer = new bool[2]; //[0] es si puede comer a la derecha y [1] a la izquierda

        for (int i = 0; i < 32; i++) 
        {
            if (piezas[i] != null)
            {
                if (pieza.posicion[1] + 1f == piezas[i].transform.position.y) //si está a una casilla de distancia hacia delante
                {
                    if (pieza.color != scriptPieza[i].color) //si es del otro color
                    {
                        if (pieza.posicion[0] + 1f == piezas[i].transform.position.x) //si está a la derecha
                        {
                            comer[0] = true;
                        }

                        if (pieza.posicion[0] - 1f == piezas[i].transform.position.x)
                        {
                            comer[1] = true; 
                        }
                    }
                    
                }
            }
        }
        return comer;
    }

    public void FichaComida(GameObject fichaQueCome)
    {
        for (int i = 0; i < 32; i++)
        {
            if (piezas[i] != null)
            {
                Debug.Log("Lo intenta");
                Debug.Log(fichaQueCome.transform.position.x + " Vs " + piezas[i].transform.position.x);
                if (fichaQueCome != piezas[i])
                {
                    if (fichaQueCome.transform.position == piezas[i].transform.position)
                    {
                        Destroy(piezas[i]);
                    }
                }
                
            }
        }
    }
}
