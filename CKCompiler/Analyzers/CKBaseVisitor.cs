// Generated from CK.g4 by ANTLR 4.0.1-SNAPSHOT
namespace CKCompiler {
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

public partial class CKBaseVisitor<Result> : AbstractParseTreeVisitor<Result>, ICKVisitor<Result> {
	public virtual Result VisitClassDef(CKParser.ClassDefContext context) { return VisitChildren(context); }

	public virtual Result VisitBlock(CKParser.BlockContext context) { return VisitChildren(context); }

	public virtual Result VisitExpr(CKParser.ExprContext context) { return VisitChildren(context); }

	public virtual Result VisitBlockStatement(CKParser.BlockStatementContext context) { return VisitChildren(context); }

	public virtual Result VisitFuncDef(CKParser.FuncDefContext context) { return VisitChildren(context); }

	public virtual Result VisitType(CKParser.TypeContext context) { return VisitChildren(context); }

	public virtual Result VisitVarDef(CKParser.VarDefContext context) { return VisitChildren(context); }

	public virtual Result VisitCreator(CKParser.CreatorContext context) { return VisitChildren(context); }

	public virtual Result VisitVarDefType(CKParser.VarDefTypeContext context) { return VisitChildren(context); }

	public virtual Result VisitStatementExpr(CKParser.StatementExprContext context) { return VisitChildren(context); }

	public virtual Result VisitFuncArgs(CKParser.FuncArgsContext context) { return VisitChildren(context); }

	public virtual Result VisitProgram(CKParser.ProgramContext context) { return VisitChildren(context); }

	public virtual Result VisitClassBodyItem(CKParser.ClassBodyItemContext context) { return VisitChildren(context); }

	public virtual Result VisitPrimary(CKParser.PrimaryContext context) { return VisitChildren(context); }

	public virtual Result VisitAction(CKParser.ActionContext context) { return VisitChildren(context); }

	public virtual Result VisitVarDefBody(CKParser.VarDefBodyContext context) { return VisitChildren(context); }

	public virtual Result VisitClassBody(CKParser.ClassBodyContext context) { return VisitChildren(context); }

	public virtual Result VisitFuncBody(CKParser.FuncBodyContext context) { return VisitChildren(context); }

	public virtual Result VisitLiteral(CKParser.LiteralContext context) { return VisitChildren(context); }

	public virtual Result VisitExprList(CKParser.ExprListContext context) { return VisitChildren(context); }
}
} // namespace CKCompiler
