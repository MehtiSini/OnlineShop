﻿using _0_Framework.Application;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ServiceHost
{
    [HtmlTargetElement(Attributes = "User")]

    public class RoleTagHelper : TagHelper
    {
        public string User { get; set; }

        private readonly IAuthHelper _authHelper;

        public RoleTagHelper(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!_authHelper.IsAuthenticated())
            {
                output.SuppressOutput();
                return;
            }

            var CurrentRole = _authHelper.CurrentAccountRole();

            var Roles = GetRoles(User);

            if(!Roles.Contains(CurrentRole))
            {
                output.SuppressOutput();
                return;
            }

            base.Process(context, output);
        }

        public List<string> GetRoles(string Value)
        {
            List<string> Roles = new List<string>();

            string[] role = Value.Split(',');

            foreach (var item in role)
            {
                Roles.Add(item);
            }

            return Roles;
        }
    }
}
