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
    class SeriousGeorge : GeorgeBase
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            float georgeCount = 1;
            float healthMultiplier;

            //Edits values on player when card is selected
            for (int i = 0; i < player.data.currentCards.Count; i++)
            {
                if (player.data.currentCards[i].cardName.Contains("George"))
                {
                    georgeCount++;
                }
                if (player.data.currentCards[i].cardName.Contains("Isomer"))
                {
                    georgeCount++;
                }
            }

            healthMultiplier = healthUpPerGeorge * georgeCount;
            statModifiers.health *= healthMultiplier;
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
        }

        protected override string GetTitle()
        {
            return "Serious George";
        }
        protected override string GetDescription()
        {
            return "Did you know running out of health makes you die?";
        }
        protected override GameObject GetCardArt()
        {
            return VariousGeorge.SeriousGeorgeArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Health",
                    amount = "+25% per Allied George",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DefensiveBlue;
        }
        public override string GetModName()
        {
            return VariousGeorge.ModInitials;
        }
    }
}
