namespace UnitTestProject
{
    [Trait("����", "��ʽ����")]
    public class UnitTest1
    {
        [Fact(DisplayName ="1==1")]
        public void Test1()
        {
            int a = 1;
            Assert.Equal(a, 1);
        }
    }

    [Trait("����", "����ʽ����")]
    public class UnitTest2
    {
        [Fact(DisplayName = "1!=1")]
        public void Test1()
        {
            int a = 1;
            Assert.NotEqual(a, 1);
        }
    }
}