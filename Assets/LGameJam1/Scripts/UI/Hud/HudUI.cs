using System;
using LGameJam1.Scripts.Station;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LGameJam1.Scripts.UI.Hud
{
    public class HudUI : MonoBehaviour
    {
        public TMP_Text overallAtkText;
        public TMP_Text atkItem0;
        public TMP_Text atkItem1;
        public TMP_Text atkItem2;
        public TMP_Text atkItem3;
        public TMP_Text atkItem4;
        public TMP_Text atkItem5;
        public TMP_Text atkItem6;
        public TMP_Text atkItem7;
        
        public TMP_Text overallDefText;
        public TMP_Text defItem0;
        public TMP_Text defItem1;
        public TMP_Text defItem2;
        public TMP_Text defItem3;
        public TMP_Text defItem4;
        public TMP_Text defItem5;
        public TMP_Text defItem6;
        public TMP_Text defItem7;

        public TMP_Text timerText;

        private Image craftImage;
        private Image enemyImage;

        public Image EnemyImage01;
        public Image EnemyImage02;
        public Image EnemyImage03;

        public Image WinScreen;
        public Image EndScreen;
        public Image BattleScreen;
        
        public GameObject worker0;
        public GameObject worker1;
        public GameObject worker2;
        public GameObject worker3;

        private void Awake()
        {
            God.Hud = this;
        }

        private void OnEnable()
        {
            God.EventS.atkItemChanged += OnAtkItemChanged;
            God.EventS.defItemChanged += OnDefItemChanged;
            God.EventS.timerChanged += OnTimerChanged;
            God.EventS.waveStarted += OnWaveStarted;
        }

        public void ShowCraftImage(Image newImage)
        {
            if (craftImage != null)
                craftImage.enabled = false;
            craftImage = newImage;
            if (craftImage != null)
                craftImage.enabled = true;
            Debug.Log("Show Craft");
        }

        private void OnWaveStarted()
        {
            if (enemyImage != null)
                enemyImage.enabled = false;
            
            switch (God.WaveS.curWave)
            {
                case 0:
                {
                    enemyImage = EnemyImage01;
                    break;
                }
                case 1:
                {
                    enemyImage = EnemyImage02;
                    break;
                }
                case 2:
                {
                    enemyImage = EnemyImage03;
                    break;
                }
            }
            enemyImage.enabled = true;
        }

        private void OnTimerChanged()
        {
            timerText.text = (God.TimerS.tickAmount - God.TimerS.curTick).ToString();
        }

        private void OnAtkItemChanged()
        {
            God.StorageS.GetResourceCountAndValue(ResourceType.Stone, out uint stoneCount, out uint stonePower);
            atkItem0.text = stoneCount.ToString();

            God.StorageS.GetResourceCountAndValue(ResourceType.Tools, out uint toolCount, out uint toolPower);
            atkItem1.text = toolCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Ore, out uint oreCount, out uint orePower);
            atkItem2.text = oreCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Ingots, out uint ingotCount, out uint ingotPower);
            atkItem3.text = ingotCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Weapon, out uint weaponCount, out uint weaponPower);
            atkItem4.text = weaponCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Bow, out uint bowCount, out uint bowPower);
            atkItem5.text = bowCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Spell, out uint spellCount, out uint spellPower);
            atkItem6.text = spellCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Rune, out uint runeCount, out uint runePower);
            atkItem7.text = runeCount.ToString();
            
            var overall = 
                stoneCount * stonePower + 
                toolCount * toolPower + 
                oreCount * orePower + 
                ingotCount * ingotPower + 
                weaponCount * weaponPower +
                bowCount * bowPower +
                spellCount * spellPower +
                runeCount * runePower;
            overallAtkText.text = overall.ToString();
        }

        private void OnDefItemChanged()
        {
            God.StorageS.GetResourceCountAndValue(ResourceType.Wood, out uint stoneCount, out uint stonePower);
            defItem0.text = stoneCount.ToString();

            God.StorageS.GetResourceCountAndValue(ResourceType.Planks, out uint toolCount, out uint toolPower);
            defItem1.text = toolCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Shield, out uint oreCount, out uint orePower);
            defItem2.text = oreCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Leather, out uint ingotCount, out uint ingotPower);
            defItem3.text = ingotCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Clothes, out uint weaponCount, out uint weaponPower);
            defItem4.text = weaponCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Armor, out uint bowCount, out uint bowPower);
            defItem5.text = bowCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Mana, out uint spellCount, out uint spellPower);
            defItem6.text = spellCount.ToString();
            
            God.StorageS.GetResourceCountAndValue(ResourceType.Golem, out uint runeCount, out uint runePower);
            defItem7.text = runeCount.ToString();
            
            var overall = 
                stoneCount * stonePower + 
                toolCount * toolPower + 
                oreCount * orePower + 
                ingotCount * ingotPower + 
                weaponCount * weaponPower +
                bowCount * bowPower +
                spellCount * spellPower +
                runeCount * runePower;
            overallDefText.text = overall.ToString();
        }

        public void ShowWorkers(int workerCount)
        {
            switch (workerCount)
            {
                case 1:
                {
                    worker0.SetActive(true);
                    break;
                }
                case 2:
                {
                    worker0.SetActive(true);
                    worker1.SetActive(true);
                    break;
                }
                case 3:
                {
                    worker0.SetActive(true);
                    worker1.SetActive(true);
                    worker2.SetActive(true);
                    break;
                }
                case 4:
                {
                    worker0.SetActive(true);
                    worker1.SetActive(true);
                    worker2.SetActive(true);
                    worker3.SetActive(true);
                    break;
                }
            }
        }
    }
}