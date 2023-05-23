using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts {
    public class ItemInstance {
        private ItemData itemType;

        public ItemData ItemData { get => itemType; set => itemType = value; }

        public ItemInstance(ItemData itemData) {
            itemType = itemData;
        }
    }
}
