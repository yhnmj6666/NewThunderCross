using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Etier.IconHelper;

namespace FileIconDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private ImageList _smallImageList = new ImageList();
		private ImageList _largeImageList = new ImageList();
		private IconListManager _iconListManager;

		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button addButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			_smallImageList.ColorDepth = ColorDepth.Depth32Bit;
			_largeImageList.ColorDepth = ColorDepth.Depth32Bit;

			_smallImageList.ImageSize = new System.Drawing.Size( 16, 16 );
			_largeImageList.ImageSize = new System.Drawing.Size( 32, 32 );

			_iconListManager = new IconListManager( _smallImageList, _largeImageList );

			listView1.SmallImageList = _smallImageList;
			listView1.LargeImageList = _largeImageList;

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
			this.listView1 = new System.Windows.Forms.ListView();
			this.addButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(8, 8);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(272, 200);
			this.listView1.TabIndex = 1;
			// 
			// addButton
			// 
			this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.addButton.Location = new System.Drawing.Point(208, 216);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(72, 32);
			this.addButton.TabIndex = 2;
			this.addButton.Text = "Add File";
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(288, 254);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.addButton,
																		  this.listView1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void addButton_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlgOpenFile = new OpenFileDialog();
			if(dlgOpenFile.ShowDialog() == DialogResult.OK)
			{
				listView1.Items.Add( dlgOpenFile.FileName, _iconListManager.AddFileIcon( dlgOpenFile.FileName ) );
			}
		}
	}
}
