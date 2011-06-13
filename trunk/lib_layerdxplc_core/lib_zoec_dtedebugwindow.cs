/*******************************************************************************
* Copyright (c) 2007, 2008 Alexis Ferreyra.
* All rights reserved. This program and the accompanying materials
* are made available under the terms of the Eclipse Public License v1.0
* which accompanies this distribution, and is available at
* http://www.eclipse.org/legal/epl-v10.html
*
* Contributors:
*     Alexis Ferreyra - initial API and implementation
*******************************************************************************/
/****************************************************************************
* 
*  Zoe Compiler Core
*  
*  Original Author: Alexis Ferreyra
*  Contact: alexis.ferreyra@layerd.net
*  
*  Please visit http://layerd.net to get the last version
*  of the software and information about LayerD technology.
*
****************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using LayerD.CodeDOM;
using LayerD.OutputModules;
using System.IO;
using System.Collections;
using System.Threading;

namespace LayerD.ZOECompiler
{
    partial class DTEDebugWindow : Form
    {
        ZOECompilerCore p_currentCore;
        XplDocument p_currentDTE;
        private TableLayoutPanel tableLayoutPanel1;
        XplDocument[] p_currentProgram;
        IEZOERender p_ezoeRender;
        private TabControl tabDocuments;
        private TabPage tabCurrentDTE;
        private SplitContainer splitContainer1;
        private RichTextBox textDTE;
        private TabControl tabControl1;
        private TabPage tabTypes;
        private TabPage tabErrors;
        private ListBox listTypes;
        private ListBox listErrors;
        private TabPage tabWarnings;
        private ListBox listWarnings;
        string p_tempFileName;
        string p_tempFindFileName;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonUpdate;
        private Button buttonContinue;
        private FlowLayoutPanel flowLayoutPanel2;
        private ComboBox listFind;
        private Button buttonFind;
        private Button buttonFindNext;
        private TabPage tabCurrentDTEZoe;
        private SplitContainer splitContainer2;
        private Panel panel1;
        private WebBrowser browserDTE;
        private WebBrowser browserFindResult;
        private Button buttonFindZoeInResult;
        private Button buttonFindZoe;
        private Label label1;
        private ComboBox textFindZoe;
        private Button buttonShowFullDTE;
        Thread p_coreThread;

        public Thread CoreThread
        {
            get { return p_coreThread; }
            set { p_coreThread = value; }
        }
        public IEZOERender EZOERender
        {
            get { return p_ezoeRender; }
            set 
            { 
                p_ezoeRender = value;
                UpdateDTE();
            }
        }
        
        public ZOECompilerCore CurrentCore
        {
            get { return p_currentCore; }
            set { p_currentCore = value; }
        }
        public XplDocument CurrentDTE
        {
            get { return p_currentDTE; }
            set 
            { 
                p_currentDTE = value;
                UpdateDTE();
            }
        }
        public XplDocument[] CurrentProgram
        {
            get { return p_currentProgram; }
            set { p_currentProgram = value; }
        }

        public DTEDebugWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DTEDebugWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabDocuments = new System.Windows.Forms.TabControl();
            this.tabCurrentDTE = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textDTE = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTypes = new System.Windows.Forms.TabPage();
            this.listTypes = new System.Windows.Forms.ListBox();
            this.tabErrors = new System.Windows.Forms.TabPage();
            this.listErrors = new System.Windows.Forms.ListBox();
            this.tabWarnings = new System.Windows.Forms.TabPage();
            this.listWarnings = new System.Windows.Forms.ListBox();
            this.tabCurrentDTEZoe = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.browserDTE = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonShowFullDTE = new System.Windows.Forms.Button();
            this.browserFindResult = new System.Windows.Forms.WebBrowser();
            this.buttonFindZoeInResult = new System.Windows.Forms.Button();
            this.buttonFindZoe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textFindZoe = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.listFind = new System.Windows.Forms.ComboBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonFindNext = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabDocuments.SuspendLayout();
            this.tabCurrentDTE.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTypes.SuspendLayout();
            this.tabErrors.SuspendLayout();
            this.tabWarnings.SuspendLayout();
            this.tabCurrentDTEZoe.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.27137F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.72863F));
            this.tableLayoutPanel1.Controls.Add(this.tabDocuments, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.007752F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.99225F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(765, 562);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabDocuments
            // 
            this.tabDocuments.Controls.Add(this.tabCurrentDTE);
            this.tabDocuments.Controls.Add(this.tabCurrentDTEZoe);
            this.tabDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDocuments.Location = new System.Drawing.Point(3, 34);
            this.tabDocuments.Name = "tabDocuments";
            this.tabDocuments.SelectedIndex = 0;
            this.tabDocuments.Size = new System.Drawing.Size(759, 479);
            this.tabDocuments.TabIndex = 4;
            // 
            // tabCurrentDTE
            // 
            this.tabCurrentDTE.Controls.Add(this.splitContainer1);
            this.tabCurrentDTE.Location = new System.Drawing.Point(4, 22);
            this.tabCurrentDTE.Name = "tabCurrentDTE";
            this.tabCurrentDTE.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrentDTE.Size = new System.Drawing.Size(751, 453);
            this.tabCurrentDTE.TabIndex = 0;
            this.tabCurrentDTE.Text = "DTE";
            this.tabCurrentDTE.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textDTE);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(745, 447);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 0;
            // 
            // textDTE
            // 
            this.textDTE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textDTE.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDTE.Location = new System.Drawing.Point(0, 0);
            this.textDTE.Name = "textDTE";
            this.textDTE.Size = new System.Drawing.Size(745, 222);
            this.textDTE.TabIndex = 1;
            this.textDTE.Text = "";
            this.textDTE.WordWrap = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTypes);
            this.tabControl1.Controls.Add(this.tabErrors);
            this.tabControl1.Controls.Add(this.tabWarnings);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(745, 221);
            this.tabControl1.TabIndex = 0;
            // 
            // tabTypes
            // 
            this.tabTypes.Controls.Add(this.listTypes);
            this.tabTypes.Location = new System.Drawing.Point(4, 22);
            this.tabTypes.Name = "tabTypes";
            this.tabTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabTypes.Size = new System.Drawing.Size(737, 195);
            this.tabTypes.TabIndex = 0;
            this.tabTypes.Text = "Types";
            this.tabTypes.UseVisualStyleBackColor = true;
            // 
            // listTypes
            // 
            this.listTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTypes.FormattingEnabled = true;
            this.listTypes.Location = new System.Drawing.Point(3, 3);
            this.listTypes.Name = "listTypes";
            this.listTypes.Size = new System.Drawing.Size(731, 186);
            this.listTypes.TabIndex = 0;
            // 
            // tabErrors
            // 
            this.tabErrors.Controls.Add(this.listErrors);
            this.tabErrors.Location = new System.Drawing.Point(4, 22);
            this.tabErrors.Name = "tabErrors";
            this.tabErrors.Padding = new System.Windows.Forms.Padding(3);
            this.tabErrors.Size = new System.Drawing.Size(737, 195);
            this.tabErrors.TabIndex = 1;
            this.tabErrors.Text = "Errors";
            this.tabErrors.UseVisualStyleBackColor = true;
            // 
            // listErrors
            // 
            this.listErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listErrors.FormattingEnabled = true;
            this.listErrors.Location = new System.Drawing.Point(3, 3);
            this.listErrors.Name = "listErrors";
            this.listErrors.Size = new System.Drawing.Size(731, 186);
            this.listErrors.TabIndex = 0;
            // 
            // tabWarnings
            // 
            this.tabWarnings.Controls.Add(this.listWarnings);
            this.tabWarnings.Location = new System.Drawing.Point(4, 22);
            this.tabWarnings.Name = "tabWarnings";
            this.tabWarnings.Size = new System.Drawing.Size(737, 195);
            this.tabWarnings.TabIndex = 2;
            this.tabWarnings.Text = "Warnings";
            this.tabWarnings.UseVisualStyleBackColor = true;
            // 
            // listWarnings
            // 
            this.listWarnings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listWarnings.FormattingEnabled = true;
            this.listWarnings.Location = new System.Drawing.Point(0, 0);
            this.listWarnings.Name = "listWarnings";
            this.listWarnings.Size = new System.Drawing.Size(737, 186);
            this.listWarnings.TabIndex = 0;
            // 
            // tabCurrentDTEZoe
            // 
            this.tabCurrentDTEZoe.Controls.Add(this.splitContainer2);
            this.tabCurrentDTEZoe.Location = new System.Drawing.Point(4, 22);
            this.tabCurrentDTEZoe.Name = "tabCurrentDTEZoe";
            this.tabCurrentDTEZoe.Size = new System.Drawing.Size(751, 453);
            this.tabCurrentDTEZoe.TabIndex = 1;
            this.tabCurrentDTEZoe.Text = "DTE Zoe";
            this.tabCurrentDTEZoe.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.browserDTE);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(751, 453);
            this.splitContainer2.SplitterDistance = 234;
            this.splitContainer2.TabIndex = 0;
            // 
            // browserDTE
            // 
            this.browserDTE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserDTE.Location = new System.Drawing.Point(0, 0);
            this.browserDTE.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserDTE.Name = "browserDTE";
            this.browserDTE.Size = new System.Drawing.Size(751, 234);
            this.browserDTE.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonShowFullDTE);
            this.panel1.Controls.Add(this.browserFindResult);
            this.panel1.Controls.Add(this.buttonFindZoeInResult);
            this.panel1.Controls.Add(this.buttonFindZoe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textFindZoe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 215);
            this.panel1.TabIndex = 0;
            // 
            // buttonShowFullDTE
            // 
            this.buttonShowFullDTE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowFullDTE.Location = new System.Drawing.Point(644, 7);
            this.buttonShowFullDTE.Name = "buttonShowFullDTE";
            this.buttonShowFullDTE.Size = new System.Drawing.Size(101, 21);
            this.buttonShowFullDTE.TabIndex = 4;
            this.buttonShowFullDTE.Text = "Show Full DTE";
            this.buttonShowFullDTE.UseVisualStyleBackColor = true;
            this.buttonShowFullDTE.Click += new System.EventHandler(this.buttonShowFullDTE_Click);
            // 
            // browserFindResult
            // 
            this.browserFindResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.browserFindResult.Location = new System.Drawing.Point(-1, 35);
            this.browserFindResult.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserFindResult.Name = "browserFindResult";
            this.browserFindResult.Size = new System.Drawing.Size(752, 177);
            this.browserFindResult.TabIndex = 4;
            // 
            // buttonFindZoeInResult
            // 
            this.buttonFindZoeInResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFindZoeInResult.Location = new System.Drawing.Point(557, 7);
            this.buttonFindZoeInResult.Name = "buttonFindZoeInResult";
            this.buttonFindZoeInResult.Size = new System.Drawing.Size(81, 21);
            this.buttonFindZoeInResult.TabIndex = 3;
            this.buttonFindZoeInResult.Text = "Find in Result";
            this.buttonFindZoeInResult.UseVisualStyleBackColor = true;
            this.buttonFindZoeInResult.Click += new System.EventHandler(this.buttonFindZoeInResult_Click);
            // 
            // buttonFindZoe
            // 
            this.buttonFindZoe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFindZoe.Location = new System.Drawing.Point(470, 7);
            this.buttonFindZoe.Name = "buttonFindZoe";
            this.buttonFindZoe.Size = new System.Drawing.Size(81, 21);
            this.buttonFindZoe.TabIndex = 2;
            this.buttonFindZoe.Text = "Find";
            this.buttonFindZoe.UseVisualStyleBackColor = true;
            this.buttonFindZoe.Click += new System.EventHandler(this.buttonFindZoe_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Find Node expression";
            // 
            // textFindZoe
            // 
            this.textFindZoe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textFindZoe.FormattingEnabled = true;
            this.textFindZoe.Location = new System.Drawing.Point(118, 8);
            this.textFindZoe.Name = "textFindZoe";
            this.textFindZoe.Size = new System.Drawing.Size(346, 21);
            this.textFindZoe.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonUpdate);
            this.flowLayoutPanel1.Controls.Add(this.buttonContinue);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 519);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(759, 40);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(3, 3);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(100, 26);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "&Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(109, 3);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(113, 26);
            this.buttonContinue.TabIndex = 5;
            this.buttonContinue.Text = "&Continue";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.listFind);
            this.flowLayoutPanel2.Controls.Add(this.buttonFind);
            this.flowLayoutPanel2.Controls.Add(this.buttonFindNext);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(759, 25);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // listFind
            // 
            this.listFind.FormattingEnabled = true;
            this.listFind.Location = new System.Drawing.Point(3, 3);
            this.listFind.Name = "listFind";
            this.listFind.Size = new System.Drawing.Size(535, 21);
            this.listFind.TabIndex = 0;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(544, 3);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(83, 23);
            this.buttonFind.TabIndex = 1;
            this.buttonFind.Text = "&Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonFindNext
            // 
            this.buttonFindNext.Location = new System.Drawing.Point(633, 3);
            this.buttonFindNext.Name = "buttonFindNext";
            this.buttonFindNext.Size = new System.Drawing.Size(89, 23);
            this.buttonFindNext.TabIndex = 2;
            this.buttonFindNext.Text = "Find &Next";
            this.buttonFindNext.UseVisualStyleBackColor = true;
            this.buttonFindNext.Click += new System.EventHandler(this.buttonFindNext_Click);
            // 
            // DTEDebugWindow
            // 
            this.ClientSize = new System.Drawing.Size(765, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DTEDebugWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoe Internal Debuger";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DTEDebugWindow_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabDocuments.ResumeLayout(false);
            this.tabCurrentDTE.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabTypes.ResumeLayout(false);
            this.tabErrors.ResumeLayout(false);
            this.tabWarnings.ResumeLayout(false);
            this.tabCurrentDTEZoe.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateDTE();
        }

        delegate void SetTextDelegate(string text);
        void UpdateDTE()
        {
            if (!this.Visible) return;
            if (CurrentDTE != null)
            {
                StreamReader reader = null;
                try{
                    // Save DTE - Zoe                   
                    if (p_tempFileName == null) p_tempFileName = Path.ChangeExtension(Path.GetTempFileName(),".xml");
                    XplWriter writer = new XplWriter(p_tempFileName);
                    CurrentDTE.Write(writer);
                    writer.Close();

                    // Save DPP
                    p_ezoeRender.SetEZOEInputDocument(p_currentDTE);
                    p_ezoeRender.SetOutputFileName(Path.GetFileName(Path.ChangeExtension(p_tempFileName, ".dpp")));
                    p_ezoeRender.SetOutputPath(Path.GetDirectoryName(Path.ChangeExtension(p_tempFileName, ".dpp")));
                    p_ezoeRender.StartParseDocument(true, null, "");
                    reader = new StreamReader(Path.ChangeExtension(p_tempFileName, ".dpp"));
                    string text = reader.ReadToEnd();
                    if (this.textDTE.InvokeRequired)
                    {
                        this.Invoke(  new SetTextDelegate( delegate(string text2) {
                            RealUpdate(text2);
                        }), new object[] { text });
                    }
                    else
                    {
                        RealUpdate(text);
                    }

                }
                finally
                {
                    if (reader != null) reader.Close();
                }
            }

        }

        private void RealUpdate(string text)
        {
            /// PENDIENTE : Mejorar esto!! es muy precario el manejo de hilos
            /// y la interfaz y funcionalidad del depurador

            if (p_coreThread != null && this.Visible==true)
            {
                p_coreThread.Suspend();
            }
            tabCurrentDTE.Text = "DTE - Compile Cicle " + p_currentCore.CurrentCompileCicle.ToString();
            tabCurrentDTEZoe.Text = "DTE Zoe - Compile Cicle " + p_currentCore.CurrentCompileCicle.ToString();

            textDTE.Text = text;
            string buffer = textDTE.Rtf;
            buffer = FormatText(buffer);

            textDTE.Rtf = buffer;
            browserDTE.Navigate("about:blank");

            // Update error and warning list
            if (CurrentCore != null)
            {
                try
                {
                    lock (p_currentCore)
                    {
                        this.listErrors.Items.Clear();
                        this.listWarnings.Items.Clear();
                        foreach (IError error in p_currentCore.get_ErrorCollection())
                        {
                            if (error.get_ErrorClass() == ErrorClass.Error)
                                this.listErrors.Items.Add(error.ToString());
                            else
                                this.listWarnings.Items.Add(error.ToString());
                        }
                        if (p_currentCore.LastTypesTable != null)
                        {
                            this.listTypes.Items.Clear();
                            this.listTypes.Sorted = true;
                            foreach (object typeInfo in p_currentCore.LastTypesTable.Values)
                            {
                                this.listTypes.Items.Add(typeInfo.ToString());
                            }
                        }
                        this.tabTypes.Text = "Types(" + this.listTypes.Items.Count + ")";
                        this.tabErrors.Text = "Errors(" + this.listErrors.Items.Count + ")";
                        this.tabWarnings.Text = "Warnings(" + this.listWarnings.Items.Count + ")";
                    }
                }
                finally
                {
                }
            }
        }

        string[] keywords;
        private string FormatText(string buffer)
        {
            return buffer;
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            if (p_coreThread != null && p_coreThread.ThreadState == ThreadState.Suspended) 
                p_coreThread.Resume();
        }

        private void DTEDebugWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (p_coreThread != null && p_coreThread.ThreadState==ThreadState.Suspended) 
                p_coreThread.Resume();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            int index = textDTE.Find(listFind.Text);
            if (index >= 0)
            {
                textDTE.Select(index, listFind.Text.Length);
                textDTE.ScrollToCaret();
            }
            else
            {
                MessageBox.Show("Text not found.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            int index = textDTE.Find(listFind.Text,textDTE.SelectionStart+1, RichTextBoxFinds.None);
            if (index >= 0)
            {
                textDTE.Select(index, listFind.Text.Length);
                textDTE.ScrollToCaret();
            }
            else
            {
                MessageBox.Show("Text not found.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        XplNode p_lastSearchNode;
        private void buttonFindZoe_Click(object sender, EventArgs e)
        {
            if (CurrentDTE != null)
            {
                SearchNode(CurrentDTE);
            }
        }

        private void buttonFindZoeInResult_Click(object sender, EventArgs e)
        {
            if (p_lastSearchNode != null)
            {
                SearchNode(p_lastSearchNode);
            }
        }

        private void SearchNode(XplNode searchFrom)
        {
            try
            {
                p_lastSearchNode = searchFrom.FindNode(textFindZoe.Text);
                if (p_lastSearchNode != null)
                {
                    if (p_tempFindFileName == null)
                    {
                        p_tempFindFileName = Path.ChangeExtension(Path.GetTempFileName(), ".xml");
                    }
                    XplWriter writer = new XplWriter(p_tempFindFileName);
                    p_lastSearchNode.Write(writer);
                    writer.Close();
                    browserFindResult.Navigate(p_tempFindFileName);
                }
                else
                {
                    MessageBox.Show("Node not found.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while find.", "Find Node", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonShowFullDTE_Click(object sender, EventArgs e)
        {
            if (p_tempFileName != null)
            {
                browserDTE.Navigate(p_tempFileName);
            }
        }

    }
}
