using System;

//[AttributeUsage()]
public class AutoLoadAttribute : Attribute
{
    public AutoLoadAttribute(FieldAutoLoadType fieldAutoLoadType = FieldAutoLoadType.ChildOnly)
    {
        FieldAutoLoadType = fieldAutoLoadType;
    }

    public FieldAutoLoadType FieldAutoLoadType { get; private set; }
}

public enum FieldAutoLoadType
{
    /// <summary>
    /// 직계 자식에서만 검색
    /// </summary>
    ChildOnly,
    /// <summary>
    /// 모든 자손들에서 검색
    /// </summary>
    Descenant
}