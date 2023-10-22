using System.Collections.Generic;
using UnityEngine;

// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable StringLiteralTypo
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable CommentTypo
// ReSharper disable UseObjectOrCollectionInitializer

namespace LectureScripts.Generics
{
    public class GenericClassExamples
    {
        //Constructor
        public GenericClassExamples()
        {
            BetterList<int> integerList = new BetterList<int>();
            
            integerList.Add(1);
            integerList.Add(2);
            integerList.Add(3);
            
            int firstIntegerValue = integerList.GetFirst();
            int lastIntegerValue = integerList.GetLast();

            integerList.Swap(0, 2);


            BetterList<float> floatList = new BetterList<float>();
            BetterList<string> stringList = new BetterList<string>();
            BetterList<Transform> transformList = new BetterList<Transform>();




        }
    }

    public class FloatClass : GenericClass<float>
    {
        public FloatClass(float pInstance) : base(pInstance)
        {
            
        }

        public float Multiply(float pOtherFloat)
        {
            return _instance * pOtherFloat;
        }
    }
    
    //Wrapper class voor List<>
    public class BetterList<T>
    {
        protected List<T> _values;

        public void Add(T pValue)
        {
            _values.Add(pValue);
        }

        public T Get(int pIndex)
        {
            return _values[pIndex];
        }

        public T GetFirst()
        {
            return _values[0];
        }

        public T GetLast()
        {
            return _values[_values.Count - 1];
        }

        public void Swap(int pIndex1, int pIndex2)
        {
            T value1 = _values[pIndex1];
            T value2 = _values[pIndex2];

            _values[pIndex2] = value1;
            _values[pIndex1] = value2;
        }
    }
    
    
    
    
    
    public class GenericClass<T>
    {
        //Variables
        protected T _instance;
        protected T[] _instancesArray;
        protected List<T> _instancesList;

        //Functions
        public GenericClass(T pInstance)
        {
            _instance = pInstance;
        }

        public T GetInstance()
        {
            return _instance;
        }
    }
}