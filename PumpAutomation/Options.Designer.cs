namespace PumpAutomation
{
    partial class Options
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
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_lock = new System.Windows.Forms.Button();
            this.tabp_rapport = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.cb_logginerval = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.tabp_hmi = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cb_modbusmode = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tb_plcPort = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tb_plcip = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_plc_fast_cycle_delay = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_plc_slow_cycle_delay = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_GuiUpdateTime = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabp_process = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_Rfilter_alarm_press = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txt_Rfilter_warn_press = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_tfilter_alarm_press = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txt_tfilter_warn_press = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.gbx_oil = new System.Windows.Forms.GroupBox();
            this.txt_oil_water_Alarm = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.txt_oil_water_warn = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txt_oil_volume_high_cm = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_oil_volume_low_cm = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_oil_volume_high = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_oil_volume_low = new System.Windows.Forms.TextBox();
            this.txt_oil_temp_high = new System.Windows.Forms.TextBox();
            this.txt_oil_temp_low = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbc_options = new System.Windows.Forms.TabControl();
            this.tabp_rapport.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabp_hmi.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabp_process.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbx_oil.SuspendLayout();
            this.tbc_options.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(229, 562);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(82, 30);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_lock
            // 
            this.btn_lock.Location = new System.Drawing.Point(315, 562);
            this.btn_lock.Margin = new System.Windows.Forms.Padding(2);
            this.btn_lock.Name = "btn_lock";
            this.btn_lock.Size = new System.Drawing.Size(82, 30);
            this.btn_lock.TabIndex = 16;
            this.btn_lock.Text = "Unlock";
            this.btn_lock.UseVisualStyleBackColor = true;
            this.btn_lock.Click += new System.EventHandler(this.btn_lock_Click);
            // 
            // tabp_rapport
            // 
            this.tabp_rapport.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabp_rapport.Controls.Add(this.groupBox5);
            this.tabp_rapport.Location = new System.Drawing.Point(4, 22);
            this.tabp_rapport.Margin = new System.Windows.Forms.Padding(2);
            this.tabp_rapport.Name = "tabp_rapport";
            this.tabp_rapport.Padding = new System.Windows.Forms.Padding(2);
            this.tabp_rapport.Size = new System.Drawing.Size(608, 531);
            this.tabp_rapport.TabIndex = 2;
            this.tabp_rapport.Text = "Rapport / Logging";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label38);
            this.groupBox5.Controls.Add(this.cb_logginerval);
            this.groupBox5.Controls.Add(this.label39);
            this.groupBox5.Location = new System.Drawing.Point(4, 5);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(214, 59);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Rapport Logging";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(188, 28);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(26, 13);
            this.label38.TabIndex = 3;
            this.label38.Text = "Sec";
            // 
            // cb_logginerval
            // 
            this.cb_logginerval.FormattingEnabled = true;
            this.cb_logginerval.Location = new System.Drawing.Point(118, 25);
            this.cb_logginerval.Name = "cb_logginerval";
            this.cb_logginerval.Size = new System.Drawing.Size(64, 21);
            this.cb_logginerval.TabIndex = 2;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(5, 28);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(116, 13);
            this.label39.TabIndex = 0;
            this.label39.Text = "Logging to DB Interval:";
            // 
            // tabp_hmi
            // 
            this.tabp_hmi.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabp_hmi.Controls.Add(this.groupBox6);
            this.tabp_hmi.Controls.Add(this.groupBox2);
            this.tabp_hmi.Location = new System.Drawing.Point(4, 22);
            this.tabp_hmi.Margin = new System.Windows.Forms.Padding(2);
            this.tabp_hmi.Name = "tabp_hmi";
            this.tabp_hmi.Padding = new System.Windows.Forms.Padding(2);
            this.tabp_hmi.Size = new System.Drawing.Size(608, 531);
            this.tabp_hmi.TabIndex = 0;
            this.tabp_hmi.Text = "GUI / HMI ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cb_modbusmode);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Location = new System.Drawing.Point(9, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(241, 295);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Comminication";
            // 
            // cb_modbusmode
            // 
            this.cb_modbusmode.AutoSize = true;
            this.cb_modbusmode.Location = new System.Drawing.Point(18, 29);
            this.cb_modbusmode.Name = "cb_modbusmode";
            this.cb_modbusmode.Size = new System.Drawing.Size(88, 17);
            this.cb_modbusmode.TabIndex = 15;
            this.cb_modbusmode.Text = "Modbus TCP";
            this.cb_modbusmode.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tb_plcPort);
            this.groupBox7.Controls.Add(this.label34);
            this.groupBox7.Controls.Add(this.tb_plcip);
            this.groupBox7.Controls.Add(this.label43);
            this.groupBox7.Location = new System.Drawing.Point(18, 51);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(204, 219);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Ethernet TCP/IP";
            // 
            // tb_plcPort
            // 
            this.tb_plcPort.Location = new System.Drawing.Point(59, 51);
            this.tb_plcPort.Name = "tb_plcPort";
            this.tb_plcPort.Size = new System.Drawing.Size(57, 20);
            this.tb_plcPort.TabIndex = 5;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(5, 55);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 13);
            this.label34.TabIndex = 4;
            this.label34.Text = "Port:";
            // 
            // tb_plcip
            // 
            this.tb_plcip.Location = new System.Drawing.Point(59, 25);
            this.tb_plcip.Name = "tb_plcip";
            this.tb_plcip.Size = new System.Drawing.Size(131, 20);
            this.tb_plcip.TabIndex = 3;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(5, 28);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(48, 13);
            this.label43.TabIndex = 0;
            this.label43.Text = "Address:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cb_plc_fast_cycle_delay);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cb_plc_slow_cycle_delay);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cb_GuiUpdateTime);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(9, 312);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(241, 145);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "ms";
            // 
            // cb_plc_fast_cycle_delay
            // 
            this.cb_plc_fast_cycle_delay.FormattingEnabled = true;
            this.cb_plc_fast_cycle_delay.Location = new System.Drawing.Point(116, 85);
            this.cb_plc_fast_cycle_delay.Name = "cb_plc_fast_cycle_delay";
            this.cb_plc_fast_cycle_delay.Size = new System.Drawing.Size(64, 21);
            this.cb_plc_fast_cycle_delay.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Plc Fast Cycle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "ms";
            // 
            // cb_plc_slow_cycle_delay
            // 
            this.cb_plc_slow_cycle_delay.FormattingEnabled = true;
            this.cb_plc_slow_cycle_delay.Location = new System.Drawing.Point(116, 57);
            this.cb_plc_slow_cycle_delay.Name = "cb_plc_slow_cycle_delay";
            this.cb_plc_slow_cycle_delay.Size = new System.Drawing.Size(64, 21);
            this.cb_plc_slow_cycle_delay.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Plc Slow Cycle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "ms";
            // 
            // cb_GuiUpdateTime
            // 
            this.cb_GuiUpdateTime.FormattingEnabled = true;
            this.cb_GuiUpdateTime.Location = new System.Drawing.Point(116, 30);
            this.cb_GuiUpdateTime.Name = "cb_GuiUpdateTime";
            this.cb_GuiUpdateTime.Size = new System.Drawing.Size(64, 21);
            this.cb_GuiUpdateTime.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "GUI Update Time:";
            // 
            // tabp_process
            // 
            this.tabp_process.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabp_process.Controls.Add(this.groupBox4);
            this.tabp_process.Controls.Add(this.groupBox3);
            this.tabp_process.Controls.Add(this.gbx_oil);
            this.tabp_process.Location = new System.Drawing.Point(4, 22);
            this.tabp_process.Margin = new System.Windows.Forms.Padding(2);
            this.tabp_process.Name = "tabp_process";
            this.tabp_process.Padding = new System.Windows.Forms.Padding(2);
            this.tabp_process.Size = new System.Drawing.Size(608, 531);
            this.tabp_process.TabIndex = 1;
            this.tabp_process.Text = "Process";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_Rfilter_alarm_press);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.txt_Rfilter_warn_press);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 414);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(286, 86);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Retur Filter";
            // 
            // txt_Rfilter_alarm_press
            // 
            this.txt_Rfilter_alarm_press.Location = new System.Drawing.Point(178, 49);
            this.txt_Rfilter_alarm_press.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Rfilter_alarm_press.Name = "txt_Rfilter_alarm_press";
            this.txt_Rfilter_alarm_press.Size = new System.Drawing.Size(44, 26);
            this.txt_Rfilter_alarm_press.TabIndex = 19;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(229, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(34, 20);
            this.label24.TabIndex = 18;
            this.label24.Text = "Bar";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 53);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(124, 20);
            this.label25.TabIndex = 17;
            this.label25.Text = "Alarm Threshold";
            // 
            // txt_Rfilter_warn_press
            // 
            this.txt_Rfilter_warn_press.Location = new System.Drawing.Point(178, 20);
            this.txt_Rfilter_warn_press.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Rfilter_warn_press.Name = "txt_Rfilter_warn_press";
            this.txt_Rfilter_warn_press.Size = new System.Drawing.Size(44, 26);
            this.txt_Rfilter_warn_press.TabIndex = 16;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(229, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(34, 20);
            this.label26.TabIndex = 3;
            this.label26.Text = "Bar";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(12, 24);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(142, 20);
            this.label27.TabIndex = 0;
            this.label27.Text = "Warning Threshold";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_tfilter_alarm_press);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txt_tfilter_warn_press);
            this.groupBox3.Controls.Add(this.label32);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 314);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(286, 86);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "T Filter";
            // 
            // txt_tfilter_alarm_press
            // 
            this.txt_tfilter_alarm_press.Location = new System.Drawing.Point(178, 49);
            this.txt_tfilter_alarm_press.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tfilter_alarm_press.Name = "txt_tfilter_alarm_press";
            this.txt_tfilter_alarm_press.Size = new System.Drawing.Size(44, 26);
            this.txt_tfilter_alarm_press.TabIndex = 19;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(229, 53);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 20);
            this.label22.TabIndex = 18;
            this.label22.Text = "Bar";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 53);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(124, 20);
            this.label23.TabIndex = 17;
            this.label23.Text = "Alarm Threshold";
            // 
            // txt_tfilter_warn_press
            // 
            this.txt_tfilter_warn_press.Location = new System.Drawing.Point(178, 20);
            this.txt_tfilter_warn_press.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tfilter_warn_press.Name = "txt_tfilter_warn_press";
            this.txt_tfilter_warn_press.Size = new System.Drawing.Size(44, 26);
            this.txt_tfilter_warn_press.TabIndex = 16;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(229, 24);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(34, 20);
            this.label32.TabIndex = 3;
            this.label32.Text = "Bar";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(12, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(142, 20);
            this.label33.TabIndex = 0;
            this.label33.Text = "Warning Threshold";
            // 
            // gbx_oil
            // 
            this.gbx_oil.Controls.Add(this.txt_oil_water_Alarm);
            this.gbx_oil.Controls.Add(this.label30);
            this.gbx_oil.Controls.Add(this.label31);
            this.gbx_oil.Controls.Add(this.txt_oil_water_warn);
            this.gbx_oil.Controls.Add(this.label28);
            this.gbx_oil.Controls.Add(this.label29);
            this.gbx_oil.Controls.Add(this.txt_oil_volume_high_cm);
            this.gbx_oil.Controls.Add(this.label18);
            this.gbx_oil.Controls.Add(this.label19);
            this.gbx_oil.Controls.Add(this.txt_oil_volume_low_cm);
            this.gbx_oil.Controls.Add(this.label20);
            this.gbx_oil.Controls.Add(this.label21);
            this.gbx_oil.Controls.Add(this.txt_oil_volume_high);
            this.gbx_oil.Controls.Add(this.label16);
            this.gbx_oil.Controls.Add(this.label17);
            this.gbx_oil.Controls.Add(this.txt_oil_volume_low);
            this.gbx_oil.Controls.Add(this.txt_oil_temp_high);
            this.gbx_oil.Controls.Add(this.txt_oil_temp_low);
            this.gbx_oil.Controls.Add(this.label9);
            this.gbx_oil.Controls.Add(this.label11);
            this.gbx_oil.Controls.Add(this.label12);
            this.gbx_oil.Controls.Add(this.label13);
            this.gbx_oil.Controls.Add(this.label14);
            this.gbx_oil.Controls.Add(this.label15);
            this.gbx_oil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_oil.Location = new System.Drawing.Point(12, 14);
            this.gbx_oil.Margin = new System.Windows.Forms.Padding(2);
            this.gbx_oil.Name = "gbx_oil";
            this.gbx_oil.Padding = new System.Windows.Forms.Padding(2);
            this.gbx_oil.Size = new System.Drawing.Size(286, 275);
            this.gbx_oil.TabIndex = 15;
            this.gbx_oil.TabStop = false;
            this.gbx_oil.Text = "Olje";
            // 
            // txt_oil_water_Alarm
            // 
            this.txt_oil_water_Alarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oil_water_Alarm.Location = new System.Drawing.Point(179, 240);
            this.txt_oil_water_Alarm.Margin = new System.Windows.Forms.Padding(2);
            this.txt_oil_water_Alarm.Name = "txt_oil_water_Alarm";
            this.txt_oil_water_Alarm.Size = new System.Drawing.Size(44, 26);
            this.txt_oil_water_Alarm.TabIndex = 33;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(228, 243);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(23, 20);
            this.label30.TabIndex = 32;
            this.label30.Text = "%";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(12, 245);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(158, 20);
            this.label31.TabIndex = 31;
            this.label31.Text = "Water Content Alarm";
            // 
            // txt_oil_water_warn
            // 
            this.txt_oil_water_warn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oil_water_warn.Location = new System.Drawing.Point(179, 210);
            this.txt_oil_water_warn.Margin = new System.Windows.Forms.Padding(2);
            this.txt_oil_water_warn.Name = "txt_oil_water_warn";
            this.txt_oil_water_warn.Size = new System.Drawing.Size(44, 26);
            this.txt_oil_water_warn.TabIndex = 30;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(228, 213);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(23, 20);
            this.label28.TabIndex = 29;
            this.label28.Text = "%";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(12, 215);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(176, 20);
            this.label29.TabIndex = 28;
            this.label29.Text = "Water Content Warning";
            // 
            // txt_oil_volume_high_cm
            // 
            this.txt_oil_volume_high_cm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oil_volume_high_cm.Location = new System.Drawing.Point(179, 180);
            this.txt_oil_volume_high_cm.Margin = new System.Windows.Forms.Padding(2);
            this.txt_oil_volume_high_cm.Name = "txt_oil_volume_high_cm";
            this.txt_oil_volume_high_cm.Size = new System.Drawing.Size(44, 26);
            this.txt_oil_volume_high_cm.TabIndex = 27;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(228, 183);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 20);
            this.label18.TabIndex = 26;
            this.label18.Text = "Cm";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(12, 185);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(157, 20);
            this.label19.TabIndex = 25;
            this.label19.Text = "High Volume In Tank";
            // 
            // txt_oil_volume_low_cm
            // 
            this.txt_oil_volume_low_cm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oil_volume_low_cm.Location = new System.Drawing.Point(179, 150);
            this.txt_oil_volume_low_cm.Margin = new System.Windows.Forms.Padding(2);
            this.txt_oil_volume_low_cm.Name = "txt_oil_volume_low_cm";
            this.txt_oil_volume_low_cm.Size = new System.Drawing.Size(44, 26);
            this.txt_oil_volume_low_cm.TabIndex = 24;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(228, 153);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 20);
            this.label20.TabIndex = 23;
            this.label20.Text = "Cm";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 155);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(153, 20);
            this.label21.TabIndex = 22;
            this.label21.Text = "Low Volume In Tank";
            // 
            // txt_oil_volume_high
            // 
            this.txt_oil_volume_high.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oil_volume_high.Location = new System.Drawing.Point(179, 120);
            this.txt_oil_volume_high.Margin = new System.Windows.Forms.Padding(2);
            this.txt_oil_volume_high.Name = "txt_oil_volume_high";
            this.txt_oil_volume_high.Size = new System.Drawing.Size(44, 26);
            this.txt_oil_volume_high.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(228, 123);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 20);
            this.label16.TabIndex = 20;
            this.label16.Text = "Liters";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 125);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(157, 20);
            this.label17.TabIndex = 19;
            this.label17.Text = "High Volume In Tank";
            // 
            // txt_oil_volume_low
            // 
            this.txt_oil_volume_low.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oil_volume_low.Location = new System.Drawing.Point(179, 90);
            this.txt_oil_volume_low.Margin = new System.Windows.Forms.Padding(2);
            this.txt_oil_volume_low.Name = "txt_oil_volume_low";
            this.txt_oil_volume_low.Size = new System.Drawing.Size(44, 26);
            this.txt_oil_volume_low.TabIndex = 18;
            // 
            // txt_oil_temp_high
            // 
            this.txt_oil_temp_high.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oil_temp_high.Location = new System.Drawing.Point(179, 60);
            this.txt_oil_temp_high.Margin = new System.Windows.Forms.Padding(2);
            this.txt_oil_temp_high.Name = "txt_oil_temp_high";
            this.txt_oil_temp_high.Size = new System.Drawing.Size(44, 26);
            this.txt_oil_temp_high.TabIndex = 17;
            // 
            // txt_oil_temp_low
            // 
            this.txt_oil_temp_low.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oil_temp_low.Location = new System.Drawing.Point(179, 30);
            this.txt_oil_temp_low.Margin = new System.Windows.Forms.Padding(2);
            this.txt_oil_temp_low.Name = "txt_oil_temp_low";
            this.txt_oil_temp_low.Size = new System.Drawing.Size(44, 26);
            this.txt_oil_temp_low.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(228, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Liters";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Low Volume In Tank";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(228, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "°C";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(160, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "High Temp Threshold";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(228, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 20);
            this.label14.TabIndex = 3;
            this.label14.Text = "°C";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(156, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Low Temp Threshold";
            // 
            // tbc_options
            // 
            this.tbc_options.Controls.Add(this.tabp_process);
            this.tbc_options.Controls.Add(this.tabp_hmi);
            this.tbc_options.Controls.Add(this.tabp_rapport);
            this.tbc_options.Location = new System.Drawing.Point(2, 1);
            this.tbc_options.Margin = new System.Windows.Forms.Padding(2);
            this.tbc_options.Name = "tbc_options";
            this.tbc_options.SelectedIndex = 0;
            this.tbc_options.Size = new System.Drawing.Size(616, 557);
            this.tbc_options.TabIndex = 15;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(620, 602);
            this.Controls.Add(this.btn_lock);
            this.Controls.Add(this.tbc_options);
            this.Controls.Add(this.btn_save);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Options";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.tabp_rapport.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabp_hmi.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabp_process.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbx_oil.ResumeLayout(false);
            this.gbx_oil.PerformLayout();
            this.tbc_options.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_lock;
        private System.Windows.Forms.TabPage tabp_rapport;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox cb_logginerval;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TabPage tabp_hmi;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_plc_fast_cycle_delay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_plc_slow_cycle_delay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_GuiUpdateTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabp_process;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_Rfilter_alarm_press;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txt_Rfilter_warn_press;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_tfilter_alarm_press;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_tfilter_warn_press;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.GroupBox gbx_oil;
        private System.Windows.Forms.TextBox txt_oil_water_Alarm;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txt_oil_water_warn;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txt_oil_volume_high_cm;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_oil_volume_low_cm;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_oil_volume_high;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_oil_volume_low;
        private System.Windows.Forms.TextBox txt_oil_temp_high;
        private System.Windows.Forms.TextBox txt_oil_temp_low;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabControl tbc_options;
        private System.Windows.Forms.CheckBox cb_modbusmode;
        private System.Windows.Forms.TextBox tb_plcip;
        private System.Windows.Forms.TextBox tb_plcPort;
        private System.Windows.Forms.Label label34;
    }
}