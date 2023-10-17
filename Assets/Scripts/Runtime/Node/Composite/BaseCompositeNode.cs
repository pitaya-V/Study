using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCompositeNode : BaseNode
{
    public List<BaseNode> Children = new List<BaseNode>();
    public override void AddChild(BaseNode child)
    {
        if (child == null) return;

        if (child.ParentNode != null)
        {
            child.ParentNode.RemoveChild(child);
        }

        child.ParentNode = this;
        Children.Add(child);
    }

    public override void ClearChild(BaseNode child)
    {
        for (int i = Children.Count - 1; i >= 0; i--) 
        {
            RemoveChild(child);
        }
    }

    public override void ForeachChild(Action<BaseNode> action)
    {
        foreach (BaseNode child in Children)
        {
            action?.Invoke(child);
        }
    }

    public override void RemoveChild(BaseNode child)
    {
        if (child == null) return;

        child.ParentNode = null;
        Children.Remove(child);
    }

    protected override void OnCancel()
    {
    }

    protected override void OnChildFinished(BaseNode child, bool success)
    {
    }

    protected override void OnStart()
    {
    }
}
