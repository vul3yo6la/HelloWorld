namespace SnackIt
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStart = new System.Windows.Forms.Button();
            this.labScore = new System.Windows.Forms.Label();
            this.labPoint = new System.Windows.Forms.Label();
            this.labSnack = new System.Windows.Forms.Label();
            this.panelMap = new System.Windows.Forms.Panel();
            this.labFood = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(57, 659);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(115, 65);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "開始";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // labScore
            // 
            this.labScore.AutoSize = true;
            this.labScore.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labScore.Location = new System.Drawing.Point(12, 25);
            this.labScore.Name = "labScore";
            this.labScore.Size = new System.Drawing.Size(47, 16);
            this.labScore.TabIndex = 1;
            this.labScore.Text = "Score:";
            // 
            // labPoint
            // 
            this.labPoint.AutoSize = true;
            this.labPoint.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labPoint.Location = new System.Drawing.Point(65, 24);
            this.labPoint.Name = "labPoint";
            this.labPoint.Size = new System.Drawing.Size(16, 16);
            this.labPoint.TabIndex = 1;
            this.labPoint.Text = "0";
            // 
            // labSnack
            // 
            this.labSnack.AutoSize = true;
            this.labSnack.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labSnack.Location = new System.Drawing.Point(96, 328);
            this.labSnack.Name = "labSnack";
            this.labSnack.Size = new System.Drawing.Size(0, 12);
            this.labSnack.TabIndex = 0;
            // 
            // panelMap
            // 
            this.panelMap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMap.Location = new System.Drawing.Point(270, 17);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(798, 710);
            this.panelMap.TabIndex = 1;
            this.panelMap.Visible = false;
            // 
            // labFood
            // 
            this.labFood.AutoSize = true;
            this.labFood.BackColor = System.Drawing.Color.Red;
            this.labFood.ForeColor = System.Drawing.Color.Red;
            this.labFood.Location = new System.Drawing.Point(123, 363);
            this.labFood.Name = "labFood";
            this.labFood.Size = new System.Drawing.Size(0, 12);
            this.labFood.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 736);
            this.Controls.Add(this.labFood);
            this.Controls.Add(this.labSnack);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.labPoint);
            this.Controls.Add(this.labScore);
            this.Controls.Add(this.panelMap);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label labScore;
        private System.Windows.Forms.Label labPoint;
        private System.Windows.Forms.Label labSnack;
        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.Label labFood;
    }
}

