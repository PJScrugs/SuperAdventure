﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public static class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int ITEM_ID_RUSTY_SWORD = 1;
        public const int ITEM_ID_RAT_TAIL = 2;
        public const int ITEM_ID_PIECE_OF_FUR = 3;
        public const int ITEM_ID_SNAKE_FANG = 4;
        public const int ITEM_ID_SNAKESKIN = 5;
        public const int ITEM_ID_CLUB = 6;
        public const int ITEM_ID_HEALING_POTION = 7;
        public const int ITEM_ID_SPIDER_FANG = 8;
        public const int ITEM_ID_SPIDER_SILK = 9;
        public const int ITEM_ID_ADVENTURER_PASS = 10;

        public const int MONSTER_ID_RAT = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_GIANT_SPIDER = 3;

        public const int QUEST_ID_CLEAR_ALCHEMIST_GARDEN = 1;
        public const int QUEST_ID_CLEAR_FARMERS_FIELD = 2;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN_SQUARE = 2;
        public const int LOCATION_ID_GUARD_POST = 3;
        public const int LOCATION_ID_ALCHEMIST_HUT = 4;
        public const int LOCATION_ID_HERB_GARDEN = 5;
        public const int LOCATION_ID_FARMHOUSE = 6;
        public const int LOCATION_ID_FARM_FIELD = 7;
        public const int LOCATION_ID_BRIDGE = 8;
        public const int LOCATION_ID_SPIDER_FIELD = 9;

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_RUSTY_SWORD, "Rusty Sword", "Rusty Swords", 0, 5));
            Items.Add(new Weapon(ITEM_ID_CLUB, "Club", "Clubs", 3, 10));
            Items.Add(new Item(ITEM_ID_RAT_TAIL, "Rat Tail", "Rat Tails"));
            Items.Add(new Item(ITEM_ID_PIECE_OF_FUR, "Piece of Fur", "Pieces of Fur"));
            Items.Add(new Item(ITEM_ID_SNAKE_FANG, "Snake Fang", "Snake Fangs"));
            Items.Add(new Item(ITEM_ID_SNAKESKIN, "Snakeskin", "Snakeskins"));
            Items.Add(new Item(ITEM_ID_SPIDER_FANG, "Spider Fang", "Spider Fangs"));
            Items.Add(new Item(ITEM_ID_SPIDER_SILK, "Spider Silk", "Spider Silks"));
            Items.Add(new Item(ITEM_ID_ADVENTURER_PASS, "Adventurer Pass", "Adventurer Passes"));
            Items.Add(new HealingPotion(ITEM_ID_HEALING_POTION, "Healing Potion", "Healing Potions", 5));
        }

        private static void PopulateMonsters()
        {
            Monster rat = new Monster(MONSTER_ID_RAT, "Rat", 5, 15, 10, 3, 3);
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RAT_TAIL), 75, false));
            rat.LootTable.Add(new LootItem(ItemByID(ITEM_ID_PIECE_OF_FUR), 75, true));

            Monster snake = new Monster(MONSTER_ID_SNAKE, "Snake", 5, 15, 10, 3, 3);
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKE_FANG), 75, false));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SNAKESKIN), 75, true));

            Monster giantSpider = new Monster(MONSTER_ID_GIANT_SPIDER, "Giant Spider", 20, 5, 40, 10, 10);
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_FANG), 75, true));
            giantSpider.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SPIDER_SILK), 25, false));

            Monsters.Add(rat);
            Monsters.Add(snake);
            Monsters.Add(giantSpider);
        }

        private static void PopulateQuests()
        {
            Quest clearAlchemistGarden = new Quest(QUEST_ID_CLEAR_ALCHEMIST_GARDEN, 
                "Clear the Alchemist's Garden", "Kill rats in the Alchemist's Garden and bring back 3 rat tails. " +
                "You will receive a healing potion and 10 gold pieces", 20, 10);
            clearAlchemistGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_RAT_TAIL), 3));
            clearAlchemistGarden.RewardItem = ItemByID(ITEM_ID_HEALING_POTION);

            Quest clearFarmersField = new Quest(QUEST_ID_CLEAR_FARMERS_FIELD, 
                "Clear the Farmer's Field", "Kill snakes in the farmer's field and bring back 3 snake fangs. " +
                "You will receive an Adventurer's Pass and 20 gold pieces.", 20, 20);
            clearFarmersField.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SNAKE_FANG), 3));
            clearFarmersField.RewardItem = ItemByID(ITEM_ID_ADVENTURER_PASS);

            Quests.Add(clearAlchemistGarden);
            Quests.Add(clearFarmersField);
        }

        private static void PopulateLocations()
        {
            string _homeMap = "C:/Users/elven/source/repos/SuperAdventure/Images/Map_Home.PNG";
            string _townSquareMap = "C:/Users/elven/source/repos/SuperAdventure/Images/Map_TownSquare.PNG";
            string _alchemistHutMap = "C:/Users/elven/source/repos/SuperAdventure/Images/Map_AlchemyHut.PNG";
            string _alchemistGardenMap = "C:/Users/elven/source/repos/SuperAdventure/Images/Map_AlchemistsGarden.PNG";
            string _farmHouseMap = "C:/Users/elven/source/repos/SuperAdventure/Images/Map_FarmHouse.PNG";
            string _farmersFieldMap = "C:/Users/elven/source/repos/SuperAdventure/Images/Map_Fields.PNG";
            string _guardPostMap = "C:/Users/elven/source/repos/SuperAdventure/Images/Map_GuardHouse.PNG";
            string _brigeMap = "C:/Users/elven/source/repos/SuperAdventure/Images/Map_Bridge.PNG";
            string _spiderField = "C:/Users/elven/source/repos/SuperAdventure/Images/Map_SpiderForest.PNG";

            Location home = new Location(LOCATION_ID_HOME, "Home", 
                "Your house. You really need to clean up the place...", 
                _homeMap);

            Location townSquare = new Location(LOCATION_ID_TOWN_SQUARE, "Town Square", 
                "You see a nice fountain in the middle.",
                _townSquareMap);

            Location alchemistHut = new Location(LOCATION_ID_ALCHEMIST_HUT, "Alchemist's Hut", 
                "There are many strange plants on the shelves.",
                _alchemistHutMap);
            alchemistHut.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_ALCHEMIST_GARDEN);

            Location alchemistGarden = new Location(LOCATION_ID_HERB_GARDEN, "Herb Garden",
                "Many plants are growing here.",
                _alchemistGardenMap);
            alchemistGarden.MonsterLivingHere = MonsterByID(MONSTER_ID_RAT);

            Location farmhouse = new Location(LOCATION_ID_FARMHOUSE, "Farmhouse",
                "There is a small farmhouse, with a farmer in front",
                _farmHouseMap);
            farmhouse.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_FARMERS_FIELD);

            Location farmersField = new Location(LOCATION_ID_FARM_FIELD, "Farmer's Field",
                "You see rows of vegetables growing here.",
                _farmersFieldMap);
            farmersField.MonsterLivingHere = MonsterByID(MONSTER_ID_SNAKE);

            Location guardPost = new Location(LOCATION_ID_GUARD_POST, "Guard Post",
                "There is a large, tough-looking guard here.",
                _guardPostMap,
                ItemByID(ITEM_ID_ADVENTURER_PASS));

            Location bridge = new Location(LOCATION_ID_BRIDGE, "Bridge",
                "A stone bridge crosses a wide river.",
                _brigeMap);

            Location spiderField = new Location(LOCATION_ID_SPIDER_FIELD, "Forest",
                "You see spider webs covering the trees in this forst.",
                _spiderField);
            spiderField.MonsterLivingHere = MonsterByID(MONSTER_ID_GIANT_SPIDER);

            //Link the locations togeather
            home.LocationToNorth = townSquare;

            townSquare.LocationToNorth = alchemistHut;
            townSquare.LocationToSouth = home;
            townSquare.LocationToEast = guardPost;
            townSquare.LocationToWest = farmhouse;

            farmhouse.LocationToEast = townSquare;
            farmhouse.LocationToWest = farmersField;

            farmersField.LocationToEast = farmhouse;

            alchemistHut.LocationToSouth = townSquare;
            alchemistHut.LocationToNorth = alchemistGarden;

            alchemistGarden.LocationToSouth = alchemistHut;

            guardPost.LocationToEast = bridge;
            guardPost.LocationToWest = townSquare;

            bridge.LocationToWest = guardPost;
            bridge.LocationToEast = spiderField;

            spiderField.LocationToWest = bridge;

            //add the locations to the static list
            Locations.Add(home);
            Locations.Add(townSquare);
            Locations.Add(guardPost);
            Locations.Add(alchemistHut);
            Locations.Add(alchemistGarden);
            Locations.Add(farmhouse);
            Locations.Add(farmersField);
            Locations.Add(bridge);
            Locations.Add(spiderField);
        }

        public static Item ItemByID(int id)
        {
            foreach(Item item in Items)
            {
                if(item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach(Monster monster in Monsters)
            {
                if(monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach(Quest quest in Quests)
            {
                if(quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }
        public static Location LocationByID(int id)
        {
            foreach(Location location in Locations)
            {
                if(location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}