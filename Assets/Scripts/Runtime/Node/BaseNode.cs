using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 节点基类
/// </summary>
public abstract class BaseNode
{
    /// <summary>
    /// 节点状态
    /// </summary>
    public enum State
    {
        /// <summary>
        /// 空闲
        /// </summary>
        Free,
        
        /// <summary>
        /// 运行中
        /// </summary>
        Running,
        
        /// <summary>
        /// 运行成功
        /// </summary>
        Success,
        
        /// <summary>
        /// 运行失败
        /// </summary>
        Failed,
    }
    
    /// <summary>
    /// 当前节点状态
    /// </summary>
    public State CurState = State.Free;
    
    /// <summary>
    /// 父节点
    /// </summary>
    public BaseNode ParentNode;

    /// <summary>
    /// 添加子节点
    /// </summary>
    /// <param name="child">子节点</param>
    public abstract void AddChild(BaseNode child);
    
    /// <summary>
    /// 移除子节点
    /// </summary>
    /// <param name="child"></param>
    public abstract void RemoveChild(BaseNode child);
    
    /// <summary>
    /// 清除所有节点
    /// </summary>
    /// <param name="child"></param>
    public abstract void ClearChild(BaseNode child);
    
    /// <summary>
    /// 遍历子节点
    /// </summary>
    /// <param name="child"></param>
    public abstract void ForeachChild(Action<BaseNode> action);

    /// <summary>
    /// 开始运行节点
    /// </summary>
    public void Start()
    {
        if (CurState == State.Running)
        {
            return;
        }

        CurState = State.Running;

        OnStart();
    }
    
    /// <summary>
    /// 取消运行节点
    /// </summary>
    public void Cancel()
    {
        if (CurState != State.Running)
        {
            return;
        }

        CurState = State.Free;
        OnCancel();
    }
    
    /// <summary>
    /// 结束运行节点
    /// </summary>
    /// <param name="success"></param>
    protected virtual void Finish(bool success)
    {
        CurState = success ? State.Success : State.Failed;

        ParentNode?.ChildFinished(this,success);
    }
    
    /// <summary>
    /// 子节点运行结束
    /// </summary>
    /// <param name="child"></param>
    /// <param name="success"></param>
    private void ChildFinished(BaseNode child, bool success)
    {
        OnChildFinished(child, success);
    }
    
    /// <summary>
    /// 开始运行节点时调用
    /// </summary>
    protected abstract void OnStart();

    /// <summary>
    /// 取消运行节点时调用
    /// </summary>
    protected abstract void OnCancel();
    
    /// <summary>
    /// 子节点运行结束时
    /// </summary>
    /// <param name="child"></param>
    /// <param name="success"></param>
    protected abstract void OnChildFinished(BaseNode child,bool success);
    

    public override string ToString()
    {
        return GetType().Name;
    }
}
