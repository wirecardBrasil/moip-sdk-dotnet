using System.Collections.Generic;
using System.Text;

namespace Moip.Models
{
    public class ScopePermissionList : List<ScopePermission>
    {
        public ScopePermissionList(params ScopePermission[] scopes)
        {
            foreach (ScopePermission scope in scopes)
            {
                this.Add(scope);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            for (int i = 0, il = this.Count; i < il; i++)
            {
                if (i > 0)
                    sb.Append(",");
                sb.Append(this[i]);
            }
            return sb.ToString();
        }
    }
}