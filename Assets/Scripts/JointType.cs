using System;

[Flags] // 标记这个枚举可以作为位掩码使用
public enum JointType
{
    None = 0,
    Arm = 1 << 0, // 1
    Body = 1 << 1, // 2
    Head = 1 << 2 // 4
    //Option4 = 1 << 3  // 8
    // 可以继续添加更多选项
}


//public class JointType
//{
//    // 使用自定义LayerMask
//    public CustomLayerMask myLayerMask;

//    public override bool Equals(object obj)
//    {
//        return obj is JointType type &&
//               System.Collections.Generic.EqualityComparer<CustomLayerMask>.Default.Equals(myLayerMask, type.myLayerMask);
//    }

//    public void ExampleMethod()
//    {
//        // 检查是否包含特定选项
//        if ((myLayerMask & CustomLayerMask.Option1) != 0)
//        {
//            // 包含Option1
//        }

//        // 组合多个选项
//        myLayerMask = CustomLayerMask.Option1 | CustomLayerMask.Option3;
//    }
//}
