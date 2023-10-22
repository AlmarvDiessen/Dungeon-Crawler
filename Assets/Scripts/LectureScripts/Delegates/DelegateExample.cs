using UnityEngine;


// ReSharper disable UseNullPropagation
// ReSharper disable InconsistentNaming
namespace LectureScripts.Delegates
{
    public class DelegateExample : MonoBehaviour
    {
        private delegate void PrintFunctions();

        private PrintFunctions _currentPrintFunction;

        private void Awake()
        {
            _currentPrintFunction = PrintFunctionA; //Delegate assignment
            _currentPrintFunction += PrintFunctionB; //Delegate subscription
            _currentPrintFunction -= PrintFunctionA; //Delegate unsubscription
            _currentPrintFunction(); //Delegate invocation
        }

        private void PrintFunctionA()
        {
            Debug.Log("PrintFunctionA");
        }

        private void PrintFunctionB()
        {
            Debug.Log("PrintFunctionB");
        }
    }
}