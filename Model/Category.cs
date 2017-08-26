using System;

/// <summary>
/// 分类实体
/// </summary>
[Serializable]
public class Category 
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int ParentId { get; set; }

    public int Depth { get; set; }

    public int Status { get; set; }

    public int Priority { get; set; }

}