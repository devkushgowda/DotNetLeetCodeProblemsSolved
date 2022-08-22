using System;

namespace DotNetLeetCodeProblemsSolved
{
    /// <summary>
    /// https://leetcode.com/problems/add-two-numbers/
    /// </summary>
    public class _2AddTwoNumbers
    {
        public ListNode AddTwoNumbersStringBased(ListNode l1, ListNode l2)
        {
            string s1 = "", s2 = "";
            ListNode num1Node = l1, num2Node = l2;
            while (num1Node != null || num2Node != null)
            {
                if (num1Node != null)
                {
                    s1 = num1Node.val.ToString() + s1;
                    num1Node = num1Node.next;
                }
                if (num2Node != null)
                {
                    s2 = num2Node.val.ToString() + s2;
                    num2Node = num2Node.next;
                }
            }
            var sum = (int.Parse(s1) + int.Parse(s2)).ToString();
            var result = new ListNode(int.Parse(sum[sum.Length - 1].ToString()));
            var currentNode = result;
            for (int i = sum.Length - 2; i >= 0; i--)
            {
                currentNode.next = new ListNode(int.Parse(sum[i].ToString()));
                currentNode = currentNode.next;
            }
            return result;
        }

        public ListNode AddTwoNumbersListAddition(ListNode l1, ListNode l2)
        {
            ListNode num1Node = l1, num2Node = l2;
            ListNode result = new ListNode(), temp = null;
            int carry = 0;
            while (num1Node != null || num2Node != null)
            {

                int n1 = 0, n2 = 0;
                if (num2Node != null)
                {
                    n2 = num2Node.val;
                    num2Node = num2Node.next;
                }
                if (num1Node != null)
                {
                    n1 = num1Node.val;
                    num1Node = num1Node.next;
                }
                var sum = n1 + n2 + carry;
                if (sum > 9)
                {
                    carry = 1;
                    sum -= 10;
                }
                else
                {
                    carry = 0;
                }
                if (temp == null)
                {
                    result.val = sum;
                    temp = result;
                }
                else
                {
                    temp.next = new ListNode(sum);
                    temp = temp.next;
                }
            }
            if (carry > 0)
            {
                temp.next = new ListNode(carry);
            }
            return result;
        }
    }

    /// <summary>
    /// Definition for singly-linked list.
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
        public ListNode SetNext(int n)
        {
            next = new ListNode(n);
            return this;
        }
    }
}
/*
 2. Add Two Numbers
Medium

You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

 

Example 1:


Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.
Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]
Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]


var num1 = new ListNode(9);
var num2 = new ListNode(9);
num1.SetNext(9).next.SetNext(9).next.SetNext(9).next.SetNext(9).next.SetNext(9).next.SetNext(9);
num2.SetNext(9).next.SetNext(9).next.SetNext(9);
var res = new _2AddTwoNumbers().AddTwoNumbers1(num1,num2);

 

Constraints:

The number of nodes in each linked list is in the range [1, 100].
0 <= Node.val <= 9
It is guaranteed that the list represents a number that does not have leading zeros.
 */
