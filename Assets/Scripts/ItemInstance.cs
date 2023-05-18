using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts {
    public class ItemInstance {
        public ItemData itemType;

        public ItemInstance(ItemData itemData) {
            itemType = itemData;
        }
    }
}
