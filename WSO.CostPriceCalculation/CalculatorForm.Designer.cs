namespace WSO.CostPriceCalculation
{
    partial class CalculatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSharesSold = new System.Windows.Forms.Label();
            this.txtSharesSold = new System.Windows.Forms.TextBox();
            this.lblPricePerShare = new System.Windows.Forms.Label();
            this.txtPricePerShare = new System.Windows.Forms.TextBox();
            this.dtSellDate = new System.Windows.Forms.DateTimePicker();
            this.lblSellDate = new System.Windows.Forms.Label();
            this.lblCostMethod = new System.Windows.Forms.Label();
            this.cbCostMethod = new System.Windows.Forms.ComboBox();
            this.btnSellShares = new System.Windows.Forms.Button();
            this.lblCostPriceSoldShares = new System.Windows.Forms.Label();
            this.lblGainLoss = new System.Windows.Forms.Label();
            this.lblRemainingShares = new System.Windows.Forms.Label();
            this.lblCostPriceRemainingShares = new System.Windows.Forms.Label();
            this.lblCostPriceSoldSharesValue = new System.Windows.Forms.Label();
            this.lblGainLossOnSaleValue = new System.Windows.Forms.Label();
            this.lblRemainingSharesValue = new System.Windows.Forms.Label();
            this.lblCostPriceRemainingSharesValue = new System.Windows.Forms.Label();
            this.btnResetShares = new System.Windows.Forms.Button();
            this.ttResetShares = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblSharesSold
            // 
            this.lblSharesSold.AutoSize = true;
            this.lblSharesSold.Location = new System.Drawing.Point(111, 16);
            this.lblSharesSold.Name = "lblSharesSold";
            this.lblSharesSold.Size = new System.Drawing.Size(67, 15);
            this.lblSharesSold.TabIndex = 0;
            this.lblSharesSold.Text = "Shares Sold";
            // 
            // txtSharesSold
            // 
            this.txtSharesSold.Location = new System.Drawing.Point(184, 13);
            this.txtSharesSold.Name = "txtSharesSold";
            this.txtSharesSold.Size = new System.Drawing.Size(100, 23);
            this.txtSharesSold.TabIndex = 1;
            // 
            // lblPricePerShare
            // 
            this.lblPricePerShare.AutoSize = true;
            this.lblPricePerShare.Location = new System.Drawing.Point(93, 50);
            this.lblPricePerShare.Name = "lblPricePerShare";
            this.lblPricePerShare.Size = new System.Drawing.Size(85, 15);
            this.lblPricePerShare.TabIndex = 0;
            this.lblPricePerShare.Text = "Price Per Share";
            // 
            // txtPricePerShare
            // 
            this.txtPricePerShare.Location = new System.Drawing.Point(184, 47);
            this.txtPricePerShare.Name = "txtPricePerShare";
            this.txtPricePerShare.Size = new System.Drawing.Size(100, 23);
            this.txtPricePerShare.TabIndex = 2;
            // 
            // dtSellDate
            // 
            this.dtSellDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSellDate.Location = new System.Drawing.Point(184, 81);
            this.dtSellDate.Name = "dtSellDate";
            this.dtSellDate.Size = new System.Drawing.Size(100, 23);
            this.dtSellDate.TabIndex = 3;
            // 
            // lblSellDate
            // 
            this.lblSellDate.AutoSize = true;
            this.lblSellDate.Location = new System.Drawing.Point(126, 84);
            this.lblSellDate.Name = "lblSellDate";
            this.lblSellDate.Size = new System.Drawing.Size(52, 15);
            this.lblSellDate.TabIndex = 0;
            this.lblSellDate.Text = "Sell Date";
            // 
            // lblCostMethod
            // 
            this.lblCostMethod.AutoSize = true;
            this.lblCostMethod.Location = new System.Drawing.Point(102, 118);
            this.lblCostMethod.Name = "lblCostMethod";
            this.lblCostMethod.Size = new System.Drawing.Size(76, 15);
            this.lblCostMethod.TabIndex = 0;
            this.lblCostMethod.Text = "Cost Method";
            // 
            // cbCostMethod
            // 
            this.cbCostMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCostMethod.FormattingEnabled = true;
            this.cbCostMethod.Items.AddRange(new object[] {
            "FIFO",
            "LIFO",
            "Highest Cost",
            "Lowest Cost"});
            this.cbCostMethod.Location = new System.Drawing.Point(184, 115);
            this.cbCostMethod.Name = "cbCostMethod";
            this.cbCostMethod.Size = new System.Drawing.Size(100, 23);
            this.cbCostMethod.TabIndex = 4;
            // 
            // btnSellShares
            // 
            this.btnSellShares.Location = new System.Drawing.Point(209, 176);
            this.btnSellShares.Name = "btnSellShares";
            this.btnSellShares.Size = new System.Drawing.Size(75, 23);
            this.btnSellShares.TabIndex = 5;
            this.btnSellShares.Text = "Sell Shares";
            this.btnSellShares.UseVisualStyleBackColor = true;
            this.btnSellShares.Click += new System.EventHandler(this.btnSellShares_Click);
            // 
            // lblCostPriceSoldShares
            // 
            this.lblCostPriceSoldShares.AutoSize = true;
            this.lblCostPriceSoldShares.Location = new System.Drawing.Point(111, 228);
            this.lblCostPriceSoldShares.Name = "lblCostPriceSoldShares";
            this.lblCostPriceSoldShares.Size = new System.Drawing.Size(140, 15);
            this.lblCostPriceSoldShares.TabIndex = 5;
            this.lblCostPriceSoldShares.Text = "Cost Price of Sold Shares:";
            // 
            // lblGainLoss
            // 
            this.lblGainLoss.AutoSize = true;
            this.lblGainLoss.Location = new System.Drawing.Point(143, 253);
            this.lblGainLoss.Name = "lblGainLoss";
            this.lblGainLoss.Size = new System.Drawing.Size(108, 15);
            this.lblGainLoss.TabIndex = 5;
            this.lblGainLoss.Text = "Gain / Loss on sale:";
            // 
            // lblRemainingShares
            // 
            this.lblRemainingShares.AutoSize = true;
            this.lblRemainingShares.Location = new System.Drawing.Point(90, 278);
            this.lblRemainingShares.Name = "lblRemainingShares";
            this.lblRemainingShares.Size = new System.Drawing.Size(161, 15);
            this.lblRemainingShares.TabIndex = 5;
            this.lblRemainingShares.Text = "Number of remaining shares:";
            // 
            // lblCostPriceRemainingShares
            // 
            this.lblCostPriceRemainingShares.AutoSize = true;
            this.lblCostPriceRemainingShares.Location = new System.Drawing.Point(81, 303);
            this.lblCostPriceRemainingShares.Name = "lblCostPriceRemainingShares";
            this.lblCostPriceRemainingShares.Size = new System.Drawing.Size(170, 15);
            this.lblCostPriceRemainingShares.TabIndex = 5;
            this.lblCostPriceRemainingShares.Text = "Cost Price of remaining shares:";
            // 
            // lblCostPriceSoldSharesValue
            // 
            this.lblCostPriceSoldSharesValue.AutoSize = true;
            this.lblCostPriceSoldSharesValue.Location = new System.Drawing.Point(257, 228);
            this.lblCostPriceSoldSharesValue.Name = "lblCostPriceSoldSharesValue";
            this.lblCostPriceSoldSharesValue.Size = new System.Drawing.Size(0, 15);
            this.lblCostPriceSoldSharesValue.TabIndex = 6;
            // 
            // lblGainLossOnSaleValue
            // 
            this.lblGainLossOnSaleValue.AutoSize = true;
            this.lblGainLossOnSaleValue.Location = new System.Drawing.Point(257, 253);
            this.lblGainLossOnSaleValue.Name = "lblGainLossOnSaleValue";
            this.lblGainLossOnSaleValue.Size = new System.Drawing.Size(0, 15);
            this.lblGainLossOnSaleValue.TabIndex = 6;
            // 
            // lblRemainingSharesValue
            // 
            this.lblRemainingSharesValue.AutoSize = true;
            this.lblRemainingSharesValue.Location = new System.Drawing.Point(257, 278);
            this.lblRemainingSharesValue.Name = "lblRemainingSharesValue";
            this.lblRemainingSharesValue.Size = new System.Drawing.Size(0, 15);
            this.lblRemainingSharesValue.TabIndex = 6;
            // 
            // lblCostPriceRemainingSharesValue
            // 
            this.lblCostPriceRemainingSharesValue.AutoSize = true;
            this.lblCostPriceRemainingSharesValue.Location = new System.Drawing.Point(257, 303);
            this.lblCostPriceRemainingSharesValue.Name = "lblCostPriceRemainingSharesValue";
            this.lblCostPriceRemainingSharesValue.Size = new System.Drawing.Size(0, 15);
            this.lblCostPriceRemainingSharesValue.TabIndex = 6;
            // 
            // btnResetShares
            // 
            this.btnResetShares.Location = new System.Drawing.Point(93, 176);
            this.btnResetShares.Name = "btnResetShares";
            this.btnResetShares.Size = new System.Drawing.Size(85, 23);
            this.btnResetShares.TabIndex = 7;
            this.btnResetShares.Text = "Reset Shares";
            this.btnResetShares.UseVisualStyleBackColor = true;
            this.btnResetShares.Click += new System.EventHandler(this.btnResetShares_Click);
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 339);
            this.Controls.Add(this.btnResetShares);
            this.Controls.Add(this.lblCostPriceRemainingSharesValue);
            this.Controls.Add(this.lblRemainingSharesValue);
            this.Controls.Add(this.lblGainLossOnSaleValue);
            this.Controls.Add(this.lblCostPriceSoldSharesValue);
            this.Controls.Add(this.lblCostPriceRemainingShares);
            this.Controls.Add(this.lblRemainingShares);
            this.Controls.Add(this.lblGainLoss);
            this.Controls.Add(this.lblCostPriceSoldShares);
            this.Controls.Add(this.btnSellShares);
            this.Controls.Add(this.cbCostMethod);
            this.Controls.Add(this.lblCostMethod);
            this.Controls.Add(this.lblSellDate);
            this.Controls.Add(this.dtSellDate);
            this.Controls.Add(this.txtPricePerShare);
            this.Controls.Add(this.lblPricePerShare);
            this.Controls.Add(this.txtSharesSold);
            this.Controls.Add(this.lblSharesSold);
            this.Name = "CalculatorForm";
            this.Text = "WSO Cost Price Calculator";
            this.Load += new System.EventHandler(this.CalculatorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSharesSold;
        private System.Windows.Forms.TextBox txtSharesSold;
        private System.Windows.Forms.Label lblPricePerShare;
        private System.Windows.Forms.TextBox txtPricePerShare;
        private System.Windows.Forms.DateTimePicker dtSellDate;
        private System.Windows.Forms.Label lblSellDate;
        private System.Windows.Forms.Label lblCostMethod;
        private System.Windows.Forms.ComboBox cbCostMethod;
        private System.Windows.Forms.Button btnSellShares;
        private System.Windows.Forms.Label lblCostPriceSoldShares;
        private System.Windows.Forms.Label lblGainLoss;
        private System.Windows.Forms.Label lblRemainingShares;
        private System.Windows.Forms.Label lblCostPriceRemainingShares;
        private System.Windows.Forms.Label lblCostPriceSoldSharesValue;
        private System.Windows.Forms.Label lblGainLossOnSaleValue;
        private System.Windows.Forms.Label lblRemainingSharesValue;
        private System.Windows.Forms.Label lblCostPriceRemainingSharesValue;
        private System.Windows.Forms.Button btnResetShares;
        private System.Windows.Forms.ToolTip ttResetShares;
    }
}

