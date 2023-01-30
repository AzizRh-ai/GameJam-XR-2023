using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-----------------------------------------------
    -Filename    : PlayerController
    -Description : Gestion du player
    -Author      : ARH
    -Date        : lundi 30 janvier 2023
-----------------------------------------------*/

public class PlayerController : MonoBehaviour, IDamageable,IMovement
{
  
    public float SpeedMovement { get; set; }
    
    public void damage(int value)
    {
        // rajout des dégats 
        // TODO: Ajouter aussi l'interface pour les objets a détruire
    }


    public void Move()
    {
       // rajout des déplacements
       // TODO: Prendre en compte la vitesse de déplacement du player
       SpeedMovement = 10f;
    }

}
