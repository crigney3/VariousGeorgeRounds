using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace VariousGeorgeSpace.Cards
{
    class GeorgeHWBush : GeorgeBase
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            int randomValue;
            float multiplier;

            for (int i = 0; i < 4; i++)
            {
                randomValue = random.Next(0, 10);
                multiplier = i >= 2 ? 0.5f : 2.0f;

                switch (randomValue)
                {
                    case 0:
                        gun.damage *= multiplier;
                        break;
                    case 1:
                        PlayerManager.instance.GetOtherPlayer(player).data.maxHealth *= multiplier;
                        break;
                    case 2:
                        gunAmmo.reloadTime *= multiplier;
                        break;
                    case 3:
                        gun.projectileSize *= multiplier;
                        break;
                    case 4:
                        gun.attackSpeed *= multiplier;
                        break;
                    case 5:
                        player.data.maxHealth *= multiplier;
                        break;
                    case 6:
                        if (multiplier == 0.5f)
                        {
                            statModifiers.numberOfJumps /= 2;
                        } else
                        {
                            statModifiers.numberOfJumps *= (int)multiplier;
                        }
                        break;
                    case 7:
                        if (multiplier == 0.5f)
                        {
                            gunAmmo.maxAmmo /= 2;
                        }
                        else
                        {
                            gunAmmo.maxAmmo *= (int)multiplier;
                        }
                        break;
                    case 8:
                        statModifiers.movementSpeed *= multiplier;
                        break;
                    case 9:
                        gravity.exponent *= multiplier;
                        break;
                    default:
                        gun.damage *= multiplier;
                        break;
                }
            }
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
        }

        protected override string GetTitle()
        {
            return "George H.W. Bush";
        }
        protected override string GetDescription()
        {
            return "2 random stats doubled, 2 random stats halved.";
        }
        protected override GameObject GetCardArt()
        {
            return VariousGeorge.GeorgeHWBushArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Something",
                    amount = "Double",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },

                new CardInfoStat()
                {
                    positive = true,
                    stat = "Something",
                    amount = "Double",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },

                new CardInfoStat()
                {
                    positive = false,
                    stat = "Something",
                    amount = "Half",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },

                new CardInfoStat()
                {
                    positive = false,
                    stat = "Something",
                    amount = "Half",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.EvilPurple;
        }
        public override string GetModName()
        {
            return VariousGeorge.ModInitials;
        }
    }
}
