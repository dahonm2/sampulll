using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public interface IChoices
    {
        string[] ethnicityChoice();
        string[] genderChoice();
        string[] bodyTypeChoice();
        string[] skinColorChoice();
        string[] hairStyleChoice();
        string[] hairColorChoice();
        string[] faceShapeChoice();
        string[] eyeShapeChoice();
        string[] eyeColorChoice();
        string[] clothesChoice();
        string[] pantsChoice();
        string[] shoesChoice();
        string[] accessoriesChoice();
        string[] personalVehicleChoice();
        string[] vehicleColorChoice();
        string[] mountChoice();
        string[] starterPackChoice();
        string[] rolesChoice();
        string[] skillsChoice();

    }
    class Choices : IChoices
    {
        public string[] ethnicityChoice()
        {
            return new string[] { "ELF", "DARK ELF", "ORC", "ANGEL", "DEMON", "DRACONIAN", "VAMPIRE", "DWARF", "HUMAN" };
        }
        public string[] genderChoice()
        {
            return new string[] { "SOLID LALAKE", "SOLID BABAE", "TAGILID" };
        }
        public string[] bodyTypeChoice()
        {
            return new string[] { "SKINNY", "AVERAGE", "BUFF", "BIG BUFF", "GRANDE BUFF (RONNIE COLEMAN)" };
        }
        public string[] skinColorChoice()
        {
            return new string[] { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET", "WHITE", "BLACK", "GRAY" };
        }
        public string[] hairStyleChoice()
        {
            return new string[] {
                "MOHAWK DREADLOCKS",
                "CASANOVA",
                "BUZZ CUT",
                "COCONUT HAIR",
                "PHOENIX HAIR",
                "BRAIDS",
                "PONYTAIL",
                "BOB CUT",
                "CORNCROWS",
                "TWIST"
            };
        }
        public string[] hairColorChoice()
        {
            return new string[] { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET", "WHITE", "BLACK", "GRAY" };
        }
        public string[] faceShapeChoice()
        {
            return new string[] {
                "FACE SHAPE 1 (TRIANGULAR)",
                "FACE SHAPE 2 (SQUARE)",
                "FACE SHAPE 3 (DIAMOND)",
                "FACE SHAPE 4 (OBLONG)",
                "FACE SHAPE 5 (HEART-SHAPED)",
                "FACE SHAPE 6 (CIRCLE)"
            };
        }
        public string[] eyeShapeChoice()
        {
            return new string[] {
                "EYE SHAPE 1 (MONOLID EYES)",
                "EYE SHAPE 2 (ALMOND EYES)",
                "EYE SHAPE 3 (CAT EYES)",
                "EYE SHAPE 4 (HUNTER EYES)",
                "EYE SHAPE 5 (DROOPY EYES)"
            };
        }
        public string[] eyeColorChoice()
        {
            return new string[] { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET", "WHITE", "BLACK", "GRAY" };
        }
        public string[] clothesChoice()
        {
            return new string[] {
                "APRON",
                "BALL GOWN",
                "BATTLE DRESS",
                "BIKINI",
                "DRESS",
                "KIMONO",
                "PAJAMAS",
                "ROBE",
                "SCHOOL UNIFORM",
                "T-SHIRT",
                "TUXEDO",
                "UNDERWEAR"
            };
        }
        public string[] pantsChoice()
        {
            return new string[] {
                "BAGGY PANTS",
                "BELL BOTTOMS",
                "CULOTTES",
                "JEANS",
                "HAREM PANTS",
                "LEGGINGS",
                "PALAZZO",
                "TROUSER",
                "STOVE PIPE"
            };
        }
        public string[] shoesChoice()
        {
            return new string[]
            {
                "ARMY BOOTS",
                "ATHLETIC SHOES",
                "BALLET SHOES",
                "DRESS SHOES",
                "FLIP-FLOPS",
                "HIGH HEELS",
                "HIKING BOOTS",
                "JACKBOOTS",
                "RIDING BOOTS"
            };
        }
        public string[] accessoriesChoice()
        {
            return new string[]
            {
                "BELT",
                "GLOVES",
                "BACKPACK",
                "SUNGLASSES",
                "BRACELET",
                "SCARF",
                "HAT"
            };
        }
        public string[] personalVehicleChoice()
        {
            return new string[] {
                "SUPERNOVA: 4-seater car. Fastest car in the game but very fragile, with only 5 bars of HP. \nPro: Incredible speed for quick getaways. \nCon: Easily destroyed under sustained fire.\n",

                "ICE CREAM TRUCK: 5-seater vehicle. Below-average speed but extremely tanky, with 10 bars of HP. \nPro: High durability, great for protection during ambushes. \nCon: Slow speed makes it vulnerable to faster enemies.\n",

                "SIDE CAR: 4-seater vehicle. Above-average speed but moderately fragile, with 7 bars of HP. \nPro: Good balance between speed and durability. \nCon: Limited off-road capability and exposed seating.\n",

                "DIRT BIKE: 2-seater bike. Extremely fast and agile but highly vulnerable, with only 4 bars of HP. \nPro: Exceptional off-road performance and maneuverability. \nCon: Exposes players to enemy fire easily and lacks durability.\n",

                "MONSTER TRUCK: 4-seater vehicle. High durability (8 bars of HP) and great off-road capabilities, but slow speed. \nPro: Can crush obstacles and smaller vehicles with ease. \nCon: Low top speed and large target size.\n",

                "UNICYCLE: 1-seater vehicle. Extremely agile but requires precision to control, with 3 bars of HP. \nPro: Perfect for quick escapes and weaving through tight spaces. \nCon: Minimal protection and difficult to master.\n",

                "BICYCLE: 1-seater vehicle. Silent and moderately fast, with 4 bars of HP. \nPro: Hard to detect due to its silent operation. \nCon: No protection and slower than motorized vehicles.\n",

                "E-TRIKE: 3-seater electric tricycle. Good speed and maneuverability but lightly armored, with 6 bars of HP. \nPro: Easy to handle and decent on uneven terrain. \nCon: The driver is very vulnerable to headshots.\n",

                "TUK-TUK: 5-seater vehicle. Low speed but decent durability, with 7 bars of HP. \nPro: Can hide in the compartment and surprise the enemies. \nCon: Poor speed and struggles on rough terrain."
            };
        }
        public string[] vehicleColorChoice()
        {
            return new string[] { "RED", "ORANGE", "YELLOW", "GREEN", "BLUE", "INDIGO", "VIOLET", "WHITE", "BLACK", "GRAY" };
        }
        public string[] mountChoice()
        {
            return new string[]
            {
                "DRAGON ",
                "UNICORN ",
                "HOT AIR BALLOON",
                "KINTO-UN (GOLDEN CLOUD / FLYING NIMBUS) ",
                "PHOENIX "
            };
        }
        public string[] starterPackChoice()
        {
            return new string[]
            {
                "DRAGON AK47 GUN SKIN",
                "OBSIDIAN BARETT SKIN",
                "GLITCHYPOP SHOTGUN SKIN",
                "DEEPFREEZE THOMPSON GUN SKIN",
                "SUMPAK M4A1 GUN SKIN"
            };
        }
        public string[] rolesChoice()
        {
            return new string[]
            {
                "ASSASSIN - SILENT FOOTSTEP",
                "SUPPORT - GRANTS BUFF TO TEAMMATES",
                "WARRIOR - ADDITIONAL FIRE RATE ON RIFLE, SMG, SHOTGUN WITH LOW RECOIL.",
                "HUNTER - HIGH ACCURACY ON SNIPER RIFLES.",
                "TANK - HIGH SHIELD PROFICIENCY AND VERY HIGH DURABILITY."
            };
        }
        public string[] skillsChoice()
        {
            return new string[]
            {
                "SKILL: DIMENSIONAL POCKET - PREFERRED ROLE: [SUPPORT, TANK]\n- Acts as the team's storage. Can hold extra ammo, guns, meds, and grenades without affecting the player's movement speed.\n",
                "SKILL: SMOKERIST - PREFERRED ROLE: [SUPPORT, TANK]\n- Creates a smoke screen for cover and blocks the enemies' bullets, lasting 15 seconds, but the blocking capabilities of the smoke are broken if it is shot, so the smoke has health to block enemy bullets.\n",
                "SKILL: YOU CAN'T SEE ME - PREFERRED ROLE: [ASSASSIN]\n- Become invisible for 15 seconds. However, you can be slightly visible to enemies if they are within close range.\n",
                "SKILL: EAGLE EYE - PREFERRED ROLE: [HUNTER]\n- Temporarily highlight all enemies in your scope within 200 meters, even behind cover.\n",
                "SKILL: BATTLE CRY - PREFERRED ROLE: [TANK, WARRIOR]\n- Emit a roar that buffs teammates’ damage output and reduces their reload time for 10 seconds.\n"
            };
        }
    }
}