namespace TestProj
{
    partial class MainForm
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
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel1 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel2 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraEditors.Repository.TrackBarLabel trackBarLabel3 = new DevExpress.XtraEditors.Repository.TrackBarLabel();
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series7 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView7 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series8 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView8 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series9 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView9 = new DevExpress.XtraCharts.LineSeriesView();
            this.lcMain = new DevExpress.XtraLayout.LayoutControl();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabSetting = new DevExpress.XtraTab.XtraTabPage();
            this.lcSetting = new DevExpress.XtraLayout.LayoutControl();
            this.meOutPut = new DevExpress.XtraEditors.MemoEdit();
            this.lcCalcTimer = new DevExpress.XtraEditors.LabelControl();
            this.rngPopulationTrack = new DevExpress.XtraEditors.TrackBarControl();
            this.sbStart = new DevExpress.XtraEditors.SimpleButton();
            this.sbFunctionEnter = new DevExpress.XtraEditors.SimpleButton();
            this.seFunctionFinishValue = new DevExpress.XtraEditors.SpinEdit();
            this.cmboFunction = new DevExpress.XtraEditors.ComboBoxEdit();
            this.seFunctionStartValue = new DevExpress.XtraEditors.SpinEdit();
            this.ceIsDisplayMutateResult = new DevExpress.XtraEditors.CheckEdit();
            this.seFunctionStep = new DevExpress.XtraEditors.SpinEdit();
            this.ceIsDuplicate = new DevExpress.XtraEditors.CheckEdit();
            this.ceIsDisplayCrossResult = new DevExpress.XtraEditors.CheckEdit();
            this.ceIsDisplaySelectionResult = new DevExpress.XtraEditors.CheckEdit();
            this.lueSelectTarget = new DevExpress.XtraEditors.LookUpEdit();
            this.seGroupSize = new DevExpress.XtraEditors.SpinEdit();
            this.seGenerationSize = new DevExpress.XtraEditors.SpinEdit();
            this.chFunction = new DevExpress.XtraCharts.ChartControl();
            this.sePopulationSize = new DevExpress.XtraEditors.SpinEdit();
            this.seSelectionTreshold = new DevExpress.XtraEditors.SpinEdit();
            this.lueSelectParent = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSelectSelection = new DevExpress.XtraEditors.LookUpEdit();
            this.lueSelectCross = new DevExpress.XtraEditors.LookUpEdit();
            this.seMutationGeneProbability = new DevExpress.XtraEditors.SpinEdit();
            this.seDevidePointCount = new DevExpress.XtraEditors.SpinEdit();
            this.seMutateGeneCount = new DevExpress.XtraEditors.SpinEdit();
            this.seMutationProbability = new DevExpress.XtraEditors.SpinEdit();
            this.lueSelectMutate = new DevExpress.XtraEditors.LookUpEdit();
            this.lcgSetting = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciSelectTarget = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectSelection = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectionTreshold = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGroupSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciIsDisplaySelectionResult = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFunctionStartValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFunctionStep = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFunctionChart = new DevExpress.XtraLayout.LayoutControlItem();
            this.esiSetting = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciPopulationTrack = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciGenerationSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciPopulationSize = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectParent = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectCross = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciDevidePointCount = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciIsDisplayCrossResult = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciSelectMutate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMutationProbability = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMutationGeneProbability = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciMutateGeneCount = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciIsDisplayMutateResult = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciIsDuplicate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFunctionEnter = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciStart = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciCalcTimer = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitSettingOutput = new DevExpress.XtraLayout.SplitterItem();
            this.lciOutPut = new DevExpress.XtraLayout.LayoutControlItem();
            this.esiFunction = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitFunctionSetting = new DevExpress.XtraLayout.SplitterItem();
            this.lciCmboFunction = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciFunctionFinishValue = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabAnalysis = new DevExpress.XtraTab.XtraTabPage();
            this.lcAnalysis = new DevExpress.XtraLayout.LayoutControl();
            this.lueAnalysisSelectionMethods = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.sbAnalysis = new DevExpress.XtraEditors.SimpleButton();
            this.seRunAmount = new DevExpress.XtraEditors.SpinEdit();
            this.meOutputAnalysis = new DevExpress.XtraEditors.MemoEdit();
            this.chAnalysis = new DevExpress.XtraCharts.ChartControl();
            this.lcgAnalysis = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciAnalysisChart = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciOutputAnalysis = new DevExpress.XtraLayout.LayoutControlItem();
            this.esiSettingAnalysis = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lciRunAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAnalysis = new DevExpress.XtraLayout.LayoutControlItem();
            this.lciAnalysisSelectionMethods = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgMain = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciTabs = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcgMutation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.calculateTimer = new System.Windows.Forms.Timer(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcSetting)).BeginInit();
            this.lcSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.meOutPut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rngPopulationTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rngPopulationTrack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionFinishValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboFunction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionStartValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDisplayMutateResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionStep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDuplicate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDisplayCrossResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDisplaySelectionResult.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectTarget.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGroupSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGenerationSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePopulationSize.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSelectionTreshold.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectSelection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectCross.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutationGeneProbability.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDevidePointCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutateGeneCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutationProbability.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectMutate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectionTreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGroupSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDisplaySelectionResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionStartValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPopulationTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGenerationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectCross)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDevidePointCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDisplayCrossResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectMutate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutationProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutationGeneProbability)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutateGeneCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDisplayMutateResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDuplicate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionEnter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCalcTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitSettingOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOutPut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitFunctionSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCmboFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionFinishValue)).BeginInit();
            this.tabAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcAnalysis)).BeginInit();
            this.lcAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueAnalysisSelectionMethods.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRunAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meOutputAnalysis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnalysisChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOutputAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiSettingAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRunAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnalysisSelectionMethods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTabs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMutation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.tabControl);
            this.lcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcMain.Location = new System.Drawing.Point(0, 0);
            this.lcMain.Name = "lcMain";
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(72, 96, 650, 400);
            this.lcMain.Root = this.lcgMain;
            this.lcMain.Size = new System.Drawing.Size(1177, 526);
            this.lcMain.TabIndex = 0;
            this.lcMain.Text = "lcMain";
            // 
            // tabControl
            // 
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.tabSetting;
            this.tabControl.Size = new System.Drawing.Size(1153, 502);
            this.tabControl.TabIndex = 38;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabSetting,
            this.tabAnalysis});
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.lcSetting);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Size = new System.Drawing.Size(1151, 473);
            this.tabSetting.Text = "Настройки";
            // 
            // lcSetting
            // 
            this.lcSetting.Controls.Add(this.meOutPut);
            this.lcSetting.Controls.Add(this.lcCalcTimer);
            this.lcSetting.Controls.Add(this.rngPopulationTrack);
            this.lcSetting.Controls.Add(this.sbStart);
            this.lcSetting.Controls.Add(this.sbFunctionEnter);
            this.lcSetting.Controls.Add(this.seFunctionFinishValue);
            this.lcSetting.Controls.Add(this.cmboFunction);
            this.lcSetting.Controls.Add(this.seFunctionStartValue);
            this.lcSetting.Controls.Add(this.ceIsDisplayMutateResult);
            this.lcSetting.Controls.Add(this.seFunctionStep);
            this.lcSetting.Controls.Add(this.ceIsDuplicate);
            this.lcSetting.Controls.Add(this.ceIsDisplayCrossResult);
            this.lcSetting.Controls.Add(this.ceIsDisplaySelectionResult);
            this.lcSetting.Controls.Add(this.lueSelectTarget);
            this.lcSetting.Controls.Add(this.seGroupSize);
            this.lcSetting.Controls.Add(this.seGenerationSize);
            this.lcSetting.Controls.Add(this.chFunction);
            this.lcSetting.Controls.Add(this.sePopulationSize);
            this.lcSetting.Controls.Add(this.seSelectionTreshold);
            this.lcSetting.Controls.Add(this.lueSelectParent);
            this.lcSetting.Controls.Add(this.lueSelectSelection);
            this.lcSetting.Controls.Add(this.lueSelectCross);
            this.lcSetting.Controls.Add(this.seMutationGeneProbability);
            this.lcSetting.Controls.Add(this.seDevidePointCount);
            this.lcSetting.Controls.Add(this.seMutateGeneCount);
            this.lcSetting.Controls.Add(this.seMutationProbability);
            this.lcSetting.Controls.Add(this.lueSelectMutate);
            this.lcSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcSetting.Location = new System.Drawing.Point(0, 0);
            this.lcSetting.Name = "lcSetting";
            this.lcSetting.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(219, 174, 650, 400);
            this.lcSetting.Root = this.lcgSetting;
            this.lcSetting.Size = new System.Drawing.Size(1151, 473);
            this.lcSetting.TabIndex = 0;
            this.lcSetting.Text = "layoutControl1";
            // 
            // meOutPut
            // 
            this.meOutPut.Location = new System.Drawing.Point(799, 12);
            this.meOutPut.MinimumSize = new System.Drawing.Size(300, 0);
            this.meOutPut.Name = "meOutPut";
            this.meOutPut.Size = new System.Drawing.Size(340, 449);
            this.meOutPut.StyleController = this.lcSetting;
            this.meOutPut.TabIndex = 6;
            // 
            // lcCalcTimer
            // 
            this.lcCalcTimer.Location = new System.Drawing.Point(387, 439);
            this.lcCalcTimer.Name = "lcCalcTimer";
            this.lcCalcTimer.Size = new System.Drawing.Size(131, 13);
            this.lcCalcTimer.StyleController = this.lcSetting;
            this.lcCalcTimer.TabIndex = 30;
            this.lcCalcTimer.Text = "Время расчета: 00:00.000";
            // 
            // rngPopulationTrack
            // 
            this.rngPopulationTrack.EditValue = null;
            this.rngPopulationTrack.Location = new System.Drawing.Point(76, 252);
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
            this.rngPopulationTrack.Size = new System.Drawing.Size(297, 72);
            this.rngPopulationTrack.StyleController = this.lcSetting;
            this.rngPopulationTrack.TabIndex = 35;
            this.rngPopulationTrack.EditValueChanged += new System.EventHandler(this.rngPopulationTrack_EditValueChanged);
            // 
            // sbStart
            // 
            this.sbStart.Location = new System.Drawing.Point(522, 439);
            this.sbStart.Name = "sbStart";
            this.sbStart.Size = new System.Drawing.Size(263, 22);
            this.sbStart.StyleController = this.lcSetting;
            this.sbStart.TabIndex = 4;
            this.sbStart.Text = "Начать";
            this.sbStart.Click += new System.EventHandler(this.sbStart_Click);
            // 
            // sbFunctionEnter
            // 
            this.sbFunctionEnter.Location = new System.Drawing.Point(12, 439);
            this.sbFunctionEnter.Name = "sbFunctionEnter";
            this.sbFunctionEnter.Size = new System.Drawing.Size(361, 22);
            this.sbFunctionEnter.StyleController = this.lcSetting;
            this.sbFunctionEnter.TabIndex = 9;
            this.sbFunctionEnter.Text = "Построить график";
            this.sbFunctionEnter.Click += new System.EventHandler(this.sbFunctionEnter_Click);
            // 
            // seFunctionFinishValue
            // 
            this.seFunctionFinishValue.EditValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.seFunctionFinishValue.Location = new System.Drawing.Point(230, 352);
            this.seFunctionFinishValue.Name = "seFunctionFinishValue";
            this.seFunctionFinishValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seFunctionFinishValue.Size = new System.Drawing.Size(143, 20);
            this.seFunctionFinishValue.StyleController = this.lcSetting;
            this.seFunctionFinishValue.TabIndex = 12;
            this.seFunctionFinishValue.EditValueChanged += new System.EventHandler(this.seFunctionFinishValue_EditValueChanged);
            // 
            // cmboFunction
            // 
            this.cmboFunction.Location = new System.Drawing.Point(78, 328);
            this.cmboFunction.Name = "cmboFunction";
            this.cmboFunction.Properties.AutoComplete = false;
            this.cmboFunction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmboFunction.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmboFunction.Size = new System.Drawing.Size(295, 20);
            this.cmboFunction.StyleController = this.lcSetting;
            this.cmboFunction.TabIndex = 13;
            this.cmboFunction.EditValueChanged += new System.EventHandler(this.cmboFunction_EditValueChanged);
            // 
            // seFunctionStartValue
            // 
            this.seFunctionStartValue.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.seFunctionStartValue.Location = new System.Drawing.Point(54, 352);
            this.seFunctionStartValue.Name = "seFunctionStartValue";
            this.seFunctionStartValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seFunctionStartValue.Size = new System.Drawing.Size(136, 20);
            this.seFunctionStartValue.StyleController = this.lcSetting;
            this.seFunctionStartValue.TabIndex = 11;
            this.seFunctionStartValue.EditValueChanged += new System.EventHandler(this.seFunctionStartValue_EditValueChanged);
            // 
            // ceIsDisplayMutateResult
            // 
            this.ceIsDisplayMutateResult.Location = new System.Drawing.Point(387, 276);
            this.ceIsDisplayMutateResult.Name = "ceIsDisplayMutateResult";
            this.ceIsDisplayMutateResult.Properties.Caption = "Отображение результатов мутации";
            this.ceIsDisplayMutateResult.Size = new System.Drawing.Size(398, 20);
            this.ceIsDisplayMutateResult.StyleController = this.lcSetting;
            this.ceIsDisplayMutateResult.TabIndex = 36;
            this.ceIsDisplayMutateResult.CheckedChanged += new System.EventHandler(this.ceIsDisplayMutateResult_CheckedChanged);
            // 
            // seFunctionStep
            // 
            this.seFunctionStep.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seFunctionStep.Location = new System.Drawing.Point(85, 376);
            this.seFunctionStep.Name = "seFunctionStep";
            this.seFunctionStep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seFunctionStep.Properties.DisplayFormat.FormatString = "G29";
            this.seFunctionStep.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.seFunctionStep.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.seFunctionStep.Size = new System.Drawing.Size(288, 20);
            this.seFunctionStep.StyleController = this.lcSetting;
            this.seFunctionStep.TabIndex = 10;
            this.seFunctionStep.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.seFunctionStep_Spin);
            this.seFunctionStep.EditValueChanged += new System.EventHandler(this.seFunctionStep_EditValueChanged);
            // 
            // ceIsDuplicate
            // 
            this.ceIsDuplicate.Location = new System.Drawing.Point(387, 396);
            this.ceIsDuplicate.Name = "ceIsDuplicate";
            this.ceIsDuplicate.Properties.Caption = "Отбор дублируемых особей";
            this.ceIsDuplicate.Size = new System.Drawing.Size(398, 20);
            this.ceIsDuplicate.StyleController = this.lcSetting;
            this.ceIsDuplicate.TabIndex = 33;
            this.ceIsDuplicate.CheckedChanged += new System.EventHandler(this.ceIsDuplicate_CheckedChanged);
            // 
            // ceIsDisplayCrossResult
            // 
            this.ceIsDisplayCrossResult.Location = new System.Drawing.Point(387, 156);
            this.ceIsDisplayCrossResult.Name = "ceIsDisplayCrossResult";
            this.ceIsDisplayCrossResult.Properties.Caption = "Отображение результатов скрещивания";
            this.ceIsDisplayCrossResult.Size = new System.Drawing.Size(398, 20);
            this.ceIsDisplayCrossResult.StyleController = this.lcSetting;
            this.ceIsDisplayCrossResult.TabIndex = 37;
            this.ceIsDisplayCrossResult.CheckedChanged += new System.EventHandler(this.ceIsDisplayCrossResult_CheckedChanged);
            // 
            // ceIsDisplaySelectionResult
            // 
            this.ceIsDisplaySelectionResult.Location = new System.Drawing.Point(387, 372);
            this.ceIsDisplaySelectionResult.Name = "ceIsDisplaySelectionResult";
            this.ceIsDisplaySelectionResult.Properties.Caption = "Отображение промежуточных результатов турнирной селекции";
            this.ceIsDisplaySelectionResult.Size = new System.Drawing.Size(398, 20);
            this.ceIsDisplaySelectionResult.StyleController = this.lcSetting;
            this.ceIsDisplaySelectionResult.TabIndex = 32;
            this.ceIsDisplaySelectionResult.CheckedChanged += new System.EventHandler(this.ceIsDisplay_CheckedChanged);
            // 
            // lueSelectTarget
            // 
            this.lueSelectTarget.Location = new System.Drawing.Point(423, 12);
            this.lueSelectTarget.Name = "lueSelectTarget";
            this.lueSelectTarget.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSelectTarget.Properties.DropDownRows = 2;
            this.lueSelectTarget.Properties.ShowFooter = false;
            this.lueSelectTarget.Properties.ShowHeader = false;
            this.lueSelectTarget.Size = new System.Drawing.Size(362, 20);
            this.lueSelectTarget.StyleController = this.lcSetting;
            this.lueSelectTarget.TabIndex = 15;
            this.lueSelectTarget.EditValueChanged += new System.EventHandler(this.lueSelectTarget_EditValueChanged);
            // 
            // seGroupSize
            // 
            this.seGroupSize.EditValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.seGroupSize.Location = new System.Drawing.Point(524, 348);
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
            this.seGroupSize.Size = new System.Drawing.Size(261, 20);
            this.seGroupSize.StyleController = this.lcSetting;
            this.seGroupSize.TabIndex = 31;
            this.seGroupSize.EditValueChanged += new System.EventHandler(this.seGroupSize_EditValueChanged);
            // 
            // seGenerationSize
            // 
            this.seGenerationSize.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.seGenerationSize.Location = new System.Drawing.Point(509, 36);
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
            this.seGenerationSize.Size = new System.Drawing.Size(276, 20);
            this.seGenerationSize.StyleController = this.lcSetting;
            this.seGenerationSize.TabIndex = 24;
            this.seGenerationSize.EditValueChanged += new System.EventHandler(this.seGenerationSize_EditValueChanged);
            // 
            // chFunction
            // 
            this.chFunction.BorderOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            xyDiagram3.AxisX.DateTimeScaleOptions.ScaleMode = DevExpress.XtraCharts.ScaleMode.Continuous;
            xyDiagram3.AxisX.Title.Text = "X";
            xyDiagram3.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram3.AxisY.Title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram3.AxisY.Title.Text = "Y";
            xyDiagram3.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram3.EnableAxisXScrolling = true;
            xyDiagram3.EnableAxisXZooming = true;
            xyDiagram3.EnableAxisYScrolling = true;
            xyDiagram3.EnableAxisYZooming = true;
            this.chFunction.Diagram = xyDiagram3;
            this.chFunction.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            this.chFunction.Legend.Name = "Default Legend";
            this.chFunction.Legend.TextVisible = false;
            this.chFunction.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chFunction.Location = new System.Drawing.Point(12, 12);
            this.chFunction.Name = "chFunction";
            series7.Name = "Целевая функция";
            lineSeriesView7.LineMarkerOptions.Size = 1;
            lineSeriesView7.LineStyle.Thickness = 1;
            lineSeriesView7.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
            series7.View = lineSeriesView7;
            series8.Name = "Рассчитанное лучшее решение";
            series8.View = lineSeriesView8;
            series9.Name = "Найденные ГА решения";
            series9.View = lineSeriesView9;
            this.chFunction.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series7,
        series8,
        series9};
            this.chFunction.Size = new System.Drawing.Size(361, 236);
            this.chFunction.TabIndex = 7;
            // 
            // sePopulationSize
            // 
            this.sePopulationSize.EditValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.sePopulationSize.Location = new System.Drawing.Point(484, 60);
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
            this.sePopulationSize.Size = new System.Drawing.Size(301, 20);
            this.sePopulationSize.StyleController = this.lcSetting;
            this.sePopulationSize.TabIndex = 25;
            this.sePopulationSize.EditValueChanged += new System.EventHandler(this.sePopulationSize_EditValueChanged);
            // 
            // seSelectionTreshold
            // 
            this.seSelectionTreshold.EditValue = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.seSelectionTreshold.Location = new System.Drawing.Point(472, 324);
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
            this.seSelectionTreshold.Size = new System.Drawing.Size(313, 20);
            this.seSelectionTreshold.StyleController = this.lcSetting;
            this.seSelectionTreshold.TabIndex = 23;
            this.seSelectionTreshold.EditValueChanged += new System.EventHandler(this.seSelectionTreshold_EditValueChanged);
            // 
            // lueSelectParent
            // 
            this.lueSelectParent.Location = new System.Drawing.Point(540, 84);
            this.lueSelectParent.Name = "lueSelectParent";
            this.lueSelectParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSelectParent.Size = new System.Drawing.Size(245, 20);
            this.lueSelectParent.StyleController = this.lcSetting;
            this.lueSelectParent.TabIndex = 27;
            this.lueSelectParent.EditValueChanged += new System.EventHandler(this.lueSelectParent_EditValueChanged);
            // 
            // lueSelectSelection
            // 
            this.lueSelectSelection.Location = new System.Drawing.Point(579, 300);
            this.lueSelectSelection.Name = "lueSelectSelection";
            this.lueSelectSelection.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSelectSelection.Size = new System.Drawing.Size(206, 20);
            this.lueSelectSelection.StyleController = this.lcSetting;
            this.lueSelectSelection.TabIndex = 22;
            this.lueSelectSelection.EditValueChanged += new System.EventHandler(this.lueSelectSelection_EditValueChanged);
            // 
            // lueSelectCross
            // 
            this.lueSelectCross.Location = new System.Drawing.Point(572, 108);
            this.lueSelectCross.Name = "lueSelectCross";
            this.lueSelectCross.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSelectCross.Size = new System.Drawing.Size(213, 20);
            this.lueSelectCross.StyleController = this.lcSetting;
            this.lueSelectCross.TabIndex = 28;
            this.lueSelectCross.EditValueChanged += new System.EventHandler(this.lueSelectCross_EditValueChanged);
            // 
            // seMutationGeneProbability
            // 
            this.seMutationGeneProbability.EditValue = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.seMutationGeneProbability.Location = new System.Drawing.Point(528, 228);
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
            this.seMutationGeneProbability.Size = new System.Drawing.Size(257, 20);
            this.seMutationGeneProbability.StyleController = this.lcSetting;
            this.seMutationGeneProbability.TabIndex = 29;
            this.seMutationGeneProbability.EditValueChanged += new System.EventHandler(this.seMutationGeneProbability_EditValueChanged);
            // 
            // seDevidePointCount
            // 
            this.seDevidePointCount.EditValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.seDevidePointCount.Location = new System.Drawing.Point(526, 132);
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
            this.seDevidePointCount.Size = new System.Drawing.Size(259, 20);
            this.seDevidePointCount.StyleController = this.lcSetting;
            this.seDevidePointCount.TabIndex = 18;
            this.seDevidePointCount.EditValueChanged += new System.EventHandler(this.seDevidePointCount_EditValueChanged);
            // 
            // seMutateGeneCount
            // 
            this.seMutateGeneCount.EditValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.seMutateGeneCount.Location = new System.Drawing.Point(524, 252);
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
            this.seMutateGeneCount.Size = new System.Drawing.Size(261, 20);
            this.seMutateGeneCount.StyleController = this.lcSetting;
            this.seMutateGeneCount.TabIndex = 19;
            this.seMutateGeneCount.EditValueChanged += new System.EventHandler(this.seMutateGeneCount_EditValueChanged);
            // 
            // seMutationProbability
            // 
            this.seMutationProbability.EditValue = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            this.seMutationProbability.Location = new System.Drawing.Point(502, 204);
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
            this.seMutationProbability.Size = new System.Drawing.Size(283, 20);
            this.seMutationProbability.StyleController = this.lcSetting;
            this.seMutationProbability.TabIndex = 26;
            this.seMutationProbability.EditValueChanged += new System.EventHandler(this.seMutationProbability_EditValueChanged);
            // 
            // lueSelectMutate
            // 
            this.lueSelectMutate.Location = new System.Drawing.Point(533, 180);
            this.lueSelectMutate.Name = "lueSelectMutate";
            this.lueSelectMutate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueSelectMutate.Size = new System.Drawing.Size(252, 20);
            this.lueSelectMutate.StyleController = this.lcSetting;
            this.lueSelectMutate.TabIndex = 20;
            this.lueSelectMutate.EditValueChanged += new System.EventHandler(this.lueSelectMutate_EditValueChanged);
            // 
            // lcgSetting
            // 
            this.lcgSetting.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgSetting.GroupBordersVisible = false;
            this.lcgSetting.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciSelectTarget,
            this.lciSelectSelection,
            this.lciSelectionTreshold,
            this.lciGroupSize,
            this.lciIsDisplaySelectionResult,
            this.lciFunctionStartValue,
            this.lciFunctionStep,
            this.lciFunctionChart,
            this.esiSetting,
            this.lciPopulationTrack,
            this.lciGenerationSize,
            this.lciPopulationSize,
            this.lciSelectParent,
            this.lciSelectCross,
            this.lciDevidePointCount,
            this.lciIsDisplayCrossResult,
            this.lciSelectMutate,
            this.lciMutationProbability,
            this.lciMutationGeneProbability,
            this.lciMutateGeneCount,
            this.lciIsDisplayMutateResult,
            this.lciIsDuplicate,
            this.lciFunctionEnter,
            this.lciStart,
            this.lciCalcTimer,
            this.splitSettingOutput,
            this.lciOutPut,
            this.esiFunction,
            this.splitFunctionSetting,
            this.lciCmboFunction,
            this.lciFunctionFinishValue});
            this.lcgSetting.Name = "lcgSetting";
            this.lcgSetting.Size = new System.Drawing.Size(1151, 473);
            this.lcgSetting.TextVisible = false;
            // 
            // lciSelectTarget
            // 
            this.lciSelectTarget.Control = this.lueSelectTarget;
            this.lciSelectTarget.Location = new System.Drawing.Point(375, 0);
            this.lciSelectTarget.Name = "lciSelectTarget";
            this.lciSelectTarget.Size = new System.Drawing.Size(402, 24);
            this.lciSelectTarget.Text = "Найти";
            this.lciSelectTarget.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSelectTarget.TextSize = new System.Drawing.Size(31, 13);
            this.lciSelectTarget.TextToControlDistance = 5;
            // 
            // lciSelectSelection
            // 
            this.lciSelectSelection.Control = this.lueSelectSelection;
            this.lciSelectSelection.Location = new System.Drawing.Point(375, 288);
            this.lciSelectSelection.Name = "lciSelectSelection";
            this.lciSelectSelection.Size = new System.Drawing.Size(402, 24);
            this.lciSelectSelection.Text = "Методика отбора в след. поколение";
            this.lciSelectSelection.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSelectSelection.TextSize = new System.Drawing.Size(187, 13);
            this.lciSelectSelection.TextToControlDistance = 5;
            // 
            // lciSelectionTreshold
            // 
            this.lciSelectionTreshold.Control = this.seSelectionTreshold;
            this.lciSelectionTreshold.Location = new System.Drawing.Point(375, 312);
            this.lciSelectionTreshold.Name = "lciSelectionTreshold";
            this.lciSelectionTreshold.Size = new System.Drawing.Size(402, 24);
            this.lciSelectionTreshold.Text = "Порог селекции";
            this.lciSelectionTreshold.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSelectionTreshold.TextSize = new System.Drawing.Size(80, 13);
            this.lciSelectionTreshold.TextToControlDistance = 5;
            // 
            // lciGroupSize
            // 
            this.lciGroupSize.Control = this.seGroupSize;
            this.lciGroupSize.Location = new System.Drawing.Point(375, 336);
            this.lciGroupSize.Name = "lciGroupSize";
            this.lciGroupSize.Size = new System.Drawing.Size(402, 24);
            this.lciGroupSize.Text = "Размер турнирной группы";
            this.lciGroupSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciGroupSize.TextSize = new System.Drawing.Size(132, 13);
            this.lciGroupSize.TextToControlDistance = 5;
            // 
            // lciIsDisplaySelectionResult
            // 
            this.lciIsDisplaySelectionResult.Control = this.ceIsDisplaySelectionResult;
            this.lciIsDisplaySelectionResult.Location = new System.Drawing.Point(375, 360);
            this.lciIsDisplaySelectionResult.Name = "lciIsDisplaySelectionResult";
            this.lciIsDisplaySelectionResult.Size = new System.Drawing.Size(402, 24);
            this.lciIsDisplaySelectionResult.TextSize = new System.Drawing.Size(0, 0);
            this.lciIsDisplaySelectionResult.TextVisible = false;
            // 
            // lciFunctionStartValue
            // 
            this.lciFunctionStartValue.Control = this.seFunctionStartValue;
            this.lciFunctionStartValue.Location = new System.Drawing.Point(0, 340);
            this.lciFunctionStartValue.Name = "lciFunctionStartValue";
            this.lciFunctionStartValue.Size = new System.Drawing.Size(182, 24);
            this.lciFunctionStartValue.Text = "Начало";
            this.lciFunctionStartValue.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciFunctionStartValue.TextSize = new System.Drawing.Size(37, 13);
            this.lciFunctionStartValue.TextToControlDistance = 5;
            // 
            // lciFunctionStep
            // 
            this.lciFunctionStep.Control = this.seFunctionStep;
            this.lciFunctionStep.Location = new System.Drawing.Point(0, 364);
            this.lciFunctionStep.Name = "lciFunctionStep";
            this.lciFunctionStep.Size = new System.Drawing.Size(365, 24);
            this.lciFunctionStep.Text = "Шаг функции";
            this.lciFunctionStep.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciFunctionStep.TextSize = new System.Drawing.Size(68, 13);
            this.lciFunctionStep.TextToControlDistance = 5;
            // 
            // lciFunctionChart
            // 
            this.lciFunctionChart.Control = this.chFunction;
            this.lciFunctionChart.Location = new System.Drawing.Point(0, 0);
            this.lciFunctionChart.Name = "lciFunctionChart";
            this.lciFunctionChart.Size = new System.Drawing.Size(365, 240);
            this.lciFunctionChart.TextSize = new System.Drawing.Size(0, 0);
            this.lciFunctionChart.TextVisible = false;
            // 
            // esiSetting
            // 
            this.esiSetting.AllowHotTrack = false;
            this.esiSetting.Location = new System.Drawing.Point(375, 408);
            this.esiSetting.Name = "esiSetting";
            this.esiSetting.Size = new System.Drawing.Size(402, 19);
            this.esiSetting.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciPopulationTrack
            // 
            this.lciPopulationTrack.Control = this.rngPopulationTrack;
            this.lciPopulationTrack.Location = new System.Drawing.Point(0, 240);
            this.lciPopulationTrack.Name = "lciPopulationTrack";
            this.lciPopulationTrack.Size = new System.Drawing.Size(365, 76);
            this.lciPopulationTrack.Text = "Популяция:";
            this.lciPopulationTrack.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciPopulationTrack.TextSize = new System.Drawing.Size(59, 13);
            this.lciPopulationTrack.TextToControlDistance = 5;
            // 
            // lciGenerationSize
            // 
            this.lciGenerationSize.Control = this.seGenerationSize;
            this.lciGenerationSize.Location = new System.Drawing.Point(375, 24);
            this.lciGenerationSize.Name = "lciGenerationSize";
            this.lciGenerationSize.Size = new System.Drawing.Size(402, 24);
            this.lciGenerationSize.Text = "Количество поколений";
            this.lciGenerationSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciGenerationSize.TextSize = new System.Drawing.Size(117, 13);
            this.lciGenerationSize.TextToControlDistance = 5;
            // 
            // lciPopulationSize
            // 
            this.lciPopulationSize.Control = this.sePopulationSize;
            this.lciPopulationSize.Location = new System.Drawing.Point(375, 48);
            this.lciPopulationSize.Name = "lciPopulationSize";
            this.lciPopulationSize.Size = new System.Drawing.Size(402, 24);
            this.lciPopulationSize.Text = "Размер популяции";
            this.lciPopulationSize.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciPopulationSize.TextSize = new System.Drawing.Size(92, 13);
            this.lciPopulationSize.TextToControlDistance = 5;
            // 
            // lciSelectParent
            // 
            this.lciSelectParent.Control = this.lueSelectParent;
            this.lciSelectParent.Location = new System.Drawing.Point(375, 72);
            this.lciSelectParent.Name = "lciSelectParent";
            this.lciSelectParent.Size = new System.Drawing.Size(402, 24);
            this.lciSelectParent.Text = "Методика отбора родителей";
            this.lciSelectParent.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSelectParent.TextSize = new System.Drawing.Size(148, 13);
            this.lciSelectParent.TextToControlDistance = 5;
            // 
            // lciSelectCross
            // 
            this.lciSelectCross.Control = this.lueSelectCross;
            this.lciSelectCross.Location = new System.Drawing.Point(375, 96);
            this.lciSelectCross.Name = "lciSelectCross";
            this.lciSelectCross.Size = new System.Drawing.Size(402, 24);
            this.lciSelectCross.Text = "Методика скрещивания родителей";
            this.lciSelectCross.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSelectCross.TextSize = new System.Drawing.Size(180, 13);
            this.lciSelectCross.TextToControlDistance = 5;
            // 
            // lciDevidePointCount
            // 
            this.lciDevidePointCount.Control = this.seDevidePointCount;
            this.lciDevidePointCount.Location = new System.Drawing.Point(375, 120);
            this.lciDevidePointCount.Name = "lciDevidePointCount";
            this.lciDevidePointCount.Size = new System.Drawing.Size(402, 24);
            this.lciDevidePointCount.Text = "Кол-во точек разделения ";
            this.lciDevidePointCount.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciDevidePointCount.TextSize = new System.Drawing.Size(134, 13);
            this.lciDevidePointCount.TextToControlDistance = 5;
            // 
            // lciIsDisplayCrossResult
            // 
            this.lciIsDisplayCrossResult.Control = this.ceIsDisplayCrossResult;
            this.lciIsDisplayCrossResult.Location = new System.Drawing.Point(375, 144);
            this.lciIsDisplayCrossResult.Name = "lciIsDisplayCrossResult";
            this.lciIsDisplayCrossResult.Size = new System.Drawing.Size(402, 24);
            this.lciIsDisplayCrossResult.TextSize = new System.Drawing.Size(0, 0);
            this.lciIsDisplayCrossResult.TextVisible = false;
            // 
            // lciSelectMutate
            // 
            this.lciSelectMutate.Control = this.lueSelectMutate;
            this.lciSelectMutate.Location = new System.Drawing.Point(375, 168);
            this.lciSelectMutate.Name = "lciSelectMutate";
            this.lciSelectMutate.Size = new System.Drawing.Size(402, 24);
            this.lciSelectMutate.Text = "Методика мутации потомка";
            this.lciSelectMutate.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciSelectMutate.TextSize = new System.Drawing.Size(141, 13);
            this.lciSelectMutate.TextToControlDistance = 5;
            // 
            // lciMutationProbability
            // 
            this.lciMutationProbability.Control = this.seMutationProbability;
            this.lciMutationProbability.Location = new System.Drawing.Point(375, 192);
            this.lciMutationProbability.Name = "lciMutationProbability";
            this.lciMutationProbability.Size = new System.Drawing.Size(402, 24);
            this.lciMutationProbability.Text = "Вероятность мутации";
            this.lciMutationProbability.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciMutationProbability.TextSize = new System.Drawing.Size(110, 13);
            this.lciMutationProbability.TextToControlDistance = 5;
            // 
            // lciMutationGeneProbability
            // 
            this.lciMutationGeneProbability.Control = this.seMutationGeneProbability;
            this.lciMutationGeneProbability.Location = new System.Drawing.Point(375, 216);
            this.lciMutationGeneProbability.Name = "lciMutationGeneProbability";
            this.lciMutationGeneProbability.Size = new System.Drawing.Size(402, 24);
            this.lciMutationGeneProbability.Text = "Вероятность мутации гена";
            this.lciMutationGeneProbability.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciMutationGeneProbability.TextSize = new System.Drawing.Size(136, 13);
            this.lciMutationGeneProbability.TextToControlDistance = 5;
            // 
            // lciMutateGeneCount
            // 
            this.lciMutateGeneCount.Control = this.seMutateGeneCount;
            this.lciMutateGeneCount.Location = new System.Drawing.Point(375, 240);
            this.lciMutateGeneCount.Name = "lciMutateGeneCount";
            this.lciMutateGeneCount.Size = new System.Drawing.Size(402, 24);
            this.lciMutateGeneCount.Text = "Кол-во мутируемых генов";
            this.lciMutateGeneCount.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciMutateGeneCount.TextSize = new System.Drawing.Size(132, 13);
            this.lciMutateGeneCount.TextToControlDistance = 5;
            // 
            // lciIsDisplayMutateResult
            // 
            this.lciIsDisplayMutateResult.Control = this.ceIsDisplayMutateResult;
            this.lciIsDisplayMutateResult.Location = new System.Drawing.Point(375, 264);
            this.lciIsDisplayMutateResult.Name = "lciIsDisplayMutateResult";
            this.lciIsDisplayMutateResult.Size = new System.Drawing.Size(402, 24);
            this.lciIsDisplayMutateResult.TextSize = new System.Drawing.Size(0, 0);
            this.lciIsDisplayMutateResult.TextVisible = false;
            // 
            // lciIsDuplicate
            // 
            this.lciIsDuplicate.Control = this.ceIsDuplicate;
            this.lciIsDuplicate.Location = new System.Drawing.Point(375, 384);
            this.lciIsDuplicate.Name = "lciIsDuplicate";
            this.lciIsDuplicate.Size = new System.Drawing.Size(402, 24);
            this.lciIsDuplicate.TextSize = new System.Drawing.Size(0, 0);
            this.lciIsDuplicate.TextVisible = false;
            // 
            // lciFunctionEnter
            // 
            this.lciFunctionEnter.Control = this.sbFunctionEnter;
            this.lciFunctionEnter.Location = new System.Drawing.Point(0, 427);
            this.lciFunctionEnter.Name = "lciFunctionEnter";
            this.lciFunctionEnter.Size = new System.Drawing.Size(365, 26);
            this.lciFunctionEnter.TextSize = new System.Drawing.Size(0, 0);
            this.lciFunctionEnter.TextVisible = false;
            // 
            // lciStart
            // 
            this.lciStart.Control = this.sbStart;
            this.lciStart.Location = new System.Drawing.Point(510, 427);
            this.lciStart.Name = "lciStart";
            this.lciStart.Size = new System.Drawing.Size(267, 26);
            this.lciStart.TextSize = new System.Drawing.Size(0, 0);
            this.lciStart.TextVisible = false;
            // 
            // lciCalcTimer
            // 
            this.lciCalcTimer.Control = this.lcCalcTimer;
            this.lciCalcTimer.Location = new System.Drawing.Point(375, 427);
            this.lciCalcTimer.Name = "lciCalcTimer";
            this.lciCalcTimer.Size = new System.Drawing.Size(135, 26);
            this.lciCalcTimer.TextSize = new System.Drawing.Size(0, 0);
            this.lciCalcTimer.TextVisible = false;
            // 
            // splitSettingOutput
            // 
            this.splitSettingOutput.AllowHotTrack = true;
            this.splitSettingOutput.Location = new System.Drawing.Point(777, 0);
            this.splitSettingOutput.Name = "splitSettingOutput";
            this.splitSettingOutput.Size = new System.Drawing.Size(10, 453);
            // 
            // lciOutPut
            // 
            this.lciOutPut.Control = this.meOutPut;
            this.lciOutPut.Location = new System.Drawing.Point(787, 0);
            this.lciOutPut.Name = "lciOutPut";
            this.lciOutPut.Size = new System.Drawing.Size(344, 453);
            this.lciOutPut.TextSize = new System.Drawing.Size(0, 0);
            this.lciOutPut.TextVisible = false;
            // 
            // esiFunction
            // 
            this.esiFunction.AllowHotTrack = false;
            this.esiFunction.Location = new System.Drawing.Point(0, 388);
            this.esiFunction.Name = "esiFunction";
            this.esiFunction.Size = new System.Drawing.Size(365, 39);
            this.esiFunction.TextSize = new System.Drawing.Size(0, 0);
            // 
            // splitFunctionSetting
            // 
            this.splitFunctionSetting.AllowHotTrack = true;
            this.splitFunctionSetting.Location = new System.Drawing.Point(365, 0);
            this.splitFunctionSetting.Name = "splitFunctionSetting";
            this.splitFunctionSetting.Size = new System.Drawing.Size(10, 453);
            // 
            // lciCmboFunction
            // 
            this.lciCmboFunction.Control = this.cmboFunction;
            this.lciCmboFunction.Location = new System.Drawing.Point(0, 316);
            this.lciCmboFunction.Name = "lciCmboFunction";
            this.lciCmboFunction.Size = new System.Drawing.Size(365, 24);
            this.lciCmboFunction.Text = "Функция y=";
            this.lciCmboFunction.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciCmboFunction.TextSize = new System.Drawing.Size(61, 13);
            this.lciCmboFunction.TextToControlDistance = 5;
            // 
            // lciFunctionFinishValue
            // 
            this.lciFunctionFinishValue.Control = this.seFunctionFinishValue;
            this.lciFunctionFinishValue.Location = new System.Drawing.Point(182, 340);
            this.lciFunctionFinishValue.Name = "lciFunctionFinishValue";
            this.lciFunctionFinishValue.Size = new System.Drawing.Size(183, 24);
            this.lciFunctionFinishValue.Text = "Конец";
            this.lciFunctionFinishValue.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciFunctionFinishValue.TextSize = new System.Drawing.Size(31, 13);
            this.lciFunctionFinishValue.TextToControlDistance = 5;
            // 
            // tabAnalysis
            // 
            this.tabAnalysis.Controls.Add(this.lcAnalysis);
            this.tabAnalysis.Name = "tabAnalysis";
            this.tabAnalysis.Size = new System.Drawing.Size(1151, 473);
            this.tabAnalysis.Text = "Анализ";
            // 
            // lcAnalysis
            // 
            this.lcAnalysis.Controls.Add(this.lueAnalysisSelectionMethods);
            this.lcAnalysis.Controls.Add(this.sbAnalysis);
            this.lcAnalysis.Controls.Add(this.seRunAmount);
            this.lcAnalysis.Controls.Add(this.meOutputAnalysis);
            this.lcAnalysis.Controls.Add(this.chAnalysis);
            this.lcAnalysis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcAnalysis.Location = new System.Drawing.Point(0, 0);
            this.lcAnalysis.Name = "lcAnalysis";
            this.lcAnalysis.Root = this.lcgAnalysis;
            this.lcAnalysis.Size = new System.Drawing.Size(1151, 473);
            this.lcAnalysis.TabIndex = 0;
            this.lcAnalysis.Text = "layoutControl1";
            // 
            // lueAnalysisSelectionMethods
            // 
            this.lueAnalysisSelectionMethods.EditValue = "";
            this.lueAnalysisSelectionMethods.Location = new System.Drawing.Point(187, 36);
            this.lueAnalysisSelectionMethods.Name = "lueAnalysisSelectionMethods";
            this.lueAnalysisSelectionMethods.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueAnalysisSelectionMethods.Properties.SelectAllItemVisible = false;
            this.lueAnalysisSelectionMethods.Size = new System.Drawing.Size(189, 20);
            this.lueAnalysisSelectionMethods.StyleController = this.lcAnalysis;
            this.lueAnalysisSelectionMethods.TabIndex = 8;
            this.lueAnalysisSelectionMethods.EditValueChanged += new System.EventHandler(this.lueAnalysisSelectionMethods_EditValueChanged);
            // 
            // sbAnalysis
            // 
            this.sbAnalysis.Location = new System.Drawing.Point(12, 60);
            this.sbAnalysis.Name = "sbAnalysis";
            this.sbAnalysis.Size = new System.Drawing.Size(364, 22);
            this.sbAnalysis.StyleController = this.lcAnalysis;
            this.sbAnalysis.TabIndex = 7;
            this.sbAnalysis.Text = "Анализ";
            this.sbAnalysis.Click += new System.EventHandler(this.sbAnalysis_Click);
            // 
            // seRunAmount
            // 
            this.seRunAmount.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.seRunAmount.Location = new System.Drawing.Point(127, 12);
            this.seRunAmount.Name = "seRunAmount";
            this.seRunAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.seRunAmount.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.seRunAmount.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.seRunAmount.Size = new System.Drawing.Size(249, 20);
            this.seRunAmount.StyleController = this.lcAnalysis;
            this.seRunAmount.TabIndex = 6;
            this.seRunAmount.EditValueChanged += new System.EventHandler(this.seRunAmount_EditValueChanged);
            // 
            // meOutputAnalysis
            // 
            this.meOutputAnalysis.Location = new System.Drawing.Point(380, 28);
            this.meOutputAnalysis.Name = "meOutputAnalysis";
            this.meOutputAnalysis.Size = new System.Drawing.Size(401, 433);
            this.meOutputAnalysis.StyleController = this.lcAnalysis;
            this.meOutputAnalysis.TabIndex = 5;
            // 
            // chAnalysis
            // 
            this.chAnalysis.Legend.Name = "Default Legend";
            this.chAnalysis.Location = new System.Drawing.Point(785, 12);
            this.chAnalysis.Name = "chAnalysis";
            this.chAnalysis.PaletteName = "Marquee";
            this.chAnalysis.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chAnalysis.Size = new System.Drawing.Size(354, 449);
            this.chAnalysis.TabIndex = 4;
            // 
            // lcgAnalysis
            // 
            this.lcgAnalysis.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgAnalysis.GroupBordersVisible = false;
            this.lcgAnalysis.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciAnalysisChart,
            this.lciOutputAnalysis,
            this.esiSettingAnalysis,
            this.lciRunAmount,
            this.lciAnalysis,
            this.lciAnalysisSelectionMethods});
            this.lcgAnalysis.Name = "lcgAnalysis";
            this.lcgAnalysis.Size = new System.Drawing.Size(1151, 473);
            this.lcgAnalysis.TextVisible = false;
            // 
            // lciAnalysisChart
            // 
            this.lciAnalysisChart.Control = this.chAnalysis;
            this.lciAnalysisChart.Location = new System.Drawing.Point(773, 0);
            this.lciAnalysisChart.Name = "lciAnalysisChart";
            this.lciAnalysisChart.Size = new System.Drawing.Size(358, 453);
            this.lciAnalysisChart.TextSize = new System.Drawing.Size(0, 0);
            this.lciAnalysisChart.TextVisible = false;
            // 
            // lciOutputAnalysis
            // 
            this.lciOutputAnalysis.Control = this.meOutputAnalysis;
            this.lciOutputAnalysis.Location = new System.Drawing.Point(368, 0);
            this.lciOutputAnalysis.Name = "lciOutputAnalysis";
            this.lciOutputAnalysis.Size = new System.Drawing.Size(405, 453);
            this.lciOutputAnalysis.Text = "Вывод результатов:";
            this.lciOutputAnalysis.TextLocation = DevExpress.Utils.Locations.Top;
            this.lciOutputAnalysis.TextSize = new System.Drawing.Size(172, 13);
            // 
            // esiSettingAnalysis
            // 
            this.esiSettingAnalysis.AllowHotTrack = false;
            this.esiSettingAnalysis.Location = new System.Drawing.Point(0, 74);
            this.esiSettingAnalysis.Name = "esiSettingAnalysis";
            this.esiSettingAnalysis.Size = new System.Drawing.Size(367, 380);
            this.esiSettingAnalysis.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lciRunAmount
            // 
            this.lciRunAmount.Control = this.seRunAmount;
            this.lciRunAmount.Location = new System.Drawing.Point(0, 0);
            this.lciRunAmount.Name = "lciRunAmount";
            this.lciRunAmount.Size = new System.Drawing.Size(368, 24);
            this.lciRunAmount.Text = "Количество прогонов";
            this.lciRunAmount.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lciRunAmount.TextSize = new System.Drawing.Size(110, 13);
            this.lciRunAmount.TextToControlDistance = 5;
            // 
            // lciAnalysis
            // 
            this.lciAnalysis.Control = this.sbAnalysis;
            this.lciAnalysis.Location = new System.Drawing.Point(0, 48);
            this.lciAnalysis.Name = "lciAnalysis";
            this.lciAnalysis.Size = new System.Drawing.Size(368, 26);
            this.lciAnalysis.TextSize = new System.Drawing.Size(0, 0);
            this.lciAnalysis.TextVisible = false;
            // 
            // lciAnalysisSelectionMethods
            // 
            this.lciAnalysisSelectionMethods.Control = this.lueAnalysisSelectionMethods;
            this.lciAnalysisSelectionMethods.Location = new System.Drawing.Point(0, 24);
            this.lciAnalysisSelectionMethods.Name = "lciAnalysisSelectionMethods";
            this.lciAnalysisSelectionMethods.Size = new System.Drawing.Size(368, 24);
            this.lciAnalysisSelectionMethods.Text = "Анализируемые методы селекции";
            this.lciAnalysisSelectionMethods.TextSize = new System.Drawing.Size(172, 13);
            // 
            // lcgMain
            // 
            this.lcgMain.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgMain.GroupBordersVisible = false;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciTabs});
            this.lcgMain.Name = "Root";
            this.lcgMain.Size = new System.Drawing.Size(1177, 526);
            this.lcgMain.TextVisible = false;
            // 
            // lciTabs
            // 
            this.lciTabs.Control = this.tabControl;
            this.lciTabs.Location = new System.Drawing.Point(0, 0);
            this.lciTabs.Name = "lciTabs";
            this.lciTabs.Size = new System.Drawing.Size(1157, 506);
            this.lciTabs.TextSize = new System.Drawing.Size(0, 0);
            this.lciTabs.TextVisible = false;
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
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "The Bezier";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 526);
            this.Controls.Add(this.lcMain);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Glow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcSetting)).EndInit();
            this.lcSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.meOutPut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rngPopulationTrack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rngPopulationTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionFinishValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmboFunction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionStartValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDisplayMutateResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seFunctionStep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDuplicate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDisplayCrossResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceIsDisplaySelectionResult.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectTarget.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGroupSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seGenerationSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sePopulationSize.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seSelectionTreshold.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectSelection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectCross.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutationGeneProbability.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seDevidePointCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutateGeneCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seMutationProbability.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueSelectMutate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectionTreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGroupSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDisplaySelectionResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionStartValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPopulationTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciGenerationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectCross)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciDevidePointCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDisplayCrossResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciSelectMutate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutationProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutationGeneProbability)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciMutateGeneCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDisplayMutateResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciIsDuplicate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionEnter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCalcTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitSettingOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOutPut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitFunctionSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCmboFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciFunctionFinishValue)).EndInit();
            this.tabAnalysis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcAnalysis)).EndInit();
            this.lcAnalysis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueAnalysisSelectionMethods.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seRunAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meOutputAnalysis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnalysisChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOutputAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiSettingAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciRunAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciAnalysisSelectionMethods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciTabs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMutation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcMain;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMain;
        private DevExpress.XtraEditors.MemoEdit meOutPut;
        private DevExpress.XtraEditors.SimpleButton sbStart;
        private DevExpress.XtraEditors.SimpleButton sbFunctionEnter;
        private DevExpress.XtraCharts.ChartControl chFunction;
        private DevExpress.XtraEditors.SpinEdit seFunctionStep;
        private DevExpress.XtraEditors.SpinEdit seFunctionFinishValue;
        private DevExpress.XtraEditors.SpinEdit seFunctionStartValue;
        private DevExpress.XtraEditors.ComboBoxEdit cmboFunction;
        private DevExpress.XtraEditors.LookUpEdit lueSelectTarget;
        private DevExpress.XtraEditors.SpinEdit seDevidePointCount;
        private DevExpress.XtraEditors.LookUpEdit lueSelectMutate;
        private DevExpress.XtraEditors.SpinEdit seMutateGeneCount;
        private DevExpress.XtraEditors.LookUpEdit lueSelectSelection;
        private DevExpress.XtraEditors.SpinEdit seSelectionTreshold;
        private DevExpress.XtraEditors.SpinEdit seGenerationSize;
        private DevExpress.XtraEditors.SpinEdit sePopulationSize;
        private DevExpress.XtraEditors.SpinEdit seMutationProbability;
        private DevExpress.XtraEditors.LookUpEdit lueSelectParent;
        private DevExpress.XtraEditors.LookUpEdit lueSelectCross;
        private DevExpress.XtraLayout.LayoutControlGroup lcgMutation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SpinEdit seMutationGeneProbability;
        private DevExpress.XtraEditors.LabelControl lcCalcTimer;
        private System.Windows.Forms.Timer calculateTimer;
        private DevExpress.XtraEditors.SpinEdit seGroupSize;
        private DevExpress.XtraEditors.CheckEdit ceIsDisplaySelectionResult;
        private DevExpress.XtraEditors.CheckEdit ceIsDuplicate;
        private DevExpress.XtraEditors.TrackBarControl rngPopulationTrack;
        private DevExpress.XtraEditors.CheckEdit ceIsDisplayMutateResult;
        private DevExpress.XtraEditors.CheckEdit ceIsDisplayCrossResult;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabSetting;
        private DevExpress.XtraTab.XtraTabPage tabAnalysis;
        private DevExpress.XtraLayout.LayoutControlItem lciTabs;
        private DevExpress.XtraLayout.LayoutControl lcSetting;
        private DevExpress.XtraLayout.LayoutControlGroup lcgSetting;
        private DevExpress.XtraLayout.LayoutControlItem lciOutPut;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectTarget;
        private DevExpress.XtraLayout.LayoutControlItem lciGenerationSize;
        private DevExpress.XtraLayout.LayoutControlItem lciPopulationSize;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectParent;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectCross;
        private DevExpress.XtraLayout.LayoutControlItem lciDevidePointCount;
        private DevExpress.XtraLayout.LayoutControlItem lciIsDisplayCrossResult;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectMutate;
        private DevExpress.XtraLayout.LayoutControlItem lciMutationProbability;
        private DevExpress.XtraLayout.LayoutControlItem lciMutationGeneProbability;
        private DevExpress.XtraLayout.LayoutControlItem lciMutateGeneCount;
        private DevExpress.XtraLayout.LayoutControlItem lciIsDisplayMutateResult;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectSelection;
        private DevExpress.XtraLayout.LayoutControlItem lciSelectionTreshold;
        private DevExpress.XtraLayout.LayoutControlItem lciGroupSize;
        private DevExpress.XtraLayout.LayoutControlItem lciIsDisplaySelectionResult;
        private DevExpress.XtraLayout.LayoutControlItem lciIsDuplicate;
        private DevExpress.XtraLayout.EmptySpaceItem esiSetting;
        private DevExpress.XtraLayout.LayoutControlItem lciFunctionChart;
        private DevExpress.XtraLayout.LayoutControlItem lciPopulationTrack;
        private DevExpress.XtraLayout.LayoutControlItem lciFunctionStartValue;
        private DevExpress.XtraLayout.LayoutControlItem lciFunctionStep;
        private DevExpress.XtraLayout.LayoutControlItem lciCmboFunction;
        private DevExpress.XtraLayout.LayoutControlItem lciFunctionFinishValue;
        private DevExpress.XtraLayout.LayoutControlItem lciFunctionEnter;
        private DevExpress.XtraLayout.LayoutControlItem lciStart;
        private DevExpress.XtraLayout.LayoutControlItem lciCalcTimer;
        private DevExpress.XtraLayout.SplitterItem splitSettingOutput;
        private DevExpress.XtraLayout.SplitterItem splitFunctionSetting;
        private DevExpress.XtraLayout.EmptySpaceItem esiFunction;
        private DevExpress.XtraLayout.LayoutControl lcAnalysis;
        private DevExpress.XtraLayout.LayoutControlGroup lcgAnalysis;
        private DevExpress.XtraCharts.ChartControl chAnalysis;
        private DevExpress.XtraLayout.LayoutControlItem lciAnalysisChart;
        private DevExpress.XtraEditors.SpinEdit seRunAmount;
        private DevExpress.XtraEditors.MemoEdit meOutputAnalysis;
        private DevExpress.XtraLayout.LayoutControlItem lciOutputAnalysis;
        private DevExpress.XtraLayout.EmptySpaceItem esiSettingAnalysis;
        private DevExpress.XtraLayout.LayoutControlItem lciRunAmount;
        private DevExpress.XtraEditors.SimpleButton sbAnalysis;
        private DevExpress.XtraLayout.LayoutControlItem lciAnalysis;
        private DevExpress.XtraEditors.CheckedComboBoxEdit lueAnalysisSelectionMethods;
        private DevExpress.XtraLayout.LayoutControlItem lciAnalysisSelectionMethods;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}

