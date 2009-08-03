using BSD.C4.Tlaxcala.Sai.Dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace PruebasUnit
{
    
    
    /// <summary>
    ///This is a test class for ReglaUsuariosPruebasUnitarias and is intended
    ///to contain all ReglaUsuariosPruebasUnitarias Unit Tests
    ///</summary>
    [TestClass()]
    public class ReglaUsuariosPruebasUnitarias
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for AutenticaUsuario
        ///</summary>
        [TestMethod()]
        public void AutenticaUsuarioPruebasUnitarias()
        {
            var st=new List<string> {"089", "066"};

            string strNombreUsuario = "jbaez";
            string strContraseña = "nikita";
            List<string> expected = st;
            List<string> actual;
            actual = ReglaUsuarios.AutenticaUsuario(strNombreUsuario, strContraseña);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
