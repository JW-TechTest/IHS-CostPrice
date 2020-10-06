using System;
using System.Windows.Forms;
using WSO.CostPriceCalculator.Domain;
using WSO.CostPriceCalculator.Domain.Enums;
using WSO.CostPriceCalculator.Domain.Models;

namespace WSO.CostPriceCalculation
{
    public partial class CalculatorForm : Form
    {
        private SharePortfolio _sharePortfolio;

        public CalculatorForm()
        {
            InitializeComponent();

            cbCostMethod.DataSource = Enum.GetValues(typeof(CostMethod));
            cbCostMethod.SelectedIndex = 0;

            ttResetShares.SetToolTip(btnResetShares, "Resets the share portfolio back to the original hardcoded values");
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {
            InitialiseSharePortfolio();
        }

        private void btnResetShares_Click(object sender, EventArgs e)
        {
            InitialiseSharePortfolio();
        }

        private void btnSellShares_Click(object sender, EventArgs e)
        {
            bool isNumberOfSharesValid = int.TryParse(txtSharesSold.Text, out int numberOfSharesToSell);
            if (!isNumberOfSharesValid || numberOfSharesToSell < 1)
            {
                MessageBox.Show($"Number of shares sold must be a number from 1 to {int.MaxValue}.");
                return;
            }

            bool isPricePerShareValid = decimal.TryParse(txtPricePerShare.Text, out decimal pricePerShare);
            if (!isPricePerShareValid)
            {
                MessageBox.Show("Price per share must be a number.");
                return;
            }

            try
            {
                var saleResults = _sharePortfolio.SellShares(dtSellDate.Value, numberOfSharesToSell, pricePerShare, (CostMethod)cbCostMethod.SelectedItem);

                lblCostPriceSoldSharesValue.Text = Math.Round(saleResults.CostPrice, 3, MidpointRounding.AwayFromZero).ToString();
                lblGainLossOnSaleValue.Text = Math.Round(saleResults.GainLoss, 3, MidpointRounding.AwayFromZero).ToString();
                RenderRemainingShareInfo();
            }
            catch (DomainValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RenderRemainingShareInfo()
        {
            lblRemainingSharesValue.Text = _sharePortfolio.NumberOfSharesOwned.ToString();
            lblCostPriceRemainingSharesValue.Text = Math.Round(_sharePortfolio.CostPrice, 8, MidpointRounding.AwayFromZero).ToString();
        }

        /// <summary>
        /// Sets the share portfolio to the hardcoded values provided
        /// </summary>
        private void InitialiseSharePortfolio()
        {
            _sharePortfolio = new SharePortfolio();
            _sharePortfolio.PurchaseShares(new DateTime(2005, 1, 1), 100, 10m);
            _sharePortfolio.PurchaseShares(new DateTime(2005, 2, 2), 40, 12m);
            _sharePortfolio.PurchaseShares(new DateTime(2005, 3, 3), 50, 11m);

            RenderRemainingShareInfo();

            lblCostPriceSoldSharesValue.Text = string.Empty;
            lblGainLossOnSaleValue.Text = string.Empty;
        }
    }
}
