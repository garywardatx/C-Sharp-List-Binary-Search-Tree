/*********************************************************************************************************

 * Project: BST Linked List
 * 
 * File: BST Linked List Class
 * 
 * Langauge: VS C#
 * 
 *
 *
 * Description: This file contains code for the BST linked list class.
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
 * 3/3/2022                - Added a constructor for the linked list.
 * 3/3/2022                - Added IEnumerable property and method.
 * 3/3/2022                - Added AddInOrder method, InsertWord method, and IsEmpty method.
 * 3/5/2022                - Continued work on the InsertMod1 routine. 
 * 
*********************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ward_PR04_WordListBST {
    class BSTLinkedList : IEnumerable<String> {

        #region Constants

        #endregion Constants

        #region Data Members

        #endregion Data Members

        #region Properties 

        public TreeNode Top { get; set; }       // Order of appearance


        public TreeNode Bottom { get; set; }    // Pointer to the bottom of the ordered link list
                                                // This prevents us from traversing the ordered 
                                                // link list every time we add a node.
        public int Count { get; set; }          // Counts the total number of words

        public TreeNode Root { get; set; }    // Point to the top of the alphabetic link list
                                                // The items will be linked in alphabetical order.

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Creates an empty link list
        /// </summary>
        public BSTLinkedList() {
            Top = null;
            Root = null;
            Count = 0;
        }

        #endregion Constructor

        #region Events

        #endregion Events

        #region Methods

        /// <summary>
        /// This routine adds the word to the BST link list.
        /// This routine will update the pointers in the ordered link list by adding 
        /// the new node to the end.
        /// </summary>
        /// <param name="word"> Word to be added</param>
        public void AddInOrder(TreeNode addedNode) {
            // add the node to the ordered link list
            if (Top is null) {
                // special case, the list is empty
                Top = addedNode;
            } else {
                Bottom.Next = addedNode;
            }

            // always update the bottom
            Bottom = addedNode;

        }

        /// <summary>
        /// This routine attempts to add the word to the link list
        /// If the word is already in the link list, then count is increased by one.
        /// If the word is not already in the link list, then the word is added to 
        /// the link list in alphabetical order.
        /// </summary>
        /// <param name="word"></param>
        public void InsertWord(String word) {
            TreeNode current = Root;
            TreeNode previous = null;


            // make everything lower case
            word = word.ToLower();

            if (IsEmpty()) {
                // special case, empty list
                TreeNode nodeToAdd = new TreeNode(word);
                Root = nodeToAdd;
                // add to the ordered link list too
                AddInOrder(nodeToAdd);

            } else {
                // walk the two poingters down the link list until one of 
                // three cases occurs.
                // 1. We reach a node where that word is > new word (not found)
                // 2. We reach the end of the list
                // 3. We find it.
                while (current != null && current.Word.CompareTo(word) < 0) {
                    // walk the two pointers, one node each
                    previous = current;
                    current = current.AlphaNext;
                }

                if (current != null && current.Word.CompareTo(word) == 0) {
                    // we found it
                    current.Count++;

                } else {
                    // We did not find it
                    // previous is before the insertion point
                    // current is after the insertion point
                    // in other words, the new word goes between them
                    TreeNode nodeToAdd = new TreeNode(word);
                    nodeToAdd.AlphaNext = current;

                    if (previous is null) {
                        // special case, this is the new first node
                        Root = nodeToAdd;
                    } else {
                        // insert after previous
                        previous.AlphaNext = nodeToAdd;
                    }
                    // add the ordered link list too
                    AddInOrder(nodeToAdd);
                }
            }
            // increment count
            Count++;

        }

      

        

        /*
         * 
        ************************************************************************************
        * ADDITIONAL NOTES:
       

        ************************************************************************************
        *Node Class
        *
        * public String Word { get; set; }          // The word in a node.

        * public String Key {get; set}              // The value assigned to the word node.

        * public TreeNode Left { get; set; }        // Pointer to the left subtree.

        * public TreeNode Right { get; set; }       // Pointer to the right subtree.

        * public TreeNode Parent { get; set; }      // Pointer to the top node.

        * public Int Count { get; set; }            // Count in the file.  
        *
        
        *************************************************************************************
        * BST Class
        
         
        * public TreeNode Parent { get; set; }        // Pointer to the Parent Node

        * public TreeNode Bottom { get; set; }        // Pointer to the bottom of the ordered link list
                                                    // This prevents us from traversing the ordered 
                                                    // link list every time we add a node.
        
        *public int Count { get; set; }              // Counts the total number of words

        *public TreeNode Root { get; set; }          // Point to the root node of the BST
                                                    


        *************************************************************************************
         * 
         * public void InsertWordMod1(String word) {
         *  TreeNode current = new TreeNode(word;
         *  
         *  if (Root.word == null);
         *      Root = current;
         *  
         *  else {
         *      current = Root;
         *      
         *      while (true) {
         *          Parent = current;
         *          if(Convert.ToInt32(current.Key)) < Convert.ToInt32(current.Key)) {
         *              current = current.Left;
         *              if(current== null) {
         *                  Parent.Left = current;
         *                  current.Parent = current;
         *                  return current;
         *              
         *              }
         *          
         *          } else {
         *              current = current.Right;
         *              
         *              if(current = null) {
         *                  Parent.Right = current;
         *                  current.Parent = Parent;
         *                  return;
         *              
         *              }
         *          
         *          }
         *          // add the ordered link list too
                    AddInOrder(current);
         *      
         *      }
         *  
         *  }
         *  // increment count
            Count++;
         *  
         *  
         *  
         *  
            TreeNode previous = null;


            // make everything lower case
            word = word.ToLower();

            if (IsEmpty()) {
                // special case, empty list
                TreeNode nodeToAdd = new TreeNode(word);
                Root = nodeToAdd;
                // add to the ordered link list too
                AddInOrder(nodeToAdd);

            } else {
                // walk the two poingters down the link list until one of 
                // three cases occurs.
                // 1. We reach a node where that word is > new word (not found)
                // 2. We reach the end of the list
                // 3. We find it.
                while (current != null && current.Word.CompareTo(word) < 0) {
                    // walk the two pointers, one node each
                    previous = current;
                    current = current.AlphaNext;
                }

                if (current != null && current.Word.CompareTo(word) == 0) {
                    // we found it
                    current.Count++;

                } else {
                    // We did not find it
                    // previous is before the insertion point
                    // current is after the insertion point
                    // in other words, the new word goes between them
                    TreeNode nodeToAdd = new TreeNode(word);
                    nodeToAdd.AlphaNext = current;

                    if (previous is null) {
                        // special case, this is the new first node
                        Root = nodeToAdd;
                    } else {
                        // insert after previous
                        previous.AlphaNext = nodeToAdd;
                    }
                    // add the ordered link list too
                    AddInOrder(nodeToAdd);
                }
            }
            // increment count
            Count++;
         * 
         * 
         * 
         * }
         * 
         * 
        */

        /// <summary>
        /// This routine attempts to add the word from the file to the BST.
        /// If the word is already in the BST, then Count is increased by one.
        /// If the word is not already in the BST, then the word is added to 
        /// the BST.
        /// </summary>
        /// <param name="word"></param>
        public void InsertWordMod1(String word) {
            TreeNode current = Root;
            TreeNode previous = null;


            // make everything lower case
            word = word.ToLower();

            if (IsEmpty()) {
                // special case, empty list
                TreeNode nodeToAdd = new TreeNode(word);
                Root = nodeToAdd;
                // add to the ordered link list too
                AddInOrder(nodeToAdd);

            } else {
                // walk the two poingters down the link list until one of 
                // three cases occurs.
                // 1. We reach a node where that word is > new word (not found)
                // 2. We reach the end of the list
                // 3. We find it.
                while (current != null && current.Word.CompareTo(word) < 0) {
                    // walk the two pointers, one node each
                    previous = current;
                    current = current.AlphaNext;
                }

                if (current != null && current.Word.CompareTo(word) == 0) {
                    // we found it
                    current.Count++;

                } else {
                    // We did not find it
                    // previous is before the insertion point
                    // current is after the insertion point
                    // in other words, the new word goes between them
                    TreeNode nodeToAdd = new TreeNode(word);
                    nodeToAdd.AlphaNext = current;

                    if (previous is null) {
                        // special case, this is the new first node
                        Root = nodeToAdd;
                    } else {
                        // insert after previous
                        previous.AlphaNext = nodeToAdd;
                    }
                    // add the ordered link list too
                    AddInOrder(nodeToAdd);
                }
            }
            // increment count
            Count++;

        }

        /// <summary>
        /// This method returns if the link list is empty
        /// - It returns true if the link list is empty
        /// - it returns false if the queue is not empty
        /// 
        /// </summary>
        /// <returns>true - if the list is empty, false - otherwise</returns>
        public bool IsEmpty() {
            return Count == 0;
        }

        /// <summary>
        /// This routine iterates through the BST link list
        /// starting at the node passed in. It will display the data in
        /// the listbox passed in.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="theListBox"></param>
        public void Iterate(TreeNode start, ListBox theListBox) {
            TreeNode current = start;

            // clear the listBox
            theListBox.Items.Clear();

            // walk down the link list and display each node
            if (start is null) {
                theListBox.Items.Add("The starting node is null");

            } else {
                while (current != null) {
                    // displayy the current node
                    theListBox.Items.Add(current.ToString());

                    // move to the next node
                    current = current.AlphaNext;

                }
            }
        }

        /// <summary>
        /// This method allows for the traversal of the items in the queue
        /// from front to back by the calling method.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<String> GetEnumerator() {
            // start from the front of the queue
            TreeNode current = Root;

            // walk down the queue (link list)
            // send one item back at a time

            while (current != null) {
                yield return current.Word;
                current = current.AlphaNext;

            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        #endregion Methods




    }
}
