using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace VariousGeorgeSpace.Cards
{
    class IsomerGeorge : GeorgeBase
    {
        Player player1;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`

            //CardInfo card1;
            //CardInfo card2;
            //int randomNum;

            //randomNum = random.Next(0, cards.Count);
            //card1 = cards[randomNum];

            //randomNum = random.Next(0, cards.Count);
            //card2 = cards[randomNum];

            //CardChoice.instance.AddCard(card1);
            //CardChoice.instance.AddCard(card2);
            ////gun.player.data.currentCards.Add();
            ////gun.player.data.currentCards.Add(card2);
            ///

            statModifiers.OnReloadDoneAction = (Action<int>)Delegate.Combine(statModifiers.OnReloadDoneAction, new Action(this.Heal));
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            player1 = player;
            int randomValue;
            float multiplier = 2.0f;

            randomValue = random.Next(0, 10);

            switch (randomValue)
            {
                case 0:
                    gun.damage *= multiplier;
                    break;
                case 1:
                    PlayerManager.instance.GetOtherPlayer(player).data.maxHealth /= multiplier;
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
                    statModifiers.numberOfJumps *= (int)multiplier;
                    break;
                case 7:
                    gunAmmo.maxAmmo *= (int)multiplier;
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
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
        }

        public void Heal()
        {
            player1.data.maxHealth += 100.0f;
        }

        protected override string GetTitle()
        {
            return "Isomer George";
        }
        protected override string GetDescription()
        {
            return "Double the George, double the power!";
        }
        protected override GameObject GetCardArt()
        {
            return VariousGeorge.IsomerGeorgeArt;
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
                    stat = "Georges",
                    amount = "2",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },

                new CardInfoStat()
                {
                    positive = true,
                    stat = "A Random Stat",
                    amount = "Double",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.TechWhite;
        }
        public override string GetModName()
        {
            return VariousGeorge.ModInitials;
        }
    }
}
