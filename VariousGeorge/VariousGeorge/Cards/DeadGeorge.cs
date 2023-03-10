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
    class DeadGeorge : GeorgeBase
    {
        Player playerRef;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`



        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            playerRef = player;
            player.data.ExecuteAfterSeconds(2.0f, DeathAction);
            //player.data.ExecuteAfterSeconds(2.0f, DeathAction);
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
        }
        public void DeathAction() {
            playerRef.data.maxHealth = 0.0f;
            playerRef.data.movement.enabled = false;
        }

        protected override string GetTitle()
        {
            return "Dead George";
        }
        protected override string GetDescription()
        {
            return "He's just sleeping.";
        }
        protected override GameObject GetCardArt()
        {
            return VariousGeorge.DeadGeorgeArt;
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
                    stat = "Time",
                    amount = "Death",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.PoisonGreen;
        }
        public override string GetModName()
        {
            return VariousGeorge.ModInitials;
        }
    }
}
