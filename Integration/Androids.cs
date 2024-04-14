using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace Androids.Integration
{
    /// <summary>
    /// Assembly container for this mod.
    /// </summary>
    public class Androids : Mod
    {
        /// <summary>
        /// Singleton instance for our mod.
        /// </summary>
        public static Androids Instance;

        /// <summary>
        /// Used for the text for the setting.
        /// </summary>
        private string explosionRadiusBuffer = "3.5";
        private string printTimeMult = "1.0";
        private string basePrintTime = "60000";

        public Androids(ModContentPack content) : base(content)
        {
            Instance = this;
            AndroidsModSettings.Instance = GetSettings<AndroidsModSettings>();

            //Load settings for buffers.
            if(AndroidsModSettings.Instance != null)
            {
                explosionRadiusBuffer = AndroidsModSettings.Instance.androidExplosionRadius.ToString();
                printTimeMult = AndroidsModSettings.Instance.printTimeMult.ToString();
                basePrintTime = AndroidsModSettings.Instance.basePrintTime.ToString();
            }
        }

        public override string SettingsCategory()
        {
            return "Androids";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            int row = 0;
            float rowHeight = 24f;

            Rect ininRect = new Rect(inRect);
            ininRect.width /= 2f;

            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;

                //Toggle for whether Androids explode or not.
                Widgets.CheckboxLabeled(rowRect, "AndroidSettingsEyeGlow".Translate(), ref AndroidsModSettings.Instance.androidEyeGlow);
            }

            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;

                //Toggle for whether Androids explode or not.
                Widgets.CheckboxLabeled(rowRect, "AndroidSettingsExplodeOnDeath".Translate(), ref AndroidsModSettings.Instance.androidExplodesOnDeath);
            }

            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;

                //Toggle for whether Androids explode or not.
                Widgets.TextFieldNumericLabeled(rowRect, "AndroidSettingsExplosionRadius".Translate(), ref AndroidsModSettings.Instance.androidExplosionRadius, ref explosionRadiusBuffer, 1.25f, GenRadial.MaxRadialPatternRadius);
            }

            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;

                //Toggle for whether Androids explode or not.
                Widgets.CheckboxLabeled(rowRect, "AndroidSettingsDroidCompatibilityMode".Translate(), ref AndroidsModSettings.Instance.droidCompatibilityMode);
                TooltipHandler.TipRegion(rowRect, "AndroidSettingsDroidCompatibilityModeTooltip".Translate());
            }

            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;

                //Toggle for whether Androids explode or not.
                Widgets.CheckboxLabeled(rowRect, "AndroidSettingsDroidDetonationDialog".Translate(), ref AndroidsModSettings.Instance.droidDetonationConfirmation);
                TooltipHandler.TipRegion(rowRect, "AndroidSettingsDroidDetonationDialogTooltip".Translate());
            }

            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;

                //Toggle for whether Androids explode or not.
                Widgets.CheckboxLabeled(rowRect, "AndroidSettingsDroidWearDown".Translate(), ref AndroidsModSettings.Instance.droidWearDown);
            }

            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;

                //Toggle for whether Androids explode or not.
                Widgets.CheckboxLabeled(rowRect, "AndroidSettingsDroidWearDownQuadrum".Translate(), ref AndroidsModSettings.Instance.droidWearDownQuadrum);
            }
            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;

                
                Widgets.CheckboxLabeled(rowRect, "expensiveAndroids".Translate(), ref AndroidsModSettings.Instance.expensiveAndroids);
                TooltipHandler.TipRegion(rowRect, "expensiveAndroidsTooltip".Translate());
            }
            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;

                
                Widgets.CheckboxLabeled(rowRect, "costSizeScale".Translate(), ref AndroidsModSettings.Instance.costSizeScale);
                TooltipHandler.TipRegion(rowRect, "expensiveAndroidsTooltip".Translate());
            }
            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;

                
                Widgets.CheckboxLabeled(rowRect, "techTreeShuffling".Translate(), ref AndroidsModSettings.Instance.techTreeShuffling);
                TooltipHandler.TipRegion(rowRect, "techTreeShufflingTooltip".Translate());
            }
            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;


                Widgets.TextFieldNumericLabeled(rowRect, "AndroidSettingsPrintTimeMult".Translate(), ref AndroidsModSettings.Instance.printTimeMult, ref printTimeMult);
                TooltipHandler.TipRegion(rowRect, "printTimeMultTooltip".Translate());
            }
            {
                Rect rowRect = UIHelper.GetRowRect(ininRect, rowHeight, row);
                row++;


                Widgets.TextFieldNumericLabeled(rowRect, "AndroidSettingsBasePrintTime".Translate(), ref AndroidsModSettings.Instance.basePrintTime, ref basePrintTime);
                TooltipHandler.TipRegion(rowRect, "basePrintTimeTooltip".Translate());
            }
        }
    }
}
