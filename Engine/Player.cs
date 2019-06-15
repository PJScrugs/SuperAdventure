using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level
        {
            get { return ((ExperiencePoints / 100) + 1); }
        }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
        public Location CurrentLocation { get; set; }

        public Player(int gold, int experiencePoints, int currentHitPoints, int maximumHitPoints) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;

            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        public int ComputePlayerLevel(int experiencePoints)
        {
            if(experiencePoints < 100)
            {
                return 1;
            }
            else if(experiencePoints < 250)
            {
                return 2;
            }
            else if (experiencePoints < 500)
            {
                return 3;
            }
            else if(experiencePoints < 1000)
            {
                return 4;
            }

            return 5; // Max level is 5
        }

        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if(location.ItemRequiredToEnter == null)
            {
                // there's no item required to enter
                return true;
            }

            // see if the player has the required in their inventory
            return Inventory.Exists(ii => ii.Details.ID == location.ItemRequiredToEnter.ID);
        }

        public bool HasThisQuest(Quest quest)
        {
            return Quests.Exists(pq => pq.Details.ID == quest.ID);
        }

        public bool CompetedThisQuest(Quest quest)
        {
            foreach(PlayerQuest playerQuest in Quests)
            {
                if(playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            //See if the player has all the items needed to complete the quest here
            foreach(QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;

                // Check each item int he player's inventory, to see if they have it, and enought of it
                foreach(InventoryItem ii in Inventory)
                {
                    // The player has the item in their inventory
                    if(ii.Details.ID == qci.Details.ID)
                    {
                        foundItemInPlayersInventory = true;

                        //The player does not have enough of this item to complete the quest
                        if(ii.Quantity < qci.Quantity)
                        {
                            return false;
                        }
                    }
                }

                //The player does not have any of this quest's competion items in their inventory
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }

            // If we got here, then the player must have all the required items and enough of them to complete the quest
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach(QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == qci.Details.ID);

                if(item != null)
                {
                    // subtract the quantity from the player's inventory that was needed to complete the quest
                    item.Quantity -= qci.Quantity;
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            InventoryItem item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);
            
            if(item == null)
            {
                // player didn't have the item so add one
                Inventory.Add(new InventoryItem(itemToAdd, 1));
            }
            else
            {
                // player has one, so add one=
                item.Quantity++;
            }
        }

        public void MarkQuestCompleted(Quest quest)
        {
            // find the quest in the plaery's quest list
            PlayerQuest playerQuest = Quests.SingleOrDefault(pq => pq.Details.ID == quest.ID);

            if(playerQuest != null)
            {
                playerQuest.IsCompleted = true;
            }
        }
    }
}
