using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


namespace DOMGenerator
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Principal : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.OpenFileDialog openFile;
		private System.Windows.Forms.SaveFileDialog saveFile;
		private System.Windows.Forms.TextBox COrigen;
		private System.Windows.Forms.TextBox CDestino;
		private System.Windows.Forms.Button COrigenB;
		private System.Windows.Forms.Button CDestinoB;
		private System.Windows.Forms.CheckBox CGenerarCS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Principal()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.COrigen = new System.Windows.Forms.TextBox();
            this.CDestino = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.COrigenB = new System.Windows.Forms.Button();
            this.CDestinoB = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.CGenerarCS = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // COrigen
            // 
            this.COrigen.Location = new System.Drawing.Point(16, 48);
            this.COrigen.Name = "COrigen";
            this.COrigen.Size = new System.Drawing.Size(224, 20);
            this.COrigen.TabIndex = 0;
            this.COrigen.Text = "C:\\Documents and Settings\\Alexis Ferreyra\\Mis documentos\\Visual Studio Projects\\L" +
                "ayerD\\Zoe 1.0\\LayerD-Zoe-1.0-Beta1.xsd";
            // 
            // CDestino
            // 
            this.CDestino.Location = new System.Drawing.Point(16, 104);
            this.CDestino.Name = "CDestino";
            this.CDestino.Size = new System.Drawing.Size(224, 20);
            this.CDestino.TabIndex = 1;
            this.CDestino.Text = "C:\\Documents and Settings\\Alexis Ferreyra\\Mis documentos\\Visual Studio Projects\\L" +
                "ayerD\\DOMGenerator\\Test\\";
            // 
            // saveFile
            // 
            this.saveFile.FileName = "doc1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "XML Schema de Origen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Directorio de Destino:";
            // 
            // COrigenB
            // 
            this.COrigenB.Location = new System.Drawing.Point(248, 48);
            this.COrigenB.Name = "COrigenB";
            this.COrigenB.Size = new System.Drawing.Size(64, 23);
            this.COrigenB.TabIndex = 4;
            this.COrigenB.Text = "Origen...";
            this.COrigenB.Click += new System.EventHandler(this.COrigenB_Click);
            // 
            // CDestinoB
            // 
            this.CDestinoB.Location = new System.Drawing.Point(248, 104);
            this.CDestinoB.Name = "CDestinoB";
            this.CDestinoB.Size = new System.Drawing.Size(64, 23);
            this.CDestinoB.TabIndex = 5;
            this.CDestinoB.Text = "Destino...";
            this.CDestinoB.Click += new System.EventHandler(this.CDestinoB_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(224, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 24);
            this.button3.TabIndex = 6;
            this.button3.Text = "&Generar !!!";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CGenerarCS
            // 
            this.CGenerarCS.Checked = true;
            this.CGenerarCS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CGenerarCS.Location = new System.Drawing.Point(16, 152);
            this.CGenerarCS.Name = "CGenerarCS";
            this.CGenerarCS.Size = new System.Drawing.Size(152, 16);
            this.CGenerarCS.TabIndex = 7;
            this.CGenerarCS.Text = "Generar Código JAVA";
            // 
            // Principal
            // 
            this.AcceptButton = this.button3;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(328, 189);
            this.Controls.Add(this.CGenerarCS);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.CDestinoB);
            this.Controls.Add(this.COrigenB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CDestino);
            this.Controls.Add(this.COrigen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DOM Generator para Java 2";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Principal());
		}

		private void CDestinoB_Click(object sender, System.EventArgs e)
		{
			saveFile.Filter="Archivo Fuente de C++|*.cpp";
			saveFile.ShowDialog();
			CDestino.Text=saveFile.FileName;
		}

		private void COrigenB_Click(object sender, System.EventArgs e)
		{
			openFile.Filter="XML Schema|*.xsd";
			openFile.ShowDialog();
			COrigen.Text=openFile.FileName;	
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			string mensaje="Esta usted seguro que desea procesar\n"
							+ "el archivo:\n\n"+COrigen.Text +
							"\n\npara obtener como salida:\n\n"+CDestino.Text+"\n\n";

			if(CDestino.Text.Trim()=="" ||  COrigen.Text.Trim()=="")
			{
				MessageBox.Show("Debe ingresar los nombres de archivos","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			if( MessageBox.Show(mensaje,"Confirmación",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
			{
				CDOMGenerator cdom;
				cdom=new CDOMGenerator();
				if(cdom.InitProcess(COrigen.Text,CDestino.Text,CGenerarCS.Checked))
					MessageBox.Show("Finalizo todo bien");
			}
		}

	}
}
