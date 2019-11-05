namespace CorpAppLab1.Forms
{
    partial class CreateOrderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.orderDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtBoxOrderTotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddDish = new System.Windows.Forms.Button();
            this.dishesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Создание заказа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Дата заказа";
            // 
            // orderDateTimePicker
            // 
            this.orderDateTimePicker.Location = new System.Drawing.Point(122, 62);
            this.orderDateTimePicker.Name = "orderDateTimePicker";
            this.orderDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.orderDateTimePicker.TabIndex = 2;
            // 
            // txtBoxOrderTotal
            // 
            this.txtBoxOrderTotal.Location = new System.Drawing.Point(122, 111);
            this.txtBoxOrderTotal.Name = "txtBoxOrderTotal";
            this.txtBoxOrderTotal.ReadOnly = true;
            this.txtBoxOrderTotal.Size = new System.Drawing.Size(200, 20);
            this.txtBoxOrderTotal.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Сумма заказа";
            // 
            // btnAddDish
            // 
            this.btnAddDish.Location = new System.Drawing.Point(16, 169);
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.Size = new System.Drawing.Size(120, 23);
            this.btnAddDish.TabIndex = 6;
            this.btnAddDish.Text = "Добавить блюдо";
            this.btnAddDish.UseVisualStyleBackColor = true;
            this.btnAddDish.Click += new System.EventHandler(this.btnAddDish_Click);
            // 
            // dishesListBox
            // 
            this.dishesListBox.FormattingEnabled = true;
            this.dishesListBox.Location = new System.Drawing.Point(16, 199);
            this.dishesListBox.Name = "dishesListBox";
            this.dishesListBox.Size = new System.Drawing.Size(306, 225);
            this.dishesListBox.TabIndex = 7;
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 434);
            this.Controls.Add(this.dishesListBox);
            this.Controls.Add(this.btnAddDish);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBoxOrderTotal);
            this.Controls.Add(this.orderDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CreateOrderForm";
            this.Text = "CreateOrderForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateOrderForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker orderDateTimePicker;
        private System.Windows.Forms.TextBox txtBoxOrderTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddDish;
        private System.Windows.Forms.ListBox dishesListBox;
    }
}