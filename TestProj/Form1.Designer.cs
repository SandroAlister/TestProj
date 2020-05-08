namespace TestProj
{
    partial class Form1
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
            DevExpress.XtraCharts.SwiftPlotDiagram swiftPlotDiagram3 = new DevExpress.XtraCharts.SwiftPlotDiagram();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView3 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.seFunctionStep = new DevExpress.XtraEditors.SpinEdit();
            this.sbFunctionEnter = new DevExpress.XtraEditors.SimpleButton();
            this.teFuncionInput = new DevExpress.XtraEditors.TextEdit();
            this.chFunction = new DevExpress.XtraCharts.ChartControl();
            this.meOutPut = new DevExpress.XtraEditors.MemoEdit();
            this.sbStart = new DevExpress.XtraEditors.SimpleButton();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciStart_btn = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciOutPut = new DevExpress.XtraLayout.LayoutControlItem();
            this.esiFooter = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciFunctionChart = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.lciFuncionInput = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFunctionEnter = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFunctionStep = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionStep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFuncionInput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meOutPut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStart_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOutPut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFuncionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionEnter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionStep)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.seFunctionStep);
            this.lcMain.Controls.Add(this.sbFunctionEnter);
            this.lcMain.Controls.Add(this.teFuncionInput);
            this.lcMain.Controls.Add(this.chFunction);
            this.lcMain.Controls.Add(this.meOutPut);
            this.lcMain.Controls.Add(this.sbStart);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.Root = this.lcgMain;
            this.lcMain.Size = new System.Drawing.Size(693, 356);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "lcMain";
            // 
            // seFunctionStep
            // 
            this.seFunctionStep.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seFunctionStep.Location = new System.Drawing.Point(83, 298);
            this.seFunctionStep.Name = "seFunctionStep";
            this.seFunctionStep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seFunctionStep.Properties.DisplayFormat.FormatString = "G29";
            this.seFunctionStep.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.seFunctionStep.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.seFunctionStep.Size = new System.Drawing.Size(217, 20);
            this.seFunctionStep.StyleController = this.lcMain;
            this.seFunctionStep.TabIndex = 10;
            this.seFunctionStep.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.seFunctionStep_Spin);
            this.seFunctionStep.EditValueChanged += new System.EventHandler(this.seFunctionStep_EditValueChanged);
            // 
            // sbFunctionEnter
            // 
            this.sbFunctionEnter.Location = new System.Drawing.Point(12, 322);
            this.sbFunctionEnter.Name = "sbFunctionEnter";
            this.sbFunctionEnter.Size = new System.Drawing.Size(288, 22);
            this.sbFunctionEnter.StyleController = this.lcMain;
            this.sbFunctionEnter.TabIndex = 9;
            this.sbFunctionEnter.Text = "Построить график";
            this.sbFunctionEnter.Click += new System.EventHandler(this.sbFunctionEnter_Click);
            // 
            // teFuncionInput
            // 
            this.teFuncionInput.EditValue = "2*x";
            this.teFuncionInput.Location = new System.Drawing.Point(78, 274);
            this.teFuncionInput.Name = "teFuncionInput";
            this.teFuncionInput.Size = new System.Drawing.Size(222, 20);
            this.teFuncionInput.StyleController = this.lcMain;
            this.teFuncionInput.TabIndex = 8;
            // 
            // chFunction
            // 
            this.chFunction.BorderOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            swiftPlotDiagram3.AxisX.Title.Text = "X";
            swiftPlotDiagram3.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            swiftPlotDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram3.AxisY.Title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            swiftPlotDiagram3.AxisY.Title.Text = "Y";
            swiftPlotDiagram3.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            swiftPlotDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram3.EnableAxisXScrolling = true;
            swiftPlotDiagram3.EnableAxisXZooming = true;
            swiftPlotDiagram3.EnableAxisYScrolling = true;
            swiftPlotDiagram3.EnableAxisYZooming = true;
            this.chFunction.Diagram = swiftPlotDiagram3;
            this.chFunction.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.chFunction.Legend.Name = "Default Legend";
            this.chFunction.Legend.TextVisible = false;
            this.chFunction.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chFunction.Location = new System.Drawing.Point(12, 12);
            this.chFunction.Name = "chFunction";
            series3.Name = "Ряд 1";
            series3.View = swiftPlotSeriesView3;
            this.chFunction.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3};
            this.chFunction.Size = new System.Drawing.Size(288, 258);
            this.chFunction.TabIndex = 7;
            // 
            // meOutPut
            // 
            this.meOutPut.Location = new System.Drawing.Point(309, 12);
            this.meOutPut.Name = "meOutPut";
            this.meOutPut.Size = new System.Drawing.Size(372, 249);
            this.meOutPut.StyleController = this.lcMain;
            this.meOutPut.TabIndex = 6;
            // 
            // sbStart
            // 
            this.sbStart.Location = new System.Drawing.Point(309, 322);
            this.sbStart.Name = "sbStart";
            this.sbStart.Size = new System.Drawing.Size(372, 22);
            this.sbStart.StyleController = this.lcMain;
            this.sbStart.TabIndex = 4;
            this.sbStart.Text = "Начать";
            this.sbStart.Click += new System.EventHandler(this.sbStart_Click);
            // 
            // lcgMain
            // 
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciStart_btn,
            this.lciOutPut,
            this.esiFooter,
            this.lciFunctionChart,
            this.splitterItem1,
            this.lciFuncionInput,
            this.lciFunctionEnter,
            this.lciFunctionStep});
            this.lcgMain.Name = "lcgMain";
            this.lcgMain.Size = new System.Drawing.Size(693, 356);
            this.lcgMain.TextVisible = false;
            // 
            // lciStart_btn
            // 
            this.lciStart_btn.Control = this.sbStart;
            this.lciStart_btn.Location = new System.Drawing.Point(297, 310);
            this.lciStart_btn.Name = "lciStart_btn";
            this.lciStart_btn.Size = new System.Drawing.Size(376, 26);
            this.lciStart_btn.TextSize = new System.Drawing.Size(0, 0);
            this.lciStart_btn.TextVisible = false;
            // 
            // lciOutPut
            // 
            this.lciOutPut.Control = this.meOutPut;
            this.lciOutPut.Location = new System.Drawing.Point(297, 0);
            this.lciOutPut.Name = "lciOutPut";
            this.lciOutPut.Size = new System.Drawing.Size(376, 253);
            this.lciOutPut.TextSize = new System.Drawing.Size(0, 0);
            this.lciOutPut.TextVisible = false;
            // 
            // esiFooter
            // 
            this.esiFooter.AllowHotTrack = false;
            this.esiFooter.Location = new System.Drawing.Point(297, 253);
            this.esiFooter.Name = "esiFooter";
            this.esiFooter.Size = new System.Drawing.Size(376, 57);
            this.esiFooter.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciFunctionChart
            // 
            this.lciFunctionChart.Control = this.chFunction;
            this.lciFunctionChart.Location = new System.Drawing.Point(0, 0);
            this.lciFunctionChart.Name = "lciFunctionChart";
            this.lciFunctionChart.Size = new System.Drawing.Size(292, 262);
            this.lciFunctionChart.TextSize = new System.Drawing.Size(0, 0);
            this.lciFunctionChart.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(292, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 336);
            // 
            // lciFuncionInput
            // 
            this.lciFuncionInput.Control = this.teFuncionInput;
            this.lciFuncionInput.Location = new System.Drawing.Point(0, 262);
            this.lciFuncionInput.Name = "lciFuncionInput";
            this.lciFuncionInput.Size = new System.Drawing.Size(292, 24);
            this.lciFuncionInput.Text = "Функция y=";
            this.lciFuncionInput.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciFuncionInput.TextSize = new System.Drawing.Size(61, 13);
            this.lciFuncionInput.TextToControlDistance = 5;
            // 
            // lciFunctionEnter
            // 
            this.lciFunctionEnter.Control = this.sbFunctionEnter;
            this.lciFunctionEnter.Location = new System.Drawing.Point(0, 310);
            this.lciFunctionEnter.Name = "lciFunctionEnter";
            this.lciFunctionEnter.Size = new System.Drawing.Size(292, 26);
            this.lciFunctionEnter.TextSize = new System.Drawing.Size(0, 0);
            this.lciFunctionEnter.TextVisible = false;
            // 
            // lciFunctionStep
            // 
            this.lciFunctionStep.Control = this.seFunctionStep;
            this.lciFunctionStep.Location = new System.Drawing.Point(0, 286);
            this.lciFunctionStep.Name = "lciFunctionStep";
            this.lciFunctionStep.Size = new System.Drawing.Size(292, 24);
            this.lciFunctionStep.Text = "Шаг функции";
            this.lciFunctionStep.TextSize = new System.Drawing.Size(68, 13);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 356);
            this.Controls.Add(this.lcMain);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionStep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFuncionInput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meOutPut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStart_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOutPut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFuncionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionEnter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraEditors.MemoEdit meOutPut;
        private DevExpress.XtraEditors.SimpleButton sbStart;
        private DevExpress.XtraLayout.LayoutControlItem lciStart_btn;
        private DevExpress.XtraLayout.LayoutControlItem lciOutPut;
        private DevExpress.XtraLayout.EmptySpaceItem esiFooter;
        private DevExpress.XtraEditors.SimpleButton sbFunctionEnter;
        private DevExpress.XtraEditors.TextEdit teFuncionInput;
        private DevExpress.XtraCharts.ChartControl chFunction;
        private DevExpress.XtraLayout.LayoutControlItem lciFunctionChart;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.LayoutControlItem lciFuncionInput;
        private DevExpress.XtraLayout.LayoutControlItem lciFunctionEnter;
        private DevExpress.XtraEditors.SpinEdit seFunctionStep;
        private DevExpress.XtraLayout.LayoutControlItem lciFunctionStep;
    }
}

