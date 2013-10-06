// Generated from CK.g4 by ANTLR 4.0.1-SNAPSHOT
namespace CKCompiler {
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

public interface ICKListener : IParseTreeListener {
	void EnterClassDef(CKParser.ClassDefContext context);
	void ExitClassDef(CKParser.ClassDefContext context);

	void EnterBlock(CKParser.BlockContext context);
	void ExitBlock(CKParser.BlockContext context);

	void EnterExpr(CKParser.ExprContext context);
	void ExitExpr(CKParser.ExprContext context);

	void EnterBlockStatement(CKParser.BlockStatementContext context);
	void ExitBlockStatement(CKParser.BlockStatementContext context);

	void EnterFuncDef(CKParser.FuncDefContext context);
	void ExitFuncDef(CKParser.FuncDefContext context);

	void EnterType(CKParser.TypeContext context);
	void ExitType(CKParser.TypeContext context);

	void EnterVarDef(CKParser.VarDefContext context);
	void ExitVarDef(CKParser.VarDefContext context);

	void EnterVarDefType(CKParser.VarDefTypeContext context);
	void ExitVarDefType(CKParser.VarDefTypeContext context);

	void EnterStatementExpr(CKParser.StatementExprContext context);
	void ExitStatementExpr(CKParser.StatementExprContext context);

	void EnterFuncArgs(CKParser.FuncArgsContext context);
	void ExitFuncArgs(CKParser.FuncArgsContext context);

	void EnterProgram(CKParser.ProgramContext context);
	void ExitProgram(CKParser.ProgramContext context);

	void EnterClassBodyItem(CKParser.ClassBodyItemContext context);
	void ExitClassBodyItem(CKParser.ClassBodyItemContext context);

	void EnterPrimary(CKParser.PrimaryContext context);
	void ExitPrimary(CKParser.PrimaryContext context);

	void EnterAction(CKParser.ActionContext context);
	void ExitAction(CKParser.ActionContext context);

	void EnterVarDefBody(CKParser.VarDefBodyContext context);
	void ExitVarDefBody(CKParser.VarDefBodyContext context);

	void EnterClassBody(CKParser.ClassBodyContext context);
	void ExitClassBody(CKParser.ClassBodyContext context);

	void EnterFuncBody(CKParser.FuncBodyContext context);
	void ExitFuncBody(CKParser.FuncBodyContext context);

	void EnterLiteral(CKParser.LiteralContext context);
	void ExitLiteral(CKParser.LiteralContext context);

	void EnterExprList(CKParser.ExprListContext context);
	void ExitExprList(CKParser.ExprListContext context);
}
} // namespace CKCompiler
