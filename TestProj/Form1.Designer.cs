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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel1 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel2 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel3 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.ceIsDuplicate = new DevExpress.XtraEditors.CheckEdit();
            this.ceIsDisplay = new DevExpress.XtraEditors.CheckEdit();
            this.seGroupSize = new DevExpress.XtraEditors.SpinEdit();
            this.lcCalcTimer = new DevExpress.XtraEditors.LabelControl();
            this.seMutationGeneProbability = new DevExpress.XtraEditors.SpinEdit();
            this.lueSelectCross = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSelectParent = new DevExpress.XtraEditors.LookUpEdit();
            this.seMutationProbability = new DevExpress.XtraEditors.SpinEdit();
            this.sePopulationSize = new DevExpress.XtraEditors.SpinEdit();
            this.seGenerationSize = new DevExpress.XtraEditors.SpinEdit();
            this.seSelectionTreshold = new DevExpress.XtraEditors.SpinEdit();
            this.lueSelectSelection = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSelectMutate = new DevExpress.XtraEditors.LookUpEdit();
            this.seMutateGeneCount = new DevExpress.XtraEditors.SpinEdit();
            this.seDevidePointCount = new DevExpress.XtraEditors.SpinEdit();
            this.lueSelectTarget = new DevExpress.XtraEditors.LookUpEdit();
            this.cmboFunction = new DevExpress.XtraEditors.ComboBoxEdit();
            this.seFunctionFinishValue = new DevExpress.XtraEditors.SpinEdit();
            this.seFunctionStartValue = new DevExpress.XtraEditors.SpinEdit();
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
            this.lciFunctionStartValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFunctionFinishValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFunctionStep = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCmboFunction = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectTarget = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDevidePointCount = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMutateGeneCount = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectSelection = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectionTreshold = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGenerationSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMutationProbability = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPopulationSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectParent = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectCross = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMutationGeneProbability = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectMutate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCalcTimer = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGroupSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciIsDisplay = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciIsDuplicate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgMutation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.calculateTimer = new System.Windows.Forms.Timer(this.components);
            this.rngPopulationTrack = new DevExpress.XtraEditors.TrackBarControl();
            this.lciPopulationTrack = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem3 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDuplicate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDisplay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGroupSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutationGeneProbability.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectCross.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutationProbability.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePopulationSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGenerationSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSelectionTreshold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectSelection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectMutate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutateGeneCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDevidePointCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectTarget.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboFunction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionFinishValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionStartValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionStep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFuncionInput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meOutPut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStart_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOutPut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFuncionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionEnter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionStartValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionFinishValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCmboFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDevidePointCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutateGeneCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectionTreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGenerationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutationProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutationGeneProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectMutate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCalcTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGroupSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDuplicate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rngPopulationTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rngPopulationTrack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPopulationTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.rngPopulationTrack);
            this.lcMain.Controls.Add(this.ceIsDuplicate);
            this.lcMain.Controls.Add(this.ceIsDisplay);
            this.lcMain.Controls.Add(this.seGroupSize);
            this.lcMain.Controls.Add(this.lcCalcTimer);
            this.lcMain.Controls.Add(this.seMutationGeneProbability);
            this.lcMain.Controls.Add(this.lueSelectCross);
            this.lcMain.Controls.Add(this.lueSelectParent);
            this.lcMain.Controls.Add(this.seMutationProbability);
            this.lcMain.Controls.Add(this.sePopulationSize);
            this.lcMain.Controls.Add(this.seGenerationSize);
            this.lcMain.Controls.Add(this.seSelectionTreshold);
            this.lcMain.Controls.Add(this.lueSelectSelection);
            this.lcMain.Controls.Add(this.lueSelectMutate);
            this.lcMain.Controls.Add(this.seMutateGeneCount);
            this.lcMain.Controls.Add(this.seDevidePointCount);
            this.lcMain.Controls.Add(this.lueSelectTarget);
            this.lcMain.Controls.Add(this.cmboFunction);
            this.lcMain.Controls.Add(this.seFunctionFinishValue);
            this.lcMain.Controls.Add(this.seFunctionStartValue);
            this.lcMain.Controls.Add(this.seFunctionStep);
            this.lcMain.Controls.Add(this.sbFunctionEnter);
            this.lcMain.Controls.Add(this.teFuncionInput);
            this.lcMain.Controls.Add(this.chFunction);
            this.lcMain.Controls.Add(this.meOutPut);
            this.lcMain.Controls.Add(this.sbStart);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(72, 96, 650, 400);
            this.lcMain.Root = this.lcgMain;
            this.lcMain.Size = new System.Drawing.Size(1177, 492);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "lcMain";
            // 
            // ceIsDuplicate
            // 
            this.ceIsDuplicate.Location = new System.Drawing.Point(407, 347);
            this.ceIsDuplicate.Name = "ceIsDuplicate";
            this.ceIsDuplicate.Properties.Caption = "Отбор дублируемых особей";
            this.ceIsDuplicate.Size = new System.Drawing.Size(360, 19);
            this.ceIsDuplicate.StyleController = this.lcMain;
            this.ceIsDuplicate.TabIndex = 33;
            this.ceIsDuplicate.CheckedChanged += new System.EventHandler(this.ceIsDuplicate_CheckedChanged);
            // 
            // ceIsDisplay
            // 
            this.ceIsDisplay.Location = new System.Drawing.Point(407, 324);
            this.ceIsDisplay.Name = "ceIsDisplay";
            this.ceIsDisplay.Properties.Caption = "Отображение промежуточных результатов";
            this.ceIsDisplay.Size = new System.Drawing.Size(360, 19);
            this.ceIsDisplay.StyleController = this.lcMain;
            this.ceIsDisplay.TabIndex = 32;
            this.ceIsDisplay.CheckedChanged += new System.EventHandler(this.ceIsDisplay_CheckedChanged);
            // 
            // seGroupSize
            // 
            this.seGroupSize.EditValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.seGroupSize.Location = new System.Drawing.Point(544, 300);
            this.seGroupSize.Name = "seGroupSize";
            this.seGroupSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seGroupSize.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.seGroupSize.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seGroupSize.Size = new System.Drawing.Size(223, 20);
            this.seGroupSize.StyleController = this.lcMain;
            this.seGroupSize.TabIndex = 31;
            this.seGroupSize.EditValueChanged += new System.EventHandler(this.seGroupSize_EditValueChanged);
            // 
            // lcCalcTimer
            // 
            this.lcCalcTimer.Location = new System.Drawing.Point(407, 458);
            this.lcCalcTimer.Name = "lcCalcTimer";
            this.lcCalcTimer.Size = new System.Drawing.Size(131, 13);
            this.lcCalcTimer.StyleController = this.lcMain;
            this.lcCalcTimer.TabIndex = 30;
            this.lcCalcTimer.Text = "Время расчета: 00:00.000";
            // 
            // seMutationGeneProbability
            // 
            this.seMutationGeneProbability.EditValue = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.seMutationGeneProbability.Location = new System.Drawing.Point(546, 204);
            this.seMutationGeneProbability.Name = "seMutationGeneProbability";
            this.seMutationGeneProbability.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seMutationGeneProbability.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seMutationGeneProbability.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seMutationGeneProbability.Size = new System.Drawing.Size(221, 20);
            this.seMutationGeneProbability.StyleController = this.lcMain;
            this.seMutationGeneProbability.TabIndex = 29;
            this.seMutationGeneProbability.EditValueChanged += new System.EventHandler(this.seMutationGeneProbability_EditValueChanged);
            // 
            // lueSelectCross
            // 
            this.lueSelectCross.Location = new System.Drawing.Point(592, 108);
            this.lueSelectCross.Name = "lueSelectCross";
            this.lueSelectCross.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSelectCross.Size = new System.Drawing.Size(175, 20);
            this.lueSelectCross.StyleController = this.lcMain;
            this.lueSelectCross.TabIndex = 28;
            this.lueSelectCross.EditValueChanged += new System.EventHandler(this.lueSelectCross_EditValueChanged);
            // 
            // lueSelectParent
            // 
            this.lueSelectParent.Location = new System.Drawing.Point(560, 84);
            this.lueSelectParent.Name = "lueSelectParent";
            this.lueSelectParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSelectParent.Size = new System.Drawing.Size(207, 20);
            this.lueSelectParent.StyleController = this.lcMain;
            this.lueSelectParent.TabIndex = 27;
            this.lueSelectParent.EditValueChanged += new System.EventHandler(this.lueSelectParent_EditValueChanged);
            // 
            // seMutationProbability
            // 
            this.seMutationProbability.EditValue = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            this.seMutationProbability.Location = new System.Drawing.Point(522, 180);
            this.seMutationProbability.Name = "seMutationProbability";
            this.seMutationProbability.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seMutationProbability.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seMutationProbability.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seMutationProbability.Size = new System.Drawing.Size(245, 20);
            this.seMutationProbability.StyleController = this.lcMain;
            this.seMutationProbability.TabIndex = 26;
            this.seMutationProbability.EditValueChanged += new System.EventHandler(this.seMutationProbability_EditValueChanged);
            // 
            // sePopulationSize
            // 
            this.sePopulationSize.EditValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.sePopulationSize.Location = new System.Drawing.Point(504, 60);
            this.sePopulationSize.Name = "sePopulationSize";
            this.sePopulationSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sePopulationSize.Properties.MaxValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.sePopulationSize.Properties.MinValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.sePopulationSize.Size = new System.Drawing.Size(263, 20);
            this.sePopulationSize.StyleController = this.lcMain;
            this.sePopulationSize.TabIndex = 25;
            this.sePopulationSize.EditValueChanged += new System.EventHandler(this.sePopulationSize_EditValueChanged);
            // 
            // seGenerationSize
            // 
            this.seGenerationSize.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.seGenerationSize.Location = new System.Drawing.Point(529, 36);
            this.seGenerationSize.Name = "seGenerationSize";
            this.seGenerationSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seGenerationSize.Properties.MaxValue = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.seGenerationSize.Properties.MinValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.seGenerationSize.Size = new System.Drawing.Size(238, 20);
            this.seGenerationSize.StyleController = this.lcMain;
            this.seGenerationSize.TabIndex = 24;
            this.seGenerationSize.EditValueChanged += new System.EventHandler(this.seGenerationSize_EditValueChanged);
            // 
            // seSelectionTreshold
            // 
            this.seSelectionTreshold.EditValue = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.seSelectionTreshold.Location = new System.Drawing.Point(546, 276);
            this.seSelectionTreshold.Name = "seSelectionTreshold";
            this.seSelectionTreshold.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seSelectionTreshold.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seSelectionTreshold.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seSelectionTreshold.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seSelectionTreshold.Size = new System.Drawing.Size(221, 20);
            this.seSelectionTreshold.StyleController = this.lcMain;
            this.seSelectionTreshold.TabIndex = 23;
            this.seSelectionTreshold.EditValueChanged += new System.EventHandler(this.seSelectionTreshold_EditValueChanged);
            // 
            // lueSelectSelection
            // 
            this.lueSelectSelection.Location = new System.Drawing.Point(599, 252);
            this.lueSelectSelection.Name = "lueSelectSelection";
            this.lueSelectSelection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSelectSelection.Size = new System.Drawing.Size(168, 20);
            this.lueSelectSelection.StyleController = this.lcMain;
            this.lueSelectSelection.TabIndex = 22;
            this.lueSelectSelection.EditValueChanged += new System.EventHandler(this.lueSelectSelection_EditValueChanged);
            // 
            // lueSelectMutate
            // 
            this.lueSelectMutate.Location = new System.Drawing.Point(553, 156);
            this.lueSelectMutate.Name = "lueSelectMutate";
            this.lueSelectMutate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSelectMutate.Size = new System.Drawing.Size(214, 20);
            this.lueSelectMutate.StyleController = this.lcMain;
            this.lueSelectMutate.TabIndex = 20;
            this.lueSelectMutate.EditValueChanged += new System.EventHandler(this.lueSelectMutate_EditValueChanged);
            // 
            // seMutateGeneCount
            // 
            this.seMutateGeneCount.EditValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.seMutateGeneCount.Location = new System.Drawing.Point(544, 228);
            this.seMutateGeneCount.Name = "seMutateGeneCount";
            this.seMutateGeneCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seMutateGeneCount.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.seMutateGeneCount.Properties.MinValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.seMutateGeneCount.Size = new System.Drawing.Size(223, 20);
            this.seMutateGeneCount.StyleController = this.lcMain;
            this.seMutateGeneCount.TabIndex = 19;
            this.seMutateGeneCount.EditValueChanged += new System.EventHandler(this.seMutateGeneCount_EditValueChanged);
            // 
            // seDevidePointCount
            // 
            this.seDevidePointCount.EditValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.seDevidePointCount.Location = new System.Drawing.Point(546, 132);
            this.seDevidePointCount.Name = "seDevidePointCount";
            this.seDevidePointCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seDevidePointCount.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.seDevidePointCount.Properties.MinValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.seDevidePointCount.Size = new System.Drawing.Size(221, 20);
            this.seDevidePointCount.StyleController = this.lcMain;
            this.seDevidePointCount.TabIndex = 18;
            this.seDevidePointCount.EditValueChanged += new System.EventHandler(this.seDevidePointCount_EditValueChanged);
            // 
            // lueSelectTarget
            // 
            this.lueSelectTarget.Location = new System.Drawing.Point(546, 12);
            this.lueSelectTarget.Name = "lueSelectTarget";
            this.lueSelectTarget.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSelectTarget.Properties.DropDownRows = 2;
            this.lueSelectTarget.Properties.ShowFooter = false;
            this.lueSelectTarget.Properties.ShowHeader = false;
            this.lueSelectTarget.Size = new System.Drawing.Size(221, 20);
            this.lueSelectTarget.StyleController = this.lcMain;
            this.lueSelectTarget.TabIndex = 15;
            this.lueSelectTarget.EditValueChanged += new System.EventHandler(this.lueSelectTarget_EditValueChanged);
            // 
            // cmboFunction
            // 
            this.cmboFunction.Location = new System.Drawing.Point(78, 386);
            this.cmboFunction.Name = "cmboFunction";
            this.cmboFunction.Properties.AutoComplete = false;
            this.cmboFunction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmboFunction.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmboFunction.Size = new System.Drawing.Size(320, 20);
            this.cmboFunction.StyleController = this.lcMain;
            this.cmboFunction.TabIndex = 13;
            this.cmboFunction.EditValueChanged += new System.EventHandler(this.cmboFunction_EditValueChanged);
            // 
            // seFunctionFinishValue
            // 
            this.seFunctionFinishValue.EditValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.seFunctionFinishValue.Location = new System.Drawing.Point(239, 434);
            this.seFunctionFinishValue.Name = "seFunctionFinishValue";
            this.seFunctionFinishValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seFunctionFinishValue.Size = new System.Drawing.Size(159, 20);
            this.seFunctionFinishValue.StyleController = this.lcMain;
            this.seFunctionFinishValue.TabIndex = 12;
            this.seFunctionFinishValue.EditValueChanged += new System.EventHandler(this.seFunctionFinishValue_EditValueChanged);
            // 
            // seFunctionStartValue
            // 
            this.seFunctionStartValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFunctionStartValue.Location = new System.Drawing.Point(54, 434);
            this.seFunctionStartValue.Name = "seFunctionStartValue";
            this.seFunctionStartValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seFunctionStartValue.Size = new System.Drawing.Size(145, 20);
            this.seFunctionStartValue.StyleController = this.lcMain;
            this.seFunctionStartValue.TabIndex = 11;
            this.seFunctionStartValue.EditValueChanged += new System.EventHandler(this.seFunctionStartValue_EditValueChanged);
            // 
            // seFunctionStep
            // 
            this.seFunctionStep.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seFunctionStep.Location = new System.Drawing.Point(85, 410);
            this.seFunctionStep.Name = "seFunctionStep";
            this.seFunctionStep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seFunctionStep.Properties.DisplayFormat.FormatString = "G29";
            this.seFunctionStep.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.seFunctionStep.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.seFunctionStep.Size = new System.Drawing.Size(313, 20);
            this.seFunctionStep.StyleController = this.lcMain;
            this.seFunctionStep.TabIndex = 10;
            this.seFunctionStep.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.seFunctionStep_Spin);
            this.seFunctionStep.EditValueChanged += new System.EventHandler(this.seFunctionStep_EditValueChanged);
            // 
            // sbFunctionEnter
            // 
            this.sbFunctionEnter.Location = new System.Drawing.Point(12, 458);
            this.sbFunctionEnter.Name = "sbFunctionEnter";
            this.sbFunctionEnter.Size = new System.Drawing.Size(386, 22);
            this.sbFunctionEnter.StyleController = this.lcMain;
            this.sbFunctionEnter.TabIndex = 9;
            this.sbFunctionEnter.Text = "Построить график";
            this.sbFunctionEnter.Click += new System.EventHandler(this.sbFunctionEnter_Click);
            // 
            // teFuncionInput
            // 
            this.teFuncionInput.EditValue = "2*x";
            this.teFuncionInput.Location = new System.Drawing.Point(78, 362);
            this.teFuncionInput.Name = "teFuncionInput";
            this.teFuncionInput.Size = new System.Drawing.Size(320, 20);
            this.teFuncionInput.StyleController = this.lcMain;
            this.teFuncionInput.TabIndex = 8;
            // 
            // chFunction
            // 
            this.chFunction.BorderOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            xyDiagram1.AxisX.DateTimeScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Continuous;
            xyDiagram1.AxisX.Title.Text = "X";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.Title.Text = "Y";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisXZooming = true;
            xyDiagram1.EnableAxisYScrolling = true;
            xyDiagram1.EnableAxisYZooming = true;
            this.chFunction.Diagram = xyDiagram1;
            this.chFunction.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.chFunction.Legend.Name = "Default Legend";
            this.chFunction.Legend.TextVisible = false;
            this.chFunction.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chFunction.Location = new System.Drawing.Point(12, 12);
            this.chFunction.Name = "chFunction";
            series1.Name = "Целевая функция";
            lineSeriesView1.LineMarkerOptions.Size = 1;
            lineSeriesView1.LineStyle.Thickness = 1;
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.View = lineSeriesView1;
            series2.Name = "Рассчитанное лучшее решение";
            series2.View = lineSeriesView2;
            series3.Name = "Найденные ГА решения";
            series3.View = lineSeriesView3;
            this.chFunction.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3};
            this.chFunction.Size = new System.Drawing.Size(386, 270);
            this.chFunction.TabIndex = 7;
            // 
            // meOutPut
            // 
            this.meOutPut.Location = new System.Drawing.Point(776, 12);
            this.meOutPut.MinimumSize = new System.Drawing.Size(300, 0);
            this.meOutPut.Name = "meOutPut";
            this.meOutPut.Size = new System.Drawing.Size(389, 442);
            this.meOutPut.StyleController = this.lcMain;
            this.meOutPut.TabIndex = 6;
            // 
            // sbStart
            // 
            this.sbStart.Location = new System.Drawing.Point(542, 458);
            this.sbStart.Name = "sbStart";
            this.sbStart.Size = new System.Drawing.Size(623, 22);
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
            this.esiFooter,
            this.lciFunctionChart,
            this.splitterItem1,
            this.lciFuncionInput,
            this.lciFunctionEnter,
            this.lciFunctionStartValue,
            this.lciFunctionFinishValue,
            this.lciFunctionStep,
            this.lciCmboFunction,
            this.lciSelectTarget,
            this.lciDevidePointCount,
            this.lciMutateGeneCount,
            this.lciSelectSelection,
            this.lciSelectionTreshold,
            this.lciGenerationSize,
            this.lciMutationProbability,
            this.lciSelectParent,
            this.lciSelectCross,
            this.lciMutationGeneProbability,
            this.lciSelectMutate,
            this.lciGroupSize,
            this.lciIsDuplicate,
            this.lciPopulationTrack,
            this.lciOutPut,
            this.lciStart_btn,
            this.lciCalcTimer,
            this.lciPopulationSize,
            this.lciIsDisplay,
            this.splitterItem3});
            this.lcgMain.Name = "Root";
            this.lcgMain.Size = new System.Drawing.Size(1177, 492);
            this.lcgMain.TextVisible = false;
            // 
            // lciStart_btn
            // 
            this.lciStart_btn.Control = this.sbStart;
            this.lciStart_btn.Location = new System.Drawing.Point(530, 446);
            this.lciStart_btn.Name = "lciStart_btn";
            this.lciStart_btn.Size = new System.Drawing.Size(627, 26);
            this.lciStart_btn.TextSize = new System.Drawing.Size(0, 0);
            this.lciStart_btn.TextVisible = false;
            // 
            // lciOutPut
            // 
            this.lciOutPut.Control = this.meOutPut;
            this.lciOutPut.Location = new System.Drawing.Point(764, 0);
            this.lciOutPut.Name = "lciOutPut";
            this.lciOutPut.Size = new System.Drawing.Size(393, 446);
            this.lciOutPut.TextSize = new System.Drawing.Size(0, 0);
            this.lciOutPut.TextVisible = false;
            // 
            // esiFooter
            // 
            this.esiFooter.AllowHotTrack = false;
            this.esiFooter.Location = new System.Drawing.Point(395, 358);
            this.esiFooter.Name = "esiFooter";
            this.esiFooter.Size = new System.Drawing.Size(364, 88);
            this.esiFooter.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciFunctionChart
            // 
            this.lciFunctionChart.Control = this.chFunction;
            this.lciFunctionChart.Location = new System.Drawing.Point(0, 0);
            this.lciFunctionChart.Name = "lciFunctionChart";
            this.lciFunctionChart.Size = new System.Drawing.Size(390, 274);
            this.lciFunctionChart.TextSize = new System.Drawing.Size(0, 0);
            this.lciFunctionChart.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(390, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 472);
            // 
            // lciFuncionInput
            // 
            this.lciFuncionInput.Control = this.teFuncionInput;
            this.lciFuncionInput.Location = new System.Drawing.Point(0, 350);
            this.lciFuncionInput.Name = "lciFuncionInput";
            this.lciFuncionInput.Size = new System.Drawing.Size(390, 24);
            this.lciFuncionInput.Text = "Функция y=";
            this.lciFuncionInput.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciFuncionInput.TextSize = new System.Drawing.Size(61, 13);
            this.lciFuncionInput.TextToControlDistance = 5;
            // 
            // lciFunctionEnter
            // 
            this.lciFunctionEnter.Control = this.sbFunctionEnter;
            this.lciFunctionEnter.Location = new System.Drawing.Point(0, 446);
            this.lciFunctionEnter.Name = "lciFunctionEnter";
            this.lciFunctionEnter.Size = new System.Drawing.Size(390, 26);
            this.lciFunctionEnter.TextSize = new System.Drawing.Size(0, 0);
            this.lciFunctionEnter.TextVisible = false;
            // 
            // lciFunctionStartValue
            // 
            this.lciFunctionStartValue.Control = this.seFunctionStartValue;
            this.lciFunctionStartValue.Location = new System.Drawing.Point(0, 422);
            this.lciFunctionStartValue.Name = "lciFunctionStartValue";
            this.lciFunctionStartValue.Size = new System.Drawing.Size(191, 24);
            this.lciFunctionStartValue.Text = "Начало";
            this.lciFunctionStartValue.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciFunctionStartValue.TextSize = new System.Drawing.Size(37, 13);
            this.lciFunctionStartValue.TextToControlDistance = 5;
            // 
            // lciFunctionFinishValue
            // 
            this.lciFunctionFinishValue.Control = this.seFunctionFinishValue;
            this.lciFunctionFinishValue.Location = new System.Drawing.Point(191, 422);
            this.lciFunctionFinishValue.Name = "lciFunctionFinishValue";
            this.lciFunctionFinishValue.Size = new System.Drawing.Size(199, 24);
            this.lciFunctionFinishValue.Text = "Конец";
            this.lciFunctionFinishValue.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciFunctionFinishValue.TextSize = new System.Drawing.Size(31, 13);
            this.lciFunctionFinishValue.TextToControlDistance = 5;
            // 
            // lciFunctionStep
            // 
            this.lciFunctionStep.Control = this.seFunctionStep;
            this.lciFunctionStep.Location = new System.Drawing.Point(0, 398);
            this.lciFunctionStep.Name = "lciFunctionStep";
            this.lciFunctionStep.Size = new System.Drawing.Size(390, 24);
            this.lciFunctionStep.Text = "Шаг функции";
            this.lciFunctionStep.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciFunctionStep.TextSize = new System.Drawing.Size(68, 13);
            this.lciFunctionStep.TextToControlDistance = 5;
            // 
            // lciCmboFunction
            // 
            this.lciCmboFunction.Control = this.cmboFunction;
            this.lciCmboFunction.Location = new System.Drawing.Point(0, 374);
            this.lciCmboFunction.Name = "lciCmboFunction";
            this.lciCmboFunction.Size = new System.Drawing.Size(390, 24);
            this.lciCmboFunction.Text = "Функция y=";
            this.lciCmboFunction.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciCmboFunction.TextSize = new System.Drawing.Size(61, 13);
            this.lciCmboFunction.TextToControlDistance = 5;
            // 
            // lciSelectTarget
            // 
            this.lciSelectTarget.Control = this.lueSelectTarget;
            this.lciSelectTarget.Location = new System.Drawing.Point(395, 0);
            this.lciSelectTarget.Name = "lciSelectTarget";
            this.lciSelectTarget.Size = new System.Drawing.Size(364, 24);
            this.lciSelectTarget.Text = "Найти";
            this.lciSelectTarget.TextSize = new System.Drawing.Size(136, 13);
            // 
            // lciDevidePointCount
            // 
            this.lciDevidePointCount.Control = this.seDevidePointCount;
            this.lciDevidePointCount.Location = new System.Drawing.Point(395, 120);
            this.lciDevidePointCount.Name = "lciDevidePointCount";
            this.lciDevidePointCount.Size = new System.Drawing.Size(364, 24);
            this.lciDevidePointCount.Text = "Кол-во точек разделения ";
            this.lciDevidePointCount.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciDevidePointCount.TextSize = new System.Drawing.Size(134, 13);
            this.lciDevidePointCount.TextToControlDistance = 5;
            // 
            // lciMutateGeneCount
            // 
            this.lciMutateGeneCount.Control = this.seMutateGeneCount;
            this.lciMutateGeneCount.Location = new System.Drawing.Point(395, 216);
            this.lciMutateGeneCount.Name = "lciMutateGeneCount";
            this.lciMutateGeneCount.Size = new System.Drawing.Size(364, 24);
            this.lciMutateGeneCount.Text = "Кол-во мутируемых генов";
            this.lciMutateGeneCount.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciMutateGeneCount.TextSize = new System.Drawing.Size(132, 13);
            this.lciMutateGeneCount.TextToControlDistance = 5;
            // 
            // lciSelectSelection
            // 
            this.lciSelectSelection.Control = this.lueSelectSelection;
            this.lciSelectSelection.Location = new System.Drawing.Point(395, 240);
            this.lciSelectSelection.Name = "lciSelectSelection";
            this.lciSelectSelection.Size = new System.Drawing.Size(364, 24);
            this.lciSelectSelection.Text = "Методика отбора в след. поколение";
            this.lciSelectSelection.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSelectSelection.TextSize = new System.Drawing.Size(187, 13);
            this.lciSelectSelection.TextToControlDistance = 5;
            // 
            // lciSelectionTreshold
            // 
            this.lciSelectionTreshold.Control = this.seSelectionTreshold;
            this.lciSelectionTreshold.Location = new System.Drawing.Point(395, 264);
            this.lciSelectionTreshold.Name = "lciSelectionTreshold";
            this.lciSelectionTreshold.Size = new System.Drawing.Size(364, 24);
            this.lciSelectionTreshold.Text = "Порог селекции";
            this.lciSelectionTreshold.TextSize = new System.Drawing.Size(136, 13);
            // 
            // lciGenerationSize
            // 
            this.lciGenerationSize.Control = this.seGenerationSize;
            this.lciGenerationSize.Location = new System.Drawing.Point(395, 24);
            this.lciGenerationSize.Name = "lciGenerationSize";
            this.lciGenerationSize.Size = new System.Drawing.Size(364, 24);
            this.lciGenerationSize.Text = "Количество поколений";
            this.lciGenerationSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciGenerationSize.TextSize = new System.Drawing.Size(117, 13);
            this.lciGenerationSize.TextToControlDistance = 5;
            // 
            // lciMutationProbability
            // 
            this.lciMutationProbability.Control = this.seMutationProbability;
            this.lciMutationProbability.Location = new System.Drawing.Point(395, 168);
            this.lciMutationProbability.Name = "lciMutationProbability";
            this.lciMutationProbability.Size = new System.Drawing.Size(364, 24);
            this.lciMutationProbability.Text = "Вероятность мутации";
            this.lciMutationProbability.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciMutationProbability.TextSize = new System.Drawing.Size(110, 13);
            this.lciMutationProbability.TextToControlDistance = 5;
            // 
            // lciPopulationSize
            // 
            this.lciPopulationSize.Control = this.sePopulationSize;
            this.lciPopulationSize.Location = new System.Drawing.Point(395, 48);
            this.lciPopulationSize.Name = "lciPopulationSize";
            this.lciPopulationSize.Size = new System.Drawing.Size(364, 24);
            this.lciPopulationSize.Text = "Размер популяции";
            this.lciPopulationSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciPopulationSize.TextSize = new System.Drawing.Size(92, 13);
            this.lciPopulationSize.TextToControlDistance = 5;
            // 
            // lciSelectParent
            // 
            this.lciSelectParent.Control = this.lueSelectParent;
            this.lciSelectParent.Location = new System.Drawing.Point(395, 72);
            this.lciSelectParent.Name = "lciSelectParent";
            this.lciSelectParent.Size = new System.Drawing.Size(364, 24);
            this.lciSelectParent.Text = "Методика отбора родителей";
            this.lciSelectParent.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSelectParent.TextSize = new System.Drawing.Size(148, 13);
            this.lciSelectParent.TextToControlDistance = 5;
            // 
            // lciSelectCross
            // 
            this.lciSelectCross.Control = this.lueSelectCross;
            this.lciSelectCross.Location = new System.Drawing.Point(395, 96);
            this.lciSelectCross.Name = "lciSelectCross";
            this.lciSelectCross.Size = new System.Drawing.Size(364, 24);
            this.lciSelectCross.Text = "Методика скрещивания родителей";
            this.lciSelectCross.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSelectCross.TextSize = new System.Drawing.Size(180, 13);
            this.lciSelectCross.TextToControlDistance = 5;
            // 
            // lciMutationGeneProbability
            // 
            this.lciMutationGeneProbability.Control = this.seMutationGeneProbability;
            this.lciMutationGeneProbability.Location = new System.Drawing.Point(395, 192);
            this.lciMutationGeneProbability.Name = "lciMutationGeneProbability";
            this.lciMutationGeneProbability.Size = new System.Drawing.Size(364, 24);
            this.lciMutationGeneProbability.Text = "Вероятность мутации гена";
            this.lciMutationGeneProbability.TextSize = new System.Drawing.Size(136, 13);
            // 
            // lciSelectMutate
            // 
            this.lciSelectMutate.Control = this.lueSelectMutate;
            this.lciSelectMutate.Location = new System.Drawing.Point(395, 144);
            this.lciSelectMutate.Name = "lciSelectMutate";
            this.lciSelectMutate.Size = new System.Drawing.Size(364, 24);
            this.lciSelectMutate.Text = "Методика мутации потомка";
            this.lciSelectMutate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSelectMutate.TextSize = new System.Drawing.Size(141, 13);
            this.lciSelectMutate.TextToControlDistance = 5;
            // 
            // lciCalcTimer
            // 
            this.lciCalcTimer.Control = this.lcCalcTimer;
            this.lciCalcTimer.Location = new System.Drawing.Point(395, 446);
            this.lciCalcTimer.Name = "lciCalcTimer";
            this.lciCalcTimer.Size = new System.Drawing.Size(135, 26);
            this.lciCalcTimer.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.lciCalcTimer.TextSize = new System.Drawing.Size(0, 0);
            this.lciCalcTimer.TextToControlDistance = 0;
            this.lciCalcTimer.TextVisible = false;
            // 
            // lciGroupSize
            // 
            this.lciGroupSize.Control = this.seGroupSize;
            this.lciGroupSize.Location = new System.Drawing.Point(395, 288);
            this.lciGroupSize.Name = "lciGroupSize";
            this.lciGroupSize.Size = new System.Drawing.Size(364, 24);
            this.lciGroupSize.Text = "Размер турнирной группы";
            this.lciGroupSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciGroupSize.TextSize = new System.Drawing.Size(132, 13);
            this.lciGroupSize.TextToControlDistance = 5;
            // 
            // lciIsDisplay
            // 
            this.lciIsDisplay.Control = this.ceIsDisplay;
            this.lciIsDisplay.Location = new System.Drawing.Point(395, 312);
            this.lciIsDisplay.Name = "lciIsDisplay";
            this.lciIsDisplay.Size = new System.Drawing.Size(364, 23);
            this.lciIsDisplay.TextSize = new System.Drawing.Size(0, 0);
            this.lciIsDisplay.TextVisible = false;
            // 
            // lciIsDuplicate
            // 
            this.lciIsDuplicate.Control = this.ceIsDuplicate;
            this.lciIsDuplicate.Location = new System.Drawing.Point(395, 335);
            this.lciIsDuplicate.Name = "lciIsDuplicate";
            this.lciIsDuplicate.Size = new System.Drawing.Size(364, 23);
            this.lciIsDuplicate.TextSize = new System.Drawing.Size(0, 0);
            this.lciIsDuplicate.TextVisible = false;
            // 
            // lcgMutation
            // 
            this.lcgMutation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.lcgMutation.Location = new System.Drawing.Point(388, 274);
            this.lcgMutation.Name = "lcgMutation";
            this.lcgMutation.Size = new System.Drawing.Size(501, 115);
            this.lcgMutation.Text = "Мутация";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.seMutationProbability;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(493, 30);
            this.layoutControlItem1.Text = "Вероятность мутации";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(110, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lueSelectMutate;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(493, 30);
            this.layoutControlItem2.Text = "Методика мутации потомка";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(141, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.seMutateGeneCount;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(493, 30);
            this.layoutControlItem3.Text = "Кол-во мутируемых генов";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(132, 13);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // rngPopulationTrack
            // 
            this.rngPopulationTrack.Location = new System.Drawing.Point(76, 286);
            this.rngPopulationTrack.Name = "rngPopulationTrack";
            this.rngPopulationTrack.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.rngPopulationTrack.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            trackBarLabel1.Label = "0";
            trackBarLabel2.Label = "1";
            trackBarLabel2.Value = 1;
            trackBarLabel3.Label = "2";
            trackBarLabel3.Value = 2;
            this.rngPopulationTrack.Properties.Labels.AddRange(new DevExpress.XtraEditors.Repository.TrackBarLabel[] {
            trackBarLabel1,
            trackBarLabel2,
            trackBarLabel3});
            this.rngPopulationTrack.Properties.Maximum = 2;
            this.rngPopulationTrack.Properties.ShowLabels = true;
            this.rngPopulationTrack.Size = new System.Drawing.Size(322, 72);
            this.rngPopulationTrack.StyleController = this.lcMain;
            this.rngPopulationTrack.TabIndex = 35;
            this.rngPopulationTrack.EditValueChanged += new System.EventHandler(this.rngPopulationTrack_EditValueChanged);
            // 
            // lciPopulationTrack
            // 
            this.lciPopulationTrack.Control = this.rngPopulationTrack;
            this.lciPopulationTrack.Location = new System.Drawing.Point(0, 274);
            this.lciPopulationTrack.Name = "lciPopulationTrack";
            this.lciPopulationTrack.Size = new System.Drawing.Size(390, 76);
            this.lciPopulationTrack.Text = "Популяция:";
            this.lciPopulationTrack.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciPopulationTrack.TextSize = new System.Drawing.Size(59, 13);
            this.lciPopulationTrack.TextToControlDistance = 5;
            // 
            // splitterItem3
            // 
            this.splitterItem3.AllowHotTrack = true;
            this.splitterItem3.Location = new System.Drawing.Point(759, 0);
            this.splitterItem3.Name = "splitterItem3";
            this.splitterItem3.Size = new System.Drawing.Size(5, 446);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 492);
            this.Controls.Add(this.lcMain);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDuplicate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDisplay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGroupSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutationGeneProbability.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectCross.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutationProbability.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePopulationSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGenerationSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSelectionTreshold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectSelection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectMutate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutateGeneCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDevidePointCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectTarget.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboFunction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionFinishValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionStartValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionStep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teFuncionInput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionStartValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionFinishValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCmboFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDevidePointCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutateGeneCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectionTreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGenerationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutationProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutationGeneProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectMutate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCalcTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGroupSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDuplicate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rngPopulationTrack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rngPopulationTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPopulationTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem3)).EndInit();
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
        private DevExpress.XtraEditors.SpinEdit seFunctionFinishValue;
        private DevExpress.XtraEditors.SpinEdit seFunctionStartValue;
        private DevExpress.XtraLayout.LayoutControlItem lciFunctionStartValue;
        private DevExpress.XtraLayout.LayoutControlItem lciFunctionFinishValue;
        private DevExpress.XtraEditors.ComboBoxEdit cmboFunction;
        private DevExpress.XtraLayout.LayoutControlItem lciCmboFunction;
        private DevExpress.XtraEditors.LookUpEdit lueSelectTarget;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectTarget;
        private DevExpress.XtraEditors.SpinEdit seDevidePointCount;
        private DevExpress.XtraLayout.LayoutControlItem lciDevidePointCount;
        private DevExpress.XtraEditors.LookUpEdit lueSelectMutate;
        private DevExpress.XtraEditors.SpinEdit seMutateGeneCount;
        private DevExpress.XtraEditors.LookUpEdit lueSelectSelection;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectSelection;
        private DevExpress.XtraEditors.SpinEdit seSelectionTreshold;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectionTreshold;
        private DevExpress.XtraEditors.SpinEdit seGenerationSize;
        private DevExpress.XtraLayout.LayoutControlItem lciGenerationSize;
        private DevExpress.XtraEditors.SpinEdit sePopulationSize;
        private DevExpress.XtraLayout.LayoutControlItem lciPopulationSize;
        private DevExpress.XtraEditors.SpinEdit seMutationProbability;
        private DevExpress.XtraEditors.LookUpEdit lueSelectParent;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectParent;
        private DevExpress.XtraEditors.LookUpEdit lueSelectCross;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectCross;
        private DevExpress.XtraLayout.LayoutControlItem lciMutateGeneCount;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectMutate;
        private DevExpress.XtraLayout.LayoutControlItem lciMutationProbability;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMutation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SpinEdit seMutationGeneProbability;
        private DevExpress.XtraLayout.LayoutControlItem lciMutationGeneProbability;
        private DevExpress.XtraEditors.LabelControl lcCalcTimer;
        private DevExpress.XtraLayout.LayoutControlItem lciCalcTimer;
        private System.Windows.Forms.Timer calculateTimer;
        private DevExpress.XtraEditors.SpinEdit seGroupSize;
        private DevExpress.XtraLayout.LayoutControlItem lciGroupSize;
        private DevExpress.XtraEditors.CheckEdit ceIsDisplay;
        private DevExpress.XtraLayout.LayoutControlItem lciIsDisplay;
        private DevExpress.XtraEditors.CheckEdit ceIsDuplicate;
        private DevExpress.XtraLayout.LayoutControlItem lciIsDuplicate;
        private DevExpress.XtraEditors.TrackBarControl rngPopulationTrack;
        private DevExpress.XtraLayout.LayoutControlItem lciPopulationTrack;
        private DevExpress.XtraLayout.SplitterItem splitterItem3;
    }
}

