// Generated from CK.g4 by ANTLR 4.0.1-SNAPSHOT
namespace CKCompiler {

using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

public partial class CKBaseListener : ICKListener {
	public virtual void EnterClassDef(CKParser.ClassDefContext context) { }
	public virtual void ExitClassDef(CKParser.ClassDefContext context) { }

	public virtual void EnterBlock(CKParser.BlockContext context) { }
	public virtual void ExitBlock(CKParser.BlockContext context) { }

	public virtual void EnterExpr(CKParser.ExprContext context) { }
	public virtual void ExitExpr(CKParser.ExprContext context) { }

	public virtual void EnterBlockStatement(CKParser.BlockStatementContext context) { }
	public virtual void ExitBlockStatement(CKParser.BlockStatementContext context) { }

	public virtual void EnterFuncDef(CKParser.FuncDefContext context) { }
	public virtual void ExitFuncDef(CKParser.FuncDefContext context) { }

	public virtual void EnterType(CKParser.TypeContext context) { }
	public virtual void ExitType(CKParser.TypeContext context) { }

	public virtual void EnterVarDef(CKParser.VarDefContext context) { }
	public virtual void ExitVarDef(CKParser.VarDefContext context) { }

	public virtual void EnterCreator(CKParser.CreatorContext context) { }
	public virtual void ExitCreator(CKParser.CreatorContext context) { }

	public virtual void EnterVarDefType(CKParser.VarDefTypeContext context) { }
	public virtual void ExitVarDefType(CKParser.VarDefTypeContext context) { }

	public virtual void EnterStatementExpr(CKParser.StatementExprContext context) { }
	public virtual void ExitStatementExpr(CKParser.StatementExprContext context) { }

	public virtual void EnterFuncArgs(CKParser.FuncArgsContext context) { }
	public virtual void ExitFuncArgs(CKParser.FuncArgsContext context) { }

	public virtual void EnterProgram(CKParser.ProgramContext context) { }
	public virtual void ExitProgram(CKParser.ProgramContext context) { }

	public virtual void EnterClassBodyItem(CKParser.ClassBodyItemContext context) { }
	public virtual void ExitClassBodyItem(CKParser.ClassBodyItemContext context) { }

	public virtual void EnterPrimary(CKParser.PrimaryContext context) { }
	public virtual void ExitPrimary(CKParser.PrimaryContext context) { }

	public virtual void EnterAction(CKParser.ActionContext context) { }
	public virtual void ExitAction(CKParser.ActionContext context) { }

	public virtual void EnterVarDefBody(CKParser.VarDefBodyContext context) { }
	public virtual void ExitVarDefBody(CKParser.VarDefBodyContext context) { }

	public virtual void EnterClassBody(CKParser.ClassBodyContext context) { }
	public virtual void ExitClassBody(CKParser.ClassBodyContext context) { }

	public virtual void EnterFuncBody(CKParser.FuncBodyContext context) { }
	public virtual void ExitFuncBody(CKParser.FuncBodyContext context) { }

	public virtual void EnterLiteral(CKParser.LiteralContext context) { }
	public virtual void ExitLiteral(CKParser.LiteralContext context) { }

	public virtual void EnterExprList(CKParser.ExprListContext context) { }
	public virtual void ExitExprList(CKParser.ExprListContext context) { }

	public virtual void EnterEveryRule(ParserRuleContext context) { }
	public virtual void ExitEveryRule(ParserRuleContext context) { }
	public virtual void VisitTerminal(ITerminalNode node) { }
	public virtual void VisitErrorNode(IErrorNode node) { }
}
} // namespace CKCompiler
