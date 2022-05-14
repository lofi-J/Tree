using System;
using System.Collections.Generic;

//고정배열을 활용한 Tree 
public class TreeNode
{
    public object Data { get; set; }
    public TreeNode[] Links { get; private set; }

    public TreeNode(object data, int maxDegree = 3)
    {
        Data = data;
        Links = new TreeNode[maxDegree];
    }
}

//동적배열을 활용한 Tree
public class DynamicTreeNode
{
    public object Data { get; set; }
    public List<DynamicTreeNode> Links
    {
        get; private set;
    }

    public DynamicTreeNode(object data)
    {
        Data = data;
        Links = new List<DynamicTreeNode>();
    }
}