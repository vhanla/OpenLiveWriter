// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using OpenLiveWriter.ApplicationFramework.Preferences;
using OpenLiveWriter.Controls;
using OpenLiveWriter.CoreServices;
using OpenLiveWriter.CoreServices.Layout;
using OpenLiveWriter.Localization;
using OpenLiveWriter.Localization.Bidi;
using OpenLiveWriter.PostEditor.Autoreplace;
using OpenLiveWriter.PostEditor.ImageInsertion;
using OpenLiveWriter.CoreServices.Settings;
using OpenLiveWriter.PostEditor.WordCount;

namespace OpenLiveWriter.PostEditor
{

    public class EditingPreferencesPanel : PreferencesPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        private GroupBox groupBoxEditing;
        private CheckBox checkBoxTypographic;
        private AutoreplacePreferences _autoReplacePreferences;
        private ImageInsertionPreferences _imageInsertionPreferences;
        private CheckBox checkBoxSmartQuotes;
        private CheckBox checkBoxSpecialChars;
        private GroupBox groupBox1;
        private TrackBar trackBar1;
        private GroupBox groupBox2;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private GroupBox groupBox3;
        private Label label1;
        private CheckBox checkBoxEmoticons;

        public EditingPreferencesPanel()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            if (!DesignMode)
            {
                this.groupBoxEditing.Text = Res.Get(StringId.SpellingPrefOptions);
                PanelName = Res.Get(StringId.EditingName);
                checkBoxTypographic.Text = Res.Get(StringId.AutoreplaceTypographic);
                checkBoxSmartQuotes.Text = Res.Get(StringId.AutoreplaceSmartQuotes);
                checkBoxSpecialChars.Text = Res.Get(StringId.AutoreplaceOtherChars);
                checkBoxEmoticons.Text = Res.Get(StringId.AutoreplaceEmoticons);
            }

            PanelBitmap = ResourceHelper.LoadAssemblyResourceBitmap("Configuration.Settings.Images.EditingPanelBitmap.png");

            _autoReplacePreferences = new AutoreplacePreferences();
            _autoReplacePreferences.PreferencesModified += _autoReplacePreferences_PreferencesModified;

            checkBoxTypographic.Checked = _autoReplacePreferences.EnableTypographicReplacement;
            checkBoxTypographic.CheckedChanged += new EventHandler(checkBoxTypographic_CheckedChanged);

            checkBoxSmartQuotes.Checked = _autoReplacePreferences.EnableSmartQuotes;
            checkBoxSmartQuotes.Visible = !BidiHelper.IsRightToLeft;

            checkBoxSpecialChars.Checked = _autoReplacePreferences.EnableSpecialCharacterReplacement;
            checkBoxSpecialChars.CheckedChanged += new EventHandler(checkBoxSpecialChars_CheckedChanged);

            checkBoxEmoticons.Checked = _autoReplacePreferences.EnableEmoticonsReplacement;
            checkBoxEmoticons.CheckedChanged += new EventHandler(checkBoxEmoticons_CheckedChanged);

            _imageInsertionPreferences = new ImageInsertionPreferences();
            _imageInsertionPreferences.PreferencesModified += _imageInsertionPreferences_PreferencseModified;

            radioButton1.Checked = _imageInsertionPreferences.EnabledPasteAsJPG;
            radioButton1.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
            radioButton2.Checked = !_imageInsertionPreferences.EnabledPasteAsJPG;
            radioButton2.CheckedChanged += new EventHandler(radioButton2_CheckedChanged);

            trackBar1.Value = _imageInsertionPreferences.EnabledJPGQuality;
            trackBar1.ValueChanged += new EventHandler(trackBar1_Scroll);
            label1.Text = trackBar1.Value.ToString() + '%';
        }

        private bool _layedOut = false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode && !_layedOut)
            {
                LayoutHelper.FixupGroupBox(groupBoxEditing);
                _layedOut = true;
            }
        }

        public override void Save()
        {
            if (_autoReplacePreferences.IsModified())
                _autoReplacePreferences.Save();
            if (_imageInsertionPreferences.IsModified())
                _imageInsertionPreferences.Save();
        }

        void checkBoxTypographic_CheckedChanged(object sender, EventArgs e)
        {
            _autoReplacePreferences.EnableTypographicReplacement = checkBoxTypographic.Checked;
        }

        void checkBoxSpecialChars_CheckedChanged(object sender, EventArgs e)
        {
            _autoReplacePreferences.EnableSpecialCharacterReplacement = checkBoxSpecialChars.Checked;
        }

        private void checkBoxSmartQuotes_CheckedChanged(object sender, EventArgs e)
        {
            _autoReplacePreferences.EnableSmartQuotes = checkBoxSmartQuotes.Checked;
        }

        private void checkBoxEmoticons_CheckedChanged(object sender, EventArgs e)
        {
            _autoReplacePreferences.EnableEmoticonsReplacement = checkBoxEmoticons.Checked;
        }

        void _autoReplacePreferences_PreferencesModified(object sender, EventArgs e)
        {
            OnModified(EventArgs.Empty);
        }

        // JPG Settings

        void _imageInsertionPreferences_PreferencseModified(object sender, EventArgs e)
        {
            OnModified(EventArgs.Empty);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxEditing = new System.Windows.Forms.GroupBox();
            this.checkBoxSpecialChars = new System.Windows.Forms.CheckBox();
            this.checkBoxSmartQuotes = new System.Windows.Forms.CheckBox();
            this.checkBoxTypographic = new System.Windows.Forms.CheckBox();
            this.checkBoxEmoticons = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBoxEditing.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEditing
            // 
            this.groupBoxEditing.Controls.Add(this.checkBoxSpecialChars);
            this.groupBoxEditing.Controls.Add(this.checkBoxSmartQuotes);
            this.groupBoxEditing.Controls.Add(this.checkBoxTypographic);
            this.groupBoxEditing.Controls.Add(this.checkBoxEmoticons);
            this.groupBoxEditing.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBoxEditing.Location = new System.Drawing.Point(8, 32);
            this.groupBoxEditing.Name = "groupBoxEditing";
            this.groupBoxEditing.Size = new System.Drawing.Size(345, 133);
            this.groupBoxEditing.TabIndex = 0;
            this.groupBoxEditing.TabStop = false;
            this.groupBoxEditing.Text = "Editing";
            // 
            // checkBoxSpecialChars
            // 
            this.checkBoxSpecialChars.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxSpecialChars.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxSpecialChars.Location = new System.Drawing.Point(16, 73);
            this.checkBoxSpecialChars.Name = "checkBoxSpecialChars";
            this.checkBoxSpecialChars.Size = new System.Drawing.Size(312, 18);
            this.checkBoxSpecialChars.TabIndex = 7;
            this.checkBoxSpecialChars.Text = "Replace other special characters";
            this.checkBoxSpecialChars.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxSpecialChars.UseVisualStyleBackColor = true;
            // 
            // checkBoxSmartQuotes
            // 
            this.checkBoxSmartQuotes.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxSmartQuotes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxSmartQuotes.Location = new System.Drawing.Point(16, 47);
            this.checkBoxSmartQuotes.Name = "checkBoxSmartQuotes";
            this.checkBoxSmartQuotes.Size = new System.Drawing.Size(312, 18);
            this.checkBoxSmartQuotes.TabIndex = 5;
            this.checkBoxSmartQuotes.Text = "Replace \"straight quotes\" with “smart &quotes”";
            this.checkBoxSmartQuotes.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxSmartQuotes.UseVisualStyleBackColor = true;
            this.checkBoxSmartQuotes.CheckedChanged += new System.EventHandler(this.checkBoxSmartQuotes_CheckedChanged);
            // 
            // checkBoxTypographic
            // 
            this.checkBoxTypographic.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxTypographic.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxTypographic.Location = new System.Drawing.Point(16, 21);
            this.checkBoxTypographic.Name = "checkBoxTypographic";
            this.checkBoxTypographic.Size = new System.Drawing.Size(312, 18);
            this.checkBoxTypographic.TabIndex = 4;
            this.checkBoxTypographic.Text = "Replace h&yphens (--) with dash (—)";
            this.checkBoxTypographic.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxTypographic.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmoticons
            // 
            this.checkBoxEmoticons.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxEmoticons.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBoxEmoticons.Location = new System.Drawing.Point(16, 99);
            this.checkBoxEmoticons.Name = "checkBoxEmoticons";
            this.checkBoxEmoticons.Size = new System.Drawing.Size(312, 18);
            this.checkBoxEmoticons.TabIndex = 8;
            this.checkBoxEmoticons.Text = "Replace text emoticons with emoticon graphics";
            this.checkBoxEmoticons.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBoxEmoticons.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(8, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 180);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Picture Editing";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Location = new System.Drawing.Point(16, 78);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 84);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Jpeg Quality";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "93%";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(21, 22);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(250, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = 93;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Location = new System.Drawing.Point(16, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paste from clipboard as";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(21, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(91, 19);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "JPEG Format";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(142, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(90, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "PNG Format";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // EditingPreferencesPanel
            // 
            this.AccessibleName = "Preferences";
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxEditing);
            this.Name = "EditingPreferencesPanel";
            this.PanelName = "Preferences";
            this.Size = new System.Drawing.Size(370, 520);
            this.Controls.SetChildIndex(this.groupBoxEditing, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBoxEditing.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _imageInsertionPreferences.EnabledPasteAsJPG = radioButton1.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _imageInsertionPreferences.EnabledPasteAsJPG = !radioButton2.Checked;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString() + '%';
            _imageInsertionPreferences.EnabledJPGQuality = trackBar1.Value;
        }
    }
}
