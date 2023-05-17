using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts {
    internal interface IInteractable {


        void Interact();

        bool CanInteract();
    }
}
