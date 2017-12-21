using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine
{
    /// <summary>
    /// 刷新类型
    /// </summary>
    [Flags]
    public enum UpdateType
    {
        Update = 1 << 0,
        LateUpdate = 1 << 1,
        FixedUpdate = 1 << 2,
    }

    /// <summary>
    /// 插值类型
    /// </summary>
    [Flags]
    public enum LerpType
    {
        Lerp = 1 << 0,
        LerpUnclamped = 1 << 1,
        Slerp = 1 << 2,
        SlerpUnclamped = 1 << 3,
    }

    [Flags]
    public enum PoiTag
    {
        PlayerStart = 1 << 0,
        Pawn = 1 << 1,
        Monster = 1 << 2,
        Character = 1 << 3,
        Map = 1 << 4,
    }

    /// <summary>
    /// 轴向
    /// </summary>
    [Flags]
    public enum Axial
    {
        X = 1 << 0,
        Y = 1 << 1,
        Z = 1 << 2,
    }

    /// <summary>
    /// 控制模式
    /// </summary>
    public enum ControlMode
    {
        /// <summary>
        /// 
        /// </summary>
        Lazy = 0,
        /// <summary>
        /// 贪婪模式
        /// </summary>
        Greedy = 1,
    }

    /// <summary>
    /// 左右
    /// </summary>
    [Flags]
    public enum LeftOrRight
    {
        Left = 1 << 0,
        Right = 1 << 1,
        Center = 1 << 2,
    }

    /// <summary>
    /// 联机模式
    /// </summary>
    [Flags]
    public enum LineMode
    {
        /// <summary>
        /// 单机模式
        /// </summary>
        Single = 1 << 0,
        /// <summary>
        /// 在线
        /// </summary>
        Online = 1 << 1,
        /// <summary>
        /// 离线
        /// </summary>
        Offline = 1 << 2,
        /// <summary>
        /// 局域网
        /// </summary>
        LAN = 1 << 3,
    }


    /// <summary>
    /// 是不是唯一的
    /// </summary>
    public enum Only
    {
        Only,
        NotOnly
    }
}
