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


            Transitions.Add(new FSMTransition<MonkEnemyController>(
                isValid: () => {

                    //Cuando ya no le quede vida
                    return mController.Vivo == false;
                },

                //Construccion del Sigueinte Estado, en caso se cumpla la validaci�n anterior
                getNextState: () => {

                    //Retornamos el Estado IDLE 
                    return new MonkDyingState(mController);

                }));
        }

        //-----------------------------------------------------
        // Desde aqui controlamos al NPC utilizando mController
        public override void OnEnter()
        {
            //Disparamos el Trigger para la Animacion de Da�o
            mController.MAnimator.SetTrigger("TakeHit");
        }

        public override void OnExit()
        {

        }

        public override void OnUpdate(float deltaTime)
        {
            ControlarOrientacionEnX();
        }

        //----------------------------------------------------------------------
        private void ControlarOrientacionEnX()
        {
            //Controlamos hacia donde estar� mirando el Jugador
            if (mController.Player.position.x < mController.transform.position.x)
            {
                mController.transform.localScale = new Vector3(
                    -1,
                    mController.transform.localScale.y,
                    mController.transform.localScale.z);

            }
            else
            {
                mController.transform.localScale = new Vector3(
                    1,
                    mController.transform.localScale.y,
                    mController.transform.localScale.z);

            }
        }
    }

}
