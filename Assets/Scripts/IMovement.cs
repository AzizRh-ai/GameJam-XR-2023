using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-----------------------------------------------
    -Filename    : IMovement
    -Description : Gestion des mouvements du player
    -Author      : ARH
    -Date        : lundi 30 janvier 2023
-----------------------------------------------*/

public interface IMovement
{
     void Move();
     float SpeedMovement { get; set;}

}
