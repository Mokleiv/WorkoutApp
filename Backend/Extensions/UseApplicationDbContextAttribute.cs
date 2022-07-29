using System.Reflection;
using HomeAPI.Data.ApplicationDbContext;
using HotChocolate.Types.Descriptors;

namespace HomeAPI.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<ApplicationDbContext>();
        }
    }
}
