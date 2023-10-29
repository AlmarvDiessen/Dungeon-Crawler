using UnityEngine;

#pragma warning disable CS0169

namespace LectureScripts.Constructor
{
    public class MonoBehaviourConstructor : MonoBehaviour
    {
        [SerializeField] private float _value1 = 1.0f;
        [SerializeField] private int _value2 = 255;
        [SerializeField] private Vector3 _value3 = new Vector3(1,2,3);

        private string _job;

        private void Awake()
        {
            //Dit werkt niet/mag niet van Unity
            //MonoBehaviour newBehaviour = new MonoBehaviour();

            //Unity verplicht je om components via de AddComponent<> functie toe te voegen.
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            ConstructorComponent constructorComponent = cube.AddComponent<ConstructorComponent>();
            constructorComponent.Initialize(1.0f, 255, new Vector3(1,2,3));
            constructorComponent.Initialize(_value1, _value2, _value3);
            
            //Dit zou een empty GameObject moeten maken met een <ConstructorComponent> eraan toegevoegd
            Instantiate(constructorComponent);
            
            
            
            //TODO EnemySpawnExample uittypen
        }

        private void Update()
        {
            //Dit gaan we niet meer doen!
            switch (_job)
            {
                case "Warrior":
                    //Warrior code
                    break;
                case "Mage":
                    //Mage code
                    break;
                case "Archer":
                    //Archer code
                    break;
            }
        }
    }
}
