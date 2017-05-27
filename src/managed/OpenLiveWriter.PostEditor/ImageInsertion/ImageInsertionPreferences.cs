// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using OpenLiveWriter.CoreServices;
using OpenLiveWriter.CoreServices.Settings;

namespace OpenLiveWriter.PostEditor.ImageInsertion
{
    public class ImageInsertionPreferences : OpenLiveWriter.ApplicationFramework.Preferences.Preferences
    {
        public ImageInsertionPreferences() : base("ImageInsertion")
        {

        }

        public bool EnabledPasteAsJPG
        {
            get { return _enabledPasteAsJPG; }
            set { _enabledPasteAsJPG = value; Modified(); }
        }
        private bool _enabledPasteAsJPG;

        public int EnabledJPGQuality
        {
            get { return _enabledJPGQuality; }
            set { _enabledJPGQuality = value; Modified(); }
        }
        private int _enabledJPGQuality;

        protected override void LoadPreferences()
        {
            EnabledPasteAsJPG = ImageInsertionSettings.EnablePasteAsJpg;
            EnabledJPGQuality = ImageInsertionSettings.JPGQuality;            
        }

        protected override void SavePreferences()
        {
            ImageInsertionSettings.EnablePasteAsJpg = EnabledPasteAsJPG;
            ImageInsertionSettings.JPGQuality = EnabledJPGQuality;
        }
    }
}
