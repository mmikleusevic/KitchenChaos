using System;
using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            KitchenObject kitchenObject = KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);

            kitchenObject.SetKitchenObjectParent(player);

            OnPlayerGrabbedObject.Invoke(this, EventArgs.Empty);
        }
    }
}
