using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts {
    public class ItemInstance : MonoBehaviour {
        [SerializeField] private ItemData itemType;

        public ItemData ItemData { get => itemType; set => itemType = value; }

        public ItemInstance(ItemData itemData) {
            itemType = itemData;
        }
    }
}
