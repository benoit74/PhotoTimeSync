using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{
    public static class SettingsUtil
    {
        // the name of the setting that flags whether we
        // should perform an upgrade or not
        private const string UpgradeFlag = "UpgradeRequired";

        public static void DoUpgrade(ApplicationSettingsBase settings)
        {
            try
            {
                // attempt to read the upgrade flag
                if ((bool)settings[UpgradeFlag] == true)
                {
                    // upgrade the settings to the latest version
                    settings.Upgrade();

                    // clear the upgrade flag
                    settings[UpgradeFlag] = false;
                    settings.Save();
                }
                else
                {
                    // the settings are up to date
                }
            }
            catch (SettingsPropertyNotFoundException ex)
            {
                // notify the developer that the upgrade
                // flag should be added to the settings file
                throw ex;
            }
        }
    }
}
