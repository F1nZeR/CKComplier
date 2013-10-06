// Generated from CK.g4 by ANTLR 4.0.1-SNAPSHOT
namespace CKCompiler {
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

public interface ICKVisitor<Result> : IParseTreeVisitor<Result> {
	Result VisitClassDef(CKParser.ClassDefContext context);

	Result VisitBlock(CKParser.BlockContext context);

	Result VisitExpr(CKParser.ExprContext context);

	Result VisitBlockStatement(CKParser.BlockStatementContext context);

	Result VisitFuncDef(CKParser.FuncDefContext context);

	Result VisitType(CKParser.TypeContext context);

	Result VisitVarDef(CKParser.VarDefContext context);

	Result VisitVarDefType(CKParser.VarDefTypeContext context);

	Result VisitStatementExpr(CKParser.StatementExprContext context);

	Result VisitFuncArgs(CKParser.FuncArgsContext context);

	Result VisitProgram(CKParser.ProgramContext context);

	Result VisitClassBodyItem(CKParser.ClassBodyItemContext context);

	Result VisitPrimary(CKParser.PrimaryContext context);

	Result VisitAction(CKParser.ActionContext context);

	Result VisitVarDefBody(CKParser.VarDefBodyContext context);

	Result VisitClassBody(CKParser.ClassBodyContext context);

	Result VisitFuncBody(CKParser.FuncBodyContext context);

	Result VisitLiteral(CKParser.LiteralContext context);

	Result VisitExprList(CKParser.ExprListContext context);
}
} // namespace CKCompiler
