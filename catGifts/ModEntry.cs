﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Menus;
using Microsoft.Xna.Framework.Graphics;

namespace catGifts
{
    public class ModEntry : Mod
    {
        private List<int> lowGifts;
        private List<int> midGifts;
        private List<int> hiGifts;
        private int giftsGiven = 0;
        private bool highTierYesterday = false;

        public override void Entry(IModHelper helper)
        {
            // Initialize gift lits
            lowGifts = new List<int>();
            midGifts = new List<int>();
            hiGifts = new List<int>();

            for(int i=0; i<803; i++)
            {
                switch(i)
                {
                    case 152:
                    case 153:
                    case 167:
                    case 168:
                    case 169:
                    case 171:
                    case 172:                    
                    case 309:
                    case 310:
                    case 311:                    
                    case 344:
                    case 372:
                    case 382:
                    case 388:
                    case 390:                                                            
                    case 404:                                                                                
                    case 684:
                    case 685:
                    case 702:
                    case 718:
                    case 719:
                    case 721:
                    case 722:
                    case 766:
                    case 767:
                        lowGifts.Add(i);
                        break;

                    case 296: // Spring
                    case 399: // Spring
                        if(Game1.currentSeason.Equals("Spring"))
                            lowGifts.Add(i);
                        break;

                    case 396: // Summer
                    case 406: // Summer
                        if (Game1.currentSeason.Equals("Summer"))
                            lowGifts.Add(i);
                        break;

                    case 408: // Fall
                    case 410: // Fall
                        if (Game1.currentSeason.Equals("Fall"))
                            lowGifts.Add(i);
                        break;

                    case 412: // Winter
                    case 416: // Winter
                        if (Game1.currentSeason.Equals("Winter"))
                            lowGifts.Add(i);
                        break;
                                            
                    case 78:
                    case 129:                    
                    case 131:
                    case 132:
                    case 142:
                    case 144:
                    case 145:
                    case 157:
                    case 174:
                    case 176:
                    case 180:
                    case 182:
                    case 340:
                    case 393:                    
                    case 420:
                    case 421:
                    case 422:                                        
                    case 440:
                    case 442:
                    case 444:                    
                    case 535:
                    case 634:
                    case 635:
                    case 636:
                    case 637:
                    case 638:
                    case 716:
                    case 717:
                    case 720:
                    case 723:
                    case 774:                    
                        midGifts.Add(i);
                        break;

                    case 16: // Spring
                    case 18: // Spring
                    case 20: // Spring
                    case 22: // Spring
                    case 427: // Spring
                    case 429: // Spring
                    case 472: // Spring
                    case 473: // Spring
                    case 474: // Spring
                    case 475: // Spring
                    case 476: // Spring
                    case 477: // Spring
                    case 478: // Spring
                    case 495: // Spring
                        if(Game1.currentSeason.Equals("Spring"))
                            midGifts.Add(i);
                        break;

                    case 453: // Summer
                    case 455: // Summer
                    case 302: // Summer                    
                    case 479: // Summer
                    case 480: // Summer
                    case 481: // Summer
                    case 482: // Summer
                    case 483: // Summer
                    case 484: // Summer
                    case 485: // Summer
                    case 496: // Summer
                        if (Game1.currentSeason.Equals("Summer"))
                            midGifts.Add(i);
                        break;

                    case 299: // Fall
                    case 301: // Fall
                    case 488: // Fall
                    case 489: // Fall
                    case 490: // Fall
                    case 491: // Fall
                    case 492: // Fall
                    case 493: // Fall
                    case 494: // Fall                    
                    case 497: // Fall
                        if (Game1.currentSeason.Equals("Fall"))
                            midGifts.Add(i);
                        break;

                    case 431: // Summer/Fall
                    case 487: // Summer/Fall  
                        if (Game1.currentSeason.Equals("Summer") || Game1.currentSeason.Equals("Fall"))
                            midGifts.Add(i);
                        break;

                    case 414: // Winter
                    case 498: // Winter
                        if (Game1.currentSeason.Equals("Winter"))
                            midGifts.Add(i);
                        break;

                    case 60:
                    case 62:
                    case 64:
                    case 66:
                    case 68:
                    case 70:
                    case 72:
                    case 80:
                    case 86:
                    case 103:
                    case 198:
                    case 202:
                    case 209:
                    case 212:
                    case 213:
                    case 219:
                    case 225:
                    case 226:
                    case 227:
                    case 228:
                    case 242:
                    case 305:
                    case 446:                                        
                        hiGifts.Add(i);
                        break;

                    case 433: // Spring / Summer
                        if (Game1.currentSeason.Equals("Spring") || Game1.currentSeason.Equals("Summer"))
                            midGifts.Add(i);
                        break;

                    case 425: // Fall
                        if (Game1.currentSeason.Equals("Fall"))
                            midGifts.Add(i);
                        break;
                }
            }
                        
            TimeEvents.AfterDayStarted += this.AfterDayStarted;
        }

        public void AfterDayStarted(object sender, EventArgs e)
        {
            bool hasCat = false;
            StardewValley.Characters.Pet theCat = null;

            // Look for a cat
            foreach(NPC pet in Game1.getLocationFromName("Farm").getCharacters())
            {
                if(pet is StardewValley.Characters.Cat)
                {
                    this.Monitor.Log("Player has a cat (on farm).");
                    hasCat = true;
                    theCat = (StardewValley.Characters.Pet)pet;
                }
            }
            foreach(NPC pet in Game1.getLocationFromName("FarmHouse").getCharacters())
            {
                if(pet is StardewValley.Characters.Cat)
                {
                    this.Monitor.Log("Player has a cat (in house).");
                    hasCat = true;
                    theCat = (StardewValley.Characters.Pet)pet;
                }
            }

            if (hasCat)
            {                
                this.Monitor.Log("Cat friendship: " + theCat.friendshipTowardFarmer);

                // Reset gifts given counter, max gifts per week -> 3
                if (Game1.dayOfMonth % 7 == 0)
                    giftsGiven = 0;

                int giftId = 0;

                // Draw a random gift ID. For clarity we do this in multiple steps
                // Step 1: Determine if cat gives a gift at all                
                // TODO: For now, use values as if the player has max friendship: Cat has 34% chance of giving a gift, ie. every three days, make customizable and/or change to fitting values
                if (Game1.random.Next(0, 100) >= 66 && !Game1.isRaining && giftsGiven <= 3)
                {
                    this.Monitor.Log("Cat will give a gift ... maybe :3");                    

                    // Step 2: Determine quality: low = mid > high -> 40% / 40% / 20%
                    int rand = Game1.random.Next(0, 100);

                    // Pick a random item
                    if (rand <= 40) {
                        this.Monitor.Log("Low quality");
                        giftId = lowGifts.ElementAt(Game1.random.Next(lowGifts.Count - 1));
                        highTierYesterday = false;
                    }
                    else if(rand > 40 && rand <= 80) {
                        this.Monitor.Log("Medium quality");
                        giftId = midGifts.ElementAt(Game1.random.Next(midGifts.Count - 1));
                        highTierYesterday = false;
                    }
                    else if(rand > 80 && !highTierYesterday) {
                        this.Monitor.Log("High quality! :3");
                        giftId = hiGifts.ElementAt(Game1.random.Next(hiGifts.Count - 1));
                        highTierYesterday = true;
                    }

                    // Spawn gift and move cat next to it
                    Game1.getLocationFromName("Farm").dropObject(new StardewValley.Object(giftId, 1, false, -1, 0), new Vector2(64, 16) * 64f, Game1.viewport, true, (Farmer)null);
                    // TODO: Fix
                    theCat.Position = new Vector2(64, 17) * 64f;
                    this.Monitor.Log("Object dropped!");

                    giftsGiven++;
                }
            }
            else
                this.Monitor.Log("Player doesn't have a cat.");

        }

    }
}
