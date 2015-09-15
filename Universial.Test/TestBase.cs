using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Universial.Test
{
    public class TestBase<T>
    {
        protected T SystemUnderTest;
        [SetUp]
        protected void SetUp()
        {
            
        }
    }
}
