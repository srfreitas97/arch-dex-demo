using ArchUnitNET.xUnit;

namespace Tests
{
    public class ArchitectureTests
    {

        private static System.Reflection.Assembly domainAssembly => System.Reflection.Assembly.Load("Domain");
        private static System.Reflection.Assembly infrastructureAssembly => System.Reflection.Assembly.Load("Infrastructure");
        private static System.Reflection.Assembly applicationAssembly => System.Reflection.Assembly.Load("Application");

        private static readonly Architecture architecture =
            new ArchLoader().LoadAssemblies(
                domainAssembly, 
                applicationAssembly, 
                infrastructureAssembly
            ).Build();

        private readonly IObjectProvider<IType> infrastructureLayer =
            Types().That().ResideInAssembly(infrastructureAssembly).As("Infrastructure Layer");

        private readonly IObjectProvider<IType> domainLayer =
            Types().That().ResideInAssembly(domainAssembly).As("Domain Layer");

        private readonly IObjectProvider<IType> applicationLayer =
            Types().That().ResideInAssembly(applicationAssembly).As("Application Layer");

        private readonly IObjectProvider<Class> apiResponseClasses =
            Classes().That().ResideInNamespace("Infrastructure.Models.Responses").As("Response Classes");

        private readonly IObjectProvider<Class> applicationServicesClasses =
            Classes().That().ResideInNamespace("Application.Services").As("Service Classes");


        [Fact]
        public void TestIfApiResponseClassesAreInCorrectLayer()
        {
            IArchRule exampleClassesShouldBeInExampleLayer =
                Classes().That().Are(apiResponseClasses).Should().Be(infrastructureLayer);

            exampleClassesShouldBeInExampleLayer.Check(architecture);
        }

        [Fact]
        public void TestIfApiResponseClassesHaveCorrectNaming()
        {
            IArchRule rule = Classes().That().ResideInNamespace("Infrastructure.Models.Responses").Should().HaveNameEndingWith("Response");

            rule.Check(architecture);
        }

        [Fact]
        public void TestIfServiceClassesDependsOnRepositoryClasses()
        {
            Classes().That().Are(applicationServicesClasses).Should().NotDependOnAnyTypesThat().ResideInAssembly(infrastructureAssembly).Check(architecture);
        }
    }
}