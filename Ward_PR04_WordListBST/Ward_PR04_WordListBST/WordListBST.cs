/*********************************************************************************************************

 * Project: Word List with Frequency Using Binary Search Tree
 * 
 * File: Form Class
 * 
 * Langauge: VS C#
 * 
 *
 *
 * Description: Read in a standard text file (.txt). Process the file keeping the word and the number of 
 * times the word occurs in the document. Modify the Binary Search Tree you previously created to now 
 * accept string data. Add a Count Property which keeps the count of how many times a word appears in the 
 * data file.
 *
 *
 * College: Husson University
 * 
 * Course:  IT 326
 * 
 * Author: Gary Edward Ward
 * 
 * 
 * 
 * Change Log:
 * 
 * Date                         Description of Change
 * 
 * ---------------           ----------------------------------------------------------------------------
 * 
 * 3/3/2022                - Initial writing.
 * 3/3/2022                - Set up the form with label, textbox, button, and listbox controls.
 * 3/3/2022                - Added regions.
 * 3/3/2022                - Added a node class for the tree. Filled in related elements.
 * 3/3/2022                - Added a BST linked list class. Filled in related elements.
 * 3/3/2022                - Added the BSTLinkedList variable called wordList to Data Members region.
 * 3/3/2022                - Added SelectFile method, ProcessFile method, and a ProcessWord method.
 * 3/4/2022                - Program research.
 * 3/4/2022                - Added new method to display the list.
 * 3/4/2022                - Added event code for the select file and process file buttons.
 * 3/4/2022                - Tested with files provided in the assignment template. 
 * 3/4/2022                - Considerations: 
 *                              - Further error trap files.
 *                              - COMPLETE: Edit the display code in the node class to improve output.
 *                              - Review BST class Insert method. This is not displaying the results as a 
 *                              BST. 
 * 3/4/2022                - Continued program research.
 * 
 * 
*********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ward_PR04_WordListBST {
    public partial class WordListBST : Form {


        #region Constants

        #endregion Constants

        #region Data Members

        private BSTLinkedList wordList = new BSTLinkedList();       // Variable for a new BST Linked List.

        #endregion Data Members

        #region Properties                        
        #endregion Properties

        #region Constructor
        public WordListBST() {
            InitializeComponent();
        }

        #endregion Constructor

        #region Events

        /// <summary>
        /// Call the routine that processes the file and displays 
        /// the results on the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonProcessFile_Click_1(object sender, EventArgs e) {
            // start with an empty link list each time
            wordList = new BSTLinkedList();

            // process the file
            ProcessFile(textBoxFileName.Text.Trim());

            // display the results
            // wordList.IterateByOrder(wordList.Top, listBoxWordOrder);
            DisplayList(wordList, listBoxWordList);
        }

        /// <summary>
        /// Calls the routine that selects the file and displays the
        /// results in the textBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectFile_Click_1(object sender, EventArgs e) {
            String fileName;

            // call the routine to allow user to select a file
            fileName = SelectFile();

            // process the file

            if (fileName != string.Empty) {
                textBoxFileName.Text = fileName;
            }
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// Display the contents of the BST Linked list.
        /// </summary>
        /// <param name="wordList"></param>
        /// <param name="theListBox"></param>
        private void DisplayList(BSTLinkedList wordList, ListBox theListBox) {
            // clear the list box
            theListBox.Items.Clear();

            // display the contents of the list
            wordList.Iterate(wordList.Root, listBoxWordList);

            // display the header
            theListBox.Items.Add(String.Empty);
            theListBox.Items.Add(String.Format("The total word count is: {0}", wordList.Count));

        }

        /// <summary>
        /// This routine will process a file by breaking it into words and
        /// passing those words to add them to the link list.
        /// </summary>
        /// <param name="fileName"></param>
        public void ProcessFile(String fileName) {
            String line;        // one line in the file

            // check to verify that the file exists
            if (File.Exists(fileName)) {
                // attempt to open the file
                using (FileStream stream = File.Open(fileName, FileMode.Open)) {

                    using (StreamReader reader = new StreamReader(stream)) {
                        // read a line at a time
                        while ((line = reader.ReadLine()) != null) {
                            // split the line into words
                            // place into an array
                            String[] wordArray = line.Split(' ');
                            foreach (String word in wordArray) {
                                ProcessWord(word);
                            }
                        }

                    }

                }

            } else {
                MessageBox.Show(String.Format("The file '{0}' does not exist.", fileName));

            }

        }

        /// <summary>
        /// This routine will process the word by adding it to the link list
        /// </summary>
        /// <param name="word">The word to be added</param>
        public void ProcessWord(String word) {
            //wordList.AddByOrder(word);
            wordList.InsertWord(word);


        }

        /// <summary>
        /// This routine will use the standard Windows Open File Dialog
        /// Box to allow the user to select a file, which will be returned.
        /// </summary>
        /// <returns>The full path of the file will be returned</returns>
        public String SelectFile() {
            String filePath = String.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                // configure the open file dialog
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = " txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                // get the answer from the user
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    // get the path of the selected file
                    filePath = openFileDialog.FileName;

                }

                // return the file path
                return filePath;
            }
        }






        #endregion Methods

        
    }
}
