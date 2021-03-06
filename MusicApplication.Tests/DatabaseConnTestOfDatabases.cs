// <copyright file="DatabaseConnTestOfDatabases.cs">Copyright ©  2017</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicApplication;

namespace MusicApplication.Tests
{
    /// <summary>This class contains parameterized unit tests for DatabaseConn</summary>
    [PexClass(typeof(DatabaseConn))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class DatabaseConnTestOfDatabases
    {
        /// <summary>Test stub for GetSongsFromTable()</summary>
        [PexMethod]
        internal void GetSongsFromTableTestOfRetrieval([PexAssumeUnderTest]DatabaseConn target)
        {
            target.GetSongsFromTable();


            // TODO: add assertions to method DatabaseConnTestOfDatabases.GetSongsFromTableTestOfRetrieval(DatabaseConn)
        }
    }
}
