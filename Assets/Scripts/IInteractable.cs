using UnityEngine;

namespace Assets.Scripts {
    public interface IInteractable {
        void Interact(GameObject player);
        bool CanInteract(bool value);
    }
}
