using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class HealingPotion : Item
    {
        public int AmountToHeal { get; set; }

        public HealingPotion(int id, string name, string namePlural, int amountToHeal) : base(id, name, namePlural)
        {
            AmountToHeal = amountToHeal;
        }

        public void HealPlayer (HealingPotion potion, Player player)
        {
            player.CurrenthitPoints = player.CurrenthitPoints + potion.AmountToHeal;

            if (player.CurrenthitPoints > player.MaximumHitPoints)
            {
                player.CurrenthitPoints = player.MaximumHitPoints;
            }

            // Remove the potion from the player's inventory
            foreach (InventoryItem ii in player.Inventory)
            {
                if (ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    break;
                }
            }
        }
    }
}
