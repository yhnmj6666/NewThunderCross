using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FileTypeAndIcon
{
    public partial class IconForm : Form
    {
        #region MEMBERS

        /// <summary>
        /// Used for containing file types and their icons information.
        /// </summary>
        private Hashtable iconsInfo;

        private ImageSize currentSize;

        public ImageSize CurrentImageSize
        {
            get { return currentSize; }
            set { this.currentSize = value; }
        }

        public enum ImageSize
        {
            /// <summary>
            /// View image in 16x16 px.
            /// </summary>
            Small,

            /// <summary>
            /// View image in 32x32 px.
            /// </summary>
            Large
        }

        #endregion        

        #region CONSTRUCTORS

        public IconForm()
        {
            InitializeComponent();
        }

        #endregion

        #region GUI EVENTS

        private void IconForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Gets file type and icon info.
                this.iconsInfo = RegisteredFileType.GetFileTypeAndIcon();
                this.currentSize = ImageSize.Large;

                //Loads file types to ListBox.
                foreach (object objString in this.iconsInfo.Keys)
                {
                    this.lbxFileType.Items.Add(objString);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSearch.Text.Trim()))
                return;
            string searchName = String.Empty;
            if (!this.txtSearch.Text.Contains("."))
                searchName = "." + this.txtSearch.Text; //Add a dot if the search text does not have it.
            else
                searchName = this.txtSearch.Text;

            //Searches in the collections of file types and icons.
            object objName = this.iconsInfo[searchName];
            if (objName != null)
            {
                this.lbxFileType.SelectedItem = searchName;
            }
        }

        private void lbxFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.renderImage();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSearch.Text.Trim()))
            {
                this.btnSearch.Enabled = false;
            }
            else
            {
                this.btnSearch.Enabled = true;
            }
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbLarge.Checked)
            {
                this.currentSize = ImageSize.Large;
                this.renderImage();
            }
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbSmall.Checked)
            {
                this.currentSize = ImageSize.Small;
                this.renderImage();
            }
        }        

        #endregion       

        #region UTILITY METHODS

        /// <summary>
        /// Validates the input data and renders the image.
        /// </summary>
        private void renderImage()
        {
            try
            {
                if (this.lbxFileType.Items.Count <= 0 || this.lbxFileType.SelectedItem == null)
                    return;
                string fileType = this.lbxFileType.SelectedItem.ToString();

                this.showIcon(fileType);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        /// <summary>
        /// Shows the icon associates with a specific file type.
        /// </summary>
        /// <param name="fileType">The type of file (or file extension).</param>
        private void showIcon(string fileType)
        {
            try
            {
                string fileAndParam = (this.iconsInfo[fileType]).ToString();
                
                if (String.IsNullOrEmpty(fileAndParam))
                    return;
                
                Icon icon = null;

                bool isLarge = true;

                if (currentSize == ImageSize.Small)
                    isLarge = false;

                icon = RegisteredFileType.ExtractIconFromFile(fileAndParam, isLarge); //RegisteredFileType.ExtractIconFromFile(fileAndParam);
                
                //The icon cannot be zero.
                if (icon != null)
                {
                    //Draw the icon to the picture box.
                    this.pbIconView.Image = icon.ToBitmap();
                }
                else //if the icon is invalid, show an error image.
                    this.pbIconView.Image = this.pbIconView.ErrorImage;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #endregion
    }
}