using UnityEngine;

namespace LectureScripts
{
    public class OmniPlayer : MonoBehaviour
    {
        //Stats variables
        public int _health = 3;
        public int _mana = 10;
        public int defense = 5;

        //Inventory variables
        public Item[] _startingInventory;
        public int _inventorySize = 20;
        public int _gold = 100;

        //Movement variables
        public int _movementSpeed = 10;
        public int _jumpForce = 200;
        public int _jumpCount = 0;

        //Audio variables
        public AudioSource _damageSound;
        public AudioSource _jumpSound;
        public AudioSource _attackSound;
    }

    public class Item
    {
        private Item()
        {
            
        }
    }
}