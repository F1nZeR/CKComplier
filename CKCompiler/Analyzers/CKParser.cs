// Generated from CK.g4 by ANTLR 4.0.1-SNAPSHOT
namespace CKCompiler {
#pragma warning disable 3021

using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using DFA = Antlr4.Runtime.Dfa.DFA;

public partial class CKParser : Parser {
	public const int
		CLASS=1, ELSE=2, FALSE=3, IF=4, RETURN=5, VAR=6, WHILE=7, NEW=8, TRUE=9, 
		VOID=10, DOT=11, NEG=12, MULT=13, DIV=14, PLUS=15, MINUS=16, LE=17, LT=18, 
		GE=19, GT=20, EQUAL=21, ASSIGN=22, SEMI=23, LPAREN=24, RPAREN=25, LCURLY=26, 
		RCURLY=27, COMMA=28, COLON=29, IntTypeName=30, FloatTypeName=31, BoolTypeName=32, 
		CharTypeName=33, StringTypeName=34, ObjectTypeName=35, STRING=36, INTEGER=37, 
		CHAR=38, FLOAT=39, ID=40, WS=41, COMMENT=42, MULTILINE_COMMENT=43, FALL_THROUGH=44;
	public static readonly string[] tokenNames = {
		"<INVALID>", "'class'", "'else'", "'false'", "'if'", "'return'", "'var'", 
		"'while'", "'new'", "'true'", "'void'", "'.'", "'~'", "'*'", "'/'", "'+'", 
		"'-'", "'<='", "'<'", "'>='", "'>'", "'=='", "'='", "';'", "'('", "')'", 
		"'{'", "'}'", "','", "':'", "'int'", "'float'", "'bool'", "'char'", "'string'", 
		"'object'", "STRING", "INTEGER", "CHAR", "FLOAT", "ID", "WS", "COMMENT", 
		"MULTILINE_COMMENT", "FALL_THROUGH"
	};
	public const int
		RULE_program = 0, RULE_classDef = 1, RULE_classBody = 2, RULE_classBodyItem = 3, 
		RULE_varDef = 4, RULE_varDefType = 5, RULE_varDefBody = 6, RULE_funcDef = 7, 
		RULE_funcArgs = 8, RULE_funcBody = 9, RULE_action = 10, RULE_statementExpr = 11, 
		RULE_block = 12, RULE_blockStatement = 13, RULE_expr = 14, RULE_primary = 15, 
		RULE_exprList = 16, RULE_literal = 17, RULE_type = 18;
	public static readonly string[] ruleNames = {
		"program", "classDef", "classBody", "classBodyItem", "varDef", "varDefType", 
		"varDefBody", "funcDef", "funcArgs", "funcBody", "action", "statementExpr", 
		"block", "blockStatement", "expr", "primary", "exprList", "literal", "type"
	};

	public override string GrammarFileName { get { return "CK.g4"; } }

	public override string[] TokenNames { get { return tokenNames; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public CKParser(ITokenStream input)
		: base(input)
	{
		_interp = new ParserATNSimulator(this,_ATN);
	}
	public partial class ProgramContext : ParserRuleContext {
		public IReadOnlyList<ClassDefContext> classDef() {
			return GetRuleContexts<ClassDefContext>();
		}
		public ClassDefContext classDef(int i) {
			return GetRuleContext<ClassDefContext>(i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_program; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterProgram(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitProgram(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProgram(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ProgramContext program() {
		ProgramContext _localctx = new ProgramContext(_ctx, State);
		EnterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 39;
			_errHandler.Sync(this);
			_la = _input.La(1);
			do {
				{
				{
				State = 38; classDef();
				}
				}
				State = 41;
				_errHandler.Sync(this);
				_la = _input.La(1);
			} while ( _la==CLASS );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ClassDefContext : ParserRuleContext {
		public ITerminalNode COLON() { return GetToken(CKParser.COLON, 0); }
		public ITerminalNode ID(int i) {
			return GetToken(CKParser.ID, i);
		}
		public ITerminalNode CLASS() { return GetToken(CKParser.CLASS, 0); }
		public IReadOnlyList<ITerminalNode> ID() { return GetTokens(CKParser.ID); }
		public ClassBodyContext classBody() {
			return GetRuleContext<ClassBodyContext>(0);
		}
		public ClassDefContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_classDef; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterClassDef(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitClassDef(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitClassDef(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ClassDefContext classDef() {
		ClassDefContext _localctx = new ClassDefContext(_ctx, State);
		EnterRule(_localctx, 2, RULE_classDef);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 43; Match(CLASS);
			State = 44; Match(ID);
			State = 47;
			_la = _input.La(1);
			if (_la==COLON) {
				{
				State = 45; Match(COLON);
				State = 46; Match(ID);
				}
			}

			State = 49; classBody();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ClassBodyContext : ParserRuleContext {
		public ITerminalNode LCURLY() { return GetToken(CKParser.LCURLY, 0); }
		public IReadOnlyList<ClassBodyItemContext> classBodyItem() {
			return GetRuleContexts<ClassBodyItemContext>();
		}
		public ClassBodyItemContext classBodyItem(int i) {
			return GetRuleContext<ClassBodyItemContext>(i);
		}
		public ITerminalNode RCURLY() { return GetToken(CKParser.RCURLY, 0); }
		public ClassBodyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_classBody; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterClassBody(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitClassBody(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitClassBody(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ClassBodyContext classBody() {
		ClassBodyContext _localctx = new ClassBodyContext(_ctx, State);
		EnterRule(_localctx, 4, RULE_classBody);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 51; Match(LCURLY);
			State = 55;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==VAR || _la==ID) {
				{
				{
				State = 52; classBodyItem();
				}
				}
				State = 57;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 58; Match(RCURLY);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ClassBodyItemContext : ParserRuleContext {
		public FuncDefContext funcDef() {
			return GetRuleContext<FuncDefContext>(0);
		}
		public VarDefContext varDef() {
			return GetRuleContext<VarDefContext>(0);
		}
		public ClassBodyItemContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_classBodyItem; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterClassBodyItem(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitClassBodyItem(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitClassBodyItem(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ClassBodyItemContext classBodyItem() {
		ClassBodyItemContext _localctx = new ClassBodyItemContext(_ctx, State);
		EnterRule(_localctx, 6, RULE_classBodyItem);
		try {
			State = 62;
			switch (_input.La(1)) {
			case ID:
				EnterOuterAlt(_localctx, 1);
				{
				State = 60; funcDef();
				}
				break;
			case VAR:
				EnterOuterAlt(_localctx, 2);
				{
				State = 61; varDef();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VarDefContext : ParserRuleContext {
		public VarDefBodyContext varDefBody(int i) {
			return GetRuleContext<VarDefBodyContext>(i);
		}
		public ITerminalNode COMMA(int i) {
			return GetToken(CKParser.COMMA, i);
		}
		public ITerminalNode VAR() { return GetToken(CKParser.VAR, 0); }
		public IReadOnlyList<ITerminalNode> COMMA() { return GetTokens(CKParser.COMMA); }
		public IReadOnlyList<VarDefBodyContext> varDefBody() {
			return GetRuleContexts<VarDefBodyContext>();
		}
		public ITerminalNode SEMI() { return GetToken(CKParser.SEMI, 0); }
		public VarDefContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_varDef; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterVarDef(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitVarDef(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVarDef(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VarDefContext varDef() {
		VarDefContext _localctx = new VarDefContext(_ctx, State);
		EnterRule(_localctx, 8, RULE_varDef);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 64; Match(VAR);
			State = 65; varDefBody();
			State = 70;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==COMMA) {
				{
				{
				State = 66; Match(COMMA);
				State = 67; varDefBody();
				}
				}
				State = 72;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 73; Match(SEMI);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VarDefTypeContext : ParserRuleContext {
		public ITerminalNode COLON() { return GetToken(CKParser.COLON, 0); }
		public ITerminalNode ID(int i) {
			return GetToken(CKParser.ID, i);
		}
		public IReadOnlyList<ITerminalNode> ID() { return GetTokens(CKParser.ID); }
		public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		public VarDefTypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_varDefType; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterVarDefType(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitVarDefType(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVarDefType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VarDefTypeContext varDefType() {
		VarDefTypeContext _localctx = new VarDefTypeContext(_ctx, State);
		EnterRule(_localctx, 10, RULE_varDefType);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 75; Match(ID);
			State = 76; Match(COLON);
			State = 79;
			switch ( Interpreter.AdaptivePredict(_input,5,_ctx) ) {
			case 1:
				{
				State = 77; type();
				}
				break;

			case 2:
				{
				State = 78; Match(ID);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class VarDefBodyContext : ParserRuleContext {
		public VarDefTypeContext varDefType() {
			return GetRuleContext<VarDefTypeContext>(0);
		}
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode ASSIGN() { return GetToken(CKParser.ASSIGN, 0); }
		public VarDefBodyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_varDefBody; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterVarDefBody(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitVarDefBody(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitVarDefBody(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public VarDefBodyContext varDefBody() {
		VarDefBodyContext _localctx = new VarDefBodyContext(_ctx, State);
		EnterRule(_localctx, 12, RULE_varDefBody);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 81; varDefType();
			State = 84;
			_la = _input.La(1);
			if (_la==ASSIGN) {
				{
				State = 82; Match(ASSIGN);
				State = 83; expr(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FuncDefContext : ParserRuleContext {
		public ITerminalNode COLON() { return GetToken(CKParser.COLON, 0); }
		public ITerminalNode RPAREN() { return GetToken(CKParser.RPAREN, 0); }
		public ITerminalNode ID(int i) {
			return GetToken(CKParser.ID, i);
		}
		public FuncArgsContext funcArgs() {
			return GetRuleContext<FuncArgsContext>(0);
		}
		public IReadOnlyList<ITerminalNode> ID() { return GetTokens(CKParser.ID); }
		public FuncBodyContext funcBody() {
			return GetRuleContext<FuncBodyContext>(0);
		}
		public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		public ITerminalNode LPAREN() { return GetToken(CKParser.LPAREN, 0); }
		public FuncDefContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_funcDef; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterFuncDef(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitFuncDef(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFuncDef(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FuncDefContext funcDef() {
		FuncDefContext _localctx = new FuncDefContext(_ctx, State);
		EnterRule(_localctx, 14, RULE_funcDef);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 86; Match(ID);
			State = 87; Match(LPAREN);
			State = 89;
			_la = _input.La(1);
			if (_la==ID) {
				{
				State = 88; funcArgs();
				}
			}

			State = 91; Match(RPAREN);
			State = 92; Match(COLON);
			State = 95;
			switch ( Interpreter.AdaptivePredict(_input,8,_ctx) ) {
			case 1:
				{
				State = 93; type();
				}
				break;

			case 2:
				{
				State = 94; Match(ID);
				}
				break;
			}
			State = 97; funcBody();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FuncArgsContext : ParserRuleContext {
		public IReadOnlyList<VarDefTypeContext> varDefType() {
			return GetRuleContexts<VarDefTypeContext>();
		}
		public ITerminalNode COMMA(int i) {
			return GetToken(CKParser.COMMA, i);
		}
		public VarDefTypeContext varDefType(int i) {
			return GetRuleContext<VarDefTypeContext>(i);
		}
		public IReadOnlyList<ITerminalNode> COMMA() { return GetTokens(CKParser.COMMA); }
		public FuncArgsContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_funcArgs; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterFuncArgs(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitFuncArgs(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFuncArgs(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FuncArgsContext funcArgs() {
		FuncArgsContext _localctx = new FuncArgsContext(_ctx, State);
		EnterRule(_localctx, 16, RULE_funcArgs);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 99; varDefType();
			State = 104;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==COMMA) {
				{
				{
				State = 100; Match(COMMA);
				State = 101; varDefType();
				}
				}
				State = 106;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class FuncBodyContext : ParserRuleContext {
		public BlockContext block() {
			return GetRuleContext<BlockContext>(0);
		}
		public FuncBodyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_funcBody; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterFuncBody(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitFuncBody(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFuncBody(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public FuncBodyContext funcBody() {
		FuncBodyContext _localctx = new FuncBodyContext(_ctx, State);
		EnterRule(_localctx, 18, RULE_funcBody);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 107; block();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ActionContext : ParserRuleContext {
		public ActionContext action(int i) {
			return GetRuleContext<ActionContext>(i);
		}
		public StatementExprContext statementExpr() {
			return GetRuleContext<StatementExprContext>(0);
		}
		public ITerminalNode WHILE() { return GetToken(CKParser.WHILE, 0); }
		public IReadOnlyList<ActionContext> action() {
			return GetRuleContexts<ActionContext>();
		}
		public BlockContext block() {
			return GetRuleContext<BlockContext>(0);
		}
		public ITerminalNode SEMI() { return GetToken(CKParser.SEMI, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode ELSE() { return GetToken(CKParser.ELSE, 0); }
		public ITerminalNode IF() { return GetToken(CKParser.IF, 0); }
		public ITerminalNode RETURN() { return GetToken(CKParser.RETURN, 0); }
		public ActionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_action; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterAction(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitAction(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAction(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ActionContext action() {
		ActionContext _localctx = new ActionContext(_ctx, State);
		EnterRule(_localctx, 20, RULE_action);
		int _la;
		try {
			State = 128;
			switch (_input.La(1)) {
			case LCURLY:
				EnterOuterAlt(_localctx, 1);
				{
				State = 109; block();
				}
				break;
			case WHILE:
				EnterOuterAlt(_localctx, 2);
				{
				State = 110; Match(WHILE);
				State = 111; expr(0);
				State = 112; action();
				}
				break;
			case IF:
				EnterOuterAlt(_localctx, 3);
				{
				State = 114; Match(IF);
				State = 115; expr(0);
				State = 116; action();
				State = 117; Match(ELSE);
				State = 118; action();
				}
				break;
			case RETURN:
				EnterOuterAlt(_localctx, 4);
				{
				State = 120; Match(RETURN);
				State = 122;
				_la = _input.La(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << FALSE) | (1L << NEW) | (1L << TRUE) | (1L << LPAREN) | (1L << STRING) | (1L << INTEGER) | (1L << CHAR) | (1L << FLOAT) | (1L << ID))) != 0)) {
					{
					State = 121; expr(0);
					}
				}

				State = 124; Match(SEMI);
				}
				break;
			case FALSE:
			case NEW:
			case TRUE:
			case LPAREN:
			case STRING:
			case INTEGER:
			case CHAR:
			case FLOAT:
			case ID:
				EnterOuterAlt(_localctx, 5);
				{
				State = 125; statementExpr();
				State = 126; Match(SEMI);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StatementExprContext : ParserRuleContext {
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public StatementExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_statementExpr; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterStatementExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitStatementExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStatementExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StatementExprContext statementExpr() {
		StatementExprContext _localctx = new StatementExprContext(_ctx, State);
		EnterRule(_localctx, 22, RULE_statementExpr);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 130; expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BlockContext : ParserRuleContext {
		public BlockStatementContext blockStatement(int i) {
			return GetRuleContext<BlockStatementContext>(i);
		}
		public ITerminalNode LCURLY() { return GetToken(CKParser.LCURLY, 0); }
		public IReadOnlyList<BlockStatementContext> blockStatement() {
			return GetRuleContexts<BlockStatementContext>();
		}
		public ITerminalNode RCURLY() { return GetToken(CKParser.RCURLY, 0); }
		public BlockContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_block; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterBlock(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitBlock(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBlock(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public BlockContext block() {
		BlockContext _localctx = new BlockContext(_ctx, State);
		EnterRule(_localctx, 24, RULE_block);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 132; Match(LCURLY);
			State = 136;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << FALSE) | (1L << IF) | (1L << RETURN) | (1L << VAR) | (1L << WHILE) | (1L << NEW) | (1L << TRUE) | (1L << LPAREN) | (1L << LCURLY) | (1L << STRING) | (1L << INTEGER) | (1L << CHAR) | (1L << FLOAT) | (1L << ID))) != 0)) {
				{
				{
				State = 133; blockStatement();
				}
				}
				State = 138;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			State = 139; Match(RCURLY);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BlockStatementContext : ParserRuleContext {
		public ActionContext action() {
			return GetRuleContext<ActionContext>(0);
		}
		public VarDefContext varDef() {
			return GetRuleContext<VarDefContext>(0);
		}
		public BlockStatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_blockStatement; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterBlockStatement(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitBlockStatement(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBlockStatement(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public BlockStatementContext blockStatement() {
		BlockStatementContext _localctx = new BlockStatementContext(_ctx, State);
		EnterRule(_localctx, 26, RULE_blockStatement);
		try {
			State = 143;
			switch (_input.La(1)) {
			case FALSE:
			case IF:
			case RETURN:
			case WHILE:
			case NEW:
			case TRUE:
			case LPAREN:
			case LCURLY:
			case STRING:
			case INTEGER:
			case CHAR:
			case FLOAT:
			case ID:
				EnterOuterAlt(_localctx, 1);
				{
				State = 141; action();
				}
				break;
			case VAR:
				EnterOuterAlt(_localctx, 2);
				{
				State = 142; varDef();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprContext : ParserRuleContext {
		public ITerminalNode RPAREN() { return GetToken(CKParser.RPAREN, 0); }
		public ITerminalNode LT() { return GetToken(CKParser.LT, 0); }
		public IReadOnlyList<ExprContext> expr() {
			return GetRuleContexts<ExprContext>();
		}
		public ITerminalNode ASSIGN() { return GetToken(CKParser.ASSIGN, 0); }
		public ITerminalNode NEW() { return GetToken(CKParser.NEW, 0); }
		public ITerminalNode GT() { return GetToken(CKParser.GT, 0); }
		public ITerminalNode PLUS() { return GetToken(CKParser.PLUS, 0); }
		public PrimaryContext primary() {
			return GetRuleContext<PrimaryContext>(0);
		}
		public ITerminalNode MULT() { return GetToken(CKParser.MULT, 0); }
		public ITerminalNode DIV() { return GetToken(CKParser.DIV, 0); }
		public ITerminalNode MINUS() { return GetToken(CKParser.MINUS, 0); }
		public ITerminalNode DOT() { return GetToken(CKParser.DOT, 0); }
		public ITerminalNode ID() { return GetToken(CKParser.ID, 0); }
		public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public ITerminalNode LPAREN() { return GetToken(CKParser.LPAREN, 0); }
		public ExprListContext exprList() {
			return GetRuleContext<ExprListContext>(0);
		}
		public ExprContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_expr; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterExpr(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitExpr(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpr(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprContext expr(int _p) {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = State;
		ExprContext _localctx = new ExprContext(_ctx, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 28;
		EnterRecursionRule(_localctx, RULE_expr, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 149;
			switch (_input.La(1)) {
			case FALSE:
			case TRUE:
			case LPAREN:
			case STRING:
			case INTEGER:
			case CHAR:
			case FLOAT:
			case ID:
				{
				State = 146; primary();
				}
				break;
			case NEW:
				{
				State = 147; Match(NEW);
				State = 148; Match(ID);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.Lt(-1);
			State = 174;
			_errHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(_input,17,_ctx);
			while ( _alt!=2 && _alt!=-1 ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 172;
					switch ( Interpreter.AdaptivePredict(_input,16,_ctx) ) {
					case 1:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 151;
						if (!(Precpred(_ctx, 4))) throw new FailedPredicateException(this, "Precpred(_ctx, 4)");
						State = 152;
						_la = _input.La(1);
						if ( !(_la==MULT || _la==DIV) ) {
						_errHandler.RecoverInline(this);
						}
						Consume();
						State = 153; expr(5);
						}
						break;

					case 2:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 154;
						if (!(Precpred(_ctx, 3))) throw new FailedPredicateException(this, "Precpred(_ctx, 3)");
						State = 155;
						_la = _input.La(1);
						if ( !(_la==PLUS || _la==MINUS) ) {
						_errHandler.RecoverInline(this);
						}
						Consume();
						State = 156; expr(4);
						}
						break;

					case 3:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 157;
						if (!(Precpred(_ctx, 2))) throw new FailedPredicateException(this, "Precpred(_ctx, 2)");
						State = 158;
						_la = _input.La(1);
						if ( !(_la==LT || _la==GT) ) {
						_errHandler.RecoverInline(this);
						}
						Consume();
						State = 159; expr(3);
						}
						break;

					case 4:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 160;
						if (!(Precpred(_ctx, 1))) throw new FailedPredicateException(this, "Precpred(_ctx, 1)");
						{
						State = 161; Match(ASSIGN);
						}
						State = 162; expr(1);
						}
						break;

					case 5:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 163;
						if (!(Precpred(_ctx, 7))) throw new FailedPredicateException(this, "Precpred(_ctx, 7)");
						State = 164; Match(DOT);
						State = 165; Match(ID);
						}
						break;

					case 6:
						{
						_localctx = new ExprContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_expr);
						State = 166;
						if (!(Precpred(_ctx, 6))) throw new FailedPredicateException(this, "Precpred(_ctx, 6)");
						State = 167; Match(LPAREN);
						State = 169;
						_la = _input.La(1);
						if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << FALSE) | (1L << NEW) | (1L << TRUE) | (1L << LPAREN) | (1L << STRING) | (1L << INTEGER) | (1L << CHAR) | (1L << FLOAT) | (1L << ID))) != 0)) {
							{
							State = 168; exprList();
							}
						}

						State = 171; Match(RPAREN);
						}
						break;
					}
					} 
				}
				State = 176;
				_errHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(_input,17,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class PrimaryContext : ParserRuleContext {
		public ITerminalNode RPAREN() { return GetToken(CKParser.RPAREN, 0); }
		public ITerminalNode ID() { return GetToken(CKParser.ID, 0); }
		public ExprContext expr() {
			return GetRuleContext<ExprContext>(0);
		}
		public ITerminalNode LPAREN() { return GetToken(CKParser.LPAREN, 0); }
		public LiteralContext literal() {
			return GetRuleContext<LiteralContext>(0);
		}
		public PrimaryContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_primary; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterPrimary(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitPrimary(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrimary(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PrimaryContext primary() {
		PrimaryContext _localctx = new PrimaryContext(_ctx, State);
		EnterRule(_localctx, 30, RULE_primary);
		try {
			State = 183;
			switch (_input.La(1)) {
			case LPAREN:
				EnterOuterAlt(_localctx, 1);
				{
				State = 177; Match(LPAREN);
				State = 178; expr(0);
				State = 179; Match(RPAREN);
				}
				break;
			case FALSE:
			case TRUE:
			case STRING:
			case INTEGER:
			case CHAR:
			case FLOAT:
				EnterOuterAlt(_localctx, 2);
				{
				State = 181; literal();
				}
				break;
			case ID:
				EnterOuterAlt(_localctx, 3);
				{
				State = 182; Match(ID);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExprListContext : ParserRuleContext {
		public ITerminalNode COMMA(int i) {
			return GetToken(CKParser.COMMA, i);
		}
		public ExprContext expr(int i) {
			return GetRuleContext<ExprContext>(i);
		}
		public IReadOnlyList<ITerminalNode> COMMA() { return GetTokens(CKParser.COMMA); }
		public IReadOnlyList<ExprContext> expr() {
			return GetRuleContexts<ExprContext>();
		}
		public ExprListContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_exprList; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterExprList(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitExprList(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExprList(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExprListContext exprList() {
		ExprListContext _localctx = new ExprListContext(_ctx, State);
		EnterRule(_localctx, 32, RULE_exprList);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 185; expr(0);
			State = 190;
			_errHandler.Sync(this);
			_la = _input.La(1);
			while (_la==COMMA) {
				{
				{
				State = 186; Match(COMMA);
				State = 187; expr(0);
				}
				}
				State = 192;
				_errHandler.Sync(this);
				_la = _input.La(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LiteralContext : ParserRuleContext {
		public ITerminalNode CHAR() { return GetToken(CKParser.CHAR, 0); }
		public ITerminalNode INTEGER() { return GetToken(CKParser.INTEGER, 0); }
		public ITerminalNode FLOAT() { return GetToken(CKParser.FLOAT, 0); }
		public ITerminalNode FALSE() { return GetToken(CKParser.FALSE, 0); }
		public ITerminalNode TRUE() { return GetToken(CKParser.TRUE, 0); }
		public ITerminalNode STRING() { return GetToken(CKParser.STRING, 0); }
		public LiteralContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_literal; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterLiteral(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitLiteral(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLiteral(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public LiteralContext literal() {
		LiteralContext _localctx = new LiteralContext(_ctx, State);
		EnterRule(_localctx, 34, RULE_literal);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 193;
			_la = _input.La(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << FALSE) | (1L << TRUE) | (1L << STRING) | (1L << INTEGER) | (1L << CHAR) | (1L << FLOAT))) != 0)) ) {
			_errHandler.RecoverInline(this);
			}
			Consume();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TypeContext : ParserRuleContext {
		public ITerminalNode IntTypeName() { return GetToken(CKParser.IntTypeName, 0); }
		public ITerminalNode StringTypeName() { return GetToken(CKParser.StringTypeName, 0); }
		public ITerminalNode BoolTypeName() { return GetToken(CKParser.BoolTypeName, 0); }
		public ITerminalNode ID() { return GetToken(CKParser.ID, 0); }
		public ITerminalNode FloatTypeName() { return GetToken(CKParser.FloatTypeName, 0); }
		public ITerminalNode CharTypeName() { return GetToken(CKParser.CharTypeName, 0); }
		public ITerminalNode ObjectTypeName() { return GetToken(CKParser.ObjectTypeName, 0); }
		public TypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int GetRuleIndex() { return RULE_type; }
		public override void EnterRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.EnterType(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ICKListener typedListener = listener as ICKListener;
			if (typedListener != null) typedListener.ExitType(this);
		}
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			ICKVisitor<TResult> typedVisitor = visitor as ICKVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TypeContext type() {
		TypeContext _localctx = new TypeContext(_ctx, State);
		EnterRule(_localctx, 36, RULE_type);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 195;
			_la = _input.La(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << IntTypeName) | (1L << FloatTypeName) | (1L << BoolTypeName) | (1L << CharTypeName) | (1L << StringTypeName) | (1L << ObjectTypeName) | (1L << ID))) != 0)) ) {
			_errHandler.RecoverInline(this);
			}
			Consume();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.ReportError(this, re);
			_errHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 14: return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(_ctx, 4);

		case 1: return Precpred(_ctx, 3);

		case 2: return Precpred(_ctx, 2);

		case 3: return Precpred(_ctx, 1);

		case 4: return Precpred(_ctx, 7);

		case 5: return Precpred(_ctx, 6);
		}
		return true;
	}

	public static readonly string _serializedATN =
		"\x5\x3.\xC8\x4\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4"+
		"\a\t\a\x4\b\t\b\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE"+
		"\x4\xF\t\xF\x4\x10\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14"+
		"\t\x14\x3\x2\x6\x2*\n\x2\r\x2\xE\x2+\x3\x3\x3\x3\x3\x3\x3\x3\x5\x3\x32"+
		"\n\x3\x3\x3\x3\x3\x3\x4\x3\x4\a\x4\x38\n\x4\f\x4\xE\x4;\v\x4\x3\x4\x3"+
		"\x4\x3\x5\x3\x5\x5\x5\x41\n\x5\x3\x6\x3\x6\x3\x6\x3\x6\a\x6G\n\x6\f\x6"+
		"\xE\x6J\v\x6\x3\x6\x3\x6\x3\a\x3\a\x3\a\x3\a\x5\aR\n\a\x3\b\x3\b\x3\b"+
		"\x5\bW\n\b\x3\t\x3\t\x3\t\x5\t\\\n\t\x3\t\x3\t\x3\t\x3\t\x5\t\x62\n\t"+
		"\x3\t\x3\t\x3\n\x3\n\x3\n\a\ni\n\n\f\n\xE\nl\v\n\x3\v\x3\v\x3\f\x3\f\x3"+
		"\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x5\f}\n\f\x3\f\x3"+
		"\f\x3\f\x3\f\x5\f\x83\n\f\x3\r\x3\r\x3\xE\x3\xE\a\xE\x89\n\xE\f\xE\xE"+
		"\xE\x8C\v\xE\x3\xE\x3\xE\x3\xF\x3\xF\x5\xF\x92\n\xF\x3\x10\x3\x10\x3\x10"+
		"\x3\x10\x5\x10\x98\n\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3"+
		"\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3\x10\x3"+
		"\x10\x3\x10\x5\x10\xAC\n\x10\x3\x10\a\x10\xAF\n\x10\f\x10\xE\x10\xB2\v"+
		"\x10\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x3\x11\x5\x11\xBA\n\x11\x3\x12"+
		"\x3\x12\x3\x12\a\x12\xBF\n\x12\f\x12\xE\x12\xC2\v\x12\x3\x13\x3\x13\x3"+
		"\x14\x3\x14\x3\x14\x2\x2\x3\x1E\x15\x2\x2\x4\x2\x6\x2\b\x2\n\x2\f\x2\xE"+
		"\x2\x10\x2\x12\x2\x14\x2\x16\x2\x18\x2\x1A\x2\x1C\x2\x1E\x2 \x2\"\x2$"+
		"\x2&\x2\x2\a\x3\xF\x10\x3\x11\x12\x4\x14\x14\x16\x16\x5\x5\x5\v\v&)\x4"+
		" %**\xD0\x2)\x3\x2\x2\x2\x4-\x3\x2\x2\x2\x6\x35\x3\x2\x2\x2\b@\x3\x2\x2"+
		"\x2\n\x42\x3\x2\x2\x2\fM\x3\x2\x2\x2\xES\x3\x2\x2\x2\x10X\x3\x2\x2\x2"+
		"\x12\x65\x3\x2\x2\x2\x14m\x3\x2\x2\x2\x16\x82\x3\x2\x2\x2\x18\x84\x3\x2"+
		"\x2\x2\x1A\x86\x3\x2\x2\x2\x1C\x91\x3\x2\x2\x2\x1E\x97\x3\x2\x2\x2 \xB9"+
		"\x3\x2\x2\x2\"\xBB\x3\x2\x2\x2$\xC3\x3\x2\x2\x2&\xC5\x3\x2\x2\x2(*\x5"+
		"\x4\x3\x2)(\x3\x2\x2\x2*+\x3\x2\x2\x2+)\x3\x2\x2\x2+,\x3\x2\x2\x2,\x3"+
		"\x3\x2\x2\x2-.\a\x3\x2\x2.\x31\a*\x2\x2/\x30\a\x1F\x2\x2\x30\x32\a*\x2"+
		"\x2\x31/\x3\x2\x2\x2\x31\x32\x3\x2\x2\x2\x32\x33\x3\x2\x2\x2\x33\x34\x5"+
		"\x6\x4\x2\x34\x5\x3\x2\x2\x2\x35\x39\a\x1C\x2\x2\x36\x38\x5\b\x5\x2\x37"+
		"\x36\x3\x2\x2\x2\x38;\x3\x2\x2\x2\x39\x37\x3\x2\x2\x2\x39:\x3\x2\x2\x2"+
		":<\x3\x2\x2\x2;\x39\x3\x2\x2\x2<=\a\x1D\x2\x2=\a\x3\x2\x2\x2>\x41\x5\x10"+
		"\t\x2?\x41\x5\n\x6\x2@>\x3\x2\x2\x2@?\x3\x2\x2\x2\x41\t\x3\x2\x2\x2\x42"+
		"\x43\a\b\x2\x2\x43H\x5\xE\b\x2\x44\x45\a\x1E\x2\x2\x45G\x5\xE\b\x2\x46"+
		"\x44\x3\x2\x2\x2GJ\x3\x2\x2\x2H\x46\x3\x2\x2\x2HI\x3\x2\x2\x2IK\x3\x2"+
		"\x2\x2JH\x3\x2\x2\x2KL\a\x19\x2\x2L\v\x3\x2\x2\x2MN\a*\x2\x2NQ\a\x1F\x2"+
		"\x2OR\x5&\x14\x2PR\a*\x2\x2QO\x3\x2\x2\x2QP\x3\x2\x2\x2R\r\x3\x2\x2\x2"+
		"SV\x5\f\a\x2TU\a\x18\x2\x2UW\x5\x1E\x10\x2VT\x3\x2\x2\x2VW\x3\x2\x2\x2"+
		"W\xF\x3\x2\x2\x2XY\a*\x2\x2Y[\a\x1A\x2\x2Z\\\x5\x12\n\x2[Z\x3\x2\x2\x2"+
		"[\\\x3\x2\x2\x2\\]\x3\x2\x2\x2]^\a\x1B\x2\x2^\x61\a\x1F\x2\x2_\x62\x5"+
		"&\x14\x2`\x62\a*\x2\x2\x61_\x3\x2\x2\x2\x61`\x3\x2\x2\x2\x62\x63\x3\x2"+
		"\x2\x2\x63\x64\x5\x14\v\x2\x64\x11\x3\x2\x2\x2\x65j\x5\f\a\x2\x66g\a\x1E"+
		"\x2\x2gi\x5\f\a\x2h\x66\x3\x2\x2\x2il\x3\x2\x2\x2jh\x3\x2\x2\x2jk\x3\x2"+
		"\x2\x2k\x13\x3\x2\x2\x2lj\x3\x2\x2\x2mn\x5\x1A\xE\x2n\x15\x3\x2\x2\x2"+
		"o\x83\x5\x1A\xE\x2pq\a\t\x2\x2qr\x5\x1E\x10\x2rs\x5\x16\f\x2s\x83\x3\x2"+
		"\x2\x2tu\a\x6\x2\x2uv\x5\x1E\x10\x2vw\x5\x16\f\x2wx\a\x4\x2\x2xy\x5\x16"+
		"\f\x2y\x83\x3\x2\x2\x2z|\a\a\x2\x2{}\x5\x1E\x10\x2|{\x3\x2\x2\x2|}\x3"+
		"\x2\x2\x2}~\x3\x2\x2\x2~\x83\a\x19\x2\x2\x7F\x80\x5\x18\r\x2\x80\x81\a"+
		"\x19\x2\x2\x81\x83\x3\x2\x2\x2\x82o\x3\x2\x2\x2\x82p\x3\x2\x2\x2\x82t"+
		"\x3\x2\x2\x2\x82z\x3\x2\x2\x2\x82\x7F\x3\x2\x2\x2\x83\x17\x3\x2\x2\x2"+
		"\x84\x85\x5\x1E\x10\x2\x85\x19\x3\x2\x2\x2\x86\x8A\a\x1C\x2\x2\x87\x89"+
		"\x5\x1C\xF\x2\x88\x87\x3\x2\x2\x2\x89\x8C\x3\x2\x2\x2\x8A\x88\x3\x2\x2"+
		"\x2\x8A\x8B\x3\x2\x2\x2\x8B\x8D\x3\x2\x2\x2\x8C\x8A\x3\x2\x2\x2\x8D\x8E"+
		"\a\x1D\x2\x2\x8E\x1B\x3\x2\x2\x2\x8F\x92\x5\x16\f\x2\x90\x92\x5\n\x6\x2"+
		"\x91\x8F\x3\x2\x2\x2\x91\x90\x3\x2\x2\x2\x92\x1D\x3\x2\x2\x2\x93\x94\b"+
		"\x10\x1\x2\x94\x98\x5 \x11\x2\x95\x96\a\n\x2\x2\x96\x98\a*\x2\x2\x97\x93"+
		"\x3\x2\x2\x2\x97\x95\x3\x2\x2\x2\x98\xB0\x3\x2\x2\x2\x99\x9A\f\x6\x2\x2"+
		"\x9A\x9B\t\x2\x2\x2\x9B\xAF\x5\x1E\x10\a\x9C\x9D\f\x5\x2\x2\x9D\x9E\t"+
		"\x3\x2\x2\x9E\xAF\x5\x1E\x10\x6\x9F\xA0\f\x4\x2\x2\xA0\xA1\t\x4\x2\x2"+
		"\xA1\xAF\x5\x1E\x10\x5\xA2\xA3\f\x3\x2\x2\xA3\xA4\a\x18\x2\x2\xA4\xAF"+
		"\x5\x1E\x10\x3\xA5\xA6\f\t\x2\x2\xA6\xA7\a\r\x2\x2\xA7\xAF\a*\x2\x2\xA8"+
		"\xA9\f\b\x2\x2\xA9\xAB\a\x1A\x2\x2\xAA\xAC\x5\"\x12\x2\xAB\xAA\x3\x2\x2"+
		"\x2\xAB\xAC\x3\x2\x2\x2\xAC\xAD\x3\x2\x2\x2\xAD\xAF\a\x1B\x2\x2\xAE\x99"+
		"\x3\x2\x2\x2\xAE\x9C\x3\x2\x2\x2\xAE\x9F\x3\x2\x2\x2\xAE\xA2\x3\x2\x2"+
		"\x2\xAE\xA5\x3\x2\x2\x2\xAE\xA8\x3\x2\x2\x2\xAF\xB2\x3\x2\x2\x2\xB0\xAE"+
		"\x3\x2\x2\x2\xB0\xB1\x3\x2\x2\x2\xB1\x1F\x3\x2\x2\x2\xB2\xB0\x3\x2\x2"+
		"\x2\xB3\xB4\a\x1A\x2\x2\xB4\xB5\x5\x1E\x10\x2\xB5\xB6\a\x1B\x2\x2\xB6"+
		"\xBA\x3\x2\x2\x2\xB7\xBA\x5$\x13\x2\xB8\xBA\a*\x2\x2\xB9\xB3\x3\x2\x2"+
		"\x2\xB9\xB7\x3\x2\x2\x2\xB9\xB8\x3\x2\x2\x2\xBA!\x3\x2\x2\x2\xBB\xC0\x5"+
		"\x1E\x10\x2\xBC\xBD\a\x1E\x2\x2\xBD\xBF\x5\x1E\x10\x2\xBE\xBC\x3\x2\x2"+
		"\x2\xBF\xC2\x3\x2\x2\x2\xC0\xBE\x3\x2\x2\x2\xC0\xC1\x3\x2\x2\x2\xC1#\x3"+
		"\x2\x2\x2\xC2\xC0\x3\x2\x2\x2\xC3\xC4\t\x5\x2\x2\xC4%\x3\x2\x2\x2\xC5"+
		"\xC6\t\x6\x2\x2\xC6\'\x3\x2\x2\x2\x16+\x31\x39@HQV[\x61j|\x82\x8A\x91"+
		"\x97\xAB\xAE\xB0\xB9\xC0";
	public static readonly ATN _ATN =
		ATNSimulator.Deserialize(_serializedATN.ToCharArray());
}
} // namespace CKCompiler
