// https://leetcode.com/problems/merge-two-sorted-lists/description/

/* 21. Merge Two Sorted Lists
Easy
Topics
Companies
You are given the heads of two sorted linked lists list1 and list2.

Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

Return the head of the merged linked list.

Example 1:


Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]
Example 2:

Input: list1 = [], list2 = []
Output: []
Example 3:

Input: list1 = [], list2 = [0]
Output: [0]
*/

//*
// *Definition for singly - linked list.
// *
using System.Collections.Generic;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}


public class Solution
{
    public ListNode MergeTwoLists(ListNode l1, ListNode l2)
    {
        // Validations
        if (l1 == null) return l2;
        if (l2 == null) return l1;

        var newHead = new ListNode(0); // Creating this dummy node ease the logic
        var runnerHead = newHead;        // This is the runner node

        while (l1 != null && l2 != null)
        {
            if (l1.val >= l2.val)
            {
                runnerHead.next = l2;
                l2 = l2.next;
            }
            else
            {
                runnerHead.next = l1;
                l1 = l1.next;
            }

            runnerHead = runnerHead.next;
        }

        // Simply add the 'leftover' from the while loop at the end 
        if (l1 != null) runnerHead.next = l1;
        if (l2 != null) runnerHead.next = l2;

        return newHead.next;
    }
}



