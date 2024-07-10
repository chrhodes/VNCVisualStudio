﻿using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace $rootnamespace$
{
    public class $safeitemname$ : VNCCSTypedSyntaxWalkerBase
    {
        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            long startTicks = Log.APPLICATIONSERVICES("Enter", Common.LOG_CATEGORY);

            if (_targetPatternRegEx.Match(node.Identifier.ToString()).Success)
            {
                RecordMatchAndContext(node, BlockType.MethodBlock);
            }

            base.VisitMethodDeclaration(node);

            Log.APPLICATIONSERVICES("Exit", Common.LOG_CATEGORY, startTicks);
        }
    }
}
