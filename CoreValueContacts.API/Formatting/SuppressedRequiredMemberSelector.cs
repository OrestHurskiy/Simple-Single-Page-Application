using System.Net.Http.Formatting;
using System.Reflection;

namespace CoreValueContacts.API.Formatting
{
    public class SuppressedRequiredMemberSelector : IRequiredMemberSelector
    {
        public bool IsRequiredMember(MemberInfo info)
        {
            return false;
        }
    }
}
