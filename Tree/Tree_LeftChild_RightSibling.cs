using System;
using System.Collections.Generic;

/*
왼쪽자식 - 오른쪽형제노드 표현법(Left Child Right Sibling Expression, LCRS)
모든 노드에 링크를 2개씩 두고, 첫번째 링크는 자식노드를 두번째 노드는 자신의 오른쪽 형제노드를 가리키는 표현방식
노드가 2개로 고정되어 있기 때문에 N-Link 표현법보다 링크 관리가 편함
 */

public class LCRSNode
{
    public object Data { get; set; }
    public LCRSNode LeftChild { get; set; }
    public LCRSNode RightSibling { get; set; }

    public LCRSNode(object data)
    {
        Data = data;
    }
}

public class LCRSTree
{
    public LCRSNode Root { get; private set; }

    public LCRSTree(object rootData)
    {
        this.Root = new LCRSNode(rootData);
    }

    public LCRSNode AddChild(LCRSNode parent, object data)
    {
        if (parent == null) return null;

        LCRSNode child = new LCRSNode(data);
        if(parent.LeftChild == null)
        {
            parent.LeftChild = child;            
        }
        else
        {
            var node = parent.RightSibling;
            while (node.RightSibling != null)
            {
                node = node.RightSibling;
            }
            node.RightSibling = child;
        }
        return child;
    }

    public LCRSNode AddSibling(LCRSNode node, object data)
    {
        if (node == null) return null;

        while (node.RightSibling != null)
        {
            node = node.RightSibling;
        }
        var sibling = new LCRSNode(data);
        node.RightSibling = sibling;

        return sibling;
    }

    public void PrintLevelOrder()
    {
        var q = new Queue<LCRSNode>();
        q.Enqueue(this.Root);

        while(q.Count > 0)
        {
            var node = q.Dequeue();
            while(node != null)
            {
                Console.WriteLine($"{node.Data}");

                if(node.LeftChild != null)
                {
                    q.Enqueue(node.LeftChild);
                }
                node = node.RightSibling;
            }
        }
    }

    public void PrintIndentTree()
    {
        PrintIndent(this.Root, 1);
    }

    private void PrintIndent(LCRSNode node, int indent)
    {
        if (node == null) return;

        //현재노드
        string pad = " ".PadLeft(indent);
        Console.WriteLine($"{pad}{node.Data}");

        //왼쪽 자식
        PrintIndent(node.LeftChild, indent + 1);

        //오른쪽 형제
        PrintIndent(node.RightSibling, indent);
    }
}