using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace $rootnamespace$
{
    public class $safeitemname$ : VNCVBSyntaxWalkerBase
    {
        public override void VisitAssignmentStatement(AssignmentStatementSyntax node)
        {
            if (identifierNameRegEx.Match(node.ToString()).Success)
            {
                Messages.AppendLine(String.Format("{0} {1}",
                    GetNodeContext(node),
                    node.ToString()));
            }

            base.VisitAssignmentStatement(node);
        }
    }
}
