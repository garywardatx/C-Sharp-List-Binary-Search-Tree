/*********************************************************************************************************

 * Project: Tree Node
 * 
 * File: Node Class
 * 
 * Langauge: VS C#
 * 
 *
 *
 * Description: This file represents the node class of the BST.
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
 * 3/3/2022                - Added regions.
 * 3/3/2022                - Added properties.
 * 3/3/2022                - Added a constructor.
 * 3/3/2022                - Added a display method.
 * 
 * 
 * 
*********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ward_PR04_WordListBST {
    class TreeNode {


        #region Constants

        #endregion Constants

        #region Data Members

        #endregion Data Members

        #region Properties  
        
        public String Word { get; set; }            // The word in a node.

        public int Key { get; set}

        public int Count { get; set; }              // Count in the file.                    

        public TreeNode Left { get; set; }          // Pointer to the left subtree.

        public TreeNode Right { get; set; }         // Pointer to the right subtree.

        public TreeNode Next { get; set; }          // Pointer to the next word in 
                                                    // order of appearance
        public TreeNode AlphaNext { get; set; }      // Pointer to the next
                                                     // word in alphabetical 
                                                     // order



        #endregion Properties

        #region Constructor

        public TreeNode(String word) {
            Word = word.ToLower();
            Count = 1;
            Left = null;
            Right = null;
            Next = null;
            AlphaNext = null;
        
        }

        #endregion Constructor

        #region Events

        #endregion Events

        #region Methods

        /// <summary>
        /// This routine outputs a Node in a default format
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return String.Format("{0}   ({1})",
                Word, Count);
        }


        #endregion Methods




    }
}
