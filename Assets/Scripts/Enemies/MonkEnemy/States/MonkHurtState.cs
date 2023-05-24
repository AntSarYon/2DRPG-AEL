using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonkEnemy
{
    public class MonkHurtState : FSMState<MonkEnemyController>
    {
        public MonkHurtState(MonkEnemyController controller) : base(controller)
        {
            //Ya se asign� el controlador y se cre� la Lista vacia de transiciones
            //Ahora corresponde crearlas y a�adirlas indicand el siguiente Estado

            Transitions.Add(new FSMTransition<MonkEnemyController>(
                isValid: () => {

                    //Condicion que debe cunplirse para efectuar la transicion
                    return true;
                },

                //Construccion del Sigueinte Estado, en caso se cumpla la validaci�n anterior
                getNextState: () => {

                    //Retornamos el EstadoMoving usando su Constructor, e ingresando el controller que asignamos
                    return new MonkMoveState(mController);

                }));
        }

        //-----------------------------------------------------
        // Desde aqui controlamos al NPC utilizando mController
        public override void OnEnter()
        {

        }

        public override void OnExit()
        {

        }

        public override void OnUpdate(float deltaTime)
        {

        }
    }

}
