using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class PersonController : TrungMonoBehaviour
{

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }



    #region Load Components

    //protected virtual void LoadCharacterController()
    //{
    //    if (this.controller != null) return;
    //    this.controller = GetComponent<CharacterController>();
    //}



    #endregion
}
