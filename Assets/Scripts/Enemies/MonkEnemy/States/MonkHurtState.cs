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

                    //Cuando el recibiminto de Da�o termine
                    return mController.HitFinalizado;
                },

                //Construccion del Sigueinte Estado, en caso se cumpla la validaci�n anterior
                getNextState: () => {

                    //Retornamos el Estado IDLE 
                    return new MonkIdleState(mController);

                }));
        }

        //-----------------------------------------------------
        // Desde aqui controlamos al NPC utilizando mController
        public override void OnEnter()
        {
            //Disparamos el Trigger para la Animacion de Da�o
            mController.MAnimator.SetTrigger("Hurt");
        }

        public override void OnExit()
        {

        }

        public override void OnUpdate(float deltaTime)
        {

        }
    }

}
