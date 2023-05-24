using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dado que Puedo utilizar la Maquina de Estados para muchos objetos; no solo
//NPCs, sino tambien Enemigos y Jugadores; viene bien asignarlos a un Namespace
//particular.
namespace Enemy
{
    //Heredamos de FSMState indicando el COMPONENTE(<T>) con el cual queremos que trabaje el Estado
    public class IdleState : FSMState<EnemyController>
    {
        //Generamos Constructor (en automatico) utilizando el Componente asociado
        public IdleState(EnemyController controller) : base(controller)
        {
            // A�adimos Transiciones a la lista de este Estado

            // Definimos la nueva Transicion utilizando su Constructor
            Transitions.Add(new FSMTransition<EnemyController>(
                
                // Funcion predicado cuya Logica me dice si ocurre o no la Transici�n
                isValid : () => {   // <-- Definici�n mediante LAMBDA

                    //Comprueba si la Distancia entre el Enemigo y
                    //el Player es la m�nima para despertar
                    return Vector3.Distance(
                        mController.transform.position,
                        mController.Player.transform.position
                    ) < mController.WakeDistance;
                },

                //Funcion que retorna el Sigueinte Estado, en casos e cumpla la validaci�n anterior
                getNextState : () => {  // <-- Definici�n mediante LAMBDA
                    
                    //Retornamos el EstadoMoving usando su Constructor
                    return new MovingState(mController);
                }
            ));

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

            // Definimos la nueva Transicion utilizando su Constructor
            Transitions.Add(new FSMTransition<EnemyController>(
                isValid : () => {   // <-- Definici�n mediante LAMBDA

                    //Comprueba si la Distancia entre el Enemigo y
                    //el Player es la m�nima para Atacar
                    return Vector3.Distance(
                        mController.transform.position,
                        mController.Player.transform.position
                    ) <= mController.AttackDistance;
                },

                //Funcion que retorna el Sigueinte Estado, en casos e cumpla la validaci�n anterior
                getNextState: () => {  // <-- Definici�n mediante LAMBDA
                    //Retornamos el EstadoAttacking usando su Constructor
                    return new AttackingState(mController);
                }
            ));
        }

        //**************************************************************************
        // IMPLEMENTACI�N DE M�TODOS ABSTRACTOS 

        public override void OnEnter()
        {
            Debug.Log("OnEnter IdleState");
            mController.animator.SetBool("IsMoving", false);
            mController.animator.SetFloat("Horizontal", 0f);
            mController.animator.SetFloat("Vertical", -1f);
            mController.AttackingEnd = false;
        }
        //-----------------------------------------------------
        public override void OnExit()
        {
            Debug.Log("OnExit IdleState");
        }
        //-------------------------------------------------------
        public override void OnUpdate(float deltaTime)
        {
        }

        
    }
    
}
