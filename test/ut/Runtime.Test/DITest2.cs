//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Loader;
//using System.Text;
//using System.Threading.Tasks;

//namespace Runtime.Test;

//[TestCaseOrderer()]
//public class DITest2
//{
//    IServiceCollection SC { get; }
//    public DITest2()
//    {
//        SC = new ServiceCollection();
//    }

//    [Fact]
//    public void ARegisteTypeWrongThrowObjTest()
//    {
//        AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.Combine(AppContext.BaseDirectory, "../../../RegisteWrong.dll"));
//        Assert.ThrowsAny<Exception>(SC.RegistePreLabelTypes);
//    }
//}