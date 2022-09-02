using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace XternalDevLib
//{
class myDataType
{
}
public class SearchByTags
{
    public int TagId { get; set; }
    /// <summary>
    /// 0 = Leaf,
    /// 1 = Group,
    /// 2 = All
    /// </summary>
    public int ItemType { get; set; }
    public bool UseQuery { get; set; }
    public string Query { get; set; }
    public string TagLabel { get; set; }
    /// <summary>
    /// 0 = Code,
    /// 1 = Name,
    /// 2 = Code + Name,
    /// 3 = Name + Code,
    /// </summary>
    public int Display { get; set; }
}
public class MultiSelectTags
{
    public int TagId { get; set; }
    /// <summary>
    /// 0 = Leaf,
    /// 1 = Group,
    /// 2 = All
    /// </summary>
    public int ItemType { get; set; }
    public bool UseQuery { get; set; }
    public string Query { get; set; }
    public string TagLabel { get; set; }
    public string IdColumnName { get; set; }
}
//}
