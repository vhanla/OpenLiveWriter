// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.

using System;
using System.Collections;
using System.Collections.Generic;
using OpenLiveWriter.CoreServices.Settings;
using OpenLiveWriter.Localization.Bidi;

namespace OpenLiveWriter.PostEditor.ImageInsertion
{
    class ImageInsertionSettings
    {

        public static event EventHandler SettingsChanged;

        public static bool EnablePasteAsJpg
        {
            get
            {
                if (!_pasteAsJpg.HasValue)
                    _pasteAsJpg = Settings.GetBoolean(PASTEJPG, true);
                return _pasteAsJpg.Value;
            }
            set
            {
                Settings.SetBoolean(PASTEJPG, value);
                OnSettingsChanged();
                _pasteAsJpg = value;
            }
        }

        public static int JPGQuality
        {
            get
            {
                if (!_compressionLevel.HasValue)
                    _compressionLevel = Settings.GetInt32(JPG_QUALITY, 93);
                return _compressionLevel.Value;
            }
            set
            {
                Settings.SetInt32(JPG_QUALITY, value);
                OnSettingsChanged();
                _compressionLevel = value;
            }
        }

        protected static void OnSettingsChanged()
        {
            if (SettingsChanged != null)
                SettingsChanged(null, EventArgs.Empty);
        }

        private static bool? _pasteAsJpg;
        private static int? _compressionLevel;

        private static readonly SettingsPersisterHelper Settings = PostEditorSettings.SettingsKey.GetSubSettings("ImageInsertion");
        private const string PASTEJPG = "JPGPaste";
        private const string JPG_QUALITY = "JPGQuality";
    }
}
