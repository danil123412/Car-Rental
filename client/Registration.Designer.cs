namespace Прокат_авто
{
    partial class Registration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            this.registratinButton = new MaterialSkin.Controls.MaterialButton();
            this.addressTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.surnameTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.numberTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.birthdayTimePicker = new System.Windows.Forms.DateTimePicker();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.dateissuanceTimePicker = new System.Windows.Forms.DateTimePicker();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.validTimePicker = new System.Windows.Forms.DateTimePicker();
            this.documentTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.experienceTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.passwordTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.loginTextBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.backButton = new MaterialSkin.Controls.MaterialButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.patronymicTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            this.nameTextBox = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // registratinButton
            // 
            this.registratinButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.registratinButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.registratinButton.Depth = 0;
            this.registratinButton.HighEmphasis = true;
            this.registratinButton.Icon = null;
            this.registratinButton.Location = new System.Drawing.Point(347, 344);
            this.registratinButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.registratinButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.registratinButton.Name = "registratinButton";
            this.registratinButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.registratinButton.Size = new System.Drawing.Size(191, 36);
            this.registratinButton.TabIndex = 48;
            this.registratinButton.Text = "Зарегистрироваться";
            this.registratinButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.registratinButton.UseAccentColor = false;
            this.registratinButton.UseVisualStyleBackColor = true;
            this.registratinButton.Click += new System.EventHandler(this.registration_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.AnimateReadOnly = false;
            this.addressTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addressTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.addressTextBox.Depth = 0;
            this.addressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addressTextBox.HideSelection = true;
            this.addressTextBox.Hint = "Город";
            this.addressTextBox.LeadingIcon = null;
            this.addressTextBox.Location = new System.Drawing.Point(288, 67);
            this.addressTextBox.MaxLength = 32767;
            this.addressTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.PasswordChar = '\0';
            this.addressTextBox.PrefixSuffixText = null;
            this.addressTextBox.ReadOnly = false;
            this.addressTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addressTextBox.SelectedText = "";
            this.addressTextBox.SelectionLength = 0;
            this.addressTextBox.SelectionStart = 0;
            this.addressTextBox.ShortcutsEnabled = true;
            this.addressTextBox.Size = new System.Drawing.Size(250, 48);
            this.addressTextBox.TabIndex = 43;
            this.addressTextBox.TabStop = false;
            this.addressTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.addressTextBox.TrailingIcon = null;
            this.addressTextBox.UseSystemPasswordChar = false;
            this.addressTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.addressTextBox_Validating);
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.AnimateReadOnly = false;
            this.surnameTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.surnameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.surnameTextBox.Depth = 0;
            this.surnameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.surnameTextBox.HideSelection = true;
            this.surnameTextBox.Hint = "Фамилия";
            this.surnameTextBox.LeadingIcon = null;
            this.surnameTextBox.Location = new System.Drawing.Point(6, 175);
            this.surnameTextBox.MaxLength = 32767;
            this.surnameTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.PasswordChar = '\0';
            this.surnameTextBox.PrefixSuffixText = null;
            this.surnameTextBox.ReadOnly = false;
            this.surnameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.surnameTextBox.SelectedText = "";
            this.surnameTextBox.SelectionLength = 0;
            this.surnameTextBox.SelectionStart = 0;
            this.surnameTextBox.ShortcutsEnabled = true;
            this.surnameTextBox.Size = new System.Drawing.Size(250, 48);
            this.surnameTextBox.TabIndex = 40;
            this.surnameTextBox.TabStop = false;
            this.surnameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.surnameTextBox.TrailingIcon = null;
            this.surnameTextBox.UseSystemPasswordChar = false;
            this.surnameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nameTextBox_Validating);
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.Location = new System.Drawing.Point(9, 193);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(1, 0);
            this.materialLabel7.TabIndex = 39;
            // 
            // numberTextBox
            // 
            this.numberTextBox.AllowPromptAsInput = true;
            this.numberTextBox.AnimateReadOnly = false;
            this.numberTextBox.AsciiOnly = false;
            this.numberTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.numberTextBox.BeepOnError = false;
            this.numberTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.numberTextBox.Depth = 0;
            this.numberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numberTextBox.HidePromptOnLeave = false;
            this.numberTextBox.HideSelection = true;
            this.numberTextBox.Hint = "Номер телефона";
            this.numberTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.numberTextBox.LeadingIcon = null;
            this.numberTextBox.Location = new System.Drawing.Point(6, 392);
            this.numberTextBox.Mask = "9(999)0000000";
            this.numberTextBox.MaxLength = 32767;
            this.numberTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.PasswordChar = '\0';
            this.numberTextBox.PrefixSuffixText = null;
            this.numberTextBox.PromptChar = '_';
            this.numberTextBox.ReadOnly = false;
            this.numberTextBox.RejectInputOnFirstFailure = false;
            this.numberTextBox.ResetOnPrompt = true;
            this.numberTextBox.ResetOnSpace = true;
            this.numberTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numberTextBox.SelectedText = "";
            this.numberTextBox.SelectionLength = 0;
            this.numberTextBox.SelectionStart = 0;
            this.numberTextBox.ShortcutsEnabled = true;
            this.numberTextBox.Size = new System.Drawing.Size(250, 48);
            this.numberTextBox.SkipLiterals = true;
            this.numberTextBox.TabIndex = 51;
            this.numberTextBox.TabStop = false;
            this.numberTextBox.Text = " (   )";
            this.numberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numberTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.numberTextBox.TrailingIcon = null;
            this.numberTextBox.UseSystemPasswordChar = false;
            this.numberTextBox.ValidatingType = null;
            // 
            // birthdayTimePicker
            // 
            this.birthdayTimePicker.Location = new System.Drawing.Point(6, 366);
            this.birthdayTimePicker.Name = "birthdayTimePicker";
            this.birthdayTimePicker.Size = new System.Drawing.Size(249, 20);
            this.birthdayTimePicker.TabIndex = 52;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(6, 344);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(118, 19);
            this.materialLabel1.TabIndex = 53;
            this.materialLabel1.Text = "Дата рождения";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(290, 235);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(101, 19);
            this.materialLabel2.TabIndex = 56;
            this.materialLabel2.Text = "Дата выдачи";
            // 
            // dateissuanceTimePicker
            // 
            this.dateissuanceTimePicker.Location = new System.Drawing.Point(289, 257);
            this.dateissuanceTimePicker.Name = "dateissuanceTimePicker";
            this.dateissuanceTimePicker.Size = new System.Drawing.Size(249, 20);
            this.dateissuanceTimePicker.TabIndex = 55;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(290, 283);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(69, 19);
            this.materialLabel3.TabIndex = 58;
            this.materialLabel3.Text = "Годен до";
            // 
            // validTimePicker
            // 
            this.validTimePicker.Location = new System.Drawing.Point(289, 305);
            this.validTimePicker.Name = "validTimePicker";
            this.validTimePicker.Size = new System.Drawing.Size(249, 20);
            this.validTimePicker.TabIndex = 57;
            // 
            // documentTextBox
            // 
            this.documentTextBox.AllowPromptAsInput = true;
            this.documentTextBox.AnimateReadOnly = false;
            this.documentTextBox.AsciiOnly = false;
            this.documentTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.documentTextBox.BeepOnError = false;
            this.documentTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.documentTextBox.Depth = 0;
            this.documentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.documentTextBox.HidePromptOnLeave = false;
            this.documentTextBox.HideSelection = true;
            this.documentTextBox.Hint = "Водительское удостоверение";
            this.documentTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.documentTextBox.LeadingIcon = null;
            this.documentTextBox.Location = new System.Drawing.Point(288, 175);
            this.documentTextBox.Mask = "00 00 000000";
            this.documentTextBox.MaxLength = 32767;
            this.documentTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.documentTextBox.Name = "documentTextBox";
            this.documentTextBox.PasswordChar = '\0';
            this.documentTextBox.PrefixSuffixText = null;
            this.documentTextBox.PromptChar = '_';
            this.documentTextBox.ReadOnly = false;
            this.documentTextBox.RejectInputOnFirstFailure = false;
            this.documentTextBox.ResetOnPrompt = true;
            this.documentTextBox.ResetOnSpace = true;
            this.documentTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.documentTextBox.SelectedText = "";
            this.documentTextBox.SelectionLength = 0;
            this.documentTextBox.SelectionStart = 0;
            this.documentTextBox.ShortcutsEnabled = true;
            this.documentTextBox.Size = new System.Drawing.Size(250, 48);
            this.documentTextBox.SkipLiterals = true;
            this.documentTextBox.TabIndex = 59;
            this.documentTextBox.TabStop = false;
            this.documentTextBox.Text = "      ";
            this.documentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.documentTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.documentTextBox.TrailingIcon = null;
            this.documentTextBox.UseSystemPasswordChar = false;
            this.documentTextBox.ValidatingType = null;
            // 
            // experienceTextBox
            // 
            this.experienceTextBox.AnimateReadOnly = false;
            this.experienceTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.experienceTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.experienceTextBox.Depth = 0;
            this.experienceTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.experienceTextBox.HideSelection = true;
            this.experienceTextBox.Hint = "Стаж";
            this.experienceTextBox.LeadingIcon = null;
            this.experienceTextBox.Location = new System.Drawing.Point(288, 121);
            this.experienceTextBox.MaxLength = 32767;
            this.experienceTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.experienceTextBox.Name = "experienceTextBox";
            this.experienceTextBox.PasswordChar = '\0';
            this.experienceTextBox.PrefixSuffixText = null;
            this.experienceTextBox.ReadOnly = false;
            this.experienceTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.experienceTextBox.SelectedText = "";
            this.experienceTextBox.SelectionLength = 0;
            this.experienceTextBox.SelectionStart = 0;
            this.experienceTextBox.ShortcutsEnabled = true;
            this.experienceTextBox.Size = new System.Drawing.Size(250, 48);
            this.experienceTextBox.TabIndex = 60;
            this.experienceTextBox.TabStop = false;
            this.experienceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.experienceTextBox.TrailingIcon = null;
            this.experienceTextBox.UseSystemPasswordChar = false;
            this.experienceTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.experienceTextBox_Validating);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.AllowPromptAsInput = true;
            this.passwordTextBox.AnimateReadOnly = false;
            this.passwordTextBox.AsciiOnly = false;
            this.passwordTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.passwordTextBox.BeepOnError = false;
            this.passwordTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.passwordTextBox.Depth = 0;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.passwordTextBox.HidePromptOnLeave = false;
            this.passwordTextBox.HideSelection = true;
            this.passwordTextBox.Hint = "Пароль";
            this.passwordTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.passwordTextBox.LeadingIcon = null;
            this.passwordTextBox.Location = new System.Drawing.Point(6, 121);
            this.passwordTextBox.Mask = "A A A A A A";
            this.passwordTextBox.MaxLength = 32767;
            this.passwordTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '\0';
            this.passwordTextBox.PrefixSuffixText = null;
            this.passwordTextBox.PromptChar = '_';
            this.passwordTextBox.ReadOnly = false;
            this.passwordTextBox.RejectInputOnFirstFailure = false;
            this.passwordTextBox.ResetOnPrompt = true;
            this.passwordTextBox.ResetOnSpace = true;
            this.passwordTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.passwordTextBox.SelectedText = "";
            this.passwordTextBox.SelectionLength = 0;
            this.passwordTextBox.SelectionStart = 0;
            this.passwordTextBox.ShortcutsEnabled = true;
            this.passwordTextBox.Size = new System.Drawing.Size(250, 48);
            this.passwordTextBox.SkipLiterals = true;
            this.passwordTextBox.TabIndex = 61;
            this.passwordTextBox.TabStop = false;
            this.passwordTextBox.Text = "          ";
            this.passwordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.passwordTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.passwordTextBox.TrailingIcon = null;
            this.passwordTextBox.UseSystemPasswordChar = false;
            this.passwordTextBox.ValidatingType = null;
            // 
            // loginTextBox
            // 
            this.loginTextBox.AllowPromptAsInput = true;
            this.loginTextBox.AnimateReadOnly = false;
            this.loginTextBox.AsciiOnly = false;
            this.loginTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loginTextBox.BeepOnError = false;
            this.loginTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.loginTextBox.Depth = 0;
            this.loginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.loginTextBox.HidePromptOnLeave = false;
            this.loginTextBox.HideSelection = true;
            this.loginTextBox.Hint = "Логин";
            this.loginTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.loginTextBox.LeadingIcon = null;
            this.loginTextBox.Location = new System.Drawing.Point(6, 67);
            this.loginTextBox.Mask = "A A A A A A";
            this.loginTextBox.MaxLength = 32767;
            this.loginTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.PasswordChar = '\0';
            this.loginTextBox.PrefixSuffixText = null;
            this.loginTextBox.PromptChar = '_';
            this.loginTextBox.ReadOnly = false;
            this.loginTextBox.RejectInputOnFirstFailure = false;
            this.loginTextBox.ResetOnPrompt = true;
            this.loginTextBox.ResetOnSpace = true;
            this.loginTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loginTextBox.SelectedText = "";
            this.loginTextBox.SelectionLength = 0;
            this.loginTextBox.SelectionStart = 0;
            this.loginTextBox.ShortcutsEnabled = true;
            this.loginTextBox.Size = new System.Drawing.Size(250, 48);
            this.loginTextBox.SkipLiterals = true;
            this.loginTextBox.TabIndex = 62;
            this.loginTextBox.TabStop = false;
            this.loginTextBox.Text = "          ";
            this.loginTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.loginTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.loginTextBox.TrailingIcon = null;
            this.loginTextBox.UseSystemPasswordChar = false;
            this.loginTextBox.ValidatingType = null;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(506, 29);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 32);
            this.pictureBox7.TabIndex = 64;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Visible = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(506, 29);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.TabIndex = 63;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // backButton
            // 
            this.backButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.backButton.Depth = 0;
            this.backButton.HighEmphasis = true;
            this.backButton.Icon = null;
            this.backButton.Location = new System.Drawing.Point(467, 392);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.backButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.backButton.Name = "backButton";
            this.backButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.backButton.Size = new System.Drawing.Size(71, 36);
            this.backButton.TabIndex = 65;
            this.backButton.Text = "Назад";
            this.backButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.backButton.UseAccentColor = false;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // patronymicTextBox
            // 
            this.patronymicTextBox.AnimateReadOnly = false;
            this.patronymicTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.patronymicTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.patronymicTextBox.Depth = 0;
            this.patronymicTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.patronymicTextBox.HideSelection = true;
            this.patronymicTextBox.Hint = "Отчество";
            this.patronymicTextBox.LeadingIcon = null;
            this.patronymicTextBox.Location = new System.Drawing.Point(6, 283);
            this.patronymicTextBox.MaxLength = 32767;
            this.patronymicTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.patronymicTextBox.Name = "patronymicTextBox";
            this.patronymicTextBox.PasswordChar = '\0';
            this.patronymicTextBox.PrefixSuffixText = null;
            this.patronymicTextBox.ReadOnly = false;
            this.patronymicTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.patronymicTextBox.SelectedText = "";
            this.patronymicTextBox.SelectionLength = 0;
            this.patronymicTextBox.SelectionStart = 0;
            this.patronymicTextBox.ShortcutsEnabled = true;
            this.patronymicTextBox.Size = new System.Drawing.Size(250, 48);
            this.patronymicTextBox.TabIndex = 66;
            this.patronymicTextBox.TabStop = false;
            this.patronymicTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.patronymicTextBox.TrailingIcon = null;
            this.patronymicTextBox.UseSystemPasswordChar = false;
            this.patronymicTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.patronymicTextBox_Validating);
            // 
            // nameTextBox
            // 
            this.nameTextBox.AnimateReadOnly = false;
            this.nameTextBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.nameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.nameTextBox.Depth = 0;
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.nameTextBox.HideSelection = true;
            this.nameTextBox.Hint = "Имя";
            this.nameTextBox.LeadingIcon = null;
            this.nameTextBox.Location = new System.Drawing.Point(6, 229);
            this.nameTextBox.MaxLength = 32767;
            this.nameTextBox.MouseState = MaterialSkin.MouseState.OUT;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.PasswordChar = '\0';
            this.nameTextBox.PrefixSuffixText = null;
            this.nameTextBox.ReadOnly = false;
            this.nameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nameTextBox.SelectedText = "";
            this.nameTextBox.SelectionLength = 0;
            this.nameTextBox.SelectionStart = 0;
            this.nameTextBox.ShortcutsEnabled = true;
            this.nameTextBox.Size = new System.Drawing.Size(250, 48);
            this.nameTextBox.TabIndex = 67;
            this.nameTextBox.TabStop = false;
            this.nameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.nameTextBox.TrailingIcon = null;
            this.nameTextBox.UseSystemPasswordChar = false;
            this.nameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nameTextBox_Validating_1);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 458);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.patronymicTextBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.experienceTextBox);
            this.Controls.Add(this.documentTextBox);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.validTimePicker);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.dateissuanceTimePicker);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.birthdayTimePicker);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.registratinButton);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.surnameTextBox);
            this.Controls.Add(this.materialLabel7);
            this.Name = "Registration";
            this.Text = "Регистрация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Registration_FormClosed);
            this.Load += new System.EventHandler(this.Registration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton registratinButton;
        private MaterialSkin.Controls.MaterialTextBox2 addressTextBox;
        private MaterialSkin.Controls.MaterialTextBox2 surnameTextBox;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialMaskedTextBox numberTextBox;
        private System.Windows.Forms.DateTimePicker birthdayTimePicker;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.DateTimePicker dateissuanceTimePicker;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.DateTimePicker validTimePicker;
        private MaterialSkin.Controls.MaterialMaskedTextBox documentTextBox;
        private MaterialSkin.Controls.MaterialTextBox2 experienceTextBox;
        private MaterialSkin.Controls.MaterialMaskedTextBox passwordTextBox;
        private MaterialSkin.Controls.MaterialMaskedTextBox loginTextBox;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private MaterialSkin.Controls.MaterialButton backButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private MaterialSkin.Controls.MaterialTextBox2 nameTextBox;
        private MaterialSkin.Controls.MaterialTextBox2 patronymicTextBox;
    }
}