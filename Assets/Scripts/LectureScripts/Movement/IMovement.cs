using UnityEngine;

namespace LectureScripts.Movement
{
    public interface IMovement
    {
        //Properties
        float MovementSpeed { get; }
        
        //Functions
        void Move(Vector3 pDirection);
    }

    // public interface IInterfaceErrorsExample
    // {
    //     //Variable
    //     GameObject[] objects;
    //     
    //     //Properties
    //     private GameObject ObjectToSpawn { get; set; }
    //     protected int SpawnedObjects { get; }
    //     
    //     //Functions
    //     void DestroyObject(GameObject pObject);
    //
    //     void SpawnObject(Vector3 pLocation, int pSpawnCount)
    //     {
    //         //Error
    //     }
    // }
}