using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DxfLibrary.Entities;
using DxfLibrary.Tests.Entities;
using DxfLibrary.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace DxfLibrary.Tests.Utilities
{
    /// <summary>
    /// Test class for the <see cref="DxfEntityLinker"/> class
    /// </summary>
    public class DxfLinkerTests : EntityTestBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger">Logger passed into the class from xUnit</param>
        public DxfLinkerTests(ITestOutputHelper logger) : base(logger)
        {

        }

        /// <summary>
        /// Test Data class for the Linker tests
        /// </summary>
        class LinkerTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {

                // Summary: An LwPolyline and a hatch both referenced to each other
                // Expected Behavior: All entities should link to each other
                yield return new object[]
                {
                    new List<IEntity>
                    {
                        new LwPolyline()
                        {
                            Handle = "polyline1",
                            References = new List<IEntityReference>()
                            {
                                new EntityReference("hatch1")
                            }
                        },

                        new Hatch()
                        {
                            Handle = "hatch1",
                            References = new List<IEntityReference>()
                            {
                                new EntityReference("polyline1")
                            }
                        }
                    }

                };

                // Summary: LwPolyline and hatch where only the hatch has a soft pointer
                // to the lwpolyline.
                // Expected Behavoir: Even though the lwpolyline is not pointing to the
                // hatch the hatch should link it anyways
                yield return new object[]
                {
                    new List<IEntity>
                    {
                        new LwPolyline()
                        {
                            Handle = "polyline",
                        },

                        new Hatch()
                        {
                            Handle = "hatch1",
                            References = new List<IEntityReference>()
                            {
                                new EntityReference("polyline1")
                            }
                        }
                    }
                };

            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        /// <summary>
        /// Test method for the entity linker class
        /// This method takes in an entity list, links the entities and
        /// then asserts that all entities are linked to each other
        /// </summary>
        /// <param name="entityList"></param>
        [Theory]
        [ClassData(typeof(LinkerTestData))]
        public void LinkerTest(List<IEntity> entityList)
        {
            var linker = new DxfEntityLinker();
            linker.LinkEntities(entityList);

            Assert.All(entityList, e => ((IEntity)e).References.All(r => r.IsLinked));
        }
    }
}
