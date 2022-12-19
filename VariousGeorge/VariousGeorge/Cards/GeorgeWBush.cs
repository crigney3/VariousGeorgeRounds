using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace VariousGeorgeSpace.Cards
{
    class GeorgeWBush : GeorgeBase
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            float georgeCount = 1;
            float reloadMultiplier;

            //Edits values on player when card is selected
            for (int i = 0; i < player.data.currentCards.Count; i++)
            {
                if (player.data.currentCards[i].cardName.Contains("George"))
                {
                    georgeCount++;
                }
            }

            //reloadMultiplier = reloadDownPerGeorge * georgeCount;
            gun.reloadTimeAdd -= 0.05f * georgeCount;
            gravity.gravityForce /= 4;
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
        }

        protected override string GetTitle()
        {
            return "George W Bush";
        }
        protected override string GetDescription()
        {
            return "Take to the skies!";
        }
        protected override GameObject GetCardArt()
        {
            return VariousGeorge.GeorgeWBushArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Gravity",
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },

                new CardInfoStat()
                {
                    positive = true,
                    stat = "Reload Speed",
                    amount = "+5% per Allied George",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DestructiveRed;
        }
        public override string GetModName()
        {
            return VariousGeorge.ModInitials;
        }
    }
}
