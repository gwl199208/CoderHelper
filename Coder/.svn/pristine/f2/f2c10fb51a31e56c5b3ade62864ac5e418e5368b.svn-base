using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Coder.Core.Models.Commons;
using Coder.Core.Repository;
using Coder.Data.Repository;
using Coder.Data;
namespace Test
{
    [TestClass]
    public class RepositoryTest
    {
        public RepositoryTest()
        {
        }

        Mock<IRepository<UserModel>> _IRepo;


        private TestContext testContextInstance;
        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            _IRepo = new Mock<IRepository<UserModel>>();
        }

        [TestMethod]
        public void AutofacRepositoryTest()
        {
            UserModel tester = new UserModel { uid = 1, username = "sa", password = "sa" };
            //arrage
            _IRepo.Setup(t => t.Get(1)).Returns(tester);

            //act

            //Assert
            Assert.AreEqual(tester, _IRepo.Object.Get(1));
        }
    }
}
